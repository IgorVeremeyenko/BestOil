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
                comboBox1.Items.Add(item.ToString());
            }
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox9.Enabled = false;

            values = new Dictionary<string, int>();
            values.Add("Хот дог", 4);
            values.Add("Гамбургер", 5);
            values.Add("Картошка фри", 7);
            values.Add("Кока кола", 4);
            textBox3.Text = values["Хот дог"].ToString();
            textBox6.Text = values["Гамбургер"].ToString();
            textBox8.Text = values["Картошка фри"].ToString();
            textBox10.Text = values["Кока кола"].ToString();           

        }       

        private int Sum(int price, int value)
        {
            return price * value;
        }

        private int Liters(int price, int value)
        {
            return value / price;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case 0: 
                    textBox11.Text = 27.ToString();
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        int val = int.Parse(textBox1.Text);
                        label7.Text = Sum(27, val).ToString();
                    }
                    if (radioButton2.Checked && textBox2.Text != "")
                    {
                        int val = int.Parse(textBox2.Text);
                        label7.Text = Liters(27, val).ToString();
                    }
                    break;
                case 1:
                    textBox11.Text = 25.ToString();
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        int val = int.Parse(textBox1.Text);
                        label7.Text = Sum(25, val).ToString();
                    }
                    if (radioButton2.Checked && textBox2.Text != "")
                    {
                        int val = int.Parse(textBox2.Text);
                        label7.Text = Liters(25, val).ToString();
                    }
                    break;
                case 2:
                    textBox11.Text = 22.ToString();
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        int val = int.Parse(textBox1.Text);
                        label7.Text = Sum(22, val).ToString();
                    }
                    if (radioButton2.Checked && textBox2.Text != "")
                    {
                        int val = int.Parse(textBox2.Text);
                        label7.Text = Liters(22, val).ToString();
                    }
                    break;
                case 3:
                    textBox11.Text = 15.ToString();
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        int val = int.Parse(textBox1.Text);
                        label7.Text = Sum(15, val).ToString();
                    }
                    if (radioButton2.Checked && textBox2.Text != "")
                    {
                        int val = int.Parse(textBox2.Text);
                        label7.Text = Liters(15, val).ToString();
                    }
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "К оплате";
            label8.Text = "грн";
            textBox2.Enabled = false;
            if(!radioButton1.Checked)
                textBox2.Enabled = true;
            if (textBox1.Text != "")
            {
                int liters = int.Parse(textBox1.Text);
                int price = int.Parse(textBox11.Text);
                summaryFuel = liters * price;
                label7.Text = summaryFuel.ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Text = "К выдаче";
            label8.Text = "Л";
            textBox1.Enabled = false;
            if (!radioButton2.Checked)
                textBox1.Enabled = true;
            if(textBox2.Text != "")
            {
                int sum = int.Parse(textBox2.Text);
                int price = int.Parse(textBox11.Text);
                summaryFuel = sum / price;
                label7.Text = summaryFuel.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            radioButton1.Checked = true;
            textBox2.Enabled = false;
            if (textBox1.Text == "")
            {
                textBox2.Enabled = true;
                radioButton2.Enabled = true;
                label7.Text = "0";
                return;
            }
            int liters = int.Parse(textBox1.Text);
            int price = int.Parse(textBox11.Text);
            summaryFuel = liters * price;
            label7.Text = summaryFuel.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            radioButton2.Checked = true;
            textBox1.Enabled = false;
            if (textBox2.Text == "")
            {
                textBox1.Enabled = true;
                radioButton1.Enabled = true;
                label7.Text = "0";
                return;
            }
            int sum = int.Parse(textBox2.Text);
            int price = int.Parse(textBox11.Text);
            summaryFuel = sum / price;
            label7.Text = summaryFuel.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Enabled = true;
                sumHotDogs = Sum(int.Parse(textBox3.Text), countHotDogs);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
            else
            {
                textBox4.Enabled = false;
                sumHotDogs = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text == "")
            {
                countHotDogs = 0;
                sumHotDogs = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
                return;
            }
            countHotDogs = int.Parse(textBox4.Text);            
            sumHotDogs = Sum(int.Parse(textBox3.Text), countHotDogs);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            label10.Text = summary.ToString();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                countGamburger = 0;
                sumGamburger = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
                return;
            }
            countGamburger = int.Parse(textBox5.Text);
            sumGamburger = Sum(int.Parse(textBox6.Text), countGamburger);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            label10.Text = summary.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox5.Enabled = true;
                sumGamburger = Sum(int.Parse(textBox6.Text), countGamburger);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
            else
            {
                textBox5.Enabled = false;
                sumGamburger = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox7.Enabled = true;
                sumPotatos = Sum(int.Parse(textBox8.Text), countPotatos);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
            else
            {
                textBox7.Enabled = false;
                sumPotatos = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                countPotatos = 0;
                sumPotatos = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
                return;
            }
            countPotatos = int.Parse(textBox7.Text);
            sumPotatos = Sum(int.Parse(textBox8.Text), countPotatos);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            label10.Text = summary.ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox9.Enabled = true;
                sumCola = Sum(int.Parse(textBox10.Text), countCola);
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
            else
            {
                textBox9.Enabled = false;
                sumCola = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                countCola = 0;
                sumCola = 0;
                summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
                label10.Text = summary.ToString();
                return;
            }
            countCola = int.Parse(textBox9.Text);
            sumCola = Sum(int.Parse(textBox10.Text), countCola);
            summary = sumHotDogs + sumGamburger + sumCola + sumPotatos;
            label10.Text = summary.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (radioButton2.Checked && textBox2.Text != "")
            {
                int sumFuel = int.Parse(textBox2.Text);
                total = sumFuel + summary;
                label12.Text = total.ToString();
                if (proceed == 0)
                    proceed = total;
                else
                    proceed += total;
            }
            else
            {
                total = summaryFuel + summary;
                label12.Text = total.ToString();
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
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox9.Clear();

            label12.Text = "0";
            comboBox1.SelectedIndex = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выручка за день составляет: " + proceed + " грн.");
        }

        private void timer1_Tick(object sender, EventArgs e)
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
