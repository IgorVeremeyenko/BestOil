using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        private enum Fuel { A95 = 1, A92, DT, GAS };
        
        private Dictionary<string, int> values;

        private int countHotDogs;
        private int countGamburger;
        private int countPotatos;
        private int countCola;

        private int sumHotDogs;
        private int sumGamburger;
        private int sumPotatos;
        private int sumCola;
        private int summary;
        private int summaryFuel;

        private int proceed;
        private int timerCount = 0;

        
        public Form1()
        {
            InitializeComponent();

            FormClosing += new FormClosingEventHandler(this.Form1_Closing);
            foreach (var item in Enum.GetValues(typeof(Fuel)))
            {
                fuelTypeComboBox.Items.Add(item.ToString());
            }
            fuelTypeComboBox.SelectedIndex = 0;
            countRadioButton.Checked = true;
            countDogTextBox.Enabled = false;
            countGamburgTextBox.Enabled = false;
            countPotatoTextBox.Enabled = false;
            countColaTextBox.Enabled = false;

            values = new Dictionary<string, int>();
            values.Add("Хот дог", 4);
            values.Add("Гамбургер", 5);
            values.Add("Картошка фри", 7);
            values.Add("Кока кола", 4);
            priceOfDogTextBox.Text = values["Хот дог"].ToString();
            priceOfGamburgTextBox.Text = values["Гамбургер"].ToString();
            priceOfPotatoTextBox.Text = values["Картошка фри"].ToString();
            priceOfColaTextBox.Text = values["Кока кола"].ToString();           

        }       

        private int Sum(int price, int value)
        {
            return price * value;
        }

        private int Liters(int price, int value)
        {
            return value / price;
        }

        private void FuelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = fuelTypeComboBox.SelectedIndex;
            switch (choice)
            {
                case 0: 
                    priceOfFuelTextBox.Text = 27.ToString();
                    if (countRadioButton.Checked && countLitresTextBox.Text != "")
                    {
                        int val = int.Parse(countLitresTextBox.Text);
                        totalPayFuelLabel.Text = Sum(27, val).ToString();
                    }
                    if (sumRadioButton.Checked && sumOfFuelTextBox.Text != "")
                    {
                        int val = int.Parse(sumOfFuelTextBox.Text);
                        totalPayFuelLabel.Text = Liters(27, val).ToString();
                    }
                    break;
                case 1:
                    priceOfFuelTextBox.Text = 25.ToString();
                    if (countRadioButton.Checked && countLitresTextBox.Text != "")
                    {
                        int val = int.Parse(countLitresTextBox.Text);
                        totalPayFuelLabel.Text = Sum(25, val).ToString();
                    }
                    if (sumRadioButton.Checked && sumOfFuelTextBox.Text != "")
                    {
                        int val = int.Parse(sumOfFuelTextBox.Text);
                        totalPayFuelLabel.Text = Liters(25, val).ToString();
                    }
                    break;
                case 2:
                    priceOfFuelTextBox.Text = 22.ToString();
                    if (countRadioButton.Checked && countLitresTextBox.Text != "")
                    {
                        int val = int.Parse(countLitresTextBox.Text);
                        totalPayFuelLabel.Text = Sum(22, val).ToString();
                    }
                    if (sumRadioButton.Checked && sumOfFuelTextBox.Text != "")
                    {
                        int val = int.Parse(sumOfFuelTextBox.Text);
                        totalPayFuelLabel.Text = Liters(22, val).ToString();
                    }
                    break;
                case 3:
                    priceOfFuelTextBox.Text = 15.ToString();
                    if (countRadioButton.Checked && countLitresTextBox.Text != "")
                    {
                        int val = int.Parse(countLitresTextBox.Text);
                        totalPayFuelLabel.Text = Sum(15, val).ToString();
                    }
                    if (sumRadioButton.Checked && sumOfFuelTextBox.Text != "")
                    {
                        int val = int.Parse(sumOfFuelTextBox.Text);
                        totalPayFuelLabel.Text = Liters(15, val).ToString();
                    }
                    break;
            }
        }

        private void CountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            totalPayFuelGroupBox.Text = "К оплате";
            currencyTotalFuelLabel.Text = "грн";
            sumOfFuelTextBox.Enabled = false;
            if(!countRadioButton.Checked)
                sumOfFuelTextBox.Enabled = true;
            if (countLitresTextBox.Text != "")
            {
                int liters = int.Parse(countLitresTextBox.Text);
                int price = int.Parse(priceOfFuelTextBox.Text);
                summaryFuel = liters * price;
                totalPayFuelLabel.Text = summaryFuel.ToString();
            }
        }

        private void SumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            totalPayFuelGroupBox.Text = "К выдаче";
            currencyTotalFuelLabel.Text = "Л";
            countLitresTextBox.Enabled = false;
            if (!sumRadioButton.Checked)
                countLitresTextBox.Enabled = true;
            if(sumOfFuelTextBox.Text != "")
            {
                int sum = int.Parse(sumOfFuelTextBox.Text);
                int price = int.Parse(priceOfFuelTextBox.Text);
                summaryFuel = sum / price;
                totalPayFuelLabel.Text = summaryFuel.ToString();
            }
        }

        private void CountLitresTextBox_TextChanged(object sender, EventArgs e)
        {
            sumOfFuelTextBox.Enabled = false;
            countRadioButton.Checked = true;
            sumOfFuelTextBox.Enabled = false;
            if (countLitresTextBox.Text == "")
            {
                sumOfFuelTextBox.Enabled = true;
                sumRadioButton.Enabled = true;
                totalPayFuelLabel.Text = "0";
                return;
            }
            int liters = int.Parse(countLitresTextBox.Text);
            int price = int.Parse(priceOfFuelTextBox.Text);
            summaryFuel = liters * price;
            totalPayFuelLabel.Text = summaryFuel.ToString();
        }

        private void SumOfFuelTextBox_TextChanged(object sender, EventArgs e)
        {

            countLitresTextBox.Enabled = false;
            sumRadioButton.Checked = true;
            countLitresTextBox.Enabled = false;
            if (sumOfFuelTextBox.Text == "")
            {
                countLitresTextBox.Enabled = true;
                countRadioButton.Enabled = true;
                totalPayFuelLabel.Text = "0";
                return;
            }
            int sum = int.Parse(sumOfFuelTextBox.Text);
            int price = int.Parse(priceOfFuelTextBox.Text);
            summaryFuel = sum / price;
            totalPayFuelLabel.Text = summaryFuel.ToString();
        }

        private void HotDogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hotDogCheckBox.Checked)
            {
                countDogTextBox.Enabled = true;
                sumHotDogs = Sum(int.Parse(priceOfDogTextBox.Text), countHotDogs);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
            else
            {
                countDogTextBox.Enabled = false;
                sumHotDogs = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
           
        }

        private void CountDogTextBox_TextChanged(object sender, EventArgs e)
        {
            if(countDogTextBox.Text == "")
            {
                countHotDogs = 0;
                sumHotDogs = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
                return;
            }
            countHotDogs = int.Parse(countDogTextBox.Text);            
            sumHotDogs = Sum(int.Parse(priceOfDogTextBox.Text), countHotDogs);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            totalPayProductsLabel.Text = summary.ToString();

        }

        private void CountGamburgTextBox_TextChanged(object sender, EventArgs e)
        {
            if (countGamburgTextBox.Text == "")
            {
                countGamburger = 0;
                sumGamburger = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
                return;
            }
            countGamburger = int.Parse(countGamburgTextBox.Text);
            sumGamburger = Sum(int.Parse(priceOfGamburgTextBox.Text), countGamburger);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            totalPayProductsLabel.Text = summary.ToString();
        }

        private void GamburgerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gamburgerCheckBox.Checked)
            {
                countGamburgTextBox.Enabled = true;
                sumGamburger = Sum(int.Parse(priceOfGamburgTextBox.Text), countGamburger);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
            else
            {
                countGamburgTextBox.Enabled = false;
                sumGamburger = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
        }

        private void PotatoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (potatoCheckBox.Checked)
            {
                countPotatoTextBox.Enabled = true;
                sumPotatos = Sum(int.Parse(priceOfPotatoTextBox.Text), countPotatos);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
            else
            {
                countPotatoTextBox.Enabled = false;
                sumPotatos = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
        }

        private void CountPotatoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (countPotatoTextBox.Text == "")
            {
                countPotatos = 0;
                sumPotatos = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
                return;
            }
            countPotatos = int.Parse(countPotatoTextBox.Text);
            sumPotatos = Sum(int.Parse(priceOfPotatoTextBox.Text), countPotatos);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            totalPayProductsLabel.Text = summary.ToString();
        }

        private void ColaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (colaCheckBox.Checked)
            {
                countColaTextBox.Enabled = true;
                sumCola = Sum(int.Parse(priceOfColaTextBox.Text), countCola);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
            else
            {
                countColaTextBox.Enabled = false;
                sumCola = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
            }
        }

        private void CountColaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (countColaTextBox.Text == "")
            {
                countCola = 0;
                sumCola = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                totalPayProductsLabel.Text = summary.ToString();
                return;
            }
            countCola = int.Parse(countColaTextBox.Text);
            sumCola = Sum(int.Parse(priceOfColaTextBox.Text), countCola);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            totalPayProductsLabel.Text = summary.ToString();
        }

        private void TotalSumButton_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (sumRadioButton.Checked && sumOfFuelTextBox.Text != "")
            {
                int sumFuel = int.Parse(sumOfFuelTextBox.Text);
                total = sumFuel + summary;
                totalPayLabel.Text = total.ToString();
                if (proceed == 0)
                    proceed = total;
                else
                    proceed += total;
            }
            else
            {
                total = summaryFuel + summary;
                totalPayLabel.Text = total.ToString();
                if (proceed == 0)
                    proceed = total;
                else
                    proceed += total;
            }
            if (total == 0)
            {
                MessageBox.Show("Не проделано ни одной операции", "Сообщение");
                return;
            }
            timer1.Start();
            
        }       

        private void ResetForm()
        {
            hotDogCheckBox.Checked = false;
            gamburgerCheckBox.Checked = false;
            potatoCheckBox.Checked = false;
            colaCheckBox.Checked = false;

            countLitresTextBox.Clear();
            sumOfFuelTextBox.Clear();
            countDogTextBox.Clear();
            countGamburgTextBox.Clear();
            countPotatoTextBox.Clear();
            countColaTextBox.Clear();

            totalPayLabel.Text = "0";
            fuelTypeComboBox.SelectedIndex = 0;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timerCount = 0;
            DialogResult dialog = MessageBox.Show(
             "Вы действительно хотите выйти из программы?",
             "Завершение программы",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning
            );
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Выручка за день составляет: " + proceed + " грн.", "Выход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TotalOfDayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выручка за день составляет: " + proceed + " грн.");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timerCount += 1;
            if(timerCount == 3)
            {
                timer1.Stop();
                DialogResult dialogResult = MessageBox.Show("Перейти к следующему клиенту?", "Очистить форму",  MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) ;
                if (dialogResult == DialogResult.Yes)
                {
                    ResetForm();
                    MessageBox.Show("Выручка за день составляет: " + proceed + " грн.");
                    timer1.Stop();
                    timerCount = 0;
                }
                if(dialogResult == DialogResult.No)
                {
                    timerCount = 0;
                    timer1.Start();
                }

            }
        }

    }
}
