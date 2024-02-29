using FryingPanParser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TeamFinalProject
{
    public class RozetkaParcer
    {
        ChromeDriver driver = new ChromeDriver();
        public List<Manufacturer> manufacturers = new List<Manufacturer>();
        public List<FryingPan> fryingPans = new List<FryingPan>();
        public List<Manufacturer> ManufacturerParcer()
        {
            List<Manufacturer> result = new List<Manufacturer>();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.Url = "https://rozetka.com.ua/skovorody/c4626754/#search_text=%D1%81%D0%BA%D0%BE%D0%B2%D0%BE%D1%80%D1%96%D0%B4%D0%BA%D0%B0";
            var findManufacturerName = driver.FindElements(By.ClassName("checkbox-filter__item"));
            foreach(var element in findManufacturerName) 
            {
                
                string originalLine = element.Text.Replace("'", "-");
                int lastSpaceIndex = originalLine.LastIndexOf(' ');
                
              
                if (lastSpaceIndex != -1)
                {
                    string modifiedLine = originalLine.Substring(0, lastSpaceIndex).Trim();
                    Console.WriteLine(modifiedLine);
                    
                    var manufacturer1 = new Manufacturer($"{modifiedLine}");
                    result.Add(manufacturer1);
                }
            }
            //foreach(var manufacturer in manufacturers)
            //{
            //    Console.WriteLine(manufacturer);
            //}

            return result;
        }
        public List<FryingPan> FryingPanParcer()
        {
            List<FryingPan> result = new List<FryingPan>();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.Url = "https://rozetka.com.ua/skovorody/c4626754/#search_text=%D1%81%D0%BA%D0%BE%D0%B2%D0%BE%D1%80%D1%96%D0%B4%D0%BA%D0%B0";
            var skovorodki = driver.FindElements(By.ClassName("catalog-grid__cell"));

            foreach(var skovorodka in skovorodki)
            {
                var FryingPanNames = skovorodka.FindElement(By.ClassName("goods-tile__title"));
                var FryingPanPrices = skovorodka.FindElement(By.ClassName("goods-tile__price-value"));

                FryingPanPrices.Text.Replace("'", " ");
                FryingPanPrices.Text.Replace("?", " ");
                
                var fryingPan = new FryingPan($"{FryingPanNames.Text}", int.Parse(FryingPanPrices.Text.Substring(1, FryingPanPrices.Text.Length - 1).Replace("'", "").Replace("?", "")));
                result.Add(fryingPan);
            }
            return result;
        }
    }
}
