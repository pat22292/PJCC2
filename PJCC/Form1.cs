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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace PJCC
{
    public partial class Form1 : MetroForm
    {

        CRUD showTable = new CRUD();
        public Form1()
        {
            InitializeComponent();
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(),metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
            //label1.Text = metroGrid1.ColumnCount.ToString();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            SQLConnect dbConnect = new SQLConnect();
            this.SendToBack();
            dbConnect.ShowDialog();
            dbConnect.BringToFront();
            
           

        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(), metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(), metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AddingNew add = new AddingNew();
            this.SendToBack();
            add.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

            showTable.printPDF(metroGrid1);



            //int count = 0;
            //try
            //{

            //    SaveFileDialog savefiledialog1 = new SaveFileDialog();
            //    savefiledialog1.FileName = (metroGrid1.Text) + " " + (DateTime.Now.ToLongDateString());
            //    savefiledialog1.Filter = "Excel Workbook|*.xlsx";

            //    //showTable.prinPDF(metroGrid1);
            //    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //    if (savefiledialog1.ShowDialog() == DialogResult.OK)
            //    {

            //        if (xlApp == null)
            //        {
            //            MessageBox.Show("Excel is not properly installed!!");
            //            return;
            //        }


            //        Excel.Workbook xlWorkBook;
            //        Excel.Worksheet xlWorkSheet;
            //        object misValue = System.Reflection.Missing.Value;

            //        xlWorkBook = xlApp.Workbooks.Add(misValue);
            //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //        for (int i = 1; i < metroGrid1.Columns.Count + 1; i++)
            //        {
            //            xlWorkSheet.Cells[1, i] = metroGrid1.Columns[i - 1].HeaderText;

            //        }

            //        // && metroGrid1.Rows[i].Cells[6].Value.ToString() == "BAGGING SERVICES"

            //        for (int i = 0; i < metroGrid1.Rows.Count; i++)
            //        {


            //            for (int j = 0; j < metroGrid1.Columns.Count; j++)
            //            {

            //                count++;
            //                xlWorkSheet.Cells[i + 2, j + 1] = metroGrid1.Rows[i].Cells[j].Value.ToString();
            //            }

            //        }

            //        //Excel.Range range = (Excel.Range)xlWorkSheet.get_Range("g1", Missing.Value);
            //        //range.EntireColumn.Delete(Missing.Value);
            //        //System.Runtime.InteropServices.Marshal.ReleaseComObject(range);

            //        Excel.Range formatRange;
            //        formatRange = xlWorkSheet.get_Range("a1");
            //        formatRange.EntireRow.Font.Bold = true;



            //        //xlWorkSheet.Rows[1, 8] = count.ToString();

            //        xlWorkBook.SaveAs(savefiledialog1.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //        xlWorkBook.Close(true, misValue, misValue);
            //        xlApp.Quit();

            //        Marshal.ReleaseComObject(xlWorkSheet);
            //        Marshal.ReleaseComObject(xlWorkBook);
            //        Marshal.ReleaseComObject(xlApp);





            //        //MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
            //        System.Diagnostics.Process.Start(savefiledialog1.FileName);
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("The file is open!");

            //}
            //Billing bill = new Billing();
            //bill.ShowDialog();




        }

        private void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(), metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
        }

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(), metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
        }

        private void metroComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            showTable.view(metroGrid1, metroDateTime2.Value.ToString(), metroDateTime1.Value.ToString(), metroComboBox1.Text, metroComboBox3.Text, metroComboBox2.Text);
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
