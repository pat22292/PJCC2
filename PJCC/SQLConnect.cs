using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Properties;
using MetroFramework;

namespace PJCC
{
    public partial class SQLConnect : MetroForm
    {
        public SQLConnect()
        {
            InitializeComponent();
        }

        private void SQLConnect_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = serverName.Text;
            Properties.Settings.Default.Database = DBname.Text;
            Properties.Settings.Default.userName = useName.Text;
            Properties.Settings.Default.pw = passWord.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Connection has been updated!");
        }
    }
}
