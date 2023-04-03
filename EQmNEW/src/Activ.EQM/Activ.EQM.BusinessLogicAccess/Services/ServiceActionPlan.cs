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
    
    public class ServiceActionPlan
    {
        public readonly IBasicCrudRepository<EqmActionPlan> _repository;
        public ServiceActionPlan(IBasicCrudRepository<EqmActionPlan> repository)
        {
            _repository = repository;
        }
       
        public async Task<EqmActionPlan> Add (ActionPlan P)
        {
            try
            {
                if (P == null)
                {
                    throw new ArgumentNullException(nameof(P));
                }
                else
                {
                    EqmActionPlan eqmActionPlan = new EqmActionPlan();
                    eqmActionPlan.ActionPlanPriority = P.ActionPlanPriority;
                    eqmActionPlan.ActionPlanId = 0;
                    eqmActionPlan.ActionPlanOrder = P.ActionPlanOrder;
                    eqmActionPlan.ActionPointId = P.ActionPointId;
                    eqmActionPlan.CreateBy = P.CreateBy;
                    eqmActionPlan.Created = DateTime.Now;
                    eqmActionPlan.Description = P.Description;
                    eqmActionPlan.EndDateEffective = P.EndDateEffective;
                    eqmActionPlan.StartDateEffective = P.StartDateEffective;
                    eqmActionPlan.Statuts = P.Statuts;
                    eqmActionPlan.Manager=P.Manager;
                    eqmActionPlan.StartDateExpected = P.StartDateExpected;
                    eqmActionPlan.EndDateExpected = P.EndDateExpected;
                    eqmActionPlan.Title = P.Title;
                     
                    return await _repository.Create(eqmActionPlan);
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
                    var obj = _repository.GetAll().Where(x => x.ActionPlanId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(long Id, ActionPlan P)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.ActionPlanId == Id).FirstOrDefault();

                    obj.ActionPlanPriority = P.ActionPlanPriority;
                    obj.ActionPlanOrder = P.ActionPlanOrder;
                    obj.ActionPointId = P.ActionPointId; 
                    obj.Description = P.Description;
                    obj.EndDateEffective = P.EndDateEffective;
                    obj.StartDateEffective = P.StartDateEffective;
                    obj.Statuts = P.Statuts;
                    obj.Manager = P.Manager;
                    obj.StartDateExpected = P.StartDateExpected;
                    obj.EndDateExpected = P.EndDateExpected;
                    obj.Title = P.Title;


                    if (obj != null) _repository.Update(obj);
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
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}