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
     

    public class ServiceProcess
    {
        public readonly IBasicCrudRepository<EqmProcess> _repository;
        public ServiceProcess(IBasicCrudRepository<EqmProcess> repository)
        {
            _repository = repository;
        }
       
        public async Task<EqmProcess> Add (Process P)
        {
            try
            {
                if (P == null)
                {
                    throw new ArgumentNullException(nameof(P));
                }
                else
                {
                    EqmProcess eqmProcess = new EqmProcess(); 
                    eqmProcess.ThirdPartyProcesses = P.ThirdPartyProcesses;
                    eqmProcess.TurnaroundTimes=P.TurnaroundTimes;
                    eqmProcess.Participants = P.Participants;
                    eqmProcess.CreateBy = P.CreateBy;
                    eqmProcess.Created = DateTime.Now;
                    eqmProcess.Manager = P.Manager;
                    eqmProcess.Description = P.Manager;
                    eqmProcess.Title= P.Title;
                    
                    return await _repository.Create(eqmProcess);
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
                    var obj = _repository.GetAll().Where(x => x.ProcessId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update (long Id, Process P)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.ProcessId == Id).FirstOrDefault();
                    if (obj != null)
                    {

                        obj.ThirdPartyProcesses = P.ThirdPartyProcesses;
                        obj.TurnaroundTimes = P.TurnaroundTimes;
                        obj.Participants = P.Participants;
                        obj.CreateBy = P.CreateBy;
                        obj.Created = DateTime.Now;
                        obj.Manager = P.Manager;
                        obj.Description = P.Manager;
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
        public IEnumerable<EqmProcess> GetAll()
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