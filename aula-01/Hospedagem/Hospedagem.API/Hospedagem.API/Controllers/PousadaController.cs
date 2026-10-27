using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace Hospedagem.API.Controllers

//api/Pousada
{
    [Route("api/[controller]")]
    [ApiController]
    public class PousadaController : ControllerBase
    {
        [HttpGet]
        public string ObterStatus()
        {
            return "Sistema de Gerenciamento da Pousada Vista Bela em operacao.";
        }

        //api/pousada/boas-vindas/fulando

        [HttpGet("boas-vindas/{nomeHospede}")]
        public string BoasVindasHospede(string nomeHospede)
        {
            return $"Seja muito bem-vindo(a) a Pousada Vista Bela, {nomeHospede}! Desejamos uma execelente estadia.";
        }

        //api/pousada/unidade?chale={numeroChale}
        [HttpGet("unidade")]
        public string ConsultarUnidade ([FromQuery] string? numeroChale)
        {
            if (numeroChale == null || numeroChale == "")
            {
                {
                 return "Chale não informado, redirecionando para o atendimento.";
                }
            }
            return $"Unidade Chale {numeroChale} selecionada para atendimento.";
        }
    }
}