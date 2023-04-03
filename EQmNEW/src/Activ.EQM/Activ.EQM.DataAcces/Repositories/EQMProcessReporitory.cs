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
    public class EQMProcessReporitory : IBasicCrudRepository<EqmProcess> {
        private readonly  EQMDbContext _dbContext ;
        private readonly ILogger _logger;

        public EQMProcessReporitory(ILogger<EqmProcess> logger, EQMDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<EqmProcess> Create(EqmProcess P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Add<EqmProcess>(P);
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

        public void Delete(EqmProcess P)
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
        public IEnumerable<EqmProcess> GetAll()
        {
            try
            {
                var obj = _dbContext.EqmProcesses.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public EqmProcess GetById(long Id)
        {
            try
            {
                 
                    var Obj = _dbContext.EqmProcesses.FirstOrDefault(x => x.ProcessId == Id);
                    if (Obj != null) return Obj;
                    else return null;
          
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(EqmProcess P)
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
