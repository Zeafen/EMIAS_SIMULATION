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
using System.Windows;
using System.Windows.Data;

namespace Client_Emias.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly long OMS;

        private RelayCommand<Appointment>? _deleteAppointment = null;
        public RelayCommand<Appointment> DeleteAppointment => _deleteAppointment ?? (_deleteAppointment = new RelayCommand<Appointment>(
            canExecute: (Appointment app) => app.IdAppointment != null,
            execute: (Appointment app) =>
            {
                if (app.IdAppointment != null)
                {
                    AppointmentsHelper.DeleteAppointments(app.IdAppointment ?? 1);
                    UpdateSource();
                }
            }));
        private RelayCommand<Appointment>? _updateAppointment = null;
        public RelayCommand<Appointment> UpdateAppointment => _updateAppointment ?? (_updateAppointment = new RelayCommand<Appointment>(
            canExecute: (Appointment app) => app.IdAppointment != null,
            execute: (Appointment app) =>
            {
                if (app.IdAppointment != null)
                {
                    AppointmentsHelper.PutAppointments(JsonConvert.SerializeObject(app), app.IdAppointment ?? 1);
                    UpdateSource();
                }
            }));
        private RelayCommand? _finishAppointment = null;
        public RelayCommand FinishAppointment => _finishAppointment ?? (_finishAppointment = new RelayCommand(
            execute: (object parameter) =>
            {
                var appoint = new Appointment()
                {
                    AppoinmentTime = SelectedTime.Value,
                    AppointmentDate = SelectedDate.Value,
                    IdDoctor = SelectedDoctor.IdDoctor ?? 1,
                    Oms = OMS,
                    IdStatus = 1
                };
                Console.WriteLine(AppointmentsHelper.PostAppointment(JsonConvert.SerializeObject(appoint)));
            },
            canExecute: (object parameter) => SelectedDoctor != null && SelectedDoctor.IdDoctor != null && SelectedDate.HasValue && SelectedTime.HasValue));

        public ObservableCollection<Doctor> currentDoctors;
        public ObservableCollection<Speciality> availableDoctors;
        public ObservableCollection<Appointment> currentAppointment;
        public ObservableCollection<Appointment> archivedAppointmens;
        public ObservableCollection<DateOnly> thisWeekDays { get; set; }
        public ObservableCollection<DateOnly> nextWeekDays { get; set; }
        public ObservableCollection<TimeOnly> MorningTimes { get; set; }
        public ObservableCollection<TimeOnly> DayTimes { get; set; }
        public ObservableCollection<TimeOnly> EveningTimes { get; set; }

        private Speciality? _selectedSpeciality { get; set; } = null;
        public Speciality SelectedSpeciality
        {
            get => _selectedSpeciality;
            set
            {
                _selectedSpeciality = value;
                OnPropertyChanged();
            }
        }

        private Direction? _selectedDirection { get; set; } = null;
        public Direction SelectedDirection
        {
            get => _selectedDirection;
            set
            {
                _selectedDirection = value;
                OnPropertyChanged();
            }
        }
        private Doctor _selectedDoctor { get; set; }
        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged();
            }
        }
        private Appointment _selectedAppointment { get; set; }
        public Appointment SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged();
            }
        }



        private DateOnly? _selectedDate { get; set; } = null;
        public DateOnly? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
        private TimeOnly? _selectedTime { get; set; } = null;
        public TimeOnly? SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            try
            {
                GenerateTimes();
                OMS = (long)Application.Current.Resources["oms"];
                UpdateSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public void AddFilterToActiveAppointments(DateTime? startDate, DateTime? endDate)
        {
            var viewModel = CollectionViewSource.GetDefaultView(currentAppointment);
            viewModel.Filter = (object app) =>
            {
                if (app is Appointment appointment)
                {
                    if (startDate.HasValue && endDate.HasValue)
                        return CompareCompanion.IsDateEarlier(startDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime)
                        && !CompareCompanion.IsDateEarlier(endDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else if (!startDate.HasValue && endDate.HasValue)
                        return !CompareCompanion.IsDateEarlier(endDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else if (startDate.HasValue && !endDate.HasValue)
                        return CompareCompanion.IsDateEarlier(startDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else return true;
                }
                else
                    return false;
            };
        }
        public void AddFilterToArchiveAppointments(DateTime? startDate, DateTime? endDate)
        {
            var viewModel = CollectionViewSource.GetDefaultView(archivedAppointmens);
            viewModel.Filter = (object app) =>
            {
                if (app is Appointment appointment)
                {
                    if (startDate.HasValue && endDate.HasValue)
                        return CompareCompanion.IsDateEarlier(startDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime)
                        && !CompareCompanion.IsDateEarlier(endDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else if (!startDate.HasValue && endDate.HasValue)
                        return !CompareCompanion.IsDateEarlier(endDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else if (startDate.HasValue && !endDate.HasValue)
                        return CompareCompanion.IsDateEarlier(startDate.Value, appointment.AppointmentDate, appointment.AppoinmentTime);
                    else return true;
                }
                else
                    return false;
            };
        }

        private void UpdateSource()
        {
            availableDoctors = new ObservableCollection<Speciality>(JsonConvert.DeserializeObject<ICollection<Speciality>>(SpecialitiesHelper.GetSpecialities()) ?? new List<Speciality>());
            currentAppointment = new ObservableCollection<Appointment>(JsonConvert.DeserializeObject<ICollection<Appointment>>(AppointmentsHelper.GetActiveAppointments()) ?? new List<Appointment>());
            archivedAppointmens = new ObservableCollection<Appointment>(JsonConvert.DeserializeObject<ICollection<Appointment>>(AppointmentsHelper.GetArchivedAppointments()) ?? new List<Appointment>());
        }
        private void UpdateDates()
        {
            thisWeekDays.Clear();
            nextWeekDays.Clear();
            var date = DateTime.Now;
            switch(date.DayOfWeek)
            {

                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    date.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    date.AddDays(-2);
                    break;
                case DayOfWeek.Thursday: date.AddDays(-3);
                    break;
                case DayOfWeek.Friday: date.AddDays(-4);
                    break;
                case DayOfWeek.Saturday: date.AddDays(-5);
                    break;
                case DayOfWeek.Sunday: date.AddDays(-6);
                    break;
            }
            for (int i = 0; i < 7; i++)
            {
                thisWeekDays.Add(DateOnly.FromDateTime(date));
                date.AddDays(1);
            }
            for (int i = 0; i < 7; i++)
            {
                nextWeekDays.Add(DateOnly.FromDateTime(date));
                date.AddDays(1);
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName == nameof(SelectedSpeciality) && SelectedSpeciality != null)
                currentDoctors = new ObservableCollection<Doctor>(JsonConvert.DeserializeObject<ICollection<Doctor>>(DoctorsHelper.GetDoctorsBySpeciality(SelectedSpeciality.IdSpeciality ?? 0)) ?? new List<Doctor>());
            else if (propertyName == nameof(SelectedDirection) && SelectedDirection != null)
                currentDoctors = new ObservableCollection<Doctor>(JsonConvert.DeserializeObject<ICollection<Doctor>>(DoctorsHelper.GetDoctorsBySpeciality(SelectedDirection.IdSpeciality)) ?? new List<Doctor>());
            else if (propertyName == nameof(SelectedDate))
                if(_selectedDate.HasValue)
                    UpdateTime(_selectedDate.Value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GenerateTimes()
        {
            TimeOnly time = new TimeOnly(8, 30, 0);
            while(time.Minute != 0 && time.Hour != 12)
            {
                MorningTimes.Add(time);
                time.AddMinutes(10);
            }
            while(time.Minute != 0 && time.Hour != 17)
            {
                DayTimes.Add(time);
                time.AddMinutes(10);
            }
            while(time.Minute != 0 && time.Hour != 20)
            {
                EveningTimes.Add(time);
                time.AddMinutes(10);
            }
        }

        private void UpdateTime(DateOnly date)
        {
            var busyTime = JsonConvert.DeserializeObject<ICollection<TimeOnly>>(AppointmentsHelper.GetDoctorsBusyTime(SelectedDoctor.IdDoctor ?? 1, JsonConvert.SerializeObject(date)))?? new List<TimeOnly>();
            if(busyTime.Count > 0)
            {
                var dayCollectionView = CollectionViewSource.GetDefaultView(DayTimes);
                var morningCollectionView = CollectionViewSource.GetDefaultView(MorningTimes);
                var eveningCollectionView = CollectionViewSource.GetDefaultView(EveningTimes);

                dayCollectionView.Filter += (object t) => { return t is TimeOnly time && busyTime.All(t => t.Ticks != time.Ticks); };
                morningCollectionView.Filter += (object t) => { return t is TimeOnly time && busyTime.All(t => t.Ticks != time.Ticks); };
                eveningCollectionView.Filter += (object t) => { return t is TimeOnly time && busyTime.All(t => t.Ticks != time.Ticks); };
            }
            else
            {
                var dayCollectionView = CollectionViewSource.GetDefaultView(DayTimes);
                var morningCollectionView = CollectionViewSource.GetDefaultView(MorningTimes);
                var eveningCollectionView = CollectionViewSource.GetDefaultView(EveningTimes);

                dayCollectionView.Filter = null;
                morningCollectionView.Filter = null;
                eveningCollectionView.Filter = null;
            }
        }
    }
}
