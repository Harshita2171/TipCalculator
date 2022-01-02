using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipCalculator
{
  
    public partial class TipCal : Form
    {
        public TipCal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        private void button7_Click(object sender, EventArgs e) // To increment number of people.
        {
            int a2 = Convert.ToInt32(textBox3.Text);
            a2 += 1;
            textBox3.Text = Convert.ToString(a2);
            
        }

        private void button6_Click(object sender, EventArgs e) // To increment tip percentage.
        {
            int a1 = Convert.ToInt32(textBox2.Text);
            if (a1 < 100)
            {
                a1 += 1;
                textBox2.Text = Convert.ToString(a1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)   // To decrement tip percentage. 
        {
            int a1 = Convert.ToInt32(textBox2.Text);
            if (a1 > 0)
            {
                a1 -= 1;
                textBox2.Text = Convert.ToString(a1);
            }
        }

        private void no_of_peopleMinus(object sender, EventArgs e) // To decrement number of people.
        {
            int a2 = Convert.ToInt32(textBox3.Text);
            if (a2 > 1)
            {
                a2 -= 1;
                textBox3.Text = Convert.ToString(a2);
            }
        }

        private void button5_Click(object sender, EventArgs e)  // To calculate. 
        {
            try                             // Try block.
            {
                double Bill = Convert.ToDouble(textBox1.Text);
                double TipPercent = Convert.ToDouble(textBox2.Text);
                double NoOfPeople = Convert.ToDouble(textBox3.Text);
                Validate(Bill,TipPercent,NoOfPeople);                                // Call validate function to validate all inputs.
                double TotalTip = Bill * (TipPercent / 100);                         // Calculate total tip.
                double TipPerPerson = TotalTip / NoOfPeople;                         // Calculate tip per person.
                double TotalBill = TipPerPerson + (Bill / NoOfPeople);               // Calculate total per person.
                textBox4.Text = "$"+String.Format("{0:F2}",TipPerPerson);            // Print tip per person.
                textBox5.Text = "$"+String.Format("{0:F2}",TotalBill);               // Print total per person.
                label6.Text = "";
            }
            catch(FormatException f)    // catch block for only take numeric values.
            {
                label6.Text = "Only Numeric values are excepted";
            }
            catch (TipException f)           // catch block for only take 0 to 100 values in tip %.
            {
                label6.Text = "Only 0 to 100 values are excepted in Tip %";
            }
            catch (MyException f)           //catch block for only take positive values.
            {
                label6.Text = "Only positive numbers are excepted";
            }

        }
        private static void Validate(double BillValue,double TipValue,double PeopleValue )    // Validate function. 
        {
            if ( (BillValue < 0) || (TipValue < 0) || (PeopleValue < 0)  )                    // To validate positive numbers.
                throw new MyException("Sorry,Bill must be in positive numbers");
            if ( (TipValue < 0) || (TipValue > 100) )                                         // To validate tip value 0 to 100.
                throw new TipException("sorry");
        }
    }
    public class MyException : Exception        // MyExceptin class for custom exception.
    {
        public MyException(String message)
       : base(message)
        {

        }
    }
    public class TipException : MyException         // TipException class for custom exception
    {
        public TipException(String message)
       : base(message)
        {

        }
    }
}
