using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Activ.EQM.DataAcces.Repositories
{
    using Models;
    using Contacts;
    using Data;
    public class EQMActionPlanReporitory : IBasicCrudRepository<EqmActionPlan>
    {
        private readonly EQMDbContext _dbContext;
        private readonly ILogger _logger;

        public EQMActionPlanReporitory(ILogger<EqmActionPlan> logger, EQMDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<EqmActionPlan> Create(EqmActionPlan P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Add<EqmActionPlan>(P);
                    await _dbContext.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(EqmActionPlan P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Remove(P);
                    if (obj != null)
                    {
                        _dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<EqmActionPlan> GetAll()
        {
            try
            {
                var obj = _dbContext.EqmActionPlans.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EqmActionPlan GetById(long Id)
        {
            try
            {

                var Obj = _dbContext.EqmActionPlans.FirstOrDefault(x => x.ActionPlanId == Id);
                if (Obj != null) return Obj;
                else return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(EqmActionPlan P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Update(P);
                    if (obj != null) _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
