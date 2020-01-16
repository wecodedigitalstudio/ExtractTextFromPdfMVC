#region librerie
using System;
using System.Net;
using System.Web.Script.Serialization; // requires the reference 'System.Web.Extensions'
using System.IO;
using System.Windows;
using iTextSharp.text.pdf;          //iTextSharp
using iTextSharp.text.pdf.parser;   //iTextSharp Text-Reader
using System.Collections.Generic;
using System.Linq;
using Path = System.IO.Path;
#endregion
class Pdf2Text
{
    #region variabili globali
    //1. definizione cartella const
    public const string sDirPath = "C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Progetti\\ExtractTextFromPdfMVC\\PDF"; //percorso dove si trovano gli allegati in formato pdf
    #endregion
    static void Main(string[] args)
    {
        List<string> vPdf=new List<string>(); //lista contenente i percorsi dei file contenuti nella directory
        Pdf2Text pdfTextExtractor = new Pdf2Text();
        
        try
        {
            //vPdf = RecuperoElencoFile(); //assegno a vPdf il numero dei file contenuti nella directory
            //List<string> Text = GetFileList(); //Legge tutti i file di una cartella e salva l'indirizzo in una lista

            // 2. Recupero elenco file
            var files = GetFileList(sDirPath); //elenco path files in var files di tipo lista

            foreach (var file in files) //per ogni file contenuto in files
            {

                // 3. lettura
                var text = ReadFile(file.FullName); //In text l'intero path del file 

                // 4. interpretazione file
                var report = Parse(text); //In report i dati estratti

                // 5. salvataggio csv
                Save(report, $"{file.Name}.csv"); //salva i file in formato csv nella stessa directory di dove li ha presi

            }

        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        Console.ReadLine();
    }

    private static void Save(Report report, string v)
    {
        throw new NotImplementedException();
    }

    private static Report Parse(string text)
    {
        return new Report() { };
    }

    private static string ReadFile(string file)
    {
        throw new NotImplementedException();
    }


    #region recupero l'elenco del percorso dei file
    public static List<string> RecuperoElencoFile()
    {
        var vPdf = Directory.GetFiles(sDirPath).ToList(); //assegno i nomi dei file contenuti nella directory all'array
        Console.WriteLine($"Number of files: {vPdf.Count}."); //stampa il numero dei file contenuti nella directory
        return vPdf;
    }
    #endregion


    #region leggo il testo dei file contenuti nella directory
    public static List<FileInfo> GetFileList(string sDirPath)
    {
        return Directory.GetFiles(sDirPath).ToList();
        string[] extractedtext = new string[pdflist.Count]; //creo un array di dimensione n file contenuti nella directory
        int i = 0;
        foreach (string path in pdflist) //per ogni percorso (del file) contenuto nell'array di percorsi (vpdf)
        {
            text = pdftextextractor.extracttext(filename); //assegna alla variabile text il testo estratto
            extractedtext[i] = text; //assegno alla posizione 'i' di un array di stringhe il contenuto di text /////sostituire text con extractedtext
            messagebox.show($"{extractedtext[i]}"); //prova visualizzazione //////////da togliere
            i += 1;
        }
        return extractedtext;
    }
    #endregion


    //Estrae il testo e lo salva in un file .csv
    public string extractText(string filename)
    {
        string pdfText = "";
        try  
        {
            string sFilename = $"C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Progetti\\ExtractTextFromPdfMVC\\PDF\\{filename}.pdf"; 

            PdfReader pdf_Reader = new PdfReader(sFilename);

            for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
            {
                pdfText = pdfText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            }

            List<string> campi = new List<string>(); 
            campi = pdfText.Split('\n').ToList(); //partiziona il testo estratto in più stringhe
            SalvataggioCSV(filename, campi);
        }
        catch (Exception e)
        {
            pdfText = $"ERROR: {e}";
        }
        return pdfText;
    }
    #region salvo i file in formato csv in un'altra directory
    public void SalvataggioCSV(string filename, List<string> linea)
    {
        System.IO.File.WriteAllLines($"C:\\Users\\Giorgio Della Roscia\\Desktop\\Andamento latte\\Tabelle\\csv\\{filename}.csv", linea.ToArray());
    }
    #endregion
}


//riferimento a "file:///C:/Users/Giorgio%20Della%20Roscia/Desktop/Andamento%20latte/allegati/LM_DILORENZO__OTTOBRE.pdf"
//Dictionary<string/*prima riga (es: "Lattosio"), double /*dati> valori = new Dictionary<string, double>()
//{
//    { "Grasso", 3.77 },
//    { "Grasso (per calcolo)", 3.88 },
//    { "Proteine", 3.58 },
//    { "Proteine (per calcolo)", 3.69 },
//    { "Lattosio", 4.52 },
//    { "Residuo secco magro", 8.79 },
//    { "pH", 6.58 }
//    //etc.
//};
//foreach (KeyValuePair<string, int> valori in valore)
//{
//    Console.WriteLine(valore.Key + " is " +valore.Value + " years old");
//}