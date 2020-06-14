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
    /// Interaction logic for UpdateNanny_Window.xaml
    /// </summary>
    public partial class UpdateNanny_Window : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public UpdateNanny_Window()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            bl = BL.FactoryBL.GetBL();
            this.Id_comboBox.ItemsSource = bl.GetAllNannies();
            this.Id_comboBox.DisplayMemberPath = "Id";
            this.Id_comboBox.SelectedValuePath = "Id";
            this.NannyGrid.DataContext = nanny;
            this.eductionComboBox.ItemsSource = Enum.GetValues(typeof(BE.Eduction));
            NannyGrid.DataContext = nanny;
           


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
        private int GetSelectedNannyId()
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
                nanny = bl.FindNannyAcordId(GetSelectedNannyId());
                this.NannyGrid.DataContext = nanny;
                ifWorkCheckBox.IsChecked = nanny.DaysWork[0].IfWork;
                if ("" + nanny.DaysWork[0].StartClock != "" + "00:00:00")
                    startClockTextBox.Text = "" + nanny.DaysWork[0].StartClock;
                if ("" + nanny.DaysWork[0].EndClock != "" + "00:00:00")
                    endClockTextBox.Text =""+ nanny.DaysWork[0].EndClock;
                ifWorkCheckBox5.IsChecked = nanny.DaysWork[1].IfWork;
                if ("" + nanny.DaysWork[1].StartClock != "" + "00:00:00")
                    startClockTextBox5.Text = "" + nanny.DaysWork[1].StartClock;
                if ("" + nanny.DaysWork[1].EndClock != "" + "00:00:00")
                    endClockTextBox5.Text = "" + nanny.DaysWork[1].EndClock;
                ifWorkCheckBox4.IsChecked = nanny.DaysWork[2].IfWork;
                if ("" + nanny.DaysWork[2].StartClock != "" + "00:00:00")
                    startClockTextBox4.Text = "" + nanny.DaysWork[2].StartClock;
                if ("" + nanny.DaysWork[2].EndClock != "" + "00:00:00")
                    endClockTextBox4.Text = "" + nanny.DaysWork[2].EndClock;
                ifWorkCheckBox3.IsChecked = nanny.DaysWork[3].IfWork;
                if ("" + nanny.DaysWork[3].StartClock != "" + "00:00:00")
                    startClockTextBox3.Text = "" + nanny.DaysWork[3].StartClock;
                if ("" + nanny.DaysWork[3].EndClock != "" + "00:00:00")
                    endClockTextBox3.Text = "" + nanny.DaysWork[3].EndClock;
                ifWorkCheckBox2.IsChecked = nanny.DaysWork[4].IfWork;
                if ("" + nanny.DaysWork[4].StartClock != "" + "00:00:00")

                    startClockTextBox2.Text = "" + nanny.DaysWork[4].StartClock;
                if ("" + nanny.DaysWork[4].EndClock != "" + "00:00:00")

                    endClockTextBox2.Text = "" + nanny.DaysWork[4].EndClock;
                ifWorkCheckBox1.IsChecked = nanny.DaysWork[5].IfWork;
                if ("" + nanny.DaysWork[5].StartClock != "" + "00:00:00")

                    startClockTextBox1.Text = "" + nanny.DaysWork[5].StartClock;
                if ("" + nanny.DaysWork[5].EndClock != "" + "00:00:00")

                    endClockTextBox1.Text = "" + nanny.DaysWork[5].EndClock;
                MaxChildNumeric.Value = nanny.MaxChild;
            }
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string errorMassage = "";
                if (this.nameTextBox.Text == "")
                    errorMassage += "You must enter name.\n";
                if (this.familyTextBox.Text == "")
                    errorMassage += "You must enter family name.\n";
                if (this.idTextBox.Text == "0")
                    errorMassage += "You must enter identity number.\n";
                if (this.birthDatePicker.Text == "01/01/0001")
                    errorMassage += "You must enter a date of birthday.\n";
                if (this.addressTextBox.Text == "")
                    errorMassage += "You must enter the address.\n";
                if (errorMassage != "")
                    throw new Exception(errorMassage);
                if ((bool)ifWorkCheckBox.IsChecked)
                    nanny.DaysWork[0].IfWork = (bool)ifWorkCheckBox.IsChecked;
                if (startClockTextBox.Text != "")
                    nanny.DaysWork[0].StartClock = TimeSpan.Parse(startClockTextBox.Text);
                if (endClockTextBox.Text != "")
                    nanny.DaysWork[0].EndClock = TimeSpan.Parse(endClockTextBox.Text);
                if ((bool)ifWorkCheckBox5.IsChecked)
                    nanny.DaysWork[1].IfWork = (bool)ifWorkCheckBox5.IsChecked;
                if (startClockTextBox5.Text != "")
                    nanny.DaysWork[1].StartClock = TimeSpan.Parse(startClockTextBox5.Text);
                if (endClockTextBox5.Text != "")
                    nanny.DaysWork[1].EndClock = TimeSpan.Parse(endClockTextBox5.Text);
                if ((bool)ifWorkCheckBox4.IsChecked)
                    nanny.DaysWork[2].IfWork = (bool)ifWorkCheckBox4.IsChecked;
                if (startClockTextBox4.Text != "")
                    nanny.DaysWork[2].StartClock = TimeSpan.Parse(startClockTextBox4.Text);
                if (endClockTextBox4.Text != "")
                    nanny.DaysWork[2].EndClock = TimeSpan.Parse(endClockTextBox4.Text);
                if ((bool)ifWorkCheckBox3.IsChecked)
                    nanny.DaysWork[3].IfWork = (bool)ifWorkCheckBox3.IsChecked;
                if (startClockTextBox3.Text != "")
                    nanny.DaysWork[3].StartClock = TimeSpan.Parse(startClockTextBox3.Text);
                if (endClockTextBox3.Text != "")
                    nanny.DaysWork[3].EndClock = TimeSpan.Parse(endClockTextBox3.Text);
                if ((bool)ifWorkCheckBox2.IsChecked)
                    nanny.DaysWork[4].IfWork = (bool)ifWorkCheckBox2.IsChecked;
                if (startClockTextBox2.Text != "")
                    nanny.DaysWork[4].StartClock = TimeSpan.Parse(startClockTextBox2.Text);
                if (endClockTextBox2.Text != "")
                    nanny.DaysWork[4].EndClock = TimeSpan.Parse(endClockTextBox2.Text);
                if ((bool)ifWorkCheckBox1.IsChecked)
                    nanny.DaysWork[5].IfWork = (bool)ifWorkCheckBox1.IsChecked;
                if (startClockTextBox1.Text != "")
                    nanny.DaysWork[5].StartClock = TimeSpan.Parse(startClockTextBox1.Text);
                if (endClockTextBox1.Text != "")
                    nanny.DaysWork[5].EndClock = TimeSpan.Parse(endClockTextBox1.Text);
                if (Convert.ToInt32(MaxChildNumeric.Value) != 0)
                    nanny.MaxChild = (int)MaxChildNumeric.Value;
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
                nanny.DaysWork[1].IfWork = (bool)ifWorkCheckBox5.IsChecked;
                if (startClockTextBox5.Text != "")
                    nanny.DaysWork[1].StartClock = TimeSpan.Parse(startClockTextBox5.Text);
                if (endClockTextBox5.Text != "")
                    nanny.DaysWork[1].EndClock = TimeSpan.Parse(endClockTextBox5.Text);
                nanny.DaysWork[2].IfWork = (bool)ifWorkCheckBox4.IsChecked;
                if (startClockTextBox4.Text != "")
                    nanny.DaysWork[2].StartClock = TimeSpan.Parse(startClockTextBox4.Text);
                if (endClockTextBox4.Text != "")
                    nanny.DaysWork[2].EndClock = TimeSpan.Parse(endClockTextBox4.Text);
                nanny.DaysWork[3].IfWork = (bool)ifWorkCheckBox3.IsChecked;
                if (startClockTextBox3.Text != "")
                    nanny.DaysWork[3].StartClock = TimeSpan.Parse(startClockTextBox3.Text);
                if (endClockTextBox3.Text != "")
                    nanny.DaysWork[3].EndClock = TimeSpan.Parse(endClockTextBox3.Text);
                nanny.DaysWork[4].IfWork = (bool)ifWorkCheckBox2.IsChecked;
                if (startClockTextBox2.Text != "")
                    nanny.DaysWork[4].StartClock = TimeSpan.Parse(startClockTextBox2.Text);
                if (endClockTextBox2.Text != "")
                    nanny.DaysWork[4].EndClock = TimeSpan.Parse(endClockTextBox2.Text);
                nanny.DaysWork[5].IfWork = (bool)ifWorkCheckBox1.IsChecked;
                if (startClockTextBox1.Text != "")
                    nanny.DaysWork[5].StartClock = TimeSpan.Parse(startClockTextBox1.Text);
                if (endClockTextBox1.Text != "")
                    nanny.DaysWork[5].EndClock = TimeSpan.Parse(endClockTextBox1.Text);
                if (Convert.ToInt32(MaxChildNumeric.Value) != 0)
                    nanny.MaxChild = (int)MaxChildNumeric.Value;
                bl.updateNanny(nanny);
                nanny = new BE.Nanny();
                Id_comboBox.Text = "";
                MessageBox.Show("The nanny successfully updated ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

                this.NannyGrid.DataContext = nanny;
                this.InvalidateVisual();
                NannyGrid.DataContext = nanny;
                ifWorkCheckBox.IsChecked = nanny.DaysWork[0].IfWork;
                startClockTextBox.Text = null;
                endClockTextBox.Text = null;
                ifWorkCheckBox5.IsChecked = nanny.DaysWork[1].IfWork;
                startClockTextBox5.Text = null;
                endClockTextBox5.Text = null;
                ifWorkCheckBox4.IsChecked = nanny.DaysWork[2].IfWork;
                startClockTextBox4.Text = null;
                endClockTextBox4.Text = null;
                ifWorkCheckBox3.IsChecked = nanny.DaysWork[3].IfWork;
                startClockTextBox3.Text = null;
                endClockTextBox3.Text = null;
                ifWorkCheckBox2.IsChecked = nanny.DaysWork[4].IfWork;
                startClockTextBox2.Text = null;
                endClockTextBox2.Text = null;
                ifWorkCheckBox1.IsChecked = nanny.DaysWork[5].IfWork;
                startClockTextBox1.Text = null;
                endClockTextBox1.Text = null;
                MaxChildNumeric.Value = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "missing!!", MessageBoxButton.OK, MessageBoxImage.Warning);

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

        private void eductionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(eductionComboBox.SelectedIndex==0)
            nanny.eduction =BE.Eduction.EducationOffice;
            else
                nanny.eduction = BE.Eduction.Tamat;

        }

    }
}
