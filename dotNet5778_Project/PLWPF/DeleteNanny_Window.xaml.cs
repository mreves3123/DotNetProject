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
    /// Interaction logic for DeleteNanny_Window.xaml
    /// </summary>
    public partial class DeleteNanny_Window : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public DeleteNanny_Window()
        {

            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
            this.Id_comboBox.ItemsSource = bl.GetAllNannies() ;
            this.Id_comboBox.DisplayMemberPath = "Id";
            this.Id_comboBox.SelectedValuePath = "Name";
            //  this.delWin.DataContext = bl.Children();


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
        private string GetSelectedNannydName()
        {
            object result = this.Id_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select Nanny First");
            return (string)result;
        }
        private void Id_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.Name_textBox.Text = GetSelectedNannydName();
            //this.refreshDataGrid(GetSelectedChildName());
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myId = Id_comboBox.Text;

                if (myId == null || myId == "")
                    throw new Exception("You need choose id!");
                BE.Nanny myNanny = bl.FindNannyAcordId(int.Parse(myId));
                var result = MessageBox.Show("Are you sure you want to delete this nanny?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delNanny(myNanny);
                }
                Id_comboBox.Text = "";
                Name_textBox.Text = "";
                MessageBox.Show("The nanny successfully removed ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Id_comboBox.BeginInit();
                this.Id_comboBox.ItemsSource = bl.GetAllNannies();
                this.Id_comboBox.DisplayMemberPath = "Id";
                this.Id_comboBox.SelectedValuePath = "Name";
                this.Id_comboBox.EndInit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
