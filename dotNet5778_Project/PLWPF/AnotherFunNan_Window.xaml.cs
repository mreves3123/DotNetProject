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
    /// Interaction logic for AnotherFunNan_Window.xaml
    /// </summary>
    public partial class AnotherFunNan_Window : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public AnotherFunNan_Window()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            bl = BL.FactoryBL.GetBL();
            this.IdNanny_comboBox.ItemsSource = bl.GetAllNannies();
            this.IdNanny_comboBox.DisplayMemberPath = "Id";
            this.IdNanny_comboBox.SelectedValuePath = "Id";
        }
        private void Main_button_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window NannyWindow = new Nanny();
            NannyWindow.Show();
            this.Close();
        }

        private int GetSelectedNannaId()
        {
            object result = this.IdNanny_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select mother First");
            return (int)result;
        }


        private void IdNanny_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                nanny = bl.FindNannyAcordId(GetSelectedNannaId());
                //  dataGrid.DataContext = mother;
                List<BE.Nanny> n = new List<BE.Nanny>();
                n.Add(nanny);
                listBox.ItemsSource = n;
                ////
                //   dataGrid.ItemsPanel = bl.FindMotherAcordId(GetSelectedMotherId());
                // StudentCoursesDataGrid.ItemsSource = bl.GetAllCourseOfStudent(studentId);

            }

        }

        
        private void listNanny_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.GetAllNannies();

        }

        private void tamat_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.NanAcordingTamat();

        }

        private void educ_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.NanAcordingEducationOffice();
        }

        private void food_button_Click(object sender, RoutedEventArgs e)
        {
            // listBox.ItemsSource = bl.NanPrepareFood();
            listBox.ItemsSource=(bl.ContractAcordDistance(true)).ToList();
        }

        private void place_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.PlaceForChild();
        }
    }
}
