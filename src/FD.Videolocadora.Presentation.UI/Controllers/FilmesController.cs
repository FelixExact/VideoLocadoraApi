using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Presentation.UI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace FD.Videolocadora.Presentation.UI.Controllers
{
    public class FilmesController : Controller
    {
        private readonly IFilmeAppService _appService;

        public FilmesController(IFilmeAppService appService)
        {
            _appService = appService;
        }

        [Authorize]
        // GET: Filmes
        public ActionResult Index()
        {
            IEnumerable<Filme> filmes = _appService.ObterTodos();
            List<FilmeModelView> filmesView = new List<FilmeModelView>();
            foreach (Filme Filme in filmes)
            {
                FilmeModelView a = new FilmeModelView();
                a.FilmeId = Filme.FilmeId;
                a.Nome = Filme.Nome;
                a.Valor = Filme.Valor;
                a.Disponivel = Filme.Disponivel;
                a.GeneroId = Filme.GeneroId;
                filmesView.Add(a);
            }

            IEnumerable<FilmeModelView> j = filmesView;
            return View(j);
        }

        [Authorize]
        // GET: Filmes/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = _appService.ObterPorId(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        [Authorize]
        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Filmes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeId,Nome,Valor,Disponivel,GeneroId")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _appService.Adicionar(filme);
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        [Authorize]
        // GET: Filmes/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Filme Filme = _appService.ObterPorId(id);

            if (Filme == null)
            {
                return HttpNotFound();
            }
            FilmeModelView a = new FilmeModelView();
            a.FilmeId = Filme.FilmeId;
            a.Nome = Filme.Nome;
            a.Valor = Filme.Valor;
            a.Disponivel = Filme.Disponivel;
            a.GeneroId = Filme.GeneroId;
            return View(a);
        }

        [Authorize]
        // POST: Filmes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeId,Nome,Valor,Disponivel,GeneroId")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _appService.Atualizar(filme);
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        [Authorize]
        // GET: Filmes/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = _appService.ObterPorId(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        [Authorize]
        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
