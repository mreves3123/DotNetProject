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
    /// Interaction logic for UpdateContract_Window.xaml
    /// </summary>
    public partial class UpdateContract_Window : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        public UpdateContract_Window()
        {
            InitializeComponent();
            contract = new BE.Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
            this.numContract_comboBox.ItemsSource = bl.GetAllContracts();
            this.numContract_comboBox.DisplayMemberPath = "NumContract";
            this.numContract_comboBox.SelectedValuePath = "NumContract";

            this.idChildComboBox.ItemsSource = bl.GetAllChildren();
            this.idChildComboBox.DisplayMemberPath = "Id";
            this.idChildComboBox.SelectedValuePath = "Id";

            this.idNannyComboBox.ItemsSource = bl.GetAllNannies();
            this.idNannyComboBox.DisplayMemberPath = "Id";
            this.idNannyComboBox.SelectedValuePath = "Id";

            this.howToPayComboBox.ItemsSource = Enum.GetValues(typeof(BE.Payment));
        }


        private int GetSelectednumContract()
        {
            object result = this.numContract_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select contract First");
            return (int)result;
        }

        //private void numContract_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
        //    {
        //        contract = bl.FindConAcordNum(GetSelectednumContract());
        //        this.IdChild_textBox.Text = "" + contract.IdChild;
        //        this.IdNan_textBox.Text = "" + contract.IdNanny;
        //    }
        //}

        private void numContract_comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                contract = bl.FindConAcordNum(GetSelectednumContract());
                grid1.DataContext = contract;

            }
        }

        private void MainMenu_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window Contract_Window = new Contract();
            Contract_Window.Show();
            this.Close();
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            bl.updateContract(contract);
            contract = new BE.Contract();
            numContract_comboBox.Text = "";

            grid1.DataContext = contract;
            MessageBox.Show("The contract successfully updated ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

            this.InvalidateVisual();
        }
    }
}