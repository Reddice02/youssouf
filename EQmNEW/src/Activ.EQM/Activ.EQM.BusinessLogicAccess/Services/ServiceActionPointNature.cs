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
     

    public class ServiceActionPointNature
    {
        public readonly IBasicCrudRepository<EqmActionPointNature> _repository;
        public ServiceActionPointNature(IBasicCrudRepository<EqmActionPointNature> repository)
        {
            _repository = repository;
        }
       
        public async Task<EqmActionPointNature> Add (ActionPointNature P)
        {
            try
            {
                if (P == null)
                {
                    throw new ArgumentNullException(nameof(P));
                }
                else
                {
                    var actionPointNature = new EqmActionPointNature(); 
                    actionPointNature.Created = DateTime.Now;
                    actionPointNature.CreateBy=P.CreateBy;
                    actionPointNature.Title=P.Title;    
                    return await _repository.Create(actionPointNature);
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
                    var obj = _repository.GetAll().Where(x => x.NatureId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update (long Id, ActionPointNature Apm)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.NatureId == Id).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.Title  =   Apm.Title;
                        obj.Created = obj.Created;
                        obj.CreateBy=  Apm.CreateBy; 
                        _repository.Update(obj);
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
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}