using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.SignalrVM
{
   public class RoomViewModel
    {
        public ICommand AddEmployeCommand => new Command(AddEmployee);     
        public ObservableCollection<string> Employees { get; set; }
        public string EmployeeName { get; set; }

        public RoomViewModel()
        {
            Employees = new ObservableCollection<string>();
            Employees.Add("Grup1");
            Employees.Add("Grup2");
            Employees.Add("Grup3");
            Employees.Add("Grup4");
            Employees.Add("Grup5");
        }
        public void AddEmployee()
        {
            Employees.Add(EmployeeName);
        }
    }
}



