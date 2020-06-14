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
    /// Interaction logic for AnotherFunChild_Window.xaml
    /// </summary>
    public partial class AnotherFunChild_Window : Window
    {

        BE.Child child;
        BL.IBL bl;
        public AnotherFunChild_Window()
        {
            InitializeComponent();
            child = new BE.Child();
            bl = BL.FactoryBL.GetBL();
            this.IdChild_comboBox.ItemsSource = bl.GetAllChildren();
            this.IdChild_comboBox.DisplayMemberPath = "Id";
            this.IdChild_comboBox.SelectedValuePath = "Id";

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
            object result = this.IdChild_comboBox.SelectedValue;

            if (result == null)
                throw new Exception("must select Child First");
            return (int)result;
        }



        private void IdChild_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                child = bl.FindChilAcordId(GetSelectedChildId());
                List<BE.Child> c = new List<BE.Child>();
                c.Add(child);
                listBox.ItemsSource = c;
                FriendCheckBox.IsChecked = bl.IsHaveFriend(c.FirstOrDefault());
                IsDiapercheckBox.IsChecked = c.FirstOrDefault().IsDiaper;
                if (c.FirstOrDefault().IsDiaper)
                {
                    if ("" + c.FirstOrDefault().TheLastReplaceDiaper == "00:00:00")
                        this.lastReplace_textBox.Text = "";
                    else
                        this.lastReplace_textBox.Text = "" + c.FirstOrDefault().TheLastReplaceDiaper;

                }
                else
                    lastReplace_textBox.Text = "";
            }
        }

        private void listChild_button_Click(object sender, RoutedEventArgs e)
        {
            FriendCheckBox.IsChecked = false;
            IsDiapercheckBox.IsChecked = false;
            IdChild_comboBox.Text = "";
            lastReplace_textBox.Text = "";
            listBox.ItemsSource = bl.GetAllChildren();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FriendCheckBox.IsChecked = false;
            IsDiapercheckBox.IsChecked =false;
            IdChild_comboBox.Text = "";
           lastReplace_textBox.Text = "";

            listBox.ItemsSource = bl.withoutNanny();

        }

        //private void listBox_MouseUp(object sender, MouseButtonEventArgs e)
        //{

        //}

        private void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            //if (sender.ToString() != "")
            //{
            //    MessageBox.Show("erorr!!");
            //}
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // listBox.SelectedItem;

        }

        private void updatReplace_button1_Click(object sender, RoutedEventArgs e)
        {
            child = bl.FindChilAcordId(GetSelectedChildId());
           bl. ReplaceNowDiaper(child);
                this.lastReplace_textBox.Text = "" + child.TheLastReplaceDiaper;

        }
    }
}
