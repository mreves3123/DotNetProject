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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        
        

        private void Child_button_Click(object sender, RoutedEventArgs e)
        {

            Window ChildWindow = new Child();
            ChildWindow.Show();
            this.Close();
        }

        private void Nanny_button_Click(object sender, RoutedEventArgs e)
        {
            Window NannyWindow = new Nanny();
            NannyWindow.Show();
            this.Close();
        }

        private void Contract_button_Click(object sender, RoutedEventArgs e)
        {

            Window ContractWindow = new Contract();
            ContractWindow.Show();
            this.Close();
        }

        private void Mother_button_Click(object sender, RoutedEventArgs e)
        {

            Window MotherWindow = new Mother();
            MotherWindow.Show();
            this.Close();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nanny_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Nanny_button.FontSize += 5;
        }

        private void Nanny_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Nanny_button.FontSize -= 5;
        }

        private void Child_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Child_button.FontSize += 5;
        }

        private void Child_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Child_button.FontSize -= 5;
        }

        private void Contract_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Contract_button.FontSize += 5;
        }

        private void Contract_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Contract_button.FontSize -= 5;
        }

        private void Mother_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Mother_button.FontSize += 5;
        }

        private void Mother_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Mother_button.FontSize -= 5;
        }

        private void Exit_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Exit_button.FontSize += 5;
        }

        private void Exit_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Exit_button.FontSize -= 5;
        }






        //private void addStudentButton_Click(object sender, RoutedEventArgs e)
        //{ Window addStudentWindow = new NannyWindow(); addStudentWindow.Show(); }
        //private void addCourseButton_Click(object sender, RoutedEventArgs e)
        //{ new ChildWindow().Show(); }
        //private void addCourseTOstudentButton_Click(object sender, RoutedEventArgs e)
        //{ new MotherWindow().ShowDialog(); }
        //private void addCourseTOstudentButton_Click(object sender, RoutedEventArgs e)
        //{ new ContractWindow().ShowDialog(); }
    }
}
