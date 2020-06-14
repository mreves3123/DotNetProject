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
    /// Interaction logic for AnotherFunCon_Window.xaml
    /// </summary>
    public partial class AnotherFunCon_Window : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        public AnotherFunCon_Window()
        {
            InitializeComponent();
            contract = new BE.Contract();
            bl = BL.FactoryBL.GetBL();
            this.NumContract_comboBox.ItemsSource = bl.GetAllContracts();
            this.NumContract_comboBox.DisplayMemberPath = "NumContract";
            this.NumContract_comboBox.SelectedValuePath = "NumContract";
           

        }
        private void Main_button_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window ContractWindow = new Contract();
            ContractWindow.Show();
            this.Close();
        }
        private int GetSelectedContractNum()
        {
            object result = this.NumContract_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select contract First");
            return (int)result;
        }



        

        private void listContracts_button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = bl.GetAllContracts();
        }

        private void NumContract_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                contract = bl.FindConAcordNum(GetSelectedContractNum());
                List<BE.Contract> c = new List<BE.Contract>();
                c.Add(contract);
                listBox.ItemsSource = c;
            }
        }

        private void NumExistCon_button_Click(object sender, RoutedEventArgs e)
        {
            this.numContract.Text = ""+bl.GetAllContracts().Count();
        }
    }
}
