﻿using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;
using domain = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.Nation.Repository
{
    public class NationRepository : repo.Repository<domain.Nation>, INationRepository
    {   
        public NationRepository(FIFAManagerPlayerDbContext fifaManagerPlayerDbContext) : base(fifaManagerPlayerDbContext)
        { }
    }
}
