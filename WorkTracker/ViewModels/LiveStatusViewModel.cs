using System.Collections.ObjectModel;
using WorkTracker.Models;
using WorkTracker.Resources.Localization;

namespace WorkTracker.ViewModels
{
    public class LiveStatusViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public DateTime CurrentDate { get; set; }

        private Dictionary<DateTime, List<Employee>> employeeData;

        public LiveStatusViewModel()
        {
            CurrentDate = new DateTime(2026, 6, 16);

            employeeData = new Dictionary<DateTime, List<Employee>>
            {
                {
                    new DateTime(2026,6,16),
                    new List<Employee>
                    {
                        new Employee
                        {
                            Name = "Alexander Allen",
                            Status = AppResources.Exception,
                            StatusColor = "Red",
                            ImagePath = "dotnet_bot.png"
                        },

                        new Employee
                        {
                            Name = "Waleed Ali Anjum",
                            Status = AppResources.NotClockedIn,
                            StatusColor = "Orange",
                            ImagePath = "dotnet_bot.png"
                        }
                    }
                },

                {
                    new DateTime(2026,6,17),
                    new List<Employee>
                    {
                        new Employee
                        {
                            Name = "Henry Baker",
                            Status = AppResources.Exception,
                            StatusColor = "Red",
                            ImagePath = "dotnet_bot.png"
                        },

                        new Employee
                        {
                            Name = "Joe Bloggs",
                            Status = AppResources.NotClockedIn,
                            StatusColor = "Orange",
                            ImagePath = "dotnet_bot.png"
                        }
                    }
                },

                {
                    new DateTime(2026,6,18),
                    new List<Employee>
                    {
                        new Employee
                        {
                            Name = "Daniel Carter",
                            Status = AppResources.Exception,
                            StatusColor = "Red",
                            ImagePath = "dotnet_bot.png"
                        }
                    }
                }
            };

            Employees = new ObservableCollection<Employee>();

            LoadEmployees();
        }

        public void NextDate()
        {
            CurrentDate = CurrentDate.AddDays(1);
            LoadEmployees();
        }

        public void PreviousDate()
        {
            CurrentDate = CurrentDate.AddDays(-1);
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            Employees.Clear();

            if (employeeData.ContainsKey(CurrentDate))
            {
                foreach (var employee in employeeData[CurrentDate])
                {
                    Employees.Add(employee);
                }
            }
        }
    }
}