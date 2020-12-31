using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using System;
using System.Net;
using System.Web.Mvc;

namespace FD.Videolocadora.Presentation.UI.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroAppService _generoAppService;

        public GeneroController(IGeneroAppService generoAppService)
        {
            _generoAppService = generoAppService;
        }
        // GET: Genero
        public ActionResult Index()
        {
            return View(_generoAppService.ObterTodos());
        }

        // GET: Genero/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = _generoAppService.ObterPorId(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneroId,Nome")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _generoAppService.Adicionar(genero);
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = _generoAppService.ObterPorId(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Genero/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneroId,Nome")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _generoAppService.Atualizar(genero);
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = _generoAppService.ObterPorId(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _generoAppService.Remover(id);
            return RedirectToAction("Index");
        }

    }
}
