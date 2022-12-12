using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranspositionCipher
{
    public partial class Form1 : Form
    {
  

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (simpleRadio.Checked)
            {

                SimpleSubstitution t = new SimpleSubstitution();
                t.SetKey(keyTextBox.Text);

                if (encryptRadioButton.Checked)
                    outputTextBox.Text = t.Encrypt(inputTextBox.Text);
                else
                    outputTextBox.Text = t.Decrypt(inputTextBox.Text);
            }
            else if(polyalphabeticRadio.Checked) 
            {
                PolyalphabeticSubstitution t = new PolyalphabeticSubstitution();
                t.SetKey(keyTextBox.Text);

                if (encryptRadioButton.Checked)
                    outputTextBox.Text = t.Encrypt(inputTextBox.Text);
                else
                    outputTextBox.Text = t.Decrypt(inputTextBox.Text);
            }
            else if(permutationRadio.Checked)
            {
                Permutation t = new Permutation();
                t.SetKey(keyTextBox.Text);

                if (encryptRadioButton.Checked)
                    outputTextBox.Text = t.Encrypt(inputTextBox.Text);
                else
                    outputTextBox.Text = t.Decrypt(inputTextBox.Text);
            }
            else if(gammaRadio.Checked)
            {
                Gamming t = new Gamming();
                t.SetKey(keyTextBox.Text);

                if (encryptRadioButton.Checked)
                    outputTextBox.Text = t.Encrypt(inputTextBox.Text);
                else
                    outputTextBox.Text = t.Decrypt(inputTextBox.Text);
            }

        }


    }
}