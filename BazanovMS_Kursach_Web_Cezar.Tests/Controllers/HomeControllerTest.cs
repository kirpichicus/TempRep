using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazanovMS_Kursach_Web_Cezar;
using BazanovMS_Kursach_Web_Cezar.Controllers;

namespace BazanovMS_Kursach_Web_Cezar.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Upload()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Upload(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod()]
        //public void DownloadFileTest()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    FilePathResult file = controller.DownloadFile("dsf", ".docx");
        //    FilePathResult file1 = controller.DownloadFile("dsf", "txt");

        //    // Assert
        //    Assert.IsNotNull(file);
        //    Assert.IsNotNull(file1);
        //}

        [TestMethod]
        public void AboutTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
        //[TestMethod] 
        //public void EncryptTest()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Encrypt("Одо уфдёмпаст уифищтзмца ыифил зтфтжч?", true, "0") as ViewResult;

        //    Assert.AreEqual("29", result.ViewBag.Shifte);


        //    // Assert

        //}

        [TestMethod]
        public void ContactTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
