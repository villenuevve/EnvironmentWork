using EnvironmentWork.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentWork.Repositories
{
    public class EventLogRepository : GenericRepository<EventLog>
    {
        public EventLogRepository(DbContext context) : base(context)
        {
        }
    }
}
