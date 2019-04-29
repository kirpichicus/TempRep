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
    public class CezarTests
    {
        [TestMethod()]
        public void ToCesarTest()
        {
            string s1 = Cezar.ToCesar("Как дела? Привет! Чем занимашеься?", 5);
            Assert.AreEqual("Пеп ийре? Фхнжйч! Ьйс метнсеэйбцд?", s1);

            s1 = Cezar.ToCesar("Коты не программируют! Коты гадят и разрабатывают план по захвату мира(", -6);
            Assert.AreEqual("Еимх зя йкиэкъжжгкншм! Еимх эъющм г къвкъыъмхьъшм йёъз йи въпьъмн жгкъ(", s1);

        }

        [TestMethod()]
        public void AutoDeCryptTest()
        {
            int Shift = Cezar.AutoDeCrypt("Щфцюъ щр яхпрю ъю ыьлнъэяпфк! К юяю эяпзк! Щр мроф нырьрп млюзцф!", "word-lib.txt");
            Assert.AreEqual(21, Shift);

            Shift = Cezar.AutoDeCrypt("Аздцр вдш едщивхзс, мзд еёдшёхввюёдчхгюъ - тзд щдчдбсгд чъжъбд ю еёюадбсгд!", "word-lib.txt");
            Assert.AreEqual(11, Shift);

        }
    }
}