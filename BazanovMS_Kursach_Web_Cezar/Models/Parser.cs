using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BazanovMS_Kursach_Web_Cezar.Models
{
    //класс для парсинга файлов
    public class Parser
    {
        public static string ParseTxt(string filename)
        {
            string s = "";
            try
            {
                using (StreamReader streamReader = new StreamReader(filename, Encoding.GetEncoding(1251)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        s += streamReader.ReadLine() + "\n";
                    }
                }
            }
            catch (Exception) { return ""; }
            return s;
        }

        public static string ParseDocx(string filename)
        {
            string s = "";
            try
            {
                using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filename, true))
                {
                    // Assign a reference to the existing document body.
                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    // Add a paragraph with some text.
                    foreach (var item in body)
                    {
                        if (item.GetType().ToString() == "DocumentFormat.OpenXml.Wordprocessing.SectionProperties")
                        {
                            break;
                        }
                        Paragraph para = (Paragraph)item;
                        s += para.InnerText+"\n";
                    }
                }
                return s;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //дает текст файлов
        public static string GetFileText(string fileName)
        {
            try
            {
                string AllFileText = "";

                Regex regexDocx = new Regex(@"[^/*<>|+%!@]+.docx$");
                Regex regexTxt = new Regex(@"[^/*<>|+%!@]+.txt$");

                if (regexDocx.IsMatch(fileName))
                {
                    AllFileText = ParseDocx(fileName);
                }
                else if (regexTxt.IsMatch(fileName))
                {
                    AllFileText = ParseTxt(fileName);
                }
                else throw new Exception();

                return AllFileText;
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}