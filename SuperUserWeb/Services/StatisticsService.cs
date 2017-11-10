using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperUserWeb.Data;

namespace SuperUserWeb.Services
{
    public class StatisticsService
    {
        private FancyDbContext _context;

        public StatisticsService(FancyDbContext context)
        {
            _context = context;
        }

        public int GetCount()
        {
            return _context.UserAccount.Count();
        }

        public int GetCompletedCount()
        {
            return 1334;
        }

        public double GetAveragePriority()
        {
            return GetCount() / GetCompletedCount();
        }
    }
}
