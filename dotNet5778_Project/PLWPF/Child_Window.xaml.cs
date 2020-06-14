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
    /// Interaction logic for Child.xaml
    /// </summary>
    public partial class Child : Window
    {
        public Child()
        {
            InitializeComponent();
        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void DeleteChild_button_Click(object sender, RoutedEventArgs e)
        {
            Window deleteChild = new DeleteChild_Window();
            deleteChild.Show();
            this.Close();
        }

        private void UpDateChild_button_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateChild_Window = new UpdateChild_Window();
            UpdateChild_Window.Show();
            this.Close();
        }

        private void AddChild_button_Click(object sender, RoutedEventArgs e)
        {
            Window AddChildWindow = new AddChild();
            AddChildWindow.Show();
            this.Close();
        }

        private void AnotherFunction_button_Click(object sender, RoutedEventArgs e)
        {
            Window AnotherFunChild_Window = new AnotherFunChild_Window();
            AnotherFunChild_Window.Show();
            this.Close();
        }
    }
}
