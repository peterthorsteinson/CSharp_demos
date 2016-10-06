using System;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;

//Visual C# 2010 includes several features that improve the experience
//of interoperating with COM APIs such as the Office Automation APIs.
//Among the improvements are the use of the dynamic type, and of named
//and optional arguments.


//Note: Based on: http://msdn.microsoft.com/en-us/library/dd264733.aspx
// ... changed to make use of dynamic keyword

//NOTE: must have Microsoft Office Excel 2007 and Microsoft Office Word 2007 installed on your computer

//NOTE: Must add references to Microsoft Excel and Word Object Libraries: 
//Project menu, click Add Reference...
//COM tab, locate Microsoft Excel Object Library, and click Select.
//Project menu, click Add Reference...
//COM tab, locate Microsoft Word Object Library, and click Select.

namespace DynamicOfficeInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Based on: http://msdn.microsoft.com/en-us/library/dd264733.aspx");

            // Create a list of accounts.
            var bankAccounts = new List<Account> {
                new Account { 
                  ID = 345678,
                  Balance = 541.27
                },
                new Account {
                  ID = 1230221,
                  Balance = -127.44
                }};

            // Display the list in an Excel spreadsheet.
            DisplayInExcel(bankAccounts);

            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            CreateIconInWordDoc();
        }

        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned 
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template. 
            // Because no argument is sent in this example, Add creates a new workbook. 
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. The explicit type casting is
            // removed in a later procedure.
            //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet; //commented out!!!
            dynamic workSheet = excelApp.ActiveSheet; //use dynamic keyword!!!

            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.ID;
                workSheet.Cells[row, "B"] = acct.Balance;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            // Put the spreadsheet contents on the clipboard. The Copy method has one
            // optional parameter for specifying a destination. Because no argument  
            // is sent, the destination is the Clipboard.
            workSheet.Range["A1:B3"].Copy();
        }

        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are 
            // optional. Visual C# 2010 allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are 
            // optional. This example uses named arguments to specify values 
            // for two of the parameters. Although these are reference 
            // parameters, you do not need to use the ref keyword, or to create 
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
    }

    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
}
