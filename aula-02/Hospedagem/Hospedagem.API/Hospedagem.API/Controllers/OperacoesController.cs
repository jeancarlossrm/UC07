using Hospedagem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospedagem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        [HttpPost]
        public IActionResult SimularEntrada([FromBody] RequisicaoEntrada entrada)
        {
            if (entrada == null || string.IsNullOrEmpty(entrada.NomeProduto))
            {
                return BadRequest("Dados de entrada necessários ou nome do produto ausente. ");
            }

            // if quantidade <=0 se preco de custo <=0, retornem bad request
            if (entrada.Quantidade <= 0 || entrada.PrecoCusto <= 0)
            {
                return BadRequest("A quantidade e o preço de custo devem ser maiores que 0!.");
            }

            decimal custoTotal = entrada.Quantidade * entrada.PrecoCusto;
            // custoTotal = x

            var resposta = new
            {
                mensagem = "Simulação de custo total efetuada com sucesso. ",
                produto = entrada.NomeProduto,
                custoTotal = custoTotal
                dataSimulacao = DateTime.Now
            };
            return Ok(resposta);
        }
    }
}
