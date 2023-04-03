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
    public class EQMActionPointReporitory : IBasicCrudRepository<EqmActionPoint> {
        private readonly  EQMDbContext _dbContext ;
        private readonly ILogger _logger;

        public EQMActionPointReporitory(ILogger<EqmActionPoint> logger, EQMDbContext db)
        {
            _logger = logger;
            _dbContext = db;
        }

        public async Task<EqmActionPoint> Create(EqmActionPoint P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Add<EqmActionPoint>(P);
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

        public void Delete(EqmActionPoint P)
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

        public IEnumerable<EqmActionPoint> GetAll()
        {
            try
            {
                var obj = _dbContext.EqmActionPoints.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EqmActionPoint GetById(long Id)
        {
            try
            { 
                var Obj = _dbContext.EqmActionPoints.FirstOrDefault(x => x.ActionPointId == Id);
                if (Obj != null) return Obj;
                else return null; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(EqmActionPoint P)
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
