﻿using Microsoft.EntityFrameworkCore;

namespace Gyakorlo.Data
{
    public class AppRepo : IAppRepo
    {
        AppDbContext dbContext;

        public AppRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Csoport>> GetAllProductsAsync()
        {
            return await dbContext.Csoportok.ToListAsync();
        }

        public void Add(string s)
        {

        }

        public string Get()
        {
            return "";
        }
    }
}
