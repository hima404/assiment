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
using System.Xml.Linq;

namespace Assissmnt
{
    /// <summary>
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        employeEntities2 db = new employeEntities2();
        public signup()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var rec = db.users.FirstOrDefault(x => x.email == emailtxt.Text);
            if (role.Text == "Manager")
            {
                if (name.Text.Length < 6)
                {
                    MessageBox.Show("name at least 6 char");
                }

                if (password.Text.Length < 9)
                {
                    MessageBox.Show("password at least 9 char");
                }
                if (rec != null)
                {
                    MessageBox.Show("Email have account");
                }

                if (password.Text == Confirmpassword.Text)
                {
                    users recc = new users();
                    recc.names = name.Text;
                    recc.email = emailtxt.Text;
                    recc.passwordd = password.Text;
                    recc.rolee = role.Text;
                    db.users.Add(recc);
                    db.SaveChanges();
                    MessageBox.Show("account craeted");
                    Login login = new Login();
                    NavigationService.Navigate(login);
                }
                else
                {
                    MessageBox.Show("password dont much");
                }
            }



            else if (role.Text == "Employee")
            {
                if (name.Text.Length < 6)
                {
                    MessageBox.Show("name at least 6 char");
                }

                if (password.Text.Length < 9)
                {
                    MessageBox.Show("password at least 9 char");
                }
                if (rec != null)
                {
                    MessageBox.Show("Email have account");
                }

                if (password.Text == Confirmpassword.Text)
                {
                    users rex = new users();
                    rex.names = name.Text;
                    rex.email = emailtxt.Text;
                    rex.passwordd = password.Text;
                    rex.rolee = role.Text;
                    db.users.Add(rex);
                    db.SaveChanges();
                    MessageBox.Show("account craeted");
                    Login login = new Login();
                    NavigationService.Navigate(login);
                }
                else
                {
                    MessageBox.Show("password dont much");
                }

            }

        }
    }
}
