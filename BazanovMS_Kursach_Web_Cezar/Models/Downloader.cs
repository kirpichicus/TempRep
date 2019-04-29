using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BazanovMS_Kursach_Web_Cezar.Models
{
    public class Downloader
    {
        //класс для сохранения файлов
        public static void MakeTxtFile(string Encrypted,string fileName)
        {
           try
            {
                Regex regexTxt = new Regex(@"[^/*<>|+%!@]+.txt$");//сделанно только для тестов
                if (!regexTxt.IsMatch(fileName)) throw new Exception();

                File.WriteAllText(fileName, Encrypted);
            }
            catch (Exception x){ }
        }

        public static void MakeDocxFile(string Encrypted, string fileName)
        {
            try
            {
                Regex regexDocx = new Regex(@"[^/*<>|+%!@]+.docx$");//сделанно только для тестов
                if (!regexDocx.IsMatch(fileName)) throw new Exception();

                List<string> stringi = Encrypted.Split('\n').ToList<string>();
                using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Create(fileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordprocessingDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    // Вы реально читаете код??
                    Body body = mainPart.Document.AppendChild(new Body());
                    // Add new text.
                    foreach (var item in stringi)
                    {
                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        run.AppendChild(new Text(item));
                    }
                    // Close the handle explicitly.
                    wordprocessingDocument.Close();
                }
            }
            catch (Exception x) { }
        }
    }
}