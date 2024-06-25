using Client_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Client_Emias.Helpers.ApiHelpers;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Client_Emias.viewModels.PatientVM
{
    public class MedcardViewModel : INotifyPropertyChanged
    {
        private readonly int OMS;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<AnalysDocument> AnalysDocuments { get; set; }
        public ObservableCollection<ResearchDocument> ResearchDocuments { get; set; }
        public Appointment Appointment
        {
            get => _appointment;
            set
            {
                if (value == null)
                    return;
                _appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }
        private Appointment _appointment { get; set; }
        public AnalysDocument AnalysDocument
        {
            get => _analysDocument;
            set
            {
                if (value == null)
                    return;
                _analysDocument = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }
        private AnalysDocument _analysDocument { get; set; }
        public ResearchDocument ResearchDocument
        {
            get => _researchDocument;
            set
            {
                if (value == null)
                    return;
                _researchDocument = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }
        private ResearchDocument _researchDocument { get; set; }

        public void UpdateSource () 
        {
            var appointments = AppointmentsHelper.GetAppointmentByOms(OMS);
            Appointments = new ObservableCollection<Appointment>(JsonConvert.DeserializeObject<ICollection<Appointment>>(appointments)??new List<Appointment>());
            var analysdocument = AnalysDocumentHelper.GetAnalysDocumentByOms(OMS);
            AnalysDocuments = new ObservableCollection<AnalysDocument>(JsonConvert.DeserializeObject<ICollection<AnalysDocument>>(analysdocument) ?? new List<AnalysDocument>());
            var researchdocuments = ResearchDocumentsHelper.GetResearchDocumentsByOms(OMS);
            ResearchDocuments = new ObservableCollection<ResearchDocument>(JsonConvert.DeserializeObject<ICollection<ResearchDocument>>(researchdocuments) ?? new List<ResearchDocument>());
        }

        public MedcardViewModel () 
        {
            OMS = (int)Application.Current.Resources["oms"];
            UpdateSource ();
        }

        private void OnPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
