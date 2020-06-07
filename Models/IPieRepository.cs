using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetanyPieShop_coreMVC.Models
{
    public interface IPieRepository
    {
        public IEnumerable<Pie> AllPies { get; }
        public IEnumerable<Pie> PiesOfTheWeek { get;}
        public Pie GetPieById(int pieId);
    }
}
