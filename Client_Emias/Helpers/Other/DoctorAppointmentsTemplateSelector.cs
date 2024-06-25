using Client_Emias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client_Emias.Helpers.Other
{
    public class DoctorAppointmentsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal {  get; set; }
        public DataTemplate Depricated {  get; set; }
        public DataTemplate Completed {  get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is PatientAppointment patApp)
            {
                if (!CompareCompanion.IsDateEarlier(DateTime.Now, patApp.AppointmentDate, patApp.AppoinmentTime))
                    return Depricated;
                else if(patApp.IdStatus == 1)
                    return Completed; 
                else return Normal;
            }
            else return base.SelectTemplate(item, container);
        }
    }
}
