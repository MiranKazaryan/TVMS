//Данный модуль предназначен для удаления тестовых заданий из базы данных
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

    public partial class DelTZ : Form
    {
        SqlDataReader reader;
        string task_q;
        int tasknumber;
        double answer;
        public DelTZ()
        {
            InitializeComponent();
        }

        //при загрузке формы
        private void DelTZ_Load(object sender, EventArgs e)
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

        //при выборе тестового задания из предложенных
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

            SqlCommand ans = new SqlCommand("SELECT [TVMS].[dbo].[Answers].[Ответ] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[Answers] WHERE [TVMS].[dbo].[Task].[Код задания]='" + tasknumber + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='"+1+"'", Autorization.myConnection);
            reader = ans.ExecuteReader();
            while (reader.Read())
            {
                answer = Convert.ToDouble(reader["Ответ"]);
            }
            reader.Close();
            textBox1.Text = answer.ToString();
        }
        
        //удаляем тестовое задание из базы
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //запрос удаляющий тестовое задание
                SqlCommand del_task = new SqlCommand("DELETE FROM [TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_inpar = new SqlCommand("DELETE FROM [TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[in_par].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_ans = new SqlCommand("DELETE FROM [TVMS].[dbo].[Answers] WHERE [TVMS].[dbo].[Answers].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_dec = new SqlCommand("DELETE FROM [TVMS].[dbo].[Desicions] WHERE [TVMS].[dbo].[Desicions].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                del_inpar.ExecuteNonQuery();
                del_ans.ExecuteNonQuery();
                del_dec.ExecuteNonQuery();
                del_task.ExecuteNonQuery();
                MessageBox.Show("Тестовое задание успешно удалено", "Удаление задания", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.PerformClick();
            }
            catch
            {

            }
        }
        
        //возврат к тестовым заданиям в базе данных
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            richTextBox1.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox1.ReadOnly = true;
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

        //выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //выход к основному меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        //открываем вкладку "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        
        //Открываем Справку
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}
