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
    public class EQMActionPointNatureReporitory : IBasicCrudRepository<EqmActionPointNature> {
        private readonly  EQMDbContext _dbContext ;
        private readonly ILogger _logger;

        public EQMActionPointNatureReporitory(ILogger<EqmActionPointNature> logger, EQMDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<EqmActionPointNature> Create(EqmActionPointNature P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Add<EqmActionPointNature>(P);
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
        public void Delete(EqmActionPointNature P)
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
        public IEnumerable<EqmActionPointNature> GetAll()
        {
            try
            {
                var obj = _dbContext.EqmActionPointNatures.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EqmActionPointNature GetById(long Id)
        {
            try
            {
                 
                    var Obj = _dbContext.EqmActionPointNatures.FirstOrDefault(x => x.NatureId == Id);
                    if (Obj != null) return Obj;
                    else return null;
          
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(EqmActionPointNature P)
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
