using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository) => this._playerRepository = playerRepository;

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

        private static PlayerDto MapperModelToDtoPlayer(Entities.Player model)
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
    }
}
