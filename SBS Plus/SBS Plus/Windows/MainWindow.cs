using SBS_Plus.Classes;
using SBS_Plus.Classes.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Diagnostics.Contracts;


namespace SBS_Plus.Windows
{
    public partial class MainWindow : Form
    {
       
        public MainWindow()
        {
            InitializeComponent();
            tableWorkView();
            DateTime dt = DateTime.Now;
            yearNumber.Text = "СБСУ";
            string dtText = dt.ToString("dd.MM");
            dogText.Text = yearNumber.Text + "-" + dtText.Substring(0, 2) + "/" + dtText.Substring(3, 2);
            using (var db = new Classes.ApplicationContext())
            {
                foreach (var Org in db.Organization)
                {
                    orgSearch.Items.Add(Org.Name);
                }
              
            }
            using (var db = new Classes.ApplicationContext())
            {
                Classes.Contract contract = db.Contract.Find(dogText.Text);

                if (contract != null)
                {
                    Organization org = db.Organization.Find(contract.OrganizationINN);
                    dateTimePicker1.Value = contract.Date;
                    addressView.Text = contract.Address;
                    orgSearch.Text = org.Name;
                    dateTimePicker2.Value = (DateTime)contract.ClosingDate;

                    var exactWorks = db.Work.Where(w => w.ContractNumber == contract.ContractNumber).OrderBy(w => w.WorkNum).ToList();


                    if (exactWorks.Count() != 0)
                    {

                        foreach (Work work in exactWorks)
                        {

                            tableWork.Rows[work.WorkNum - 1].Cells[1].Value = work.Name;
                            tableWork.Rows[work.WorkNum - 1].Cells[2].Value = work.Quantity;
                            tableWork.Rows[work.WorkNum - 1].Cells[3].Value = work.UnitOfMeasurement;
                            tableWork.Rows[work.WorkNum - 1].Cells[4].Value = work.Price;
                            tableWork.Rows[work.WorkNum - 1].Cells[5].Value = work.Quantity * work.Price;
                            if (work.WorkNum - 1 != exactWorks.Count() - 1)
                            {
                                tableWork.Rows.Add();
                            }



                        }

                    }

                }

            }
        }


        private void newDocButton_Click(object sender, EventArgs e)
        {

            Classes.ClassesAdder classesAdder = new ClassesAdder();
            try
            {
                classesAdder.newContract(orgSearch.Text, dogText.Text, dateTimePicker1.Value.Date, addressView.Text, dateTimePicker2.Value.Date);
                int rowcount = tableWork.RowCount;
                foreach (DataGridViewRow row in tableWork.Rows)
                {
                    if (row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null || row.Cells[4].Value == null)
                    {

                    }
                    else
                    {
                        classesAdder.newWorks(dogText.Text, row.Cells[1].Value.ToString(), Convert.ToDecimal(row.Cells[2].Value.ToString()), Convert.ToDecimal(row.Cells[4].Value.ToString()), row.Cells[3].Value.ToString(), Convert.ToInt32(row.Cells[0].Value));
                        rowcount--;
                        if (rowcount == 1)
                        {
                            break;
                        }
                    }
                   
                }

                classesAdder.newDocument(orgSearch.Text, dogText.Text, @"C:\Users\Pekarnya\source\repos\SBS Plus\SBS Plus\bin\Debug\last model.docx");
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "Входная строка имела неверный формат.")
                {
                    MessageBox.Show("Входная строка имела неверный формат");
                }
            }
        }

        private void dogText_TextChanged(object sender, EventArgs e)
        {
            using (var db = new Classes.ApplicationContext())
            {
                Classes.Contract contract = db.Contract.Find(dogText.Text);
                
                if (contract != null)
                {   Organization org = db.Organization.Find(contract.OrganizationINN);
                    dateTimePicker1.Value = contract.Date;
                    addressView.Text = contract.Address;
                    orgSearch.Text = org.Name;
                    dateTimePicker2.Value = (DateTime)contract.ClosingDate;

                    var exactWorks = db.Work.Where(w => w.ContractNumber == contract.ContractNumber).OrderBy(w => w.WorkNum).ToList();


                    if (exactWorks.Count() != 0)
                    {
                       
                        foreach (Work work in exactWorks)
                        {
                           
                                tableWork.Rows[work.WorkNum-1].Cells[1].Value = work.Name;
                                tableWork.Rows[work.WorkNum - 1].Cells[2].Value = work.Quantity;
                                tableWork.Rows[work.WorkNum - 1].Cells[3].Value = work.UnitOfMeasurement;
                                tableWork.Rows[work.WorkNum - 1].Cells[4].Value = work.Price;
                                tableWork.Rows[work.WorkNum - 1].Cells[5].Value = work.Quantity * work.Price;
                                if (work.WorkNum-1 != exactWorks.Count() - 1)
                                {
  tableWork.Rows.Add();
                                }
                              

                            
                        }

                    }
                  
                }
               
            }
        }

        private void orgSearch_TextChanged(object sender, EventArgs e)
        {
            orgSearch.Items.Clear();
            using (Classes.ApplicationContext db = new Classes.ApplicationContext())
            {
                if (orgSearch.Text == "")
                {
                    foreach (var Org in db.Organization)
                    {
                        orgSearch.Items.Add(Org.Name);
                    }
                }
                else
                {
                    var result1 = db.Database.SqlQuery<Organization>("SELECT * FROM Organizations WHERE [Name] LIKE '" + orgSearch.Text + "%'");
                    bool flag = false;
                    if (result1 != null)
                    {
                       
                        foreach (var obj in result1)
                        {
                            foreach (var item in orgSearch.Items)
                            {
                                if (item.ToString() == obj.Name)
                                {
                                    flag = true;
                                    break;

                                }
                            }
                            if (!flag)
                                orgSearch.Items.Add(obj.Name);

                        }
                    }
                }
                
                
            }
            orgSearch.Focus();
            orgSearch.SelectionStart = orgSearch.Text.Length;
        }

      
        private void CloseKSBtn_Click(object sender, EventArgs e)
        {
            using (var db = new Classes.ApplicationContext())
            {
                Classes.Contract contract = db.Contract.Find(dogText.Text);

                if (contract != null)
                {
                    Organization org = db.Organization.Find(contract.OrganizationINN);


                    ExcelEditor excelEditor = new ExcelEditor(@"C:\Users\Pekarnya\source\repos\SBS Plus\SBS Plus\bin\Debug\A model.xlsx");
                    excelEditor.newExcelDoc(contract, org);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewOrgForm orgForm = new NewOrgForm();
            orgForm.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void orgSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void tableWork_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void tableWork_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tableWork.Rows[tableWork.Rows.Count-1].Cells[0].Value = tableWork.Rows.Count;

        }
        private void tableWorkView()
        {
            tableWork.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            tableWork.Rows[0].Cells[1].Value = "Устройство переходов методом ГНБ, прокладка 1-ой трубы d=63 мм.";
            tableWork.Rows[0].Cells[0].Value = "1";
            tableWork.Columns[0].Width = 20;
            tableWork.Columns[1].Width = 200;
            tableWork.Columns[2].Width = 50;
            tableWork.Columns[3].Width = 50;
            tableWork.Columns[4].Width = 50;
            tableWork.Columns[5].Width = 100;

        }
    }
}
