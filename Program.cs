using System;
using System.Net;
using System.Web.Script.Serialization; // requires the reference 'System.Web.Extensions'
using System.IO;
using System.Windows;
using iTextSharp.text.pdf;          //*iTextSharp
using iTextSharp.text.pdf.parser;   //*iTextSharp Text-Reader
using System.Collections.Generic;
using System.Linq;

class Pdf2Text
{
    static void Main(string[] args)
    {
        // TODO: Specify the URL of your small PDF document (less than 1MB and 10 pages)
        // To extract text from bigger PDf document, you need to use the async method.
        string pdfUrl = "file:///C:/Users/Giorgio%20Della%20Roscia/Desktop/1sad.pdf";
        Pdf2Text pdfTextExtractor = new Pdf2Text();
        string text = pdfTextExtractor.extractText(pdfUrl);
        Console.WriteLine("===============================");
        Console.WriteLine("PDF TEXT IS AS FOLLOWS:");
        Console.WriteLine(text);
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
    public string extractText(string pdfUrl)
    {
        string pdfText = "";
        try  
        {

            String sFilename = "file:///C:/Users/Giorgio%20Della%20Roscia/Desktop/Andamento%20latte/allegati/COSTANTINI_20190304-16.pdf";

            //--< read File >--

            PdfReader pdf_Reader = new PdfReader(sFilename);

            for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
            {
                pdfText = pdfText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            }


            List<string> linea = new List<string>();
            //linea = pdftext che diventa una lista
            linea = pdfText.Split('\n').ToList();
            //object reader=null;
            //while (reader.Read())
            //{
            //    linea.Add(reader.GetValue(0).ToString()
            //              + ","
            //              + reader.GetValue(1).ToString()
            //              + ","
            //              + reader.GetValue(2).ToString());
            //}
            System.IO.File.WriteAllLines("C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Tabelle\\csv\\ProvaTabellaLatte.csv", linea.ToArray());
            MessageBox.Show(pdfText);
        }
        catch (WebException webEx)
        {
            pdfText = "ERROR";
        }
        return pdfText;
    }
}