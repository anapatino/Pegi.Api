using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
namespace SeleniumTest;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void ConsultProposal()
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
        //enter to cv
        var cvButton = driver.FindElement((By.Id("cv")));
        cvButton.Click();
        Thread.Sleep(5000);
        //enter to cv
        var consultProposal = driver.FindElement((By.Id("table-of-proposals")));
        consultProposal.Click();
        Thread.Sleep(5000);
        var viewProposalButton = driver.FindElement((By.Id("details")));
        viewProposalButton.Click();
        Thread.Sleep(5500);
        var closeDetails = driver.FindElement((By.Id("closeDetails")));
        closeDetails.Click();
        Thread.Sleep(2500);
        var historyProposalButton = driver.FindElement((By.Id("history")));
        historyProposalButton.Click();
        Thread.Sleep(5500);
        var closeHistoryButton = driver.FindElement((By.Id("closeHistory")));
        closeHistoryButton.Click();
        Thread.Sleep(2500);
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

    [Test]
    public void Login()
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
        Thread.Sleep(6000);
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

    [Test]
        public void RegisterPropoposal()
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
            Thread.Sleep(6000);
            //enter to a dashboard
            var proposal = driver.FindElement((By.Id("proposal")));
            proposal.Click();
            Thread.Sleep(2500);
            var title = driver.FindElement(By.Name("title"));
            title.SendKeys("Esto es un titulo");
            Thread.Sleep(2500);
            var personDocument = driver.FindElement(By.Name("personDocument"));
            personDocument.SendKeys("1067590360");
            Thread.Sleep(2500);
            var codeLine = driver.FindElement(By.Name("codeLine"));
            var optionCodeLine = codeLine.FindElement(By.CssSelector("option[value='2222']"));
            optionCodeLine.Click();
            Thread.Sleep(2500);
            var codeSubline = driver.FindElement(By.Name("codeSubline"));
            var optionCodeSubline = codeSubline.FindElement(By.CssSelector("option[value='444']"));
            optionCodeSubline.Click();
            Thread.Sleep(2500);
            var thematicAreaCode = driver.FindElement(By.Name("thematicAreaCode"));
            var optionThematicAreaCode = thematicAreaCode.FindElement(By.CssSelector("option[value='88']"));
            optionThematicAreaCode.Click();
            Thread.Sleep(2500);
            var investigationGroup = driver.FindElement(By.Name("investigationGroup"));
            investigationGroup.SendKeys("Esto es un grupo de investigacion");
            Thread.Sleep(2500);
            var approach = driver.FindElement(By.Name("approach"));
            approach.SendKeys("esto es una problematica");
            Thread.Sleep(2500);
            var justification = driver.FindElement(By.Name("justification"));
            justification.SendKeys("Esto es una justificacion");
            Thread.Sleep(2500);
            var generalObjective = driver.FindElement(By.Name("generalObjective"));
            generalObjective.SendKeys("Esto es un objetivo general");
            Thread.Sleep(2500);
            var specificObjective = driver.FindElement(By.Name("specificObjective"));
            specificObjective.SendKeys("Esto es un objetivo especifico");
            Thread.Sleep(2500);
            var bibliographical = driver.FindElement(By.Name("bibliographical"));
            bibliographical.SendKeys("Esto es una biliografia");
            Thread.Sleep(2500);
            var submit = driver.FindElement((By.Id("submit")));
            submit.Click();
            Thread.Sleep(3000);
            driver.Close();

            Assert.Pass();
        }

        [Test]
        public void RegisterProyect()
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
            Thread.Sleep(6000);
            //enter to  project
            var project = driver.FindElement((By.Id("project")));
            project.Click();
            Thread.Sleep(2500);
            var proposalCode = driver.FindElement(By.Name("proposalCode"));
            var optionProposalCode = proposalCode.FindElement(By.CssSelector("option[value='840267774']"));
            optionProposalCode.Click();
            Thread.Sleep(2500);
            var content = driver.FindElement(By.Name("content"));
            content.SendKeys("https://docs.google.com/document/d/1-SVpTkUos4Ae9C8WxUiJpPCRd8iTlPal/edit#");
            Thread.Sleep(2500);
            var submit = driver.FindElement((By.Id("submit")));
            submit.Click();
            Thread.Sleep(3000);

            driver.Close();

            Assert.Pass();
        }
}
