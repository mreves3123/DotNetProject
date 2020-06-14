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
    /// Interaction logic for AddChild.xaml
    /// </summary>
    public partial class AddChild : Window
    {
        BE.Child child;
        BL.IBL bl;
        public AddChild()
        {
            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;

            bl = BL.FactoryBL.GetBL();
            
            this.childGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
       
            try
            {
                string errorMassage = "";
                if ( this.nameTextBox.Text == "")
                    errorMassage += "You must enter name.\n";
                if(this.idTextBox.Text=="0")
                    errorMassage += "You must enter identity number.\n";
                if (this.birthDatePicker.Text =="01/01/0001")
                    errorMassage += "You must enter a date of birthday.\n";
                if (this.motherIdTextBox.Text == "0")
                    errorMassage += "You must enter identity number of mother.\n";
                if (errorMassage!="")
                    throw new Exception(errorMassage);
                bl.addChild(child);
                child = new BE.Child();
                this.DataContext = child;
                MessageBox.Show("The child successfully added ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "missing!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window ChildWindow = new Child();
            ChildWindow.Show();
            this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Return_button_MouseEnter(object sender, MouseEventArgs e)
        {
            //Return_button.FontSize = 30;
        }
    }
}
