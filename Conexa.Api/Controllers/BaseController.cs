using Conexa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ConfigureResult(Task<ResultAction<Playlist>> action)
        {
            if (action == null)
                return NotFound();
            
            if (action.Result.Sucess) return Ok(action);

            //PopularModelStateComErros(action.Mensagens.Values);
            return BadRequest(action);
        }

        private void PopularModelStateComErros(IEnumerable<string> mensagens)
        {

            foreach (var mensagem in mensagens)
            {
                AdicionarErroNoModelState(mensagem);
            }

        }

        private void AdicionarErroNoModelState(string mensagem)
        {
            ModelState.AddModelError("Erros", mensagem);
        }
    }
}
