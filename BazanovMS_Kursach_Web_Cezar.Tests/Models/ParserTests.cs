using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazanovMS_Kursach_Web_Cezar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BazanovMS_Kursach_Web_CezarTests.Models
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParseTxtTest()
        {
            string txtExpected = "Срйётвднба, фэ срнхщкн кучрёпэл фжмуф!!!\n\n\n" +
                "Д сткпшксж српбфю, щфр фхф кусрнюйхжфуб ъкцт Шжйвтб пж рургр фтхёпр, рупрдпвб йведрйёмв уруфркф д фро, щфргэ ргэетвфю увох укфхвшка у ёжъкцтрдмрл к рстжёжнжпкжо пвствднжпкб к ъвев уёдкев. Фжсжтю ёжнр руфвнрую йв овнэо, ёрёжнвфю стретвоох ёр нрекщжумрер мрпшв, дэсрнпкфю дуж хунрдкб йвёвпкб к рсхгнкмрдвфю удра твгрфх! Орнрёжш, яфр гэнк ёруфвфрщпр фтхёпэж к кпфжтжупэж ёдв у срнрдкпрл ожубшв, пр дсжтжёк пву иёжф жыж оприжуфдр рфмтэфкл, к б пвёжаую ргыкч уджтъжпкл!\n" +
                "Рф нкшв мросвпкк FirstLineSoftware к Хпкджтукфжфв КФОР, б твё срйётвдкфю фжгб у рцкшквнюпэо рмрпщвпкжо пвъкч мхтурд У# ёнб пвщкпваыкч! Оэ чрфко срижнвфю хусжчрд д ёвнюпжлъжо сретхижпкк д окт КФ к стретвооктрдвпкб у кусрнюйрдвпкжо уфжмв фжчпрнрекл .Net, ортж фжтсжпкб к кпфжтжупэч йвёвщ!\n";
            string txtActual = Parser.ParseTxt("Result.txt");
            System.Diagnostics.Debug.WriteLine(txtExpected);
            System.Diagnostics.Debug.WriteLine(txtActual);
            Assert.AreEqual(txtExpected, txtActual);
            try
            {
                txtActual = Parser.ParseTxt("Rest.txt");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ParseDocxTest()
        {
            string docxExpected = "Срйётвднба, фэ срнхщкн кучрёпэл фжмуф!!!\n" +
                "Д сткпшксж српбфю, щфр фхф кусрнюйхжфуб ъкцт Шжйвтб пж рургр фтхёпр, рупрдпвб йведрйёмв уруфркф д фро, щфргэ ргэетвфю увох укфхвшка у ёжъкцтрдмрл к рстжёжнжпкжо пвствднжпкб к ъвев уёдкев. Фжсжтю ёжнр руфвнрую йв овнэо, ёрёжнвфю стретвоох ёр нрекщжумрер мрпшв, дэсрнпкфю дуж хунрдкб йвёвпкб к рсхгнкмрдвфю удра твгрфх! Орнрёжш, яфр гэнк ёруфвфрщпр фтхёпэж к кпфжтжупэж ёдв у срнрдкпрл ожубшв, пр дсжтжёк пву иёжф жыж оприжуфдр рфмтэфкл, к б пвёжаую ргыкч уджтъжпкл!\n" +
                "Рф нкшв мросвпкк FirstLineSoftware к Хпкджтукфжфв КФОР, б твё срйётвдкфю фжгб у рцкшквнюпэо рмрпщвпкжо пвъкч мхтурд У# ёнб пвщкпваыкч! Оэ чрфко срижнвфю хусжчрд д ёвнюпжлъжо сретхижпкк д окт КФ к стретвооктрдвпкб у кусрнюйрдвпкжо уфжмв фжчпрнрекл .Net, ортж фжтсжпкб к кпфжтжупэч йвёвщ!\n";
            string docxActual = Parser.ParseDocx(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Result.docx"));
            Assert.AreEqual(docxExpected, docxActual);
            try
            {
               docxActual = Parser.ParseDocx("Rest.docx");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
