using SBS_Plus.Classes.Editors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;

namespace SBS_Plus.Classes
{
    internal class ClassesAdder
    {
        static Dictionary<int, string> monthNames = new Dictionary<int, string>
        {
            {1,"января" },
            {2,"февраля" },
            {3,"марта" },
            {4,"апреля" },
            {5,"мая" },
            {6,"июня" },
            {7,"июля" },
            {8,"августа" },
            {9,"сентября" },
            {10,"октября" },
            {11,"ноября" },
            {12,"декабря" }
        };
       
        public void newContract(string orgName, string contractNum, DateTime date, string address, DateTime dateClose)
        {

            try
            {
                using (var db = new Classes.ApplicationContext())
                {
                    var findContract = db.Contract.FirstOrDefault(o => o.ContractNumber == contractNum);
                    var findOrg = db.Organization.FirstOrDefault(o => o.Name == orgName);
                    if (findOrg != null) {  if (findContract != null)
                    {
                        findContract.EditContract(date, address, findOrg.INN, dateClose);

                    }
                    else
                    {
                        Contract contract = new Contract(contractNum, date, findOrg.INN, address, dateClose);
                        db.Contract.Add(contract);

                    }
                    db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("нет организации добавьте");
                    }
                }
            }
            catch (Exception e)
            {

                if (e.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    System.Windows.Forms.MessageBox.Show("Такой инн уже есть");
                }

            }

        }
        public void newWorks(string contractNum, string name,  decimal quantity, decimal price, string unitOfMeasure, int workNum)
        {
            try
            {
                using (var db = new Classes.ApplicationContext())
                {
                    var exactWorks = db.Work.Where(w => w.ContractNumber == contractNum && w.WorkNum==workNum).ToList();

                    if (exactWorks.Count() != 0)
                    {
                        foreach (Work work in exactWorks)
                        {
                            work.EditWork(name, price,quantity, unitOfMeasure);
                        }

                    }
                    else
                    {
                        var work = new Work(contractNum,name, price, quantity,unitOfMeasure, workNum);
                        db.Work.Add(work);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                if (e.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    System.Windows.Forms.MessageBox.Show("Такой инн уже есть");
                }

            }
        }
        public void newDocument(string orgName, string contractNum, string modelName)
        {
            Organization findOrg;
            Contract findContract;
            using (var db = new Classes.ApplicationContext())
            {
                findOrg = db.Organization.FirstOrDefault(o => o.Name == orgName);
                findContract = db.Contract.FirstOrDefault(o => o.ContractNumber == contractNum);
            }
            decimal sum; string sumPropis; decimal nds; string ndsPropis;
            counting(contractNum, out sum, out sumPropis, out nds, out ndsPropis);
            var helper = new WordEditor("A model.docx");
            var items = new Dictionary<string, string>
                {
                {"<ORG>",  findOrg.Name},
                {"<DIR>" , findOrg.Director },
                {"<DIRa>", findOrg.Directors  },
                {"<INN>",  findOrg.INN},
                {"<KPP>",  findOrg.KPP },
                {"<ORG_ADRES>",  findOrg.LegalAddress} ,
                {"<RS>",  findOrg.RS },
                {"<KS>",  findOrg.KS },
                {"<BANK>",  findOrg.Bank},
                {"<OKPO>",  findOrg.OKPO },
                {"<OGRN>",  findOrg.OGRN },
                {"<BIK>",  findOrg.BIC },
                {"<DATE_NUM>", findContract.Date.Day.ToString() },
                {"<MONTH>", findContract.Date.Month.ToString()},
                {"<MONTH_WORD>", monthNames[findContract.Date.Month] },
                {"<YEAR>",findContract.Date.Year.ToString() },
                {"<DOC_NUM>",findContract.ContractNumber },
                { "<SUM>", Math.Round(sum, 2).ToString() },
                { "<SUM_WORD>", sumPropis},
                { "<NDS>", Math.Round(nds, 2).ToString()},
                { "<NDS_WORD>", ndsPropis},
                {"<ADDRESS>",findContract.Address},
                { "<AVANS>", "\r\nАванс равен 50000"}

                };
            Classes.Editors.WordEditor wordEditor = new Classes.Editors.WordEditor(@"C:\Users\Pekarnya\source\repos\SBS Plus\SBS Plus\bin\Debug\last model.docx");
            wordEditor.MakeANewDocument(items, findContract.ContractNumber);

        }
        public void counting( string contractNum, out decimal sum, out string sumPropis, out decimal nds, out string ndsPropis)
        {
            nds = 0;   
            sum = 0;
            using (var db = new Classes.ApplicationContext())
            {
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@Num", contractNum);
                var result1 = db.Database.SqlQuery<Work>("SELECT * FROM Works WHERE ContractNumber = @Num", param2);
             
                foreach (Work work in result1)
                {
                    sum = ((decimal)sum + (decimal)work.Price * (decimal)work.Quantity);
                }
                nds = (decimal)sum * (decimal)0.1666666666666666;
                numbersToStrings numbersToStrings = new numbersToStrings((decimal)Math.Round(sum, 2));
                sumPropis=numbersToStrings.Propis.ToString();
                numbersToStrings numbersToStringsNds = new numbersToStrings((decimal)Math.Round(nds, 2));
                ndsPropis=numbersToStringsNds.Propis.ToString();
            }
        }
    }
}
