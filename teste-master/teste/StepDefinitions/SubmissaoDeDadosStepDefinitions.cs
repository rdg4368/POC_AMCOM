using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using teste.Drivers;
using teste.Pages;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Runtime.ConstrainedExecution;
using teste.Support;

namespace teste.StepDefinitions
{
    [Binding]
    public class SubmissaoDeDadosStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        Browser browser = new Browser();
        Formulario01 formulario = new Formulario01();
        //Ultils support = new Ultils();

        //[BeforeTestRun]
        //public void abreNavegador()
        //{
        //    //browser.abreNavegador(driver, "https://amcomtesteqa.z15.web.core.windows.net/");
        //}

        //[AfterTestRun]
        //public void fecharNavegador()
        //{
        //    if (driver != null)
        //    {
        //        browser.driveClose(driver);
        //    }
        //    else throw new Exception("Erro durante o fechamento do browser");
        //}

        [Given(@"que estou na principal")]

        public void GivenQueEstouNaPrincipal()
        {
            Thread.Sleep(1000);
            browser.abreNavegador(driver, "https://amcomtesteqa.z15.web.core.windows.net/");
        }

        [When(@"preencher os dados com valores válidos")]
        public void WhenPreencherOsDadosComValoresValidos()
        {
            formulario.CampoNome(driver, "Rodrigo");
            formulario.CampoSobreNome(driver, "Barbosa");
            formulario.CampoTelefone(driver, "61 988898889");
        }

        [When(@"submeto o formulário")]
        public void WhenSubmetoOFormulario()
        {
            formulario.BtnSubmeter(driver);
        }

        [Then(@"devo receber uma modal com a mensagem de sucesso")]
        public void ThenDevoReceberUmaModalComAMensagemDeSucesso()
        {
            formulario.MsgCadastroSucesso(driver, "Enviado com sucesso");
            // Não está funcionando, inclusive foi aberto uma issue no https://github.com/SpecFlowOSS/SpecFlow/issues/2696
            //support.Screenshot(driver, "E:\\screenshot");
        }

        [Then(@"fecho a modal")]
        public void ThenFechoAModal()
        {
            formulario.FecharModal(driver);
        }

        [When(@"preencher o nome ""([^""]*)""")]
        public void WhenPreencherONome(string nome)
        {
            formulario.CampoNome(driver, nome);
        }

        [When(@"preencher o sobrenome ""([^""]*)""")]
        public void WhenPreencherOSobrenome(string sobrenome)
        {
            formulario.CampoSobreNome(driver, sobrenome);
        }

        [Then(@"devo receber uma modal com a ""([^""]*)""")]
        public void ThenDevoReceberUmaModalComA(string mensagem)
        {
            formulario.MsgcamposObrigatórios(driver, mensagem);
        }

        [When(@"preencher o dado telefone ""([^""]*)""")]
        public void WhenPreencherODadoTelefone(string telefone)
        {
            formulario.CampoTelefone(driver, telefone);
        }

        [When(@"alterar o checkbox com a ""([^""]*)""")]
        public void WhenAlterarOCheckboxComA(string cor)
        {
            formulario.SelecionarCor(driver, cor);
        }

        [Then(@"deve ser alterada a ""([^""]*)""")]
        public void ThenDeveSerAlteradaA(string cor_de_fundo)
        {
            formulario.ValidarCorHomePage(driver, cor_de_fundo);
        }

        [When(@"alterar submeter a saudacao")]
        public void WhenAlterarSubmeterASaudacao()
        {
            formulario.BtnSubmeterSaudacao(driver);
        }

        [Then(@"devo receber uma modal com mensagem de saudação")]
        public void ThenDevoReceberUmaModalComMensagemDeSaudacao()
        {
            formulario.MsgSaudacao(driver);
            browser.driveClose(driver);
        }
    }
}
