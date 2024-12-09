//using Microsoft.Office.Interop.Word;
using Excel;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Office;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Xceed.Document.NET;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Table = Microsoft.Office.Interop.Word.Table;
using Word = Microsoft.Office.Interop.Word;



namespace SBS_Plus.Classes.Editors
{
    public class WordEditor
    {
        private FileInfo _fileInfo;

        public WordEditor(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }
        public bool MakeANewDocument(Dictionary<string, string> items, string contractNum)
        {
            TableNew(contractNum, Process(items));
            return true;
        }
        internal bool TableNew(string contractNum, Object fileName )
        {
          
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(fileName);

            Table table = doc.Tables[1];

            Microsoft.Office.Interop.Word.Range rowRange = table.Rows[2].Range;
            rowRange.Copy();

            System.Data.SqlClient.SqlParameter contractNumParam = new System.Data.SqlClient.SqlParameter("@WorkContractNum", contractNum);
            using (var db = new Classes.ApplicationContext())
            {     
                var exactWorks = db.Work.Where(w => w.ContractNumber == contractNum).ToList();

                for (int i = 0; i < exactWorks.Count()-1; i++)
                {
                    table.Rows.Add(table.Rows[2]);
                    table.Rows[2].Range.PasteAndFormat(Microsoft.Office.Interop.Word.WdRecoveryType.wdFormatOriginalFormatting);
                }
                int rowCount=2;
                foreach (Work work in exactWorks)
                {
                    table.Rows[rowCount].Cells[1].Range.Text = work.WorkNum.ToString();
                    table.Rows[rowCount].Cells[2].Range.Text = work.Name.ToString();
                    table.Rows[rowCount].Cells[3].Range.Text = work.Quantity.ToString();
                    table.Rows[rowCount].Cells[4].Range.Text = work.UnitOfMeasurement.ToString();
                    table.Rows[rowCount].Cells[5].Range.Text = work.Price.ToString();
                    table.Rows[rowCount].Cells[6].Range.Text = (work.Price* work.Quantity).ToString();
                    rowCount++;
                }
            }
              

            doc.Save();
            doc.Close();
            wordApp.Quit();
            
            Marshal.ReleaseComObject(table);
            Marshal.ReleaseComObject(doc);
            Marshal.ReleaseComObject(wordApp);
            return true;

        }
        public Object Process(Dictionary<string, string> items )
        {
            Object newFileName = null;
            Microsoft.Office.Interop.Word.Application app = null;
            try
            {
                app = new Microsoft.Office.Interop.Word.Application();

                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace
                    );
                }
              
                newFileName = Path.Combine(_fileInfo.DirectoryName, items[items.Keys.ElementAt(12)].ToString()+" " + items[items.Keys.ElementAt(13)].ToString()+" " +items[items.Keys.ElementAt(15)].ToString() + " "+items[items.Keys.ElementAt(0)] );
                  if (File.Exists(newFileName.ToString()+".docx"))
                {
                    // Delete the existing file.
                    File.Delete(newFileName.ToString() + ".docx");
                }
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }

            }
          
            return  newFileName+".docx";
        }
    }
}
