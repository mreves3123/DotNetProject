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
    /// Interaction logic for DeleteChild_Window.xaml
    /// </summary>
    public partial class DeleteChild_Window : Window
    {
        BE.Child child;
        BL.IBL bl;
        public DeleteChild_Window()
        {

            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;
            bl = BL.FactoryBL.GetBL();
            this.Id_comboBox.ItemsSource = bl.GetAllChildren();
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
            Window ChildWindow = new Child();
            ChildWindow.Show();
            this.Close();
        }
        private string GetSelectedChildName()
        {
            object result = this.Id_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select Child First");
            return (string)result;
        }
        private void Id_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.Name_textBox.Text = GetSelectedChildName();
            //this.refreshDataGrid(GetSelectedChildName());
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myId = Id_comboBox.Text;

                if (myId == null || myId == "" )
                    throw new Exception("You need choose id!");
                BE.Child myChild = bl.FindChilAcordId(int.Parse(myId));
                var result = MessageBox.Show("Are you sure you want to delete this child?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bl.delChild(myChild);
                }
                Id_comboBox.Text = "";
                Name_textBox.Text = "";
                MessageBox.Show("The child successfully removed ", "Informaion", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Id_comboBox.BeginInit();
                this.Id_comboBox.ItemsSource = bl.GetAllChildren();
                this.Id_comboBox.DisplayMemberPath = "Id";
                this.Id_comboBox.SelectedValuePath = "Name";
                this.Id_comboBox.EndInit();

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
