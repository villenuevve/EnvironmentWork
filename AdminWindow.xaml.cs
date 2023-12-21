using System;
using System.Linq;
using System.Windows;
using System.Data;
using System.Collections.ObjectModel;
using EnvironmentWork.Repositories;
using EnvironmentWork.Context;

namespace EnvironmentWork
{
    public partial class AdminWindow : Window
    {
        public int Admin_ID { get; set; }
        public EventLog selectedEventLog;
        private EventLogRepository eventLogRepository;
        private ObservableCollection<EventLog> eventLogs;

        public AdminWindow(int admin_ID)
        {
            InitializeComponent();
            eventLogRepository = new EventLogRepository(new CleverEnvironmentContext());
            eventLogs = new ObservableCollection<EventLog>();
            LoadAdminData();


            Admin_ID = admin_ID;
        }

        private async void LoadAdminData()
        {
            var loadEventLogs = await eventLogRepository.GetAllAsync();
            eventLogs = new ObservableCollection<EventLog>(loadEventLogs);
            AdminGrid.ItemsSource = eventLogs;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAdminData();
        }
        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            int id = eventLogs.Last<EventLog>().Event_ID + 1;
            var eventLog = new EventLog { Event_ID = id, EventName = "Unknown"};
            eventLogRepository.CreateOrUpdate(eventLog);
            eventLogRepository.Save();
            eventLogs.Add(eventLog);
        }

        private void EditEvent_Click(object sender, RoutedEventArgs e)
        {
            eventLogRepository.CreateOrUpdate(selectedEventLog);
            eventLogRepository.Save();
        }

        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            eventLogRepository.Delete(selectedEventLog);
            eventLogRepository.Save();
            eventLogs.Remove(selectedEventLog);
        }

        private void Analysis_Click(object sender, RoutedEventArgs e)
        {
            string environmentalInfo = GenerateEnvironmentalInfo();
            MessageBox.Show(environmentalInfo, "Summary on Environment Analysis", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private string GenerateEnvironmentalInfo()
        {
            Random random = new Random();

            string[] environmentalFacts = new string[]
            {
        "Pollution levels are fluctuating across different regions.",
        "Renewable energy adoption is on the rise.",
        "Biodiversity preservation efforts are showing positive outcomes."
            };

            string[] technicianInfo = new string[]
            {
        "Technicians are implementing advanced monitoring systems.",
        "Technical teams are working on renewable energy projects."
            };

            string[] administratorInfo = new string[]
            {
        "Administrators is collaborating on sustainability programs now."
            };

            // Shuffle the facts to get a random order every time
            environmentalFacts = environmentalFacts.OrderBy(x => random.Next()).ToArray();
            technicianInfo = technicianInfo.OrderBy(x => random.Next()).ToArray();
            administratorInfo = administratorInfo.OrderBy(x => random.Next()).ToArray();

            // Generate a message with random environmental, technician, and administrator facts
            string environmentalInfo = "Current environmental situation:";
            environmentalInfo += $"\n\nEnvironmental Information:";
            foreach (string fact in environmentalFacts)
            {
                environmentalInfo += $"\n- {fact}";
            }

            environmentalInfo += $"\n\nTechnician Information:";
            foreach (string techFact in technicianInfo)
            {
                environmentalInfo += $"\n- {techFact}";
            }

            environmentalInfo += $"\n\nAdministrator Information:";
            foreach (string adminFact in administratorInfo)
            {
                environmentalInfo += $"\n- {adminFact}";
            }

            return environmentalInfo;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void AdminGrid_Selected(object sender, RoutedEventArgs e)
        {
                selectedEventLog = (EventLog)AdminGrid.SelectedItem;
        }
    }
}

