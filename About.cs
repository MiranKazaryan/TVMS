//Данный модуль выводит информацию "О программе"
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

namespace TV_and_MS
{

    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        //загрузка справки к программному средству
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
