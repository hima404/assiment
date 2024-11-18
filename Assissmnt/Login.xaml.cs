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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assissmnt
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        employeEntities2 db = new employeEntities2();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users rec = new users();    
            var email = Email.Text;
            var pass = passs.Password;
            rec = db.users.FirstOrDefault(x => x.email == email && x.passwordd == pass && x.rolee == "employee");
            var s = db.users.FirstOrDefault(x => x.email == email && x.passwordd == pass && x.rolee == "manager");
            if (rec != null)
            {
                Employe emp = new Employe(rec.userid );
                NavigationService.Navigate(emp );
                MessageBox.Show("Login sucssesfuly");

            }
            if (s != null)
            {
                Manger m = new Manger();
                NavigationService.Navigate(m);
                MessageBox.Show("Login sucssesfuly");

            }
           
        }
    }
}
