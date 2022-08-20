using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.DtoModels;
using TimeLog.DAL.Interfaces;

namespace TimeLog.DAL.Repositories
{
    public class TimeLogRepository : BaseRepository, ITimeLogRepository
    {
        public void Create(Data.DescartesModels.TimeLog model)
        {
            base.TimeLog.Add(model);
            base.SaveChanges();
        }

        public IEnumerable<Data.DescartesModels.TimeLog> GetAll()
        {
            return base.TimeLog.ToList();
        }

        public Data.DescartesModels.TimeLog GetByEmployeeId(string employeeId)
        {
            return base.TimeLog.Where(r => r.EmployeeId == employeeId).FirstOrDefault();
        }

        public string GetIdByEmployeeId(string employeeId)
        {
            return base.TimeLog.Where(r => r.EmployeeId == employeeId).Select(r => r.Id).FirstOrDefault();
        }

        /// <summary>
        /// EmployeeId and IsTimeIn only
        /// </summary>        
        public DateTime Update(TimeLogDto modelDto)
        {
            var entity = base.TimeLog.Where(r => r.EmployeeId == modelDto.EmployeeId).FirstOrDefault();

            if (entity != null)
            {
                entity.IsTimeIn = modelDto.IsTimeIn;
                if (modelDto.IsTimeIn)
                    entity.TimeIn = DateTime.Now;
                else
                    entity.TimeOut = DateTime.Now;

                base.TimeLog.Attach(entity);
                base.SaveChanges();

                return (modelDto.IsTimeIn) ? entity.TimeIn : entity.TimeOut.Value;
            }
            else
            {
                var createModel = new DAL.Data.DescartesModels.TimeLog()
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = modelDto.EmployeeId,
                    IsTimeIn = true,
                    TimeIn = DateTime.Now
                };
                this.Create(createModel);
                return createModel.TimeIn;
            }
        }

        public void Delete(string id)
        {
            var model = new Data.DescartesModels.TimeLog() { Id = id };
            base.TimeLog.Attach(model);
            base.TimeLog.Remove(model);
            base.SaveChanges();
        }

        public void DeleteByEmployeeId(string employeeId)
        {
            var entity = GetByEmployeeId(employeeId);
            if (entity != null)
            {
                base.TimeLog.Attach(entity);
                base.TimeLog.Remove(entity);
                base.SaveChanges();
            }            
        }
    }
}
