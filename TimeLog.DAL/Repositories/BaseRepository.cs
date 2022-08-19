using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.Data;
using TimeLog.DAL.Interfaces;

namespace TimeLog.DAL.Repositories
{
    public class BaseRepository : DescartesContext,  IBaseRepository
    {
    }
}
