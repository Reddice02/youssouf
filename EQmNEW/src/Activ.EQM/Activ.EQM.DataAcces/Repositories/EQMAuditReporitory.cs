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
    public class EQMAuditReporitory : IBasicCrudRepository<EqmAudit> {
        private readonly  EQMDbContext _dbContext ;
        private readonly ILogger _logger;

        public EQMAuditReporitory(ILogger<EqmAudit> logger, EQMDbContext db)
        {
            _logger = logger;
            _dbContext = db;
        }

        public async Task<EqmAudit> Create(EqmAudit P)
        {
            try
            {
                if (P != null)
                {
                    var obj = _dbContext.Add<EqmAudit>(P);
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
        public void Delete(EqmAudit P)
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
		public IEnumerable<EqmAudit> GetAll()
        {
            try
            {
                var obj = _dbContext.EqmAudits.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

		/*public IEnumerable<EqmTotalAudit> GetAll()
		{
			try
			{
				var query = from c in _dbContext.EqmProcesses
							join o in _dbContext.EqmAudits on c.ProcessId equals o.ProcessId
							select new { c, o }; // Sélectionne tous les champs

                EqmTotalAudit eqmTotalAudit = new EqmTotalAudit();

				foreach (var result in query)
				{
                    eqmTotalAudit.Report = result.o.Report;
                    eqmTotalAudit.Reference = result.o.Reference;
                    eqmTotalAudit.TitleProcess = result.c.Title;
                    eqmTotalAudit.Title = result.o?.Title;
                    eqmTotalAudit.ProcessId = result.c.ProcessId;
                    eqmTotalAudit.StartDateEffective = result.o?.StartDateEffective;
                    eqmTotalAudit.EndDateEffective = result.o?.EndDateEffective;
                    eqmTotalAudit.AuditId = result.o.AuditId;
                    eqmTotalAudit.CreateBy = result.o?.CreateBy;
                    eqmTotalAudit.Created = result.o.Created;
                    eqmTotalAudit.Description = result.o?.Description;
                    eqmTotalAudit.StartDateExpected = result.o?.StartDateExpected;
                    eqmTotalAudit.EndDateExpected = result.o?.EndDateExpected;
				}

                return eqmTotalAudit;
			}
			catch (Exception)
			{
				throw;
			}
		}*/

		public EqmAudit GetById(long Id)
        {
            try
            {
                 
                    var Obj = _dbContext.EqmAudits.FirstOrDefault(x => x.AuditId == Id);
                    if (Obj != null) return Obj;
                    else return null;
          
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(EqmAudit P)
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
