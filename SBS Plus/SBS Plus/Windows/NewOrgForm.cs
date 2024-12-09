using Microsoft.EntityFrameworkCore;
using SBS_Plus.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.IO;
using Xceed.Document.NET;
using System.Text.RegularExpressions;

namespace SBS_Plus.Windows
{
    public partial class NewOrgForm : Form
    {
        public NewOrgForm()
        {
            InitializeComponent();
            typeTb.Text = "ООО";
        }

        private void addChangeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Classes.ApplicationContext())
                {
                    Organization org = db.Organization.Find(innTb.Text);
                    if (org != null)
                    {
                        org.EditOrg(nameTb.Text, directorTb.Text, directoraTb.Text, adressTb.Text, kppTb.Text, rsTb.Text, ksTb.Text, bankTb.Text, bikTb.Text, okpoTb.Text, ogrnTb.Text, typeTb.Text);
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        Organization orgnew = new Organization(innTb.Text, nameTb.Text, directorTb.Text, directoraTb.Text, adressTb.Text, kppTb.Text, rsTb.Text, ksTb.Text, bankTb.Text, bikTb.Text, okpoTb.Text, ogrnTb.Text, typeTb.Text);
                        db.Organization.Add(orgnew);
                        db.SaveChanges();
                        this.Close();

                    }

                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    System.Windows.Forms.MessageBox.Show("Такой инн уже есть");
                }

            }

        }

        private void innTb_TextChanged(object sender, EventArgs e)
        {
            using (Classes.ApplicationContext db = new Classes.ApplicationContext())
            {
                Organization org = db.Organization.Find(innTb.Text);
                if (org != null) {

                    TextBoxesFill(org.Name, org.Director, org.Directors, org.LegalAddress, org.KPP, org.RS, org.KS, org.Bank, org.BIC, org.OKPO, org.OGRN, org.Type);

                }
            }
        }

        private void nameOrgcmbBpx_TextChanged(object sender, EventArgs e)
        {
            nameOrgcmbBpx.Items.Clear();
            using (Classes.ApplicationContext db = new Classes.ApplicationContext())
            {

                var result1 = db.Database.SqlQuery<Organization>("SELECT * FROM Organizations WHERE [Name] LIKE '" + nameOrgcmbBpx.Text + "%'");
                bool flag = false;
                foreach (var obj in result1)
                {
                    foreach (var item in nameOrgcmbBpx.Items)
                    {
                        if (item.ToString() == obj.Name)
                        {
                            flag = true;
                            break;

                        }
                    }
                    if (!flag)
                        nameOrgcmbBpx.Items.Add(obj.Name);

                }
            }
        }

        private void nameOrgcmbBpx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (Classes.ApplicationContext db = new Classes.ApplicationContext())
            {
                var findOrg = db.Organization.FirstOrDefault(o => o.Name == nameOrgcmbBpx.Text);

                if (findOrg != null)
                {
                    TextBoxesFill(findOrg.Name, findOrg.Director, findOrg.Directors, findOrg.LegalAddress, findOrg.KPP, findOrg.RS, findOrg.KS, findOrg.Bank, findOrg.BIC, findOrg.OKPO, findOrg.OGRN, findOrg.Type);
                    innTb.Text = findOrg.INN;
                }
            }
        }

        private void nameOrgcmbBpx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxesFill(string Name, string Director, string Directors, string LegalAddress, string KPP, string RS, string KS, string Bank, string BIC, string OKPO, string OGRN, string Type)
        {
            nameTb.Text = Name;
            directorTb.Text = Director;
            directoraTb.Text = Directors;
            adressTb.Text = LegalAddress;
            kppTb.Text = KPP;
            rsTb.Text = RS;
            ksTb.Text = KS;
            bankTb.Text = Bank;
            bikTb.Text = BIC;
            okpoTb.Text = OKPO;
            ogrnTb.Text = OGRN;
            typeTb.Text = Type;
        }

        private void NewOrgForm_Load(object sender, EventArgs e)
        {

        }

        private void ogrnTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }
        public bool keyPressCheck(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                return  true;
            }
            else
            {
                return false;

            }
        }

        private void okpoTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }

        private void bikTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }

        private void ksTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }

        private void rsTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rsTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }

        private void kppTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }

        private void innTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = keyPressCheck(e);
        }
    }
}
