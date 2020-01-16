using System;
using System.Net;
using System.Web.Script.Serialization; // requires the reference 'System.Web.Extensions'
using System.IO;
using System.Windows;
using iTextSharp.text.pdf;          //*iTextSharp
using iTextSharp.text.pdf.parser;   //*iTextSharp Text-Reader
using System.Collections.Generic;
using System.Linq;
using Path = System.IO.Path;

class Pdf2Text
{
    static void Main(string[] args)
    {
        //Salva in una variabile la lista dei file

        Pdf2Text pdfTextExtractor = new Pdf2Text();
        string text = "";
        try
        {

            //Legge tutti i file di una cartella e salva l'indirizzo in una lista

            string[] dirs = Directory.GetFiles(@"C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Progetti\\ExtractTextFromPdfMVC\\PDF");
            Console.WriteLine($"Number of files: {dirs.Length}.");

            foreach (string path in dirs)
            {
                string filename = Path.GetFileName(path).Replace(".pdf","");
                text = pdfTextExtractor.extractText( filename);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }

        //MessageBox.Show("Stampa la lista dei testi estratti dai file a schermo");

        Console.WriteLine("===============================");
        Console.WriteLine("PDF TEXT IS AS FOLLOWS:");
       // Console.WriteLine(text);
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
       
    
    //Estrae il testo e lo salva in un file Csv
    public string extractText(string filename)
    {
        string pdfText = "";
        try  
        {

            string sFilename = $"C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Progetti\\ExtractTextFromPdfMVC\\PDF\\{filename}.pdf";

            //--< read File >--

            PdfReader pdf_Reader = new PdfReader(sFilename);

            for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
            {
                pdfText = pdfText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            }

            //linea = pdftext che diventa una lista
            List<string> linea = new List<string>();
            linea = pdfText.Split('\n').ToList();

            System.IO.File.WriteAllLines($"C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Tabelle\\csv\\{filename}.csv", linea.ToArray());
            //MessageBox.Show(pdfText);
        }
        catch (WebException webEx)
        {
            pdfText = "ERROR";
        }
        return pdfText;
    }
}




//list<pdfreader> pdfreader0 = new list<pdfreader>();
//pdfreader0.addrange(sfilename.getfiles.postedfiles.select(f => new pdfreader(f.inputstream)));

//foreach (string path in args)
//{
//    if (file.exists(path))
//    {
//        // this path is a file
//        processfile(path);
//    }
//    else if (directory.exists(path))
//    {
//        // this path is a directory
//        processdirectory(path);
//    }
//    else
//    {
//        console.writeline("{0} is not a valid file or directory.", path);
//    }
//}


//public static void processdirectory(string targetdirectory)
//{
//    // process the list of files found in the directory.
//    string[] fileentries = directory.getfiles(targetdirectory);
//    foreach (string filename in fileentries)
//        processfile(filename);

//    // recurse into subdirectories of this directory.
//    string[] subdirectoryentries = directory.getdirectories(targetdirectory);
//    foreach (string subdirectory in subdirectoryentries)
//        processdirectory(subdirectory);
//}

//// insert logic for processing found files here.
//public static void processfile(string path)
//{
//    console.writeline("processed file '{0}'.", path);
//}