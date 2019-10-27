using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        public static Endereco BuscarEnderecoViaCEP(string CEP)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, CEP);
            WebClient wc = new WebClient();
            var conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.CEP == null)
            {
                return null;
            }

            return end;
        }
    }
}
