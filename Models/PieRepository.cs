﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BethenysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public IEnumerable<Pie> AllPies {
            get
            {
               return _appDbContext.Pies.Include(c=> c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p=> p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}