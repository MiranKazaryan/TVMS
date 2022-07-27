//Данный модуль предназначен для вывода справки по программе
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

    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        //при загрузке формы пытаемся подгрузить справку .htm
        private void Help_Load(object sender, EventArgs e)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "myhelp.htm";
            try
            {
                webBrowser1.Navigate(fileName);
            }
            catch
            {
                webBrowser1.DocumentText = "<font style = \"font-weight: normal; font-size: 14pt; color: red; font-style: normal; font-family: 'Times New Roman'; font-variant: normal; text-decoration: none\">" +
                    "Невозможно загрузить лекционный материал</ font><hr>";
            }
        }
    }
}
