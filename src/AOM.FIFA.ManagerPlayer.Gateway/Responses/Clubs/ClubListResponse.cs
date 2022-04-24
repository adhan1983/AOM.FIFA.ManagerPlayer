﻿using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs
{
    public class ClubListResponse : BaseResponse
    {
        public List<Club> items { get; set; } = new();
    }

    public class Club
    {
        public int id { get; set; }
        public string name { get; set; }
        public int league { get; set; }
    }
}
