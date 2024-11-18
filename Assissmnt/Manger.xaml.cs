using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Manger.xaml
    /// </summary>
    public partial class Manger : Page
    {
        employeEntities2 db = new employeEntities2();
        public Manger()
        {
            users u = new users();  
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            var c = db.Tasks.Select(x => new { x.users.email, x.taskid, x.title, x.descr, x.statuss }).ToList();
            cdg.ItemsSource = c;
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            Tasks tasks = new Tasks();

            tasks.title = titlee.Text;
            tasks.descr = des.Text;
            tasks.statuss = combo.Text;
            users users = new users();

            users = db.users.FirstOrDefault(x => x.email == email.Text);

            if (users == null)
            {
                MessageBox.Show("Invaild email");
            }
            else
            {
                tasks.useridd = users.userid;
            }
            db.Tasks.Add(tasks);
            db.SaveChanges();

            MessageBox.Show("Task added");
            cdg.ItemsSource = db.Tasks.Select(x => new { x.users.email, x.useridd, x.taskid, x.title, x.descr, x.statuss }).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tasks rec = new Tasks();
            rec.taskid = int.Parse(tid.Text);
            rec.title = titlee.Text;
            rec.descr = des.Text;
            rec.statuss = combo.Text;
            db.Tasks.AddOrUpdate(rec);
            db.SaveChanges();
            cdg.ItemsSource = db.Tasks.Select(x => new { x.users.email, x.useridd, x.taskid, x.title, x.descr, x.statuss }).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tid.Text);
            Tasks t = db.Tasks.Remove(db.Tasks.First(x => x.taskid == id));
            db.SaveChanges();
            MessageBox.Show("Record deleted");
        }
    }
}
