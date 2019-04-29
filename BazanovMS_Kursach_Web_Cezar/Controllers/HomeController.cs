using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BazanovMS_Kursach_Web_Cezar.Models;

namespace BazanovMS_Kursach_Web_Cezar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Shifte = 0;
            return View();
        }
        
        
        //заружаем файл на сервер и вставлям его текст в поле
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase download)
        {
            try
            {
                //Очищает папку с файлами
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Files/"));

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }

                if (download == null)
                {
                    return View("Index");
                }
                string fileName = Path.GetFileName(download.FileName);
                download.SaveAs(Server.MapPath("~/Files/" + fileName));


                string AllFileText = Parser.GetFileText(Server.MapPath("~/Files/" + fileName));
                // получаем имя файла
               
                ViewBag.Text = AllFileText;
            }
            catch (Exception) { }

            return View("Index");
        }
        //шифруем текст
        public ActionResult Encrypt(string InputText, bool Enable, string Shifte)
        {
            try
            {
                ViewBag.Text = InputText;

                int Shift;
                if (Enable)
                {
                    Shift = Cezar.AutoDeCrypt(InputText, Server.MapPath("~/Library/") + "word-lib.txt");
                }
                else
                {
                    if (!Int32.TryParse(Shifte, out Shift))
                    {
                        ViewBag.Text = InputText;
                        return View("Index");
                    }
                }
                string temp = "";
                temp = InputText;


                temp = Cezar.ToCesar(temp, Shift);
                ViewBag.Encrypted = temp;
                ViewBag.Shifte = Shift;

                return View("Index");
            }
            catch(Exception)
            {
                ViewBag.Text = InputText;
                ViewBag.Shifte = Shifte;
                return View("Index");
            }
            
        }
        //скачиваем файл
        public FilePathResult DownloadFile(string Encrypted,string fileExtension)
        {
            try
            {
                string postfix = "";
                if (fileExtension == "docx")
                {
                    postfix = ".docx";
                    Downloader.MakeDocxFile(Encrypted, Server.MapPath("~/Files/") + "Cezar" + postfix);
                }
                else if (fileExtension == "txt")
                {
                    postfix = ".txt";
                    Downloader.MakeTxtFile(Encrypted, Server.MapPath("~/Files/") + "Cezar" + postfix);
                }

                string file_path = (Server.MapPath("~/Files/") + "Cezar" + postfix);
                string file_type = "application/" + postfix;
                string file_name = "Cezar" + postfix;
                return File(file_path, file_type, file_name);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Основная информация о приложении";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Мои основные контактные данные";

            return View();
        }
    }
}