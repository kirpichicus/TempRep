using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazanovMS_Kursach_Web_Cezar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazanovMS_Kursach_Web_Cezar.Models.Tests
{
    [TestClass()]
    public class DownloaderTests
    {
        [TestMethod()]
        public void MakeDocxFileTest() //можно было бы сделать приватным и рефлексия
        {
            try
            {
                Downloader.MakeDocxFile("text\ntext", "Txt.docx");
                Downloader.MakeDocxFile("text\ntext", "txt.txt");
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void MakeTxtFileTest()
        {
            try
            {
                Downloader.MakeTxtFile("text\ntext", "Txt.docx");
                Downloader.MakeTxtFile("text\ntext", "txt.txt");
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void GetFileTextTest()
        {
            string txtExpected = "Срйётвднба, фэ срнхщкн кучрёпэл фжмуф!!!\n\n\n" +
                "Д сткпшксж српбфю, щфр фхф кусрнюйхжфуб ъкцт Шжйвтб пж рургр фтхёпр, рупрдпвб йведрйёмв уруфркф д фро, щфргэ ргэетвфю увох укфхвшка у ёжъкцтрдмрл к рстжёжнжпкжо пвствднжпкб к ъвев уёдкев. Фжсжтю ёжнр руфвнрую йв овнэо, ёрёжнвфю стретвоох ёр нрекщжумрер мрпшв, дэсрнпкфю дуж хунрдкб йвёвпкб к рсхгнкмрдвфю удра твгрфх! Орнрёжш, яфр гэнк ёруфвфрщпр фтхёпэж к кпфжтжупэж ёдв у срнрдкпрл ожубшв, пр дсжтжёк пву иёжф жыж оприжуфдр рфмтэфкл, к б пвёжаую ргыкч уджтъжпкл!\n" +
                "Рф нкшв мросвпкк FirstLineSoftware к Хпкджтукфжфв КФОР, б твё срйётвдкфю фжгб у рцкшквнюпэо рмрпщвпкжо пвъкч мхтурд У# ёнб пвщкпваыкч! Оэ чрфко срижнвфю хусжчрд д ёвнюпжлъжо сретхижпкк д окт КФ к стретвооктрдвпкб у кусрнюйрдвпкжо уфжмв фжчпрнрекл .Net, ортж фжтсжпкб к кпфжтжупэч йвёвщ!\n";
            string txtActual = Downloader.GetFileText("Result.txt");

            string docxExpected = "Срйётвднба, фэ срнхщкн кучрёпэл фжмуф!!!\n" +
                "Д сткпшксж српбфю, щфр фхф кусрнюйхжфуб ъкцт Шжйвтб пж рургр фтхёпр, рупрдпвб йведрйёмв уруфркф д фро, щфргэ ргэетвфю увох укфхвшка у ёжъкцтрдмрл к рстжёжнжпкжо пвствднжпкб к ъвев уёдкев. Фжсжтю ёжнр руфвнрую йв овнэо, ёрёжнвфю стретвоох ёр нрекщжумрер мрпшв, дэсрнпкфю дуж хунрдкб йвёвпкб к рсхгнкмрдвфю удра твгрфх! Орнрёжш, яфр гэнк ёруфвфрщпр фтхёпэж к кпфжтжупэж ёдв у срнрдкпрл ожубшв, пр дсжтжёк пву иёжф жыж оприжуфдр рфмтэфкл, к б пвёжаую ргыкч уджтъжпкл!\n" +
                "Рф нкшв мросвпкк FirstLineSoftware к Хпкджтукфжфв КФОР, б твё срйётвдкфю фжгб у рцкшквнюпэо рмрпщвпкжо пвъкч мхтурд У# ёнб пвщкпваыкч! Оэ чрфко срижнвфю хусжчрд д ёвнюпжлъжо сретхижпкк д окт КФ к стретвооктрдвпкб у кусрнюйрдвпкжо уфжмв фжчпрнрекл .Net, ортж фжтсжпкб к кпфжтжупэч йвёвщ!\n";
            string docxActual = Downloader.GetFileText("Result.docx");

            Assert.AreEqual(txtExpected, txtActual);
            Assert.AreEqual(docxExpected, docxActual);
            try
            {
                txtActual = Downloader.GetFileText("res.pes");
                docxActual = Downloader.GetFileText("res.shez");
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }
    }
}