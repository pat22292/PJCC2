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
using System.IO;
using DevComponents.DotNetBar.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Reflection;
//using ClosedXML.Excel;


namespace PJCC
{
   public class CRUD
    {
        //NEW
        private static SqlConnection con = null;


        private void dbConnect()
        {

            con = new SqlConnection("Server = " + Properties.Settings.Default.server.ToString() + ";Database = " + Properties.Settings.Default.Database.ToString() + "; User Id = " + Properties.Settings.Default.userName.ToString() + "; Password = " + Properties.Settings.Default.pw.ToString() + "");

            //using (SqlConnection conn = new SqlConnection("Server = " + Properties.Settings.Default.server.ToString() + ";Database = " + Properties.Settings.Default.Database.ToString() + "; User Id = " + Properties.Settings.Default.userName.ToString() + "; Password = " + Properties.Settings.Default.pw.ToString() + ""))
            //{

            //    conn.Open();

            //    //Do Work with connection

            //}
            con.Open();
        }
        private void dbOut()
        {
            con.Close();

        }




        //Instance Variables
        private string date;
        private string description;
        private string weight;
        private string ratePerTon;
        private string amout;
        private string remarks;
        private string service;
        private string shift;
        private string department;

        //Properties
        public string Date { get { return date;} set { date = value; }}
        public string Description{get { return description; }set { description = value; }}
        public string Weight {get { return weight; }set { weight = value; }}
        public string RatePerTon {get { return ratePerTon; }set { ratePerTon = value; }}
        public string Amout {get { return amout; }set { amout = value; }}
        public string Remarks{get { return remarks; }set { remarks = value; }}
        public string Service { get { return service; } set { service = value; } }
        public string Shift { get { return shift; } set { shift = value; } }
        public string Department { get { return department; } set { department = value; } }

        //FUNCTIONS





        public void searchServiceID(string ID) 
        {
            dbConnect();

            SqlCommand cmd = new SqlCommand("[modifyRow] '" + ID + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Service = dr["F1"].ToString();
                Date = dr["F2"].ToString();
                Description = dr["F3"].ToString();
                Weight = dr["F4"].ToString();
                RatePerTon = dr["F5"].ToString();
                Remarks = dr["F6"].ToString();
                Shift = dr["F7"].ToString();
                Department = dr["F8"].ToString();

            }
            dbOut();
        }

        public void view(DataGridView table, string startDate, string endDate, string service, string department, string shift) //Filtering of PJCC transactions
        {
          
            //sqlcon userConnect = new sqlcon();
            dbConnect();
            SqlCommand recipe = new SqlCommand("[computeServices] '" + startDate + "','" + endDate + "','" + service + "','" + department + "','" + shift + "'", con);
            SqlDataAdapter calculated = new SqlDataAdapter();
            calculated.SelectCommand = recipe;
            DataTable dataSet = new DataTable();
            calculated.Fill(dataSet);
            BindingSource nSource = new BindingSource();
            nSource.DataSource = dataSet;
            table.DataSource = nSource;
            calculated.Update(dataSet);
            dbOut();
        }


        public void viewtEMP(DataGridView table, string SQLquery)
        {

            //sqlcon userConnect = new sqlcon();
            dbConnect();
            SqlCommand recipe = new SqlCommand(SQLquery, con);
            SqlDataAdapter calculated = new SqlDataAdapter();
            calculated.SelectCommand = recipe;
            DataTable dataSet = new DataTable();
            calculated.Fill(dataSet);
            BindingSource nSource = new BindingSource();
            nSource.DataSource = dataSet;
            table.DataSource = nSource;
            calculated.Update(dataSet);
            dbOut();
        }

        public void insertService(string Date, string description, string service, string department, string shift, decimal weight, decimal rate, string remarks) //Filtering of PJCC transactions
        {

            //sqlcon userConnect = new sqlcon();
            dbConnect();
         
            SqlCommand material = new SqlCommand("[newService]", con);
            material.CommandType = System.Data.CommandType.StoredProcedure;
            material.Parameters.AddWithValue("@date", Date);
            material.Parameters.AddWithValue("@description", description);
            material.Parameters.AddWithValue("@service", service);
            material.Parameters.AddWithValue("@department", department);
            material.Parameters.AddWithValue("@shift", shift);
            material.Parameters.AddWithValue("@weight", weight);
            material.Parameters.AddWithValue("@rate", rate);
            material.Parameters.AddWithValue("@remarks", remarks);
 
            material.ExecuteNonQuery();
            
            dbOut();
        }

        public void ratePrice(ComboBox service)
        {
            
             dbConnect();
            SqlCommand cmd = new SqlCommand("SELECT [Rate] FROM[PJCC].[dbo].[PJCC_RATE] WHERE JOB = '"+ service.Text+ "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //metroLabel5.Text = dr["Price"].ToString();
                //metroLabel7.Text = dr["Bagging"].ToString();
                ratePerTon = dr["Rate"].ToString();
            }
            dbOut();
        }


        public static void Insert_Data_RPT()
        {

        }

        public void autoSuggest(TextBoxX textBoxname)
        {
           
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            SqlDataReader dReader;
            dbConnect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM views_Autosuggest", con);
            cmd.CommandType = CommandType.Text;
          
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                {
                    namesCollection.Add(dReader["Description"].ToString());
                }
            }
            dbOut();
            textBoxname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxname.AutoCompleteCustomSource = namesCollection;
        }


        public void printPDF(DataGridView tableGRID)
        {


            //try
            //{

                SaveFileDialog savefiledialog1 = new SaveFileDialog();
                savefiledialog1.FileName = (tableGRID.Text) + " " + (DateTime.Now.ToLongDateString());
                savefiledialog1.Filter = "PDF Files|*.pdf";


                if (savefiledialog1.ShowDialog() == DialogResult.OK)
                {

                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 30, 30, 25, 25);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savefiledialog1.FileName, FileMode.Create));

                    doc.Open();

                    Paragraph para1 = new Paragraph(new Phrase("PCJ HANDLING SERVICES", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                    //para1.Alignment = Element.ALIGN_LEFT;
                  
                    Paragraph para2 = new Paragraph(new Phrase("973 Pulo St. Matungao Bulakan, Bulacan", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    Paragraph para3 = new Paragraph(new Phrase("0943-2691880 /0919-3369064/ (044) 760-0129", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    Paragraph para4 = new Paragraph(new Phrase("pcjhandlingservices@gmail.com", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.UNDERLINE, BaseColor.BLUE)));
                    doc.Add(para1);
                    doc.Add(para2);
                    doc.Add(para3);
                    doc.Add(para4);
                  

                    PdfPTable description = new PdfPTable(2);
                    description.SpacingBefore = 10f;
                    description.WidthPercentage = 60;
                    description.SetWidths(new float[] { 1, 6});
                    description.HorizontalAlignment = Element.ALIGN_LEFT;
                    description.DefaultCell.HorizontalAlignment = 1;
                    description.AddCell(new Phrase("Date : ", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    description.AddCell(new Phrase("January 13,2017", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                    description.AddCell(new Phrase("Billing to :", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    description.AddCell(new Phrase("TEXICON AGRIVENTURES CORP Aqua Division", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                    description.AddCell(new Phrase("Billing\nPeriod: ", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    description.AddCell(new Phrase("January 06-,2017", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));





                    doc.Add(description);


                Paragraph unload = new Paragraph(new Phrase("UNLOADING SERVICES", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                Paragraph prep = new Paragraph(new Phrase("MATERIAL PREPARATION", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                Paragraph pour = new Paragraph(new Phrase("MATERIAL POURING", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                Paragraph bag = new Paragraph(new Phrase("BAGGING SERVICES", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                Paragraph load = new Paragraph(new Phrase("LOADING SERVICES", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                Paragraph pallet = new Paragraph(new Phrase("PALLETIZING / REPALLETIZING SERVICES/REBAGGING", FontFactory.GetFont("Times New Roman", 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

            

                PdfPTable table1 = new PdfPTable(tableGRID.Columns.Count - 3);
                    PdfPTable table2 = new PdfPTable(tableGRID.Columns.Count - 3);
                    PdfPTable table3 = new PdfPTable(tableGRID.Columns.Count - 3);
                    PdfPTable table4 = new PdfPTable(tableGRID.Columns.Count - 3);
                    PdfPTable table5 = new PdfPTable(tableGRID.Columns.Count - 3);
                    PdfPTable table6 = new PdfPTable(tableGRID.Columns.Count - 3);




                    printTable(tableGRID, "UNLOADING",table1);
                    printTable(tableGRID, "MATERIAL PREPARATION", table2);
                    printTable(tableGRID, "MATERIAL POURING", table3);
                    printTable(tableGRID, "BAGGING SERVICES", table4);
                    printTable(tableGRID, "LOADING SERVICES", table5);

               


                   
                       printTable(tableGRID, "PALLETIZING / REPALLETIZING SERVICES/REBAGGING", table6);





                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("UNLOADING"))
                    {

                        doc.Add(unload);
                        doc.Add(table1);
                        break;
                    }
                }



                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("MATERIAL PREPARATION"))
                    {

                        doc.Add(prep);
                        doc.Add(table2);
                        break;
                    }
                }



                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("MATERIAL POURING"))
                    {


                        doc.Add(pour);
                        doc.Add(table3);
                        break;

                    }
                }


                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("BAGGING SERVICES"))
                    {
                        doc.Add(bag);
                        doc.Add(table4);
                        break;
                    }
                }

                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("LOADING SERVICES"))
                    {

                        doc.Add(load);
                        doc.Add(table5);
                        break;
                    }
                }

                foreach (DataGridViewRow row in tableGRID.Rows)
                {
                    if (row.Cells[6].Value.ToString().Contains("PALLETIZING / REPALLETIZING SERVICES/REBAGGING"))
                    {
                        doc.Add(pallet);
                        doc.Add(table6);
                        break;
                    }
                    //row.Cells["chat1"].Style.ForeColor = Color.CadetBlue;
                }
                

                doc.Close();


                //    //AddPageNumber(savefiledialog1.FileName, savefiledialog1.FileName);
                System.Diagnostics.Process.Start(savefiledialog1.FileName);
                  
                }

            //}
            //catch
            //{
            //    DesktopAlert.Show("The file is open!");

            //}


        }



    
        private static void printTable(DataGridView tableGRID, string service, PdfPTable table)
        {


            //table = new PdfPTable(tableGRID.Columns.Count - 3);

            table.SpacingAfter = 10;
            table.WidthPercentage = 100;
            table.SpacingBefore = 5f;

        



            table.SetWidths(new float[] { 1, 5, 1, 1, 1, 1});


            String[] headers = { "DATE", "DESCRIPTION", "Kgs.", "RATE PER \nTON", "TOTAL \nAMOUNT", "REMARKS" };


            for (int cnt = 0; cnt < tableGRID.Columns.Count - 3; cnt++)
            {
                
                PdfPCell cell = new PdfPCell(new Phrase(headers[cnt], FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#959799"));
                table.AddCell(cell);

            }

            table.HeaderRows = 0;

            decimal sum = 0;


            for (int i = 0; i < tableGRID.Rows.Count; i++)
            {
                for (int k = 0; k < tableGRID.Columns.Count - 3 && tableGRID.Rows[i].Cells[6].Value.ToString() == service; k++)
                {
                    PdfPCell cell2 = new PdfPCell(new Phrase(tableGRID[k, i].Value.ToString(), FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(cell2);

                }

                if (tableGRID.Rows[i].Cells[6].Value.ToString() == service)
                {
                    sum += Convert.ToDecimal(tableGRID.Rows[i].Cells[4].Value);
                }

            }


            PdfPCell header = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            header.HorizontalAlignment = 1;

            header.Colspan = 4;
            header.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#959799"));
            table.AddCell(header);
            PdfPCell total = new PdfPCell(new Phrase(String.Format("{0:n}", sum), FontFactory.GetFont("Times New Roman", 7f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            total.Colspan = 2;

            total.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#959799"));
            table.AddCell(total);

            //header.Colspan = 4;
            //doc.Add(table);
            //doc.Add(total);

        }
        
    }
}
