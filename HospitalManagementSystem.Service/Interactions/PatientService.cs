using System.ComponentModel;
using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.DBClasses;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;
using Microsoft.EntityFrameworkCore;

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

        public List<PatientModel> GetPatientList()
        {
            var dbPatientList = _dbcontext.PatientAppointmentMaster.Include(p => p.PatientMaster).ToList();
            var patientList = _mapper.Map<List<PatientModel>>(dbPatientList);
            return patientList;

        }

        public ReturnResponseModel<PatientInputModel> CheckPatientByCRMNumber(string crmNumber)
        {
            var returnResponseModel = new ReturnResponseModel<PatientInputModel>();
            var dbPatientEntityByCRMNumber = _dbcontext.PatientAppointmentMaster.Where(u => u.CRMNumber == crmNumber).FirstOrDefault();

            if (dbPatientEntityByCRMNumber != null)
            {
                var dbPatientEntity = _dbcontext.PatientMaster.Where(u => u.Id == dbPatientEntityByCRMNumber.PatientId).FirstOrDefault();

                if (dbPatientEntity != null)
                {
                    var patientInputModel = new PatientInputModel();

                    patientInputModel = _mapper.Map<PatientInputModel>(dbPatientEntity);
                    patientInputModel.PatientAppointmentInputModel = _mapper.Map<PatientAppointmentInputModel>(dbPatientEntityByCRMNumber);

                    returnResponseModel.Data = patientInputModel;
                    returnResponseModel.message = "Patient found. Details fetched successfully.";
                    returnResponseModel.status = true;
                }
            }
            else
            {
                returnResponseModel.message = "Patient not found with this CRM Number...";
                returnResponseModel.status = false;
                returnResponseModel.Data = null;
            }
            return returnResponseModel;
        }

        public ReturnResponseModel<string> AddPatientAppointment(PatientInputModel patientInputModel)
        {
            var returnResponseModel = new ReturnResponseModel<string>();
            var dbPatientEntityByCRMNumber = _dbcontext.PatientAppointmentMaster.Where(u => u.CRMNumber == patientInputModel.PatientAppointmentInputModel.CRMNumber).FirstOrDefault();

            if (dbPatientEntityByCRMNumber != null)
            {
                

                
                var updatedAppointment = _mapper.Map<PatientAppointmentMaster>(patientInputModel.PatientAppointmentInputModel);

                _mapper.Map(patientInputModel.PatientAppointmentInputModel, dbPatientEntityByCRMNumber);

                dbPatientEntityByCRMNumber.UpdatedBy = 1;
                dbPatientEntityByCRMNumber.UpdatedOn = DateTime.Now;
                
                _dbcontext.PatientAppointmentMaster.Update(dbPatientEntityByCRMNumber);
                _dbcontext.SaveChanges();

                returnResponseModel.message = "Existing appointment updated successfully!";
                returnResponseModel.status = true;
            }
            else
            {
                var patientMaster = _mapper.Map<PatientMaster>(patientInputModel);
                patientMaster.Password = "abc@123";
                _dbcontext.PatientMaster.Add(patientMaster);
                _dbcontext.SaveChanges();

                var patientAppointmentMaster = _mapper.Map<PatientAppointmentMaster>(patientInputModel.PatientAppointmentInputModel);
                patientAppointmentMaster.PatientId = patientMaster.Id;
                _dbcontext.PatientAppointmentMaster.Add(patientAppointmentMaster);
                _dbcontext.SaveChanges();

                returnResponseModel.message = "New Patient Appointment added successfully!!! ";
                returnResponseModel.status = true;
            }
            return returnResponseModel;
        }
        public List<KeyValueModel<int, string>> GetDoctorByDepartmentId(int departmentId)
        {
            var doctorList = new List<KeyValueModel<int, string>>();
            var dbDoctorListByDepartmentId = _dbcontext.UserMaster.Include(u => u.DesignationMaster).Where(u => u.IsDoctor == true && u.isActive == true && u.DesignationMaster.DepartmentId == departmentId).OrderBy(u => u.FirstName).ToList();

            foreach (var item in dbDoctorListByDepartmentId)
            {
                doctorList.Add(new KeyValueModel<int, string>
                {
                    key = item.Id,
                    value = item.FirstName + " " + item.LastName + " " + item.DesignationMaster.DesignationName + " ( " + item.DesignationMaster.DesignationCode + " )",

                });
            }
            return doctorList;
        }

    }
}
