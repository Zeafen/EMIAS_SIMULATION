using Client_Emias.Helpers.ApiHelpers;
using Client_Emias.Helpers.Other;
using Client_Emias.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Client_Emias.viewModels.DoctorVm
{
    public class DoctorPageViewModel : INotifyPropertyChanged
    {
        private readonly int DOC_ID;
        public ObservableCollection<Speciality> Specialities { get; set; }
        public ObservableCollection<PatientAppointment> Appointments { get; set; } = new ObservableCollection<PatientAppointment>();
        public List<Direction> Directions { get; set; } = new List<Direction>();

        public DoctorPageViewModel()
        {
            DOC_ID = (int)Application.Current.Resources["docID"];
        }

        private PatientAppointment _selectedAppointment { get; set; }
        public PatientAppointment SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                if (value == null)
                    return;
                _selectedAppointment = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedDate {  get; set; }
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
        

        private string _currentComplains { get; set; }
        public string CurrentComplains
        {
            get => _currentComplains;
            set
            {
                if (value == null)
                    return;
                _currentComplains = value;
                OnPropertyChanged();
            }
        }

        private string _currentInspection { get; set; }
        public string CurrentInspection
        {
            get => _currentInspection;
            set
            {
                if (value == null)
                    return;
                _currentInspection = value;
                OnPropertyChanged();
            }
        }

        private string _diagnosis { get; set; }
        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (value == null)
                    return;
                _diagnosis = value;
                OnPropertyChanged();
            }
        }

        private string _additions { get; set; }
        public string Additions
        {
            get => _additions;
            set
            {
                if (value == null)
                    return;
                _additions = value;
                OnPropertyChanged();
            }
        }

        private string _recomendations { get; set; }
        public string Recomendations
        {
            get => _recomendations;
            set
            {
                if (value == null)
                    return;
                _recomendations = value;
                OnPropertyChanged();
            }
        }

        private string _analysName { get; set; }
        public string AnalysName
        {
            get => _analysName;
            set
            {
                if (value == null)
                    return;
                _analysName = value;
                OnPropertyChanged();
            }
        }

        private string _researchName { get; set; }
        public string ResearchName
        {
            get => _researchName;
            set
            {
                if (value == null)
                    return;
                _researchName = value;
                OnPropertyChanged();
            }
        }

        public void UpdateSource()
        {
            var part = new ObservableCollection<Speciality>(JsonConvert.DeserializeObject<ICollection<Speciality>>(SpecialitiesHelper.GetSpecialities()) ?? new List<Speciality>());
            var appointments = JsonConvert.DeserializeObject<ICollection<Appointment>>(AppointmentsHelper.GetAppointmentsByDocID(DOC_ID)) ?? new List<Appointment>();
            List<PatientAppointment> existingPatients = new List<PatientAppointment>();
            foreach (var dir in appointments)
            {
                if (dir.Oms == null)
                    continue;
                var patient = JsonConvert.DeserializeObject<Patient>(PatientsHelper.GetPatientById(dir.Oms ?? 0));
                if(patient != null)
                    existingPatients.Add(new PatientAppointment()
                    {
                        AppoinmentTime = dir.AppoinmentTime,
                        AppointmentDate = dir.AppointmentDate,
                        IdAppointment = dir.IdAppointment,
                        IdDoctor = dir.IdDoctor,
                        IdStatus = dir.IdStatus,
                        Oms = patient.Oms,
                        Name = patient.Name,
                        Patronymic = patient.Patronymic,
                        SurName = patient.SurName
                    });
            }
            Appointments = new ObservableCollection<PatientAppointment>(existingPatients);
        }
        private void ClearUI()
        {
            _currentComplains = string.Empty;
            _currentInspection=  string.Empty;
            _diagnosis = string.Empty;
            _additions = string.Empty;
            _recomendations = string.Empty;
            _analysName = string.Empty;
            _researchName = string.Empty;
            Directions.Clear();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName == nameof(SelectedAppointment))
                ClearUI();
            else if(propertyName == nameof(SelectedDate))
            {
                var colView = CollectionViewSource.GetDefaultView(Appointments);
                colView.Filter += (object appointment) =>
                {
                    return appointment is Appointment appoint && Equals(appoint.AppointmentDate, DateOnly.FromDateTime(DateTime.Now));
                };
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
