using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Automation;

public class authProfessor
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
         driver = new ChromeDriver();
    }

    [Test]
    public void LoginProfessor()
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
        userName.SendKeys("maribel");
        Thread.Sleep(2500);
        var password = driver.FindElement(By.Name("password"));
        password.SendKeys("maribel");
        Thread.Sleep(2500);
        var sendButton = driver.FindElement(By.Id("send"));
        sendButton.Click();
        Thread.Sleep(4000);
        //enter to a dashboard
        var dashButton = driver.FindElement((By.Id("dashboard")));
        dashButton.Click();
        Thread.Sleep(8000);
        //enter  to a cv
        var cvButton = driver.FindElement((By.Id("cv")));
        cvButton.Click();
        Thread.Sleep(5000);
        //enter  to a dashboard
        var consultProposalButton = driver.FindElement((By.Id("proposal-repository")));
        consultProposalButton.Click();
        Thread.Sleep(5000);
        var viewProposalButton = driver.FindElement((By.Id("details")));
        viewProposalButton.Click();
        Thread.Sleep(5500);
        var closeviewButton = driver.FindElement((By.Id("closeDetails")));
        closeviewButton.Click();
        Thread.Sleep(2500);
        var historyProposalButton = driver.FindElement((By.Id("history")));
        historyProposalButton.Click();
        Thread.Sleep(5500);
        var closeHistoryButton = driver.FindElement((By.Id("closeHistory")));
        closeHistoryButton.Click();
        Thread.Sleep(2500);
        var qualifyButton = driver.FindElement((By.Id("qualify")));
        qualifyButton.Click();
        Thread.Sleep(3000);
        var selectElement = driver.FindElement(By.Name("status"));
        var option = selectElement.FindElement(By.CssSelector("option[value='Aprobado']"));
        option.Click();
        Thread.Sleep(2500);
        var comment = driver.FindElement(By.Name("comment"));
        comment.SendKeys("su propuesta ha sido aprobada, felicitaciones.");
        Thread.Sleep(2500);
        var submit = driver.FindElement((By.Id("submit")));
        submit.Click();
        Thread.Sleep(5000);
        driver.Close();
        Assert.Pass();
    }

}
