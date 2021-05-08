using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalulator
{
    public partial class Form1 : Form
    {
        Double displayResult = 0;
        String performedOperation = "";
        bool isperformedOperation = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if(txtResult.Text=="0" || (isperformedOperation))
            {
                txtResult.Clear();
            }

            
            isperformedOperation = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text = txtResult.Text + button.Text;
                }
                
            }
            else
                txtResult.Text = txtResult.Text + button.Text;

           

        }

        private void Operation(string performedOperation)
        {
            switch (performedOperation)
            {
                case "+":
                    txtResult.Text = (displayResult + Double.Parse(txtResult.Text)).ToString();

                    break;

                case "-":
                    txtResult.Text = (displayResult - Double.Parse(txtResult.Text)).ToString();
                    break;

                case "*":
                    txtResult.Text = (displayResult * Double.Parse(txtResult.Text)).ToString();
                    break;

                case "/":
                    txtResult.Text = (displayResult / Double.Parse(txtResult.Text)).ToString();
                    break;

                case "mod":
                    txtResult.Text = (displayResult % Double.Parse(txtResult.Text)).ToString();
                    break;


            }
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button operation = (Button)sender;

            Operation(performedOperation);

            performedOperation = operation.Text;
            displayResult = Double.Parse(txtResult.Text);

            lblCurrentOperation.Text = displayResult + " " + performedOperation ;
            
            isperformedOperation = true;
              

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            displayResult = 0;
            lblCurrentOperation.Text = "";
            
            txtResult.Text = "0";
            
        }

        
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Operation(performedOperation);

            lblCurrentOperation.Text = "";            
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            if(txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }
    }
}
