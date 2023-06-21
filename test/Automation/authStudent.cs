using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation;

public class authStudent
{

     private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
         driver = new ChromeDriver();
    }

    [Test]
    public void LoginStudent()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--allow-insecure-localhost");
        driver.Navigate().GoToUrl("https://pegi-web.vercel.app/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(18000);
        var loginButton = driver.FindElement(By.Id("login"));
        loginButton.Click();
        Thread.Sleep(2000);
        var userName = driver.FindElement(By.Name("user"));
        userName.SendKeys("anap");
        Thread.Sleep(2500);
        var password = driver.FindElement(By.Name("password"));
        password.SendKeys("anap");
        Thread.Sleep(2500);
        var sendButton = driver.FindElement(By.Id("send"));
        sendButton.Click();
        Thread.Sleep(4000);
        //enter to a dashboard
        var dashButton = driver.FindElement((By.Id("dashboard")));
        dashButton.Click();
        Thread.Sleep(4000);
        //enter  option
        var isOpen = driver.FindElement((By.Id("react-aria-5")));
        isOpen.Click();
        Thread.Sleep(1500);
        //enter  option logout
        var logout = driver.FindElement(By.XPath("//li[@data-key='logout']"));
        logout.Click();

        driver.Close();

        Assert.Pass();
    }

}
