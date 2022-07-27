//Данный модуль предназначен для изменения тестового задания, хранящегося в базе данных
//Исполнитель: Казарян Миран Размикович
//Дипломная работа 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TV_and_MS
{

    public partial class ChangeTZ : Form
    {
        SqlDataReader reader;
        string task_q;
        int tasknumber;
        double answer;

        public ChangeTZ()
        {
            InitializeComponent();
        }
        
        //при загрузке формы
        private void ChangeTZ_Load(object sender, EventArgs e)
        {
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();
            //вывод заданий
            SqlCommand cmd4 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[in_par].[Код параграфа],[TVMS].[dbo].[Task].[Вопрос] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[in_par].[Код задания] ", Autorization.myConnection);
            reader = cmd4.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Код параграфа"].ToString(), reader["Вопрос"].ToString());
            }
            reader.Close();
        }

        //при нажатии на задание
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Visible = false;
            label6.Text = "Вопрос";
            task_q = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            richTextBox1.Visible = true;
            label7.Visible = true;
            textBox1.Visible = true;
            richTextBox1.Text = task_q;
            button1.Visible = true;
            button2.Visible = true;

            SqlCommand task = new SqlCommand("SELECT [TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + task_q + "'", Autorization.myConnection);
            reader = task.ExecuteReader();
            while (reader.Read())
            {
                tasknumber = Convert.ToInt32(reader["Код задания"]);
            }
            reader.Close();

            SqlCommand ans = new SqlCommand("SELECT [TVMS].[dbo].[Answers].[Ответ] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[Answers] WHERE [TVMS].[dbo].[Task].[Код задания]='" + tasknumber + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
            reader = ans.ExecuteReader();
            while (reader.Read())
            {
                answer = Convert.ToDouble(reader["Ответ"]);
            }
            reader.Close();
            textBox1.Text = answer.ToString();
            textBox1.Text = textBox1.Text.Replace(',', '.');
        }
        
        //изменить тестовое задание
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //float ans1 =(float)Convert.ToDouble(textBox1.Text);
               // double ans = Convert.ToDouble(textBox1.Text);
                //запрос изменяющий тестовое задание
                SqlCommand change_task = new SqlCommand("UPDATE [TVMS].[dbo].[Task] SET [TVMS].[dbo].[Task].[Вопрос] = '" + richTextBox1.Text + "' WHERE [TVMS].[dbo].[Task].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                change_task.ExecuteNonQuery();
                SqlCommand change_ans = new SqlCommand("UPDATE [TVMS].[dbo].[Answers] SET [TVMS].[dbo].[Answers].[Ответ] = '" + textBox1.Text + "' WHERE [TVMS].[dbo].[Answers].[Код задания]='" + tasknumber + "' AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);//"' 
                change_ans.ExecuteNonQuery();
                MessageBox.Show("Тестовое задание успешно изменено", "Изменение задания", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.PerformClick();
            }
            catch
            {

            }
        }
        
        //вернуться к списку тестовых заданий
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            richTextBox1.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            label6.Text = "Вопросы, которые находятся в базе:";
            //вывод заданий
            SqlCommand cmd4 = new SqlCommand("SELECT DISTINCT [Код задания],[Вопрос] FROM [TVMS].[dbo].[Task]", Autorization.myConnection);
            reader = cmd4.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Код задания"].ToString(), reader["Вопрос"].ToString());
            }
            reader.Close();
        }

        //возврат к авторизации
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //возврат к основному меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        //открываем вкладу о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
       
        //открываем вкладу справочной документации
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если это не цифра.
            if (!Char.IsDigit(e.KeyChar))
            {
                // Запрет на ввод более одной десятичной точки.
                if ((e.KeyChar != '.' || textBox1.Text.IndexOf(".") != -1) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }
    }
}
