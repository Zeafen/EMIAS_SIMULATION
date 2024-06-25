using Client_Emias.Helpers.ApiHelpers;
using Client_Emias.Helpers.Commands;
using Client_Emias.Helpers.Other;
using Client_Emias.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.viewModels.Admins
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private RelayCommand<Patient>? _addPatientCommand = null;
        public RelayCommand<Patient> AddPatientCommand => _addPatientCommand ?? (_addPatientCommand = new RelayCommand<Patient>(
            execute: AddPatient,
            canExecute: (Patient patient) =>
            {
                return IsPatientNotBlank(patient) &&
                Patients.FirstOrDefault(p => p.Oms == patient.Oms) == null;
            }));
        private RelayCommand<Patient>? _updatePatientCommand = null;
        public RelayCommand<Patient> UpdatePatientCommand => _updatePatientCommand ?? (_updatePatientCommand = new RelayCommand<Patient>(
            execute: UpdatePatient,
            canExecute: (Patient patient) =>
            {
                return IsPatientNotBlank(patient) &&
                Patients.FirstOrDefault(p => p.Oms == patient.Oms) != null;
            }));
        private RelayCommand<Patient>? _deletePatientCommand = null;
        public RelayCommand<Patient> DeletePatientCommand => _deletePatientCommand ?? (_deletePatientCommand = new RelayCommand<Patient>(
            execute: DeletePatient,
            canExecute: (Patient patient) =>
            {
                return IsPatientNotBlank(patient) &&
                Patients.FirstOrDefault(p => p.Oms == patient.Oms) != null;
            }));

        private RelayCommand<Admin>? _addAdminCommand = null;
        public RelayCommand<Admin> AddAdminCommand => _addAdminCommand ?? (_addAdminCommand = new RelayCommand<Admin>(
            execute: AddAdmin,
            canExecute: (Admin admin) =>
            {
                return IsAdminNotBlank(admin) &&
                Admins.FirstOrDefault(a => a.IdAdmin == admin.IdAdmin) == null;
            }));
        private RelayCommand<Admin>? _updateAdminCommand = null;
        public RelayCommand<Admin> UpdateAdminCommand => _updateAdminCommand ?? (_updateAdminCommand = new RelayCommand<Admin>(
            execute: UpdateAdmin,
            canExecute: (Admin admin) =>
            {
                return IsAdminNotBlank(admin) &&
                Admins.FirstOrDefault(a => a.IdAdmin == admin.IdAdmin) != null;
            }));
        private RelayCommand<Admin>? _deleteAdminCommand = null;
        public RelayCommand<Admin> DeleteAdminCommand => _deleteAdminCommand ?? (_deleteAdminCommand = new RelayCommand<Admin>(
            execute: DeleteAdmin,
            canExecute: (Admin admin) =>
            {
                return IsAdminNotBlank(admin) &&
                Admins.FirstOrDefault(a => a.IdAdmin == admin.IdAdmin) != null;
            }));

        private RelayCommand<Doctor>? _addDoctorCommand = null;
        public RelayCommand<Doctor> AddDoctorCommand => _addDoctorCommand ?? (_addDoctorCommand = new RelayCommand<Doctor>(
            execute: AddDoctor,
            canExecute: (Doctor doctor) =>
            {
                return IsDoctorNotBlank(doctor) &&
                Doctors.FirstOrDefault(p => p.IdDoctor == doctor.IdDoctor) == null;
            }));
        private RelayCommand<Doctor>? _updateDoctorCommand = null;
        public RelayCommand<Doctor> UpdateDoctorCommand => _updateDoctorCommand ?? (_updateDoctorCommand = new RelayCommand<Doctor>(
            execute: UpdateDoctor,
            canExecute: (Doctor doctor) =>
            {
                return IsDoctorNotBlank(doctor) &&
                Doctors.FirstOrDefault(p => p.IdDoctor == doctor.IdDoctor) != null;
            }));
        private RelayCommand<Doctor>? _deleteDoctorCommand = null;
        public RelayCommand<Doctor> DeleteDoctorCommand => _deleteDoctorCommand ?? (_deleteDoctorCommand = new RelayCommand<Doctor>(
            execute: DeleteDoctor,
            canExecute: (Doctor doctor) =>
            {
                return IsDoctorNotBlank(doctor) &&
                Doctors.FirstOrDefault(p => p.IdDoctor == doctor.IdDoctor) != null;
            }));


        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Admin> Admins { get; set; }
        public ObservableCollection<Speciality> Specialities { get; set; }

        private Patient _selectedPatient {  get; set; }
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set {
                if (value == null)
                    return;
                _selectedPatient = value;
                OnPropertyChanged();
            }
        }

        private Doctor _selectedDoctor {  get; set; }
        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                if (value == null)
                    return;
                _selectedDoctor = value;
                OnPropertyChanged();
            }
        }
        private Admin _selectedAdmin {  get; set; }
        public Admin SelectedAdmin
        {
            get => _selectedAdmin;
            set
            {
                if (value == null)
                    return;
                _selectedAdmin = value;
                OnPropertyChanged();
            }
        }
        private Speciality _selectedSpeciality {  get; set; }
        public Speciality SelectedSpeciality
        {
            get => _selectedSpeciality;
            set
            {
                if (value == null)
                    return;
                _selectedSpeciality = value;
                OnPropertyChanged();
            }
        }



        public AdminViewModel()
        {
            UpdateSource();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName == nameof(SelectedSpeciality))
                _selectedDoctor.IdSpeciality = _selectedSpeciality.IdSpeciality ?? 1;
            else if (propertyName == nameof(SelectedDoctor))
                _selectedSpeciality = Specialities.FirstOrDefault(s => s.IdSpeciality == _selectedDoctor.IdSpeciality) ?? Specialities.First();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateSource()
        {
            try
            {
                Patients = new ObservableCollection<Patient>(JsonConvert.DeserializeObject<ICollection<Patient>>(PatientsHelper.GetPatients())?? new List<Patient>());
                Doctors = new ObservableCollection<Doctor>(JsonConvert.DeserializeObject<ICollection<Doctor>>(PatientsHelper.GetPatients()) ?? new List<Doctor>());
                Admins = new ObservableCollection<Admin>(JsonConvert.DeserializeObject<ICollection<Admin>>(PatientsHelper.GetPatients()) ?? new List<Admin>());
                Specialities = new ObservableCollection<Speciality>(JsonConvert.DeserializeObject<ICollection<Speciality>>(SpecialitiesHelper.GetSpecialities()) ?? new List<Speciality>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool IsPatientNotBlank(Patient patient)
        {
            return patient != null &&
                !string.IsNullOrEmpty(patient.Patronymic) &&
                !string.IsNullOrEmpty(patient.Name) &&
                !string.IsNullOrEmpty(patient.Nickname) &&
                !string.IsNullOrEmpty(patient.Email) &&
                !string.IsNullOrEmpty(patient.Address) &&
                !string.IsNullOrEmpty(patient.LivingAddress) &&
                !string.IsNullOrEmpty(patient.Phone) &&
                !string.IsNullOrEmpty(patient.SurName) &&
                patient.Oms != null && long.IsPositive(patient.Oms??0) &&
                CompareCompanion.IsDateEarlier(patient.BirthDate, DateOnly.FromDateTime(DateTime.Now));
        }
        private bool IsAdminNotBlank(Admin admin)
        {
            return admin != null &&
                !string.IsNullOrEmpty(admin.Patronymic) &&
                !string.IsNullOrEmpty(admin.Name) &&
                !string.IsNullOrEmpty(admin.EnterPassword) &&
                !string.IsNullOrEmpty(admin.SurName) &&
                admin.IdAdmin != null && admin.IdAdmin > 0;
        }
        private bool IsDoctorNotBlank(Doctor doc)
        {
            return doc != null &&
                !string.IsNullOrEmpty(doc.Patronymic) &&
                !string.IsNullOrEmpty(doc.Name) &&
                !string.IsNullOrEmpty(doc.EnterPassword) &&
                !string.IsNullOrEmpty(doc.SurName) &&
                !string.IsNullOrEmpty(doc.WorkAddress) &&
                doc.IdDoctor != null && doc.IdDoctor > 0 &&
                doc.IdSpeciality != null && doc.IdSpeciality> 0;
        }

        private void AddPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                    return;
                var json = JsonConvert.SerializeObject(patient);
                PatientsHelper.PostPatient(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdatePatient(Patient patient)
        {
            try
            {
                if (patient == null || patient.Oms == null)
                    return;
                var key = patient.Oms;
                patient.Oms = null;
                var json = JsonConvert.SerializeObject(patient);
                PatientsHelper.PutPatient(json, key??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DeletePatient(Patient patient)
        {
            try
            {
                if (patient == null || patient.Oms == null)
                    return;
                PatientsHelper.DeletePatient(patient.Oms??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddAdmin(Admin admin)
        {
            try
            {
                if (admin == null)
                    return;
                var json = JsonConvert.SerializeObject(admin);
                AdminHelper.PostAdmin(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdateAdmin(Admin admin)
        {
            try
            {
                if (admin == null || admin.IdAdmin == null)
                    return;
                var key = admin.IdAdmin;
                admin.IdAdmin = null;
                var json = JsonConvert.SerializeObject(admin);
                AdminHelper.PutAdmin(json, key??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DeleteAdmin(Admin admin)
        {
            try
            {
                if (admin == null || admin.IdAdmin == null)
                    return;
                AdminHelper.DeleteAdmin(admin.IdAdmin??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null)
                    return;
                var json = JsonConvert.SerializeObject(doctor);
                DoctorsHelper.PostDoctor(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdateDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null || doctor.IdDoctor == null)
                    return;
                var key = doctor.IdDoctor;
                doctor.IdDoctor = null;
                var json = JsonConvert.SerializeObject(doctor);
                DoctorsHelper.PutDoctor(json, key??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DeleteDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null || doctor.IdDoctor == null)
                    return;
                DoctorsHelper.DeleteDoctor(doctor.IdDoctor ??0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
