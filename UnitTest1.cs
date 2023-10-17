using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;
using System.Xml.Linq;

namespace SeleniumCsharp
{
    public class Tests
    {

        IWebDriver driver;
        String test_url = "https://vladimirdudakov22.thkit.ee";
        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Thread.Sleep(2500);
        }
        [Test]
        public void test() { 
            driver.Navigate().GoToUrl(test_url);
            try
            {
                Thread.Sleep(2500);
                IWebElement header = driver.FindElement(By.TagName("header"));
                IList<IWebElement> h1Elements = header.FindElements(By.TagName("h1"));
                IList<IWebElement> h2Elements = header.FindElements(By.TagName("h2"));

                foreach (IWebElement element in h1Elements)
                {
                    Thread.Sleep(5000);
                    string text = element.Text;
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    bool isHighlighted = element.GetCssValue("background-color").Equals("orange");
                    Assert.IsTrue(isHighlighted, "Элемент не подсвечивается.");
                }

                foreach (IWebElement element in h2Elements)
                {
                    Thread.Sleep(5000);
                    string text = element.Text;
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    bool isHighlighted = element.GetCssValue("background-color").Equals("orange");
                    Assert.IsTrue(isHighlighted, "Элемент не подсвечивается.");
                }
            }
            catch (Exception) { }
            try { 
            //// Находим элемент, к которому хотим подвести курсор
            IWebElement nav = driver.FindElement(By.Id("hide"));
            IList<IWebElement> liElements = nav.FindElements(By.CssSelector("ul > li"));

            foreach (IWebElement liElement in liElements)
            {
                Thread.Sleep(5000);
                // Выполните нужные действия с каждым элементом li
                string text = liElement.Text;
                // ... остальные действия
                Actions actions = new Actions(driver);

                // Подводим курсор к элементу
                actions.MoveToElement(liElement).Perform();
                

                // Проверяем, что элемент подсвечивается (например, изменяется цвет фона или бордюра)
                bool isHighlighted = liElement.GetCssValue("background-color").Equals("deepskyblue");
                

                // Делаем утверждение (assert), чтобы проверить, подсвечивается ли элемент
                Assert.IsTrue(isHighlighted, "Элемент не подсвечивается.");
                
            }
            } catch (Exception) { }


            // Нажимаем кнопку "Avaleht, Tööd, Materjalid, WB portfoolio" (Показать данные)
            try
            {
                IWebElement showDataButton = driver.FindElement(By.XPath("//a[contains(@href, 'index.html')]"));
                showDataButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Элемент не найден: " + ex.Message);
                // Здесь вы можете выполнить другие действия при отсутствии элемента
            }

            try
            {
                IWebElement showDataButton1 = driver.FindElement(By.XPath("//a[contains(@href, 'tood.html')]"));
                showDataButton1.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Элемент не найден: " + ex.Message);
            }

            try
            {
                IWebElement showDataButton2 = driver.FindElement(By.XPath("//a[contains(@href, 'materjalid.html')]"));
                showDataButton2.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Элемент не найден: " + ex.Message);
            }

            try
            {
                IWebElement showDataButton3 = driver.FindElement(By.XPath("//a[contains(@href, 'https://vladimirdudakov22.thkit.ee/wp')]"));
                showDataButton3.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Элемент не найден: " + ex.Message);
            }

            // Закрываем браузер
            driver.Quit();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}

//namespace TestProject
//{
//    public class WebPageTests
//    {
//        IWebDriver driver;
//        String test_url = "";
//        private readonly Random _random = new Random();

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();

//            // Открываем веб-страницу
//            driver.Url = test_url;

//            // Получаем заголовок страницы
//            string pageTitle = driver.Title;

//            // Проверяем, что заголовок страницы содержит ожидаемый текст
//            Assert.AreEqual("Vladimir Koduleht", pageTitle);
//            //driver.Navigate().GoToUrl(test_url);
//            //// Получаем заголовок страницы
//            //string pageTitle = driver.Title;
//            //// Проверяем, что заголовок страницы содержит ожидаемый текст
//            //Assert.AreEqual("Vladimir Koduleht", pageTitle);

//            driver.Quit();
//        }


//        //[Test]
//        //public void TestPageTitle()
//        //{
//        //    // Открываем веб-страницу
//        //    driver.Url = "vladimirdudakov22.thkit.ee";
//        //    // Получаем заголовок страницы
//        //    string pageTitle = driver.Title;
//        //    // Проверяем, что заголовок страницы содержит ожидаемый текст
//        //    Assert.AreEqual("Vladimir Koduleht", pageTitle);
//        //}
//        [TearDown]
//        public void Cleanup()
//        {
//            // Завершение сеанса браузера и освобождение ресурсов
//            driver.Quit();
//        }
//    }
//}
//// Заполняем поле "Eesnimi" (Имя)
//IWebElement firstNameField = driver.FindElement(By.Id("eesnimi"));
//firstNameField.SendKeys("Arina");

//// Заполняем поле "Perekonnanimi" (Фамилия)
//IWebElement lastNameField = driver.FindElement(By.Id("perekonnanimi"));
//lastNameField.SendKeys("Nikulina");

//// Выбираем опции из выпадающих списков
//SelectElement genderDropdown = new SelectElement(driver.FindElement(By.Id("sugu")));
//genderDropdown.SelectByValue("mees");

//SelectElement educationDropdown = new SelectElement(driver.FindElement(By.Id("haridus")));
//educationDropdown.SelectByValue("keskharidus");

//SelectElement languageDropdown = new SelectElement(driver.FindElement(By.Id("keel")));
//languageDropdown.SelectByValue("B1");
//IWebElement showDataButton = driver.FindElement(By.Id("kuva-andmed"));
//showDataButton.Click();

// Проверяем результаты опроса (здесь вы можете добавить дополнительные проверки по вашему усмотрению)
//IWebElement surveyResult = driver.FindElement(By.Id("tulemus"));
//Assert.IsTrue(surveyResult.Text.Contains("Arina") && surveyResult.Text.Contains("Nikulina"));



//IWebElement element = driver.FindElement(By.XPath("//a[contains(@href, 'index.html')]"));
//IWebElement element1 = driver.FindElement(By.XPath("//a[contains(@href, 'tood.html')]"));
//IWebElement element2 = driver.FindElement(By.XPath("//a[contains(@href, 'materjalid.html')]"));
//IWebElement element3 = driver.FindElement(By.XPath("//a[contains(@href, 'https://vladimirdudakov22.thkit.ee/wp')]"));

//// Создаем объект Actions
//Actions actions = new Actions(driver);

//// Подводим курсор к элементу
//actions.MoveToElement(element).Perform();
//actions.MoveToElement(element1).Perform();
//actions.MoveToElement(element2).Perform();
//actions.MoveToElement(element3).Perform();

//// Проверяем, что элемент подсвечивается (например, изменяется цвет фона или бордюра)
//bool isHighlighted = element.GetCssValue("background-color").Equals("turquoise");
//bool isHighlighted1 = element1.GetCssValue("background-color").Equals("turquoise");
//bool isHighlighted2 = element2.GetCssValue("background-color").Equals("turquoise");
//bool isHighlighted3 = element3.GetCssValue("background-color").Equals("turquoise");

//// Делаем утверждение (assert), чтобы проверить, подсвечивается ли элемент
//Assert.IsTrue(isHighlighted, "Элемент не подсвечивается.");
//Assert.IsTrue(isHighlighted1, "Элемент не подсвечивается.");
//Assert.IsTrue(isHighlighted2, "Элемент не подсвечивается.");
//Assert.IsTrue(isHighlighted3, "Элемент не подсвечивается.");