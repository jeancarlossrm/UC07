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
                return NotFound(new { erro = $"Item não localizado pelo codigo {id}" });
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CadastrarItem([FromBody] Item novoItem)
        {
            if ((novoItem == null || string.IsNullOrWhiteSpace(novoItem.Nome)))
            {
                return BadRequest(new { erro = $"Não foi possivel cadastrar o novo item devido estar incorreto!. " });
            }

            if ((novoItem.Preco) <= 0)
            {
                return BadRequest(new { erro = $"Não foi possivel cadastrar o novo item devido preço estar incorreto!. " });
            }

            int proxId = _itens.Count > 0 ? _itens.Max(f => f.Id) + 1 : 1;
            novoItem.Id = proxId;
            _itens.Add(novoItem);
            return CreatedAtAction(nameof(MostrarPorId), new { id = novoItem.Id }, novoItem);

        }
        [HttpPost("{id}")]
        public IActionResult DeletePorId(int id)
        {
            var capturarItemDalista = _itens.FirstOrDefault(x => x.Id == id);

            if (capturarItemDalista == null)
            {
                return BadRequest("Item não existe! ");
            }
            _itens.Remove(capturarItemDalista);

            return Ok("Item Deletado");
            }
        }
    };
