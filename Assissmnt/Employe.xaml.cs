using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Employe.xaml
    /// </summary>
    public partial class Employe : Page
    {
        employeEntities2 db = new employeEntities2();
        int _idd;
        public Employe(int data)
        {
            _idd = data;
            InitializeComponent();
            int idd = data;
            var rec = db.users.First(x => x.userid == data);
          
            emp.Content = rec.names;
            Tasks t = new Tasks();
            

          pdg.ItemsSource = db.Tasks.Select(x => new { x.taskid, x.title, x.descr, x.statuss ,x.useridd}).Where(x =>x.useridd == idd&& x.statuss == "pending" || x.statuss == "in progress" && t.useridd ==idd ).ToList();
            cdg.ItemsSource = db.Tasks.Select(x => new { x.taskid, x.title, x.descr, x.statuss , x.useridd }).Where(x => x.useridd == idd&& x.statuss== "completed").ToList();




        }

        private void pdg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tid.Text);
            var rec = db.Tasks.FirstOrDefault(x => x.taskid == id);
            if (rec != null)
            {
                if (combo.Text == "completed" || combo.Text == "pending" || combo.Text == "in progress")
                {
                    rec.statuss = combo.Text;
                    db.Tasks.AddOrUpdate(rec);
                    db.SaveChanges();
                }

                cdg.ItemsSource = db.Tasks.Where(x => x.useridd == _idd && x.statuss == "completed").Select(x => new { x.taskid, x.title, x.descr, x.statuss , x.useridd }).ToList();
                pdg.ItemsSource = db.Tasks.Where(x => x.useridd == _idd && x.statuss == "pending" || x.statuss == "in progress").Select(x => new { x.taskid, x.title, x.descr, x.statuss  ,x.useridd }).ToList();

            }
            else
            {
                MessageBox.Show("invaild id");
            }
          
        }

    }
}

