//Josh DePauw
//Cash register using XAML
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

namespace JD_CashRegister
{
          
    public partial class MainWindow : Window
    {
        List<decimal> nums = new List<decimal>();
        private decimal subtotal = 0m;
        private decimal taxRate = .07m;
        private decimal total;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //event handler for numbers and decimal
        private void btn_Click(object sender, RoutedEventArgs e)
        {           
           Button btn = (Button)sender;
           amountTextBox.Text = amountTextBox.Text + btn.Content;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nums.Add(decimal.Parse(amountTextBox.Text));//adds to the nums list

               amountTextBox.Clear();//clears what is in the textbox
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a number:");

            }
        }
       
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (amountTextBox.Text == null)
            {
                amountTextBox.Clear();//clears the textBox   
            }
            else
            {
                MessageBox.Show("There is nothing in the textbox to delete!");
            }
        }

        private void btnTotal_Click(object sender, RoutedEventArgs e)
        {
            subtotal = nums.Sum(); //adds all numbers in the list and 
            txtSubtotal.Text = subtotal.ToString("F");//displays the subtotal in the subtotal textbox
            decimal tax = Convert.ToDecimal(subtotal * taxRate);//gets the amount of tax
            txtTax.Text = tax.ToString("F");//diplays the amount of tax
            total = Convert.ToDecimal(subtotal + tax);//gets the total
            txtTotal.Text = total.ToString("F");//displays the total
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //clear the textboxes
            amountTextBox.Clear();
            txtSubtotal.Clear();
            txtTax.Clear();
            txtTotal.Clear();            

            nums = new List<Decimal>();//clears the list
            subtotal = 0; //resets subtotal
            total = 0; // resets total
        }
    }
}
