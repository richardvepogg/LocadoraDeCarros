using AutoMapper;
using LocadoraDeCarros.Controllers.Base;
using LocadoraDeCarros.Models.ModeloDados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.ServiçoNegocio.Base;

namespace LocadoraDeCarros.Controllers
{
    [Authorize(Roles ="Admin, Balconista")]
    public class ClienteController : BaseController
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper, IClienteServico clienteServico)
        { 
         _mapper = mapper;
        _clienteServico = clienteServico;   
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            ClienteViewModel clienteVM = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));
            return View(clienteVM);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View(new ClienteViewModel());
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteVM)
        {
            try
            {
                    var novoCliente = _mapper.Map<Cliente>(clienteVM);


                    if (novoCliente.EmailEstaDuplicado(_clienteServico))
                        ModelState.AddModelError("Email", "O email ´já existe no banco de dados");


                
                //TODO: validar regras de negocio
                if (ModelState.IsValid)
                {
                    if (_clienteServico.Inserir(novoCliente))
                    {
                        Mensagem("O cliente foi inserido com sucesso.", "Info");
                        return RedirectToAction(nameof(Index));
                    }

                }
                Mensagem("Ocorreu algum erro ao inserir o novo cliente.", "Error");
                return View(clienteVM);
            }
            catch
            {
                Mensagem("Ocorreu algum erro ao inserir o novo cliente.", "Error");
                return View(clienteVM);
            }
        }

        // GET: ClienteController/Edit/5
        
        public ActionResult Edit(int id)
        {
            var clientEditar = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));

            return View(clientEditar);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteVM)
        {
            try
            {
                    var clienteEditado = _mapper.Map<Cliente>(clienteVM);

                    if (clienteEditado.EmailEstaDuplicado(_clienteServico))
                        ModelState.AddModelError("Email", "O email ´já existe no banco de dados");

                    if (ModelState.IsValid)
                    {
                        if (_clienteServico.Editar(clienteEditado))
                        {
                            Mensagem("O cliente foi editado com sucesso.", "Info");
                            return RedirectToAction(nameof(Index));
                        }
                    }
                
                Mensagem("Ocorreu algum erro ao editar o cliente", "Error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Mensagem("Ocorreu alguma exception ao editar o cliente.", "Error");
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var clientExcluir = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));
            return View(clientExcluir);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel clienteExcluir)
        {
            try
            {
                if (_clienteServico.Excluir(clienteExcluir.Id))
                {
                    Mensagem("O cliente foi excluido com sucesso.", "Info");
                return RedirectToAction(nameof(Index));
                }

                Mensagem("Ocorreu alguma erro ao excluir o cliente.", "Error");
                return View(clienteExcluir);
            }
            catch
            {
                Mensagem("Ocorreu alguma exception ao excluir o cliente.", "Error");
                return View(clienteExcluir);
            }
        }

        public ActionResult CarregarDados()
        {
            var draw = Request.Form["draw"];
            var start = Request.Form["start"];
            var length = Request.Form["length"];
            var sortColumn = Request.Form["columns["+Request.Form["order[0][column]"]+"][name]"];
            var sortColumnDir = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            int pageSize = length != string.Empty ? Convert.ToInt32(length) : 0;
            int skip = start != string.Empty ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var result = _clienteServico.ObterListaClientes();

            if (!string.IsNullOrEmpty(searchValue))
            {
                result = (List<Cliente>)result.Where(m => m.Nome.Contains(searchValue)).ToList();

            }

            recordsTotal = result.Count();

            var data = result.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

    }
}
