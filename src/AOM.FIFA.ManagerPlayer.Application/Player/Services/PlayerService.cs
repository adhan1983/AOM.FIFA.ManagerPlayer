using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;
using System;
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

        public PlayerService(IPlayerRepository playerRepository, IClubService clubService, INationService nationService) 
        { 
            this._playerRepository = playerRepository;
            this._clubService = clubService;
            this._nationService = nationService;
        }

        public async Task<PlayerResponse> GetPlayerByIdAsync(int id)
        {
            var player = await _playerRepository.GetPlayerByExpression(x => x.Id == id) ;
            
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

        public async Task<int> InsertPlayerAsync(PlayerDto playerDto)
        {
            var nation = await _nationService.GetNationBySourceId(playerDto.SourceNationId);

            var club = await _clubService.GetClubBySourceId(playerDto.SourceClubId.Value);            
            
            var model = MapperDtoToModelPlayer(playerDto, club.Id, nation.Id);
            
            var result = await _playerRepository.InsertAsync(model);

            return result.Id;
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
                SourceId = player.Id,
                TotalStats = player.TotalStats,
                Weight = player.Weight,
                IsActive = true,                
            };

            return model;
        }
        
    }
}
