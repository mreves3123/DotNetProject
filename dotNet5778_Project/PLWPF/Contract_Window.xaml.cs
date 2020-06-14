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
    /// Interaction logic for Contract.xaml
    /// </summary>
    public partial class Contract : Window
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        private void Main_button_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void AddContract_button_Click(object sender, RoutedEventArgs e)
        {
            Window AddContract_Window = new AddContract_Window();
            AddContract_Window.Show();
            this.Close();

        }

        private void DeleteContract_button_Click(object sender, RoutedEventArgs e)
        {
            Window DeleteContract_Window = new DeleteContract_Window();
            DeleteContract_Window.Show();
            this.Close();
        }

        private void UpDateContract_button_Click(object sender, RoutedEventArgs e)
        {

            Window UpdateContract_Window = new UpdateContract_Window();
            UpdateContract_Window.Show();
            this.Close();
        }

        private void AnotherFunction_button_Click(object sender, RoutedEventArgs e)
        {
            Window AnotherFunCon_Window = new AnotherFunCon_Window();
            AnotherFunCon_Window.Show();
            this.Close();
            
        }
    }
}
