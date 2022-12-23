using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Responses
{
    public class NationResponse
    {
        public NationResponse()
        {
            Nations = new List<NationDto>();
        }
        
        public int Total { get; set; }
        public List<NationDto> Nations { get; set; }
    }
}
