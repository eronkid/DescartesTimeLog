using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.DtoModels;

namespace TimeLog.DAL.Interfaces
{
    public interface ITimeLogRepository : IBaseRepository
    {
        void Create(Data.DescartesModels.TimeLog model);
        Data.DescartesModels.TimeLog GetByEmployeeId(string employeeId);
        string GetIdByEmployeeId(string employeeId);
        void Update(TimeLogDto modelDto);
        void Delete(string id);

    }
}
