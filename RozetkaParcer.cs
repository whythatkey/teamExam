using FryingPanParser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using System.Security.Cryptography.X509Certificates;

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
            var findFryingPanName = driver.FindElements(By.ClassName("goods-tile__title"));
            var findFryingPanPrice = driver.FindElements(By.ClassName("__price-value"));
            var origText = 0;
            foreach(var element in findFryingPanName) 
            {
                //Console.WriteLine(element.Text);
                foreach(var price in findFryingPanPrice)
                {
                    origText = int.Parse(price.Text);
                }
                var fryingPan = new FryingPan($"{element.Text}", origText);
                result.Add(fryingPan);
            }
            //foreach(var item in fryingPans)
            //{
            //    Console.WriteLine(item);
            //}

            return result;
            
        }
    }
}
