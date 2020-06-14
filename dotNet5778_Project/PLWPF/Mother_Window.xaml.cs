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
    /// Interaction logic for Mother.xaml
    /// </summary>
    public partial class Mother : Window
    {
        public Mother()
        {
            InitializeComponent();
        }

        private void AddMother_button_Click(object sender, RoutedEventArgs e)
        {
            Window AddMother_Window = new AddMother_Window();
            AddMother_Window.Show();
            this.Close();
        }

        private void Return_button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Menu_button_Click(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void DeleteMother_button_Click(object sender, RoutedEventArgs e)
        {
            Window Delete = new DeleteMother_Window();
            Delete.Show();
            this.Close();
        }

        private void UpDateMother_button_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateMother = new UpdateMother_Window();
            UpdateMother.Show();
            this.Close();
        }

        private void AnotherFunction_button_Click(object sender, RoutedEventArgs e)
        {
            Window AnotherFunMom = new AnotherFunMom_Window();
            AnotherFunMom.Show();
            this.Close();
        }
    }
}
