using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetanyPieShop_coreMVC.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return this._appDbContext.Pies.Include(x => x.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return this._appDbContext.Pies.Include(x => x.Category).Where(i => i.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(x => x.PieId == pieId);
        }
    }
}
