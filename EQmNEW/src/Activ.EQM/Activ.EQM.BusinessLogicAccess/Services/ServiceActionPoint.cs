using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.EQM.BusinessLogicAccess.Services
{
    using Activ.EQM.BusinessLogicAccess.InputData;
    using Activ.EQM.DataAcces.Models;
    using DataAcces.Contacts;
     
    public class ServiceActionPoint 
    {
        public readonly IBasicCrudRepository<EqmActionPoint> _repository;
        public ServiceActionPoint(IBasicCrudRepository<EqmActionPoint> repository)
        {
            _repository = repository;
        }
       
        public async Task<EqmActionPoint> Add(ActionPoint P)
        {
            try
            {
                if (P == null)
                {
                    throw new ArgumentNullException(nameof(P));
                }
                else
                {
                    EqmActionPoint eqmActionPoint = new EqmActionPoint();
                    eqmActionPoint.ActionPointPriority = P.ActionPointPriority;
                    eqmActionPoint.ActionPointLevel = P.ActionPointLevel;
                    eqmActionPoint.ThirdPartyProcessStep = P.ThirdPartyProcessStep;
                    eqmActionPoint.NatureId = P.NatureId;
                    eqmActionPoint.AuditId = P.AuditId;
                    eqmActionPoint.CreateBy = P.CreateBy;
                    eqmActionPoint.Created = DateTime.Now;
                    eqmActionPoint.Description = P.Description;
                    eqmActionPoint.Title = P.Title;    
                    return await _repository.Create(eqmActionPoint);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(long Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.ActionPointId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(long Id, ActionPoint P)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.ActionPointId == Id).FirstOrDefault();
                    if (obj != null) { 
                        obj.ActionPointPriority = P.ActionPointPriority;
                    obj.ActionPointLevel = P.ActionPointLevel;
                    obj.ThirdPartyProcessStep = P.ThirdPartyProcessStep;
                    obj.NatureId = P.NatureId;
                    obj.AuditId = P.AuditId;
                    obj.Description = P.Description;
                    obj.Title = P.Title;

                    _repository.Update(obj); }
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
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}