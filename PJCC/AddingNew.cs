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
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;


namespace PJCC
{
    public partial class AddingNew : MetroForm
    {
        string a = "SELECT ID, CONVERT(VARCHAR(10),[F2], 101) as 'Date',[F3] as 'Description' ,[F4] as 'Weight',[F5] as 'Rate',[F6] as 'Remarks',[F1] as 'Service',[F7] as 'Shift',[F8] as 'Department'FROM[PJCC].[dbo].[Services_temporary]";
        public AddingNew()
        {
            InitializeComponent();
            slidePanel1.IsOpen = false;
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
            metroDateTime1.Value = DateTime.Today;
            CRUD autoSugg = new CRUD();
            autoSugg.autoSuggest(textBoxX1);





            autoSugg.viewtEMP(metroGrid2, a);
           
        }

        private void done_Click(object sender, EventArgs e)
        {
            CRUD newService = new CRUD();
            newService.insertService(metroDateTime1.Value.ToString(), textBoxX1.Text, metroComboBox2.Text, metroComboBox3.Text, metroComboBox1.Text, Convert.ToDecimal(metroTextBox2.Text), Convert.ToDecimal(metroLabel5.Text), metroTextBox4.Text);
            newService.autoSuggest(textBoxX2);
            newService.viewtEMP(metroGrid2, a);
        }

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            CRUD rate = new CRUD();
            rate.ratePrice(metroComboBox2);
            metroLabel5.Text = rate.RatePerTon;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid2_DoubleClick(object sender, EventArgs e)
        {
            slidePanel1.BringToFront();
            metroGrid1.Enabled = false;
            slidePanel1.AnimationTime = 1000;
            slidePanel1.SlideSide = eSlideSide.Left;
            slidePanel1.IsOpen = true;    
            CRUD searchID = new CRUD();

            var rowsCount = metroGrid2.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;
            metroLabel10.Text = metroGrid2.SelectedCells[0].Value.ToString();
            searchID.searchServiceID(metroLabel10.Text);
            textBoxX2.Text = searchID.Description;
            metroComboBox4.Text = searchID.Service;
            metroDateTime1.Value = Convert.ToDateTime(searchID.Date);
            metroTextBox1.Text = searchID.Weight;
            metroTextBox3.Text = searchID.Remarks;




        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            slidePanel1.SlideSide = eSlideSide.Right;
            slidePanel1.IsOpen = false;
            metroGrid1.Enabled = true;
        }

        private void metroComboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            CRUD rate = new CRUD();
            rate.ratePrice(metroComboBox4);
            metroLabel8.Text = rate.RatePerTon;
        }
    }
}
