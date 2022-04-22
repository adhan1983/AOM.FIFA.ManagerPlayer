﻿using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues
{
    public class LeagueListResponse : BaseResponse
    {
        public List<League> items { get; set; } = new List<League>();
    }

    public class League 
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}