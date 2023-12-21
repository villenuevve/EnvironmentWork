using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;

namespace EnvironmentWork
{
    public partial class EventLogWindow : Window
    {
        public EventLogWindow()
        {
            InitializeComponent();
            LoadEventLogData();
        }

        private void LoadEventLogData()
        {
            try
            {
                string connectionString = @"Server=HELLMACHINE\VLADISLAVASQL; Database=CleverEnvironment; Integrated Security=True; Encrypt=False;";
                string query = "SELECT * FROM User_Info"; 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);
                    eventLogGrid.ItemsSource = dataTable.DefaultView;
                }
                eventLogGrid.IsReadOnly = true;
                eventLogGrid.CanUserAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void AnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            string environmentalInfo = GenerateEnvironmentalInfo();
            MessageBox.Show(environmentalInfo, "Summary on Environment Analysis", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string GenerateEnvironmentalInfo()
        {
            Random random = new Random();

            string[] environmentalFacts = new string[]
            {"Pollution levels are fluctuating across different regions.",
             "Efforts towards sustainability are increasing globally.",
             "Renewable energy adoption is on the rise.",
             "Biodiversity preservation efforts are showing positive outcomes.",
             "Deforestation rates are being actively monitored and addressed."
            };

            environmentalFacts = environmentalFacts.OrderBy(x => random.Next()).ToArray();

            string environmentalInfo = "Current environmental situation:";
            foreach (string fact in environmentalFacts)
            {
                environmentalInfo += $"\n- {fact}";
            }

            return environmentalInfo;
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}

