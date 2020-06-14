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
    /// Interaction logic for DeleteContract_Window.xaml
    /// </summary>
    public partial class DeleteContract_Window : Window
    {

        BE.Contract contract;
        BL.IBL bl;
        public DeleteContract_Window()
        {
            InitializeComponent();
            contract = new BE.Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
            this.numContract_comboBox.ItemsSource = bl.GetAllContracts();
            this.numContract_comboBox.DisplayMemberPath = "NumContract";
            this.numContract_comboBox.SelectedValuePath = "NumContract";
        }

        private int GetSelectednumContract()
        {
            object result = this.numContract_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select contract First");
            return (int)result;
        }
        //private void Id_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
        //    {
        //        child = bl.FindChilAcordId(GetSelectedChildId());
        //        this.DetailsChildGrid.DataContext = child;

        //    }
        //    //    this.DetailsChildGrid.Text = GetSelectedChildName();
        //    //  this.refreshDataGrid(GetSelectedChildName());
        //}

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
        // הוספתי פונקציה בBL
        private void numContract_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                contract = bl.FindConAcordNum(GetSelectednumContract());
                this.IdChild_textBox.Text = "" + contract.IdChild;
                this.IdNan_textBox.Text = "" + contract.IdNanny;
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConNum = numContract_comboBox.Text;

                if (myConNum == null || myConNum == "")
                    throw new Exception("You need choose id!");
                BE.Contract myContract = bl.FindConAcordNum(int.Parse(myConNum));
                var result = MessageBox.Show("Are you sure you want to delete this child?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delContract(myContract);
                }
                numContract_comboBox.Text = "";
                IdNan_textBox.Text = "";
                IdChild_textBox.Text = "";

                this.numContract_comboBox.BeginInit();
                this.numContract_comboBox.ItemsSource = bl.GetAllContracts();
                this.numContract_comboBox.DisplayMemberPath = "NumContract";
                this.numContract_comboBox.SelectedValuePath = "NumContract";
                this.numContract_comboBox.EndInit();

                MessageBox.Show("The contract successfully removed ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

                // this.Id_comboBox.cl

                //Window DeleteChild_Window = new DeleteChild_Window();
                //DeleteChild_Window.Show();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
