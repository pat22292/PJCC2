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
using System.Data.SqlClient;
using System.IO;


namespace PJCC
{
    public partial class AddingNew : MetroForm
    {
        public AddingNew()
        {
            InitializeComponent();
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
            metroDateTime1.Value = DateTime.Today;
            CRUD autoSugg = new CRUD();
            autoSugg.autoSuggest(textBoxX1);





            string a = "SELECT CONVERT(VARCHAR(10),[F2], 101) as 'Date',[F3] as 'Description' ,[F4] as 'Weight',[F5] as 'Rate',[F6] as 'Remarks',[F1] as 'Service',[F7] as 'Shift',[F8] as 'Department'FROM[PJCC].[dbo].[Services_temporary]";
            autoSugg.viewtEMP(metroGrid2, a);
           
        }

        private void done_Click(object sender, EventArgs e)
        {
            CRUD newService = new CRUD();
            newService.insertService(metroDateTime1.Value.ToString(), textBoxX1.Text, metroComboBox2.Text, metroComboBox3.Text, metroComboBox1.Text, Convert.ToDecimal(metroTextBox2.Text), Convert.ToDecimal(metroLabel5.Text), metroTextBox4.Text);
        }

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            CRUD rate = new CRUD();
            rate.ratePrice(metroComboBox2);
            metroLabel5.Text = rate.RatePerTon;
        }
    }
}
