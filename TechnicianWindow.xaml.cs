using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;
using EnvironmentWork.Repositories;
using System.Collections.ObjectModel;
using EnvironmentWork.Context;
using System.Linq;

namespace EnvironmentWork
{
    public partial class TechnicianWindow : Window
    {
        public int Tech_ID { get; set; }
        public EventLog selectedEventLog;
        private EventLogRepository eventLogRepository;
        private ObservableCollection<EventLog> eventLogs;
        public TechnicianWindow(int tech_ID)
        {
            InitializeComponent();
            eventLogRepository = new EventLogRepository(new CleverEnvironmentContext());
            eventLogs = new ObservableCollection<EventLog>();
            LoadEventLogData();

            Tech_ID = tech_ID;
        }

        private async void LoadEventLogData()
        {
            var loadEventLogs = await eventLogRepository.GetAllAsync();
            eventLogs = new ObservableCollection<EventLog>(loadEventLogs);
            TechnicianGrid.ItemsSource = eventLogs;
        }
        private void PlusEvent_Click(object sender, RoutedEventArgs e)
        {
            int id = eventLogs.Last<EventLog>().Event_ID + 1;
            var eventLog = new EventLog { Event_ID = id, EventName = "Unknown", Tech_ID = this.Tech_ID};
            eventLogRepository.CreateOrUpdate(eventLog);
            eventLogRepository.Save();
            eventLogs.Add(eventLog);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            eventLogRepository.CreateOrUpdate(selectedEventLog);
            eventLogRepository.Save();
        }

        private void TechnicianGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEventLog = (EventLog)TechnicianGrid.SelectedItem;
        }
    }
}