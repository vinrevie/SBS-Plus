using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel;
using Microsoft.Office.Interop.Excel;


namespace SBS_Plus.Classes.Editors
{
    internal class ExcelEditor
    {
        private FileInfo _fileInfo;

        public ExcelEditor(string fileName)
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
        public void newExcelDoc(Contract contract, Organization org)
        {
            using (var db = new Classes.ApplicationContext())
            {
                var exactWorks = db.Work.Where(w => w.ContractNumber == contract.ContractNumber).OrderBy(w => w.WorkNum).ToList();
                string filePath = Process(contract, org);
                newRow(exactWorks.Count, filePath);
                fillRows(exactWorks, filePath);
            }
        }
        public void fillRows(List<Work> exactWorks, string filePath)
        {

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];
            int row = 27;

            foreach (Work work in exactWorks)
            {
                worksheet.Cells[row, 1].Value2 = work.WorkNum;
                worksheet.Cells[row, 6].Value2 = work.Name;
                worksheet.Cells[row, 17].Value2 = work.UnitOfMeasurement;
                worksheet.Cells[row, 21].Value2 = work.Quantity;
                worksheet.Cells[row, 25].Value2 = work.Price;
                worksheet.Cells[row, 30].Value2 = work.Price*work.Quantity;
                row++;

            }


            workbook.Save();
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
        public void newRow(int RowsNumToAdd, string excelFilePath)
        {
            //string excelFilePath = @"C:\Users\Pekarnya\source\repos\SBS Plus\SBS Plus\bin\Debug\A model.xlsx";


            int rowToCopy = 27;

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            Microsoft.Office.Interop.Excel.Range sourceRange = worksheet.Rows[rowToCopy];
            sourceRange.Copy();
            for (int i = 0; i < RowsNumToAdd-1; i++)
            {
                Microsoft.Office.Interop.Excel.Range destinationRange = worksheet.Rows[rowToCopy + 1 + i];
                destinationRange.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
            }


            workbook.Save();
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
        internal string Process(Contract contract, Organization org)
        {


            string excelFilePath = @"C:\Users\Pekarnya\source\repos\SBS Plus\SBS Plus\bin\Debug\A model.xlsx";


            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1]; 

            {
      
                worksheet.Cells[6, 7].Value2 = org.Type+ " «"+org.Name+ ", ИНН: "+org.INN +", КПП: "+org.KPP+", юр. адрес: "+org.LegalAddress;
                worksheet.Cells[6, 30].Value2 = org.OKPO;
                worksheet.Cells[12, 30].Value2 = contract.ContractNumber;
                worksheet.Cells[13, 30].Value2 = contract.Date.Day;
                worksheet.Cells[13, 31].Value2 = contract.Date.Month;
                worksheet.Cells[13, 33].Value2 = contract.Date.Year;
                worksheet.Cells[17, 30].Value2 = contract.Date;
                worksheet.Cells[17, 32].Value2 = contract.ClosingDate;
                worksheet.Cells[9, 3].Value2 = contract.Address;
                worksheet.Cells[36, 21].Value2 = org.Director;
                worksheet.Cells[36, 5].Value2 = "Генеральный директор "+org.Type+ " «"+org.Name+ "»";

            }
            Object newFileName = Path.Combine(_fileInfo.DirectoryName,  org.Name+ DateTime.Now.ToString("HHmmss"));
            workbook.SaveAs(newFileName);

            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);

            return newFileName.ToString();
        }
    }
}
