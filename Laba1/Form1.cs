using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            int enteredNumber = getNumberFromInput();
            if (enteredNumber == 0)
            {
                return;
            }
            resultLabel.Text = createAnswerString(getMinimalDigits(enteredNumber));
        }

        private (int, int) getMinimalDigits(int number)
        {
            int a = number / 100;
            int b = number / 10 % 10;
            int c = number % 10;
            if (a > b)
            {
                if (a > c)
                {
                    return (b, c);
                } else
                {
                    return (a, b);
                }
            } else
            {
                if (b > c)
                {
                    return (a, c);
                } else
                {
                    return (a, b);
                }
            }
        }

        private string createAnswerString((int, int) minimalNumbers)
        {
            string answer = "Сумма двух наименьших цифр:\n";
            answer += minimalNumbers.Item1.ToString() + " + " + minimalNumbers.Item2.ToString() + " = ";
            answer += (minimalNumbers.Item1 + minimalNumbers.Item2).ToString();
            return answer;
        }

        private int getNumberFromInput()
        {
            if (this.numberTextBox.TextLength > 3)
            {
                this.invitationLabel.Text = "Слишком длинно! Ожидалось 3 цифры!";
                this.invitationLabel.ForeColor = Color.Red;
                return 0;
            }
            if (this.numberTextBox.TextLength < 3)
            {
                this.invitationLabel.Text = "Слишком коротко! Ожидалось 3 цифры!";
                this.invitationLabel.ForeColor = Color.Red;
                return 0;
            }

            uint enteredNumber;
            if (!uint.TryParse(this.numberTextBox.Text, out enteredNumber))
            {
                this.invitationLabel.Text = "Только цифры!";
                this.invitationLabel.ForeColor = Color.Red;
                return 0;
            }

            if (enteredNumber < 100)
            {
                this.invitationLabel.Text = "Слишком коротко! Нужно 3 ЗНАЧАЩИХ цифры!";
                this.invitationLabel.ForeColor = Color.Red;
                return 0;
            }

            this.invitationLabel.Text = "Введите число";
            this.invitationLabel.ForeColor = Color.Black;
            return (int)enteredNumber;
        }
    }
}
