using System.Linq;
using System.Windows;
using System.Windows.Input;
using EnvironmentWork.Context;

namespace EnvironmentWork
{
    public partial class LoginWindow : Window
    {
        public bool IsAuthenticated { get; set; }
        public int Tech_ID { get; set; }
        public int Admin_ID { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (AuthUser(email, password))
            {
                IsAuthenticated = true;

                using (var DataBaseCont = new CleverEnvironmentContext())
                {
                    var authUser = DataBaseCont.Technician.FirstOrDefault(u => u.Tech_Email == email && u.Tech_Password == password);
                    if (authUser != null)
                    {
                        Tech_ID = authUser.Tech_ID;
                    }
                }
                var technicianWindow = new TechnicianWindow(Tech_ID);
                technicianWindow.Show();
                Close();
            }
            else if (AuthAdmin(email, password))
            {
                IsAuthenticated = true;
                using (var DataBaseCont = new CleverEnvironmentContext())
                {
                    var authUser = DataBaseCont.Administrator.FirstOrDefault(u => u.Admin_Email == email && u.Admin_Password == password);
                    if (authUser != null)
                    {
                        Admin_ID = authUser.Admin_ID;
                    }
                }
                var adminWindow = new AdminWindow(Admin_ID);
                adminWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid information. Try once more.");
            }
        }

        private bool AuthUser(string email, string password)
        {
            using (var DataBaseCont = new CleverEnvironmentContext())
            {
                var user = DataBaseCont.Technician.FirstOrDefault(u => u.Tech_Email == email && u.Tech_Password == password);
                return user != null;
            }
        }

        private bool AuthAdmin(string email, string password)
        {
            using (var DataBaseCont = new CleverEnvironmentContext())
            {
                var admin = DataBaseCont.Administrator.FirstOrDefault(u => u.Admin_Email == email && u.Admin_Password == password);
                return admin != null;
            }
        }

        private void GuestLogin_Click(object sender, MouseButtonEventArgs e)
        {
            var eventWindow = new EventLogWindow();
            eventWindow.Show();
            Close();
        }
    }
}
