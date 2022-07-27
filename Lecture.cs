//Данный модуль предназначен для вывода теоретического материала
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

    public partial class Lecture : Form
    {
        SqlDataReader reader;
        int n = 1;//индекс выбранной лекции
        int i = 0;
        int[] h = new int[50];

        public Lecture()
        {
            InitializeComponent();
        }
        //узнаем выбранную лекцию
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //номер выбранной лекции
            n = listBox1.SelectedIndex;

        }
       
        //открываем содержаниее
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBox1.Visible = true;
            webB.Visible = false;
        }
       
        //загрузка лекции
        public void LoadLecture(int l)
        {

            //загрузка данных в WebBrowser
            string fileName = AppDomain.CurrentDomain.BaseDirectory + l.ToString() + ".mht";
            try
            {
                webB.Navigate(fileName);
            }
            catch
            {
                webB.DocumentText = "<font style = \"font-weight: normal; font-size: 14pt; color: red; font-style: normal; font-family: 'Times New Roman'; font-variant: normal; text-decoration: none\">" +
                    "Невозможно загрузить лекционный материал</ font><hr>";
            }
        }
       
        //открываем выбранную лекцию
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            webB.Visible = true;
            LoadLecture(n);
        }
       
        //переход к предыдущей лекции
        private void linkLBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (n == 1) n = 2;
            n--;
            LoadLecture(n);
        }
      
        //переход к следующей лекции
        private void linkLNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (n == 4) n = 0;
            n++;
            LoadLecture(n);
        }
       
        //при загрузке формы
        private void Lecture_Load(object sender, EventArgs e)
        {

        }

        //окно о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        
        //открываем основное меню
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }
        
        //выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autorization a = new Autorization();
            a.Show();
            this.Close();
        }
    }
}