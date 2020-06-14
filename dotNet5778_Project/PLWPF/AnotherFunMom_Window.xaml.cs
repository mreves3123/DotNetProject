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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AnotherFunMom_Window.xaml
    /// </summary>
    public partial class AnotherFunMom_Window : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public AnotherFunMom_Window()
        {
            InitializeComponent();
            mother = new BE.Mother();
            bl = BL.FactoryBL.GetBL();
            this.IdMom_comboBox.ItemsSource = bl.GetAllMothers();
            this.IdMom_comboBox.DisplayMemberPath = "Id";
            this.IdMom_comboBox.SelectedValuePath = "Id";
        }
        private void Main_button_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window MotherWindow = new Mother();
            MotherWindow.Show();
            this.Close();
        }
        private int GetSelectedMotherId()
        {
            object result = this.IdMom_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select mother First");
            return (int)result;
        }


        private void IdMom_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                mother = bl.FindMotherAcordId(GetSelectedMotherId());
                //  dataGrid.DataContext = mother;
                List<BE.Mother> m = new List<BE.Mother>();
                m.Add(mother);
                listBox.ItemsSource = m;
                ////
             //   dataGrid.ItemsPanel = bl.FindMotherAcordId(GetSelectedMotherId());
               // StudentCoursesDataGrid.ItemsSource = bl.GetAllCourseOfStudent(studentId);

            }

        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {
                    mother = dg.SelectedItem as BE.Mother;
                   
                }
                else
                {
                    mother = null;
                }
            }
            catch
            {

            }
        }

        private void listMom_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.GetAllMothers();
        }

        private void MomsAccordNumChild_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.MomAcordNumChild().AsEnumerable().ToList().Select(x=>x.Key);    
            //listBox.ContextMenu = bl.();
            
            //listBox.ItemsSource = bl.MomAcordNumChild().AsEnumerable().ToList();
            //var r = bl.MomAcordNumChild();
            //foreach (var item in r)
            //{
            //    Console.WriteLine("{0}: \n", item.Key);
            //    foreach (var n in item)
            //    {
            //        Console.Write("{0}, ", n);
            //        Console.WriteLine("\n");
            //    }
            //}
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
