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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddContract_Window.xaml
    /// </summary>
    public partial class AddContract_Window : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        public AddContract_Window()
        {
            InitializeComponent();
            contract = new BE.Contract();
            grid1.DataContext = contract;
            bl = BL.FactoryBL.GetBL();

            this.idChildComboBox.ItemsSource = bl.GetAllChildren();
            this.idChildComboBox.DisplayMemberPath = "Id";
            this.idChildComboBox.SelectedValuePath = "Id";

            this.idNannyComboBox.ItemsSource = bl.GetAllNannies();
            this.idNannyComboBox.DisplayMemberPath = "Id";
            this.idNannyComboBox.SelectedValuePath = "Id";

            this.howToPayComboBox.ItemsSource = Enum.GetValues(typeof(BE.Payment));
        }
        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window Contract_Window = new Contract();
            Contract_Window.Show();
            this.Close();
        }


        private void Main_button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMassage = "";
                if (this.idChildComboBox.Text == "0")
                    errorMassage += "You must enter identity number of child.\n";
                if (this.idNannyComboBox.Text == "0")
                    errorMassage += "You must enter identity number of nanny.\n";
                if (this.startingDateDatePicker.Text == "01/01/0001")
                    errorMassage += "You must enter a date of start working.\n";
                if (this.endDateDatePicker.Text == "0")
                    errorMassage += "You must enter a date of end working.\n";
                if (errorMassage != "")
                    throw new Exception(errorMassage);

                bl.addContract(contract);
                contract = new BE.Contract();
                grid1.DataContext = contract;
                MessageBox.Show("The contract successfully added ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "missing!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        

        private void accordingMounthCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (accordingMounthCheckBox.IsChecked == true)
            {
                accordingHourCheckBox.IsChecked = false;
                salaryPerHourTextBox.Text = "";
            }
            else
            {
                accordingHourCheckBox.IsChecked = true;
                accordingHourCheckBox.IsEnabled = true;
                accordingMounthCheckBox.IsEnabled = false;
                mounthSalaryTextBox.Text = "";
            }
        }

        private void accordingHourCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (accordingHourCheckBox.IsChecked == true)
            {
                accordingMounthCheckBox.IsChecked = false;
                mounthSalaryTextBox.Text = "";
            }
            else
            {
                accordingMounthCheckBox.IsChecked = true;
                accordingMounthCheckBox.IsEnabled = true;
                accordingHourCheckBox.IsEnabled = false;
                salaryPerHourTextBox.Text = "";
            }
        }
    }
}
