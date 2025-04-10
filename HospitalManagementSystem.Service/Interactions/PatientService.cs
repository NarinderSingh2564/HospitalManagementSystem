using System.ComponentModel;
using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Service.Interactions
{
    public class PatientService : IDisposable
    {
        #region Private Variables
        private ApplicationDBContext _dbcontext;
        private readonly IMapper _mapper;

        private Component component = new Component();
        private bool disposed = false;
        private IntPtr handle;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion

        #region Constructor
        public PatientService(ApplicationDBContext dBContext, IMapper mapper)
        {
            _dbcontext = dBContext;
            _mapper = mapper;
        }
        #endregion

        #region Destructor
        ~PatientService()
        {
            Dispose(false);
        }
        #endregion

        //public List<PatientModel> GetPatientList()
        //{
        //    var patientList = new List<PatientModel>();
        //    var dbPatientList = _dbcontext.PatientMaster.ToList();

        //    foreach (var item in dbPatientList)
        //    {
        //        patientList.Add(new PatientModel
        //        {
        //            Id = item.Id,
        //            FirstName = item.FirstName + " "+item.LastName,
        //        });
        //    }

        //    return patientList;
        //}
    }
}
