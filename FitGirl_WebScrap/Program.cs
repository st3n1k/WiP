using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WiP.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WiP.Core.Interfaces;
using WiP.Infrastructure;
using WiP.Infrastructure.Data.Repository;
using WiP.Core.Interfaces.Repositories;
using WiP.Core.Entity;

namespace FitGirl_WebScrap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .AddEnvironmentVariables();
            // ovdje treba dodati da se u zavisnosti od environmenta cita odgovarajuci appsettings.json

            IConfigurationRoot config = builder.Build();

            string readConnectionString = config["ConnectionStrings:Connection"];

            var serviceProvider = new ServiceCollection()
                .AddDbContext<WiPContext>(x => x.UseMySql(readConnectionString, ServerVersion.AutoDetect(readConnectionString)))
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddSingleton(typeof(IGenericRepository<>), (typeof(GenericRepository<>)))

                .BuildServiceProvider();

            var _unitOfWork = serviceProvider.GetService<IUnitOfWork>();


            // Set up ChromeDriver
            IWebDriver driver = new ChromeDriver();

            // Navigate to the demo website
            driver.Navigate().GoToUrl("https://fitgirl-repacks.site/");

            // Add your scraping logic here

            // Find elements that contain the product details
            ReadPage(driver, _unitOfWork);

            // Close the browser
            driver.Quit();
        }
        private static void ReadPage(IWebDriver driver, IUnitOfWork _unitOfWork)
        {
            IReadOnlyCollection<IWebElement> gameArticles = driver.FindElements(By.ClassName("category-lossless-repack"));

            // Loop through the product elements and extract the desired information
            foreach (IWebElement gameItem in gameArticles)
            {
                // Extract the name and price of the product
                string name = gameItem.FindElement(By.CssSelector(".entry-title a")).Text;

                _unitOfWork.Repository<GameEntity>().Add(new GameEntity() { Title = name });

                _unitOfWork.Complete();

                //string image = gameItem.FindElement(By.CssSelector(".entry-content p a img")).GetAttribute("src");

                Console.WriteLine(string.Format("Game:{0}", name));

            }

            IWebElement nextPageBtn = driver.FindElement(By.CssSelector("a.next.page-numbers"));

            if (nextPageBtn != null)
            {
                nextPageBtn.Click();
                ReadPage(driver, _unitOfWork);
            }
        }
    }
}
