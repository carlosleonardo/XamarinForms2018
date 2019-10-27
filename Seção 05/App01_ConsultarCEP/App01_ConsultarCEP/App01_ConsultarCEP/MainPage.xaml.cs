using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnBuscarCEP_Clicked(object sender, EventArgs e)
        {
            string CEP = txtCEP.Text;

            if (string.IsNullOrEmpty(CEP))
            {
                DisplayAlert("ERRO", "Informe CEP", "OK");
                return;
            }
            CEP = CEP.Trim();
            if (ehCEPValido(CEP))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(CEP);
                    if (endereco != null)
                    {
                        Resultado.Text = string.Format("Endereço: {2} {3} {0}, {1} ", endereco.Localidade,
                            endereco.UF, endereco.Logradouro, endereco.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o CEP informado: " + CEP, "OK");
                    }
                }catch(Exception exc)
                {
                    DisplayAlert("ERRO CRÍTICO", exc.Message, "OK");
                }
            }
        }

        private bool ehCEPValido(string CEP)
        {
            bool valido = true;

            if (CEP.Length != 8)
            {
                DisplayAlert("ERRO", "CEP deve conter 8 dígitos", "OK");
                valido = false;
            }

            int CEPNumerico = 0;
            if (!int.TryParse(CEP, out CEPNumerico))
            {
                DisplayAlert("ERRO", "CEP deve ser numérico", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
