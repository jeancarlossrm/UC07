using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pousada.API.Models;

namespace Pousada.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private static readonly List<Item> _itens = new()
        {
            new Item {Id = 1, Nome = "Agua Mineral 500 ml", Preco = 5.00m,Descricao = "Agua sem gas"},
            new Item {Id = 2, Nome = "Refrigerante Lata", Preco = 8.50m,Descricao = "Lata 350ml"},
            new Item {Id = 3, Nome = "Pacote de Biscoito Artesanal", Preco = 12.00m, Descricao = "Biscoito amanteigado caseiro" }
        };

        [HttpGet]
        public IActionResult MostrasItens()
        {
            return Ok(_itens);
        }
        [HttpGet("{id}")]
        public IActionResult MostrarPorId(int id)
        {
            var item = _itens.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound(new { erro = $"Item não localizado pelo {id}" });
            }
            return Ok(item);
        }

        [HttpPost]
    }
};
