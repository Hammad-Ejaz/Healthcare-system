using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class LogService : ILogService
    {
        private IUnitOfWork UnitOfWork;

        public LogService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task AddLog(HealthCareExceptionLog log)
        {
            await UnitOfWork.Log.InsertAsync(log);
        }


    }
}
