using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace MatthewLearningCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false; // Suppress alert messages

                workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                worksheet.Cells[1, 1].Value = "Happy Birthday!";
                worksheet.Cells[1, 1].Font.Size = 36;
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                worksheet.Columns[1].AutoFit();

                //Change the below putfilepathhere to the file path where you want the Excel document saved.
                string outputPath = @"putfilepathhere";
                Directory.CreateDirectory(outputPath);  // Create the directory if it doesn't exist

                string filePath = Path.Combine(outputPath, "BirthdayMessage.xlsx");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath); // Delete the existing file
                }

                workbook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook); // Use xlOpenXMLWorkbook to save as xlsx format

                // Maximize the Excel window
                excelApp.WindowState = Excel.XlWindowState.xlMaximized;

                Console.WriteLine("Excel file saved successfully. Excel window maximized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (workbook != null)
                {
                    // Do not close the workbook here
                    // System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }

                if (excelApp != null)
                {
                    // Do not quit the application here
                    // System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }
    }
}
