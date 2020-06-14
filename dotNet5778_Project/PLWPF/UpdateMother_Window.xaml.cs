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
    /// Interaction logic for UpdateMother_Window.xaml
    /// </summary>
    public partial class UpdateMother_Window : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public UpdateMother_Window()
        {
            InitializeComponent();

            mother = new BE.Mother();
            bl = BL.FactoryBL.GetBL();
            this.Id_comboBox.ItemsSource = bl.GetAllMothers();
            this.Id_comboBox.DisplayMemberPath = "Id";
            this.Id_comboBox.SelectedValuePath = "Id";
            MotherDetailsGrid.DataContext = mother;
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
            object result = this.Id_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select Nanny First");
            return (int)result;
        }

        private void Id_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                mother = bl.FindMotherAcordId(GetSelectedMotherId());
                this.MotherDetailsGrid.DataContext = mother;
                ifWorkCheckBox.IsChecked = mother.DaysNeed[0].IfWork;
                if ("" + mother.DaysNeed[0].StartClock != "" + "00:00:00")
                    startClockTextBox.Text = "" + mother.DaysNeed[0].StartClock;
                if ("" + mother.DaysNeed[0].EndClock != "" + "00:00:00")
                    endClockTextBox.Text = "" + mother.DaysNeed[0].EndClock;
                ifWorkCheckBox5.IsChecked = mother.DaysNeed[1].IfWork;
                if ("" + mother.DaysNeed[1].StartClock != "" + "00:00:00")
                    startClockTextBox5.Text = "" + mother.DaysNeed[1].StartClock;
                if ("" + mother.DaysNeed[1].EndClock != "" + "00:00:00")
                    endClockTextBox5.Text = "" + mother.DaysNeed[1].EndClock;
                ifWorkCheckBox4.IsChecked = mother.DaysNeed[2].IfWork;
                if ("" + mother.DaysNeed[2].StartClock != "" + "00:00:00")
                    startClockTextBox4.Text = "" + mother.DaysNeed[2].StartClock;
                if ("" + mother.DaysNeed[2].EndClock != "" + "00:00:00")
                    endClockTextBox4.Text = "" + mother.DaysNeed[2].EndClock;
                ifWorkCheckBox3.IsChecked = mother.DaysNeed[3].IfWork;
                if ("" + mother.DaysNeed[3].StartClock != "" + "00:00:00")
                    startClockTextBox3.Text = "" + mother.DaysNeed[3].StartClock;
                if ("" + mother.DaysNeed[3].EndClock != "" + "00:00:00")
                    endClockTextBox3.Text = "" + mother.DaysNeed[3].EndClock;
                ifWorkCheckBox2.IsChecked = mother.DaysNeed[4].IfWork;
                if ("" + mother.DaysNeed[4].StartClock != "" + "00:00:00")

                    startClockTextBox2.Text = "" + mother.DaysNeed[4].StartClock;
                if ("" + mother.DaysNeed[4].EndClock != "" + "00:00:00")

                    endClockTextBox2.Text = "" + mother.DaysNeed[4].EndClock;
                ifWorkCheckBox1.IsChecked = mother.DaysNeed[5].IfWork;
                if ("" + mother.DaysNeed[5].StartClock != "" + "00:00:00")

                    startClockTextBox1.Text = "" + mother.DaysNeed[5].StartClock;
                if ("" + mother.DaysNeed[5].EndClock != "" + "00:00:00")

                    endClockTextBox1.Text = "" + mother.DaysNeed[5].EndClock;
            }
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string errorMassage = "";
                if (this.idTextBox.Text == "")
                    errorMassage += "You must enter identity number.\n";
                if (this.nameTextBox.Text == "")
                    errorMassage += "You must enter name.\n";
                if (this.familyTextBox.Text == "")
                    errorMassage += "You must enter family name.\n";

                if (this.addressTextBox.Text == "")
                    errorMassage += "You must enter the address.\n";
                if (errorMassage != "")
                    throw new Exception(errorMassage);
                if ((ifWorkCheckBox.IsChecked == true) && (startClockTextBox.Text == "" || endClockTextBox.Text == ""))
                    errorMassage += "The works hour in sunday are not correct.\n";
                if ((ifWorkCheckBox5.IsChecked == true) && (startClockTextBox5.Text == "" || endClockTextBox5.Text == ""))
                    errorMassage += "The works hour in monday are not correct.\n";
                if ((ifWorkCheckBox4.IsChecked == true) && (startClockTextBox4.Text == "" || endClockTextBox4.Text == ""))
                    errorMassage += "The works hour in tuesday are not correct.\n";
                if ((ifWorkCheckBox3.IsChecked == true) && (startClockTextBox3.Text == "" || endClockTextBox3.Text == ""))
                    errorMassage += "The works hour in wednesday are not correct.\n";
                if ((ifWorkCheckBox2.IsChecked == true) && (startClockTextBox2.Text == "" || endClockTextBox2.Text == ""))
                    errorMassage += "The works hour in thursday are not correct.\n";
                if ((ifWorkCheckBox1.IsChecked == true) && (startClockTextBox1.Text == "" || endClockTextBox1.Text == ""))
                    errorMassage += "The works hour in friday are not correct.\n";
                if (errorMassage != "")
                    throw new Exception(errorMassage);


                mother.DaysNeed[1].IfWork = (bool)ifWorkCheckBox5.IsChecked;
                if (startClockTextBox5.Text != "")
                    mother.DaysNeed[1].StartClock = TimeSpan.Parse(startClockTextBox5.Text);
                if (endClockTextBox5.Text != "")
                    mother.DaysNeed[1].EndClock = TimeSpan.Parse(endClockTextBox5.Text);
                mother.DaysNeed[2].IfWork = (bool)ifWorkCheckBox4.IsChecked;
                if (startClockTextBox4.Text != "")
                    mother.DaysNeed[2].StartClock = TimeSpan.Parse(startClockTextBox4.Text);
                if (endClockTextBox4.Text != "")
                    mother.DaysNeed[2].EndClock = TimeSpan.Parse(endClockTextBox4.Text);
                mother.DaysNeed[3].IfWork = (bool)ifWorkCheckBox3.IsChecked;
                if (startClockTextBox3.Text != "")
                    mother.DaysNeed[3].StartClock = TimeSpan.Parse(startClockTextBox3.Text);
                if (endClockTextBox3.Text != "")
                    mother.DaysNeed[3].EndClock = TimeSpan.Parse(endClockTextBox3.Text);
                mother.DaysNeed[4].IfWork = (bool)ifWorkCheckBox2.IsChecked;
                if (startClockTextBox2.Text != "")
                    mother.DaysNeed[4].StartClock = TimeSpan.Parse(startClockTextBox2.Text);
                if (endClockTextBox2.Text != "")
                    mother.DaysNeed[4].EndClock = TimeSpan.Parse(endClockTextBox2.Text);
                mother.DaysNeed[5].IfWork = (bool)ifWorkCheckBox1.IsChecked;
                if (startClockTextBox1.Text != "")
                    mother.DaysNeed[5].StartClock = TimeSpan.Parse(startClockTextBox1.Text);
                if (endClockTextBox1.Text != "")
                    mother.DaysNeed[5].EndClock = TimeSpan.Parse(endClockTextBox1.Text);

                bl.updateMother(mother);
                mother = new BE.Mother();
                Id_comboBox.Text = "";
                MessageBox.Show("The mother successfully updated ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

                this.MotherDetailsGrid.DataContext = mother;
                this.InvalidateVisual();
                MotherDetailsGrid.DataContext = mother;
                ifWorkCheckBox.IsChecked = mother.DaysNeed[0].IfWork;
                startClockTextBox.Text = null;
                endClockTextBox.Text = null;
                ifWorkCheckBox5.IsChecked = mother.DaysNeed[1].IfWork;
                startClockTextBox5.Text = null;
                endClockTextBox5.Text = null;
                ifWorkCheckBox4.IsChecked = mother.DaysNeed[2].IfWork;
                startClockTextBox4.Text = null;
                endClockTextBox4.Text = null;
                ifWorkCheckBox3.IsChecked = mother.DaysNeed[3].IfWork;
                startClockTextBox3.Text = null;
                endClockTextBox3.Text = null;
                ifWorkCheckBox2.IsChecked = mother.DaysNeed[4].IfWork;
                startClockTextBox2.Text = null;
                endClockTextBox2.Text = null;
                ifWorkCheckBox1.IsChecked = mother.DaysNeed[5].IfWork;
                startClockTextBox1.Text = null;
                endClockTextBox1.Text = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void ifWorkCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkCheckBox.IsChecked == false)
            {
                startClockTextBox.Text = "";
                endClockTextBox.Text = "";
            }
        }

        private void ifWorkCheckBox5_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkCheckBox5.IsChecked == false)
            {
                startClockTextBox5.Text = "";
                endClockTextBox5.Text = "";
            }
        }

        private void ifWorkCheckBox4_Click(object sender, RoutedEventArgs e)
        {

            if (ifWorkCheckBox4.IsChecked == false)
            {
                startClockTextBox4.Text = "";
                endClockTextBox4.Text = "";
            }
        }

        private void ifWorkCheckBox3_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkCheckBox3.IsChecked == false)
            {
                startClockTextBox3.Text = "";
                endClockTextBox3.Text = "";
            }
        }

        private void ifWorkCheckBox2_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkCheckBox2.IsChecked == false)
            {
                startClockTextBox2.Text = "";
                endClockTextBox2.Text = "";
            }
        }

        private void ifWorkCheckBox1_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkCheckBox1.IsChecked == false)
            {
                startClockTextBox1.Text = "";
                endClockTextBox1.Text = "";
            }
        }

     
    }
    
}




//        private void Update_button_Click(object sender, RoutedEventArgs e)
//        {

//           
//    }
//}
