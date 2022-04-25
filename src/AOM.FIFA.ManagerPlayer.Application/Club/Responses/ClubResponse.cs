using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Responses
{
    public class ClubResponse
    {
        public int Total { get; set; }

        public List<ClubDto> Clubs { get; set; }
    }
}
