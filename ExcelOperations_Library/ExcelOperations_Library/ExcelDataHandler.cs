using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace ExcelOperations_Library
{
    public class ExcelDataHandler
    {
        private
            string Filename;
            string Filepath;
            Excel.Application ExcelHandler;
            Excel.Workbook ExcelWorkbook;
            Excel.Worksheet ExcelWorkSheet;

        public ExcelDataHandler()
        {
            // Initialize all class variables
            Filename = "";
            Filepath = "";
            ExcelHandler = new Excel.Application();
            ExcelWorkbook = null;

        }
        ~ExcelDataHandler()
        {
            ExcelWorkbook.Close();
            ExcelHandler.Quit();
        }
        public bool Initialize(string file)
        {
            Filename = file;
            FileInfo fileinfo = new FileInfo(Filename);
            try
            {
                Filepath = Path.GetFullPath(Filename);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Getting the following exception while trying to build path '" + ex.Message + "'");
                return false;
            }
            return true;

        }
        public bool Open()
        {
            if (File.Exists(Filepath))
            {
                try
                {
                    ExcelWorkbook = ExcelHandler.Workbooks.Open(Filepath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Getting the following exception while trying to open the file '" + ex.Message + "'");
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("Unable to Find/Open the file specified '" + Filepath + "'");
                return false;
            }
        }
        public void ReadOneSheet(int sheetindex)
        {
            // Need to implement when required
        }

        public bool ReadOneRow(int sheetindex, int rowNo, List <string> data)
        {
            int TotalSheetcount = ExcelWorkbook.Worksheets.Count;
            if (sheetindex > TotalSheetcount)
            {
                Console.WriteLine("Invalid sheet index");
                return false;
            }
            ExcelWorkSheet = ExcelWorkbook.Sheets[sheetindex];
            Excel.Range xlRange = ExcelWorkSheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int ColCount = xlRange.Columns.Count;
            if (rowNo > rowCount)
            {
                Console.WriteLine("Invalid row count");
                return false;
            }
            ExcelWorkSheet = ExcelWorkbook.Sheets[sheetindex];
            for( int i=1;i<=ColCount;i++)
            {
                data.Add(xlRange.Cells[rowNo, i].Value2.ToString());
               // data.Add(xlRange.Cells[2, 1].Value2.ToString()];
            }
            return true;
        }//End of ReadOneRow
    }// End of class ExcelDataHandler
}
