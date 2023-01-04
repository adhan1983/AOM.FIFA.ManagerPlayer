using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IClubService _clubService;
        private readonly INationService _nationService;
        private readonly ILeagueService _leagueService;

        public PlayerService(ILeagueService leagueService, IPlayerRepository playerRepository, IClubService clubService, INationService nationService)
        {
            this._playerRepository = playerRepository;
            this._clubService = clubService;
            this._nationService = nationService;
            this._leagueService = leagueService;
        }

        public async Task<PlayerByNationByLeagueResponse> GetPlayersByNationByLeague(int nation, int league)
        {
            var models = await _playerRepository.GetPlayersByExpression(a => a.NationId == nation && a.Club.LeagueId == league);

            var response = new PlayerByNationByLeagueResponse() { Total = models.Count };

            for (int i = 0, ii = models.Count; i < ii; i++)
            {
                response.PlayersByNationByLeague.Add(new PlayerByNationByLeagueDto
                {
                    Nome = models[i].Name,
                    Age = models[i].Age,
                    Club = models[i]?.Club.Name,
                    Nation = models[i]?.Nation?.Name
                });
            }

            return response;
        }


        public async Task<PlayerResponse> GetPlayerByIdAsync(int id)
        {
            var player = await _playerRepository.GetPlayerByExpression(x => x.Id == id);

            var response = new PlayerResponse();

            if (player != null)
            {
                response.Player = MapperModelToDtoPlayer(player);
            }

            return response;

        }

        public async Task<PlayerListResponse> GetPlayersByClubAsync(PlayerClubParameterRequest request)
        {
            Expression<Func<domain.Player, bool>> expression = x => x.ClubId == request.ClubId;

            var players = await _playerRepository.GetPlayersByExpression(expression);

            var response = new PlayerListResponse();

            if (players != null)
            {
                response.Total = players.Count;
                response.PlayersDto = players.Select(model => MapperModelToDtoPlayer(model)).ToList();
            }

            return response;
        }

        public async Task<PlayerListResponse> GetPlayersAsync(PlayerParameterRequest request)
        {
            var players = await _playerRepository.GetPagedListPlayersAsync(request);

            return new PlayerListResponse
            {
                Total = players.Count,
                PlayersDto = players.Select(model => MapperModelToDtoPlayer(model)).ToList()
            };
        }

        public async Task<PlayerListFUT22ICONResponse> GetPlayerByFUT22ICONSAsync()
        {
            Expression<Func<domain.Player, bool>> expression = x => x.ClubId == 587 && x.IsActive;

            var players = await _playerRepository.GetPlayersByExpression(expression);

            var response = new PlayerListFUT22ICONResponse();

            if (players != null)
            {
                response.Total = players.Count;
                response.Players =
                    players.Select(model => new PlayerFUT22IconDto()
                    {
                        Name = model.Name,
                        Nation = model.Nation.Name ?? string.Empty,
                        Position = model.Position
                    }).ToList();
            }

            return response;
        }

        public async Task<TotalPlayersByLeagueByNationResponse> GetTotalNationalityPlayerByNation()
        {
            var players = await _playerRepository.GetPlayersByExpression(a => a.ClubId != null && a.Rarity != null);

            var leagues = await _leagueService.GetLeaguesAsync();

            var response = new TotalPlayersByLeagueByNationResponse();
            
            for (int i = 0, ii = leagues.Count; i < ii; i++)
            {
                var dto = new TotalPlayersByLeagueByNationDto();

                dto.LeagueName = leagues[i].Name;

                var nationsDistinct = players.
                                            Where(a => a.Club.LeagueId == leagues[i].Id).
                                            Select(a => a.Nation).
                                            Distinct().
                                            ToList();

                if (nationsDistinct.Count == 0)
                    continue;

                response.Total++;
                
                for (int y = 0, yy = nationsDistinct.Count; y < yy; y++)
                {
                    var playerByNationByLeague = new PlayerByNationByLeague();

                    playerByNationByLeague.NationName = nationsDistinct[y].Name;

                    playerByNationByLeague.TotalPlayer = players.
                                            Count(a => a.Club.LeagueId == leagues[i].Id && a.NationId == nationsDistinct[y].Id);

                    dto.PlayerByNationByLeague.Add(playerByNationByLeague);
                }

                response.TotalPlayersByLeagueByNationDto.Add(dto);
            }


            return response;
        }

        public async Task<FIFAManagerResponse> InsertPlayerAsync(PlayerDto playerDto)
        {
            var nation = await _nationService.GetNationBySourceId(playerDto.SourceNationId);

            if (nation == null) 
            {
                return new FIFAManagerResponse() { Id = 0, Status = false, Message = "Nation not found" };
            }

            var club = await _clubService.GetClubBySourceId(playerDto.SourceClubId.Value);

            if (club == null)
            {
                return new FIFAManagerResponse() { Id = 0, Message = "Club not found", Status = false };
            }

            var modelPlayer = _playerRepository.GetPlayersByExpression(a => a.SourceId == playerDto.SourceId);

            if (modelPlayer != null) 
            {
                return new FIFAManagerResponse() { Id = 0, Message = "Player already exist", Status = false };
            }

            var model = MapperDtoToModelPlayer(playerDto, club.Id, nation.Id);            

            var playersInserted = await _playerRepository.GetPlayersByExpression(a => a.Nation.SourceId == playerDto.SourceNationId && a.Name == playerDto.Name);

            if (playersInserted.Any())
            {
                var theGreatestSourceId = playersInserted.Max(a => a.SourceId);

                if (model.SourceId > theGreatestSourceId)
                {
                    foreach (var playerInserted in playersInserted)
                    {
                        playerInserted.IsActive = false;
                    }
                }
                else
                {
                    model.IsActive = false;
                    foreach (var playerInserted in playersInserted)
                    {
                        if (playerInserted.SourceId == theGreatestSourceId)
                        {
                            playerInserted.IsActive = true;
                            continue;
                        }
                        playerInserted.IsActive = false;
                    }
                }
                var playerId = await _playerRepository.InsertAndUpdatePlayerAsync(model, playersInserted);

                return new FIFAManagerResponse { Id = playerId, Status = true, Message = "Success" };
            }
            else
            {
                await _playerRepository.InsertAsync(model);

                return new FIFAManagerResponse { Id = model.Id, Status = true, Message = "Success" };
            }

            
        }

        private static PlayerDto MapperModelToDtoPlayer(domain.Player model)
        {
            return new PlayerDto
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                AttackWorkRate = model.AttackWorkRate,
                ClubId = model.ClubId,
                CommonName = model.CommonName,
                Defending = model.Defending,
                DefenseWorkRate = model.DefenseWorkRate,
                Dribbling = model.Dribbling,
                Foot = model.Foot,
                Height = model.Height,
                LastName = model.LastName,
                NationId = model.NationId,
                Pace = model.Pace,
                Passing = model.Passing,
                Physicality = model.Physicality,
                Position = model.Position,
                Rarity = model.Rarity,
                Shooting = model.Shooting,
                SourceId = model.SourceId,
                Rating = model.Rating,
                TotalStats = model.TotalStats,
                Weight = model.Weight,
                ClubName = model?.Club?.Name ?? string.Empty,
                Nation = model?.Nation?.Name ?? string.Empty,

            };
        }

        private domain.Player MapperDtoToModelPlayer(PlayerDto player, int clubId, int nationId)
        {
            var model = new domain.Player
            {
                Name = player.Name,
                Age = player.Age,
                AttackWorkRate = player.AttackWorkRate,
                ClubId = clubId,
                CommonName = player.CommonName,
                Defending = player.Defending,
                DefenseWorkRate = player.DefenseWorkRate,
                Dribbling = player.Dribbling,
                Foot = player.Foot,
                Height = player.Height,
                LastName = player.LastName,
                NationId = nationId,
                Pace = player.Pace,
                Passing = player.Passing,
                Physicality = player.Physicality,
                Position = player.Position,
                Rarity = player.Rarity,
                Rating = player.Rating,
                Shooting = player.Shooting,
                SourceId = player.SourceId,
                TotalStats = player.TotalStats,
                Weight = player.Weight,
                IsActive = true,
            };

            return model;
        }

    }

    public class TotalPlayersByLeagueByNationResponse 
    {
        public TotalPlayersByLeagueByNationResponse()
        {
            TotalPlayersByLeagueByNationDto = new List<TotalPlayersByLeagueByNationDto>();
        }
        public int Total { get; set; }

        public List<TotalPlayersByLeagueByNationDto> TotalPlayersByLeagueByNationDto { get; set; }
    }

    public class TotalPlayersByLeagueByNationDto
    {
        public TotalPlayersByLeagueByNationDto()
        {
            PlayerByNationByLeague = new List<PlayerByNationByLeague>();
        }
        public string LeagueName { get; set; }

        public List<PlayerByNationByLeague> PlayerByNationByLeague { get; set; }
    }

    public class PlayerByNationByLeague 
    {
        public string NationName { get; set; }
        public int TotalPlayer { get; set; }
    }
}
