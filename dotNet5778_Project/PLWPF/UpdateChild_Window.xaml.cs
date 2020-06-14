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
    /// Interaction logic for UpdateChild_Window.xaml
    /// </summary>
    public partial class UpdateChild_Window : Window
    {
        BE.Child child;
        BL.IBL bl;
        public UpdateChild_Window()
        {
            InitializeComponent();
            child = new BE.Child();
            bl = BL.FactoryBL.GetBL();
            this.Id_comboBox.ItemsSource = bl.GetAllChildren();
            this.Id_comboBox.DisplayMemberPath = "Id";
           this.Id_comboBox.SelectedValuePath = "Id";
            this.DetailsChildGrid.DataContext = child;
            this.childGenderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));


        }
        private void Main_button_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window ChildWindow = new Child();
            ChildWindow.Show();
            this.Close();
        }
        private int GetSelectedChildId()
        {
            object result = this.Id_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select Child First");
            return (int)result;
        }
        private void Id_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                child = bl.FindChilAcordId(GetSelectedChildId());
                this.DetailsChildGrid.DataContext = child;

            }
            //    this.DetailsChildGrid.Text = GetSelectedChildName();
            //  this.refreshDataGrid(GetSelectedChildName());
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(this.Id_comboBox.SelectedValue== null)
                    throw new Exception("must select Child First");

                string errorMassage = "";
                if (this.nameTextBox.Text == "")
                    errorMassage += "You must enter name.\n";
                if (this.birthDatePicker.Text == "")
                    errorMassage += "You must enter a date of birthday.\n";
                if (this.motherIdTextBox.Text == "")
                    errorMassage += "You must enter identity number of mother.\n";
                if (errorMassage != "")
                    throw new Exception(errorMassage);
                bl.updateChild(child);
                MessageBox.Show("The child successfully updated ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                child = new BE.Child();
                Id_comboBox.Text = "";
            
                this.DetailsChildGrid.DataContext = child;

                this.InvalidateVisual();
            
        }
    }
}

