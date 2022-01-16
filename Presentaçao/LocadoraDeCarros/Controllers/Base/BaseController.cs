using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.Controllers.Base
{
    public class BaseController : Controller
    {

        public void Mensagem(string mensagem, string tipoMensagem)
        {
            if (tipoMensagem == "Error")
                ViewData["error"] = "error";
            else if (tipoMensagem == "Warning")
                ViewData["warning"] = "warning";
            else if (tipoMensagem == "Sucess")
                ViewData["sucess"] = "sucess";
            else
                ViewData["info"] = "info";

            ViewData["Mensagem"] = mensagem;
        }

    }
}
