using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Activ.EQM.BusinessLogicAccess.Services
{
    using Activ.EQM.DataAcces.Models;
    using DataAcces.Contacts;
     

    public class ServiceAudit
    {
        public readonly IBasicCrudRepository<EqmAudit> _repository;
        public ServiceAudit(IBasicCrudRepository<EqmAudit> repository)
        {
            _repository = repository;
        }
       
        public async Task<EqmAudit> Add (InputData.Audit P)
        {
            try
            {
                if (P == null)
                {
                    throw new ArgumentNullException(nameof(P));
                }
                else
                {
                    EqmAudit eqmAudit = new EqmAudit();
                    eqmAudit.CreateBy= P.CreateBy;
                    eqmAudit.Created = DateTime.Now;
                    eqmAudit.Reference = P.Reference;
                    eqmAudit.Report = P.Report;
                    eqmAudit.Description=  P.Description;
                    eqmAudit.EndDateEffective = P.EndDateEffective;
                    eqmAudit.StartDateEffective = P.StartDateEffective;
                    eqmAudit.ProcessId= P.ProcessId;
                    eqmAudit.StartDateExpected = P.StartDateExpected;
                    eqmAudit.EndDateExpected = P.EndDateExpected;
                    eqmAudit.Title= P.Title;

                    return await _repository.Create(eqmAudit);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete (long Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.AuditId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update (long Id, InputData.Audit P)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.AuditId == Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CreateBy = P.CreateBy;
                        obj.Created = DateTime.Now;
                        obj.Reference = P.Reference;
                        obj.Report = P.Report;
                        obj.Description = P.Description;
                        obj.EndDateEffective = P.EndDateEffective;
                        obj.StartDateEffective = P.StartDateEffective;
                        obj.ProcessId = P.ProcessId;
                        obj.StartDateExpected = P.StartDateExpected;
                        obj.EndDateExpected = P.EndDateExpected;
                        obj.Title = P.Title;

                        _repository.Update(obj);
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
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}