using iTextSharp.text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace teste.Pages
{
    public class Formulario01
    {
        IWebElement formulario;

        public void CampoNome(IWebDriver driver, string nome)
        {
            driver.FindElement(By.Id("fname")).SendKeys(nome);
        }

        public void CampoSobreNome(IWebDriver driver, string sobrenome)
        {
            driver.FindElement(By.Id("lname")).SendKeys(sobrenome);
        }

        public void CampoTelefone(IWebDriver driver, string telefone)
        {
            driver.FindElement(By.Id("phone")).SendKeys(telefone);
        }

        public void BtnSubmeter(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//input[@value='Enviar']")).Click();
            Thread.Sleep(2000);
        }

        public void FecharModal(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[@class='close']")).Click();
            driver.Close();
        }

        public void MsgCadastroSucesso(IWebDriver driver, string mensagem)
        {
            var temp = driver.FindElement(By.XPath("//*[@id=\"modal\"]/div/div")).Text;
            string rgx = Regex.Replace(temp, "[×\r\n]+", "");
            Assert.AreEqual(mensagem, rgx);
        }

        public void MsgcamposObrigatórios(IWebDriver driver, string mensagem)
        {
            try
            {
                var temp = driver.FindElement(By.XPath("//*[@id=\"modal\"]/div/div")).Text;
                string rgx = Regex.Replace(temp, "[×\r\n]+", "");
                Assert.AreEqual(mensagem, rgx);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                driver.Quit();
            }
        }


        public void SelecionarCor(IWebDriver driver, string cor)
        {
            new SelectElement(driver.FindElement(By.Id("colors"))).SelectByText(cor);
            var waitColor = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            waitColor.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"card-color\"]")));

            Console.WriteLine(cor);
            Console.WriteLine(waitColor);

            if (cor == "background-color: red")
            {
                Console.WriteLine("Cor do formulário vermelho validado com sucesso!");
            }
            else if (cor == "background-color: blue")
            {
                Console.WriteLine("Cor do formulário azul validado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cor do formulário amarelo validado com sucesso!");
            }
        }

        public void ValidarCorHomePage(IWebDriver driver, string cor_de_fundo)
        {
            var corHome = driver.FindElement(By.XPath("//*[@id=\"card-color\"]"));
            var colorValue = corHome.GetAttribute("style");
            Assert.AreEqual(cor_de_fundo, colorValue);
            driver.Close();
        }

        public void BtnSubmeterSaudacao(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//input[@value='Saudação']")).Click();
            Thread.Sleep(1000);
        }

        public void MsgSaudacao(IWebDriver driver)
        {
            DateTime hora = DateTime.Now;
            var alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Thread.Sleep(1000);
            alert.Accept();

            if (hora.Hour >= 0 && hora.Hour < 12)
            {
                string msg = alertText;
                string bomDia = "Bom dia";
                msg.Contains(bomDia);

                if (alertText == msg)
                {
                    Assert.AreEqual(alertText, bomDia);
                }
            }
            
            else if (hora.Hour >= 12 && hora.Hour < 18)
            {
                string msg = alertText;
                string boaTarde = "Boa tarde";
                msg.Contains(boaTarde);

                if (alertText == msg)
                {
                    Assert.AreEqual(alertText, boaTarde);
                }
            }

            else if (hora.Hour == 18 && hora.Hour < 0)
            {
                string msg = alertText;
                string boaNoite = "Boa noite";
                msg.Contains(boaNoite);
                
                if (alertText == msg)
                {
                    Assert.AreEqual(alertText, boaNoite);
                }
            }
        }
    }
}
