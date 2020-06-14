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
    /// Interaction logic for Nanny.xaml
    /// </summary>
    public partial class Nanny : Window
    {
        public Nanny()
        {
            InitializeComponent();
        }

        private void AddNanny_button_Click(object sender, RoutedEventArgs e)
        {
            Window AddNanny_Window = new AddNanny_Window();
            AddNanny_Window.Show();
            this.Close();
        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Menu_button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void DeleteNanny_button_Click(object sender, RoutedEventArgs e)
        {

            Window DeleteNanny_Window = new DeleteNanny_Window();
            DeleteNanny_Window.Show();
            this.Close();
        }

        private void UpDateNanny_button_Click(object sender, RoutedEventArgs e)
        {

            Window UpdateNanny_Window = new UpdateNanny_Window();
            UpdateNanny_Window.Show();
            this.Close();

        }

        private void AnotherFunction_button_Click(object sender, RoutedEventArgs e)
        {
            Window AnotherFunNan_Window = new AnotherFunNan_Window();
            AnotherFunNan_Window.Show();
            this.Close();
        }
    }
}
