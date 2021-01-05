using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Presentation.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FD.Videolocadora.Presentation.UI.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly ILocacaoAppService _appService;
        private readonly IFilmeAppService _appServiceFilme;
        private readonly IUsuarioAppService _appServiceUsuario;
        public LocacaoController(ILocacaoAppService appService, IFilmeAppService appServiceFilme, IUsuarioAppService appServiceUsuario)
        {
            _appService = appService;
            _appServiceFilme = appServiceFilme;
            _appServiceUsuario = appServiceUsuario;
        }

        [Authorize]
        // GET: Locacao
        public ActionResult Index()
        {
            var locacoes = _appService.ObterTodos();
            var Filmes = _appServiceFilme.ObterTodos();
            var usuarios = _appServiceUsuario.ObterTodos();

            List<LocacaoModelView> locacaos = new List<LocacaoModelView>();
            foreach (Locacao locacao in locacoes)
            {
                LocacaoModelView l = new LocacaoModelView();
                l.LocacaoId = locacao.LocacaoId;
                l.DataDevolucao = locacao.DataDevolucao;
                l.filmeId = locacao.FilmeId;
                l.usuarioId = locacao.UsuarioId;
                l.Filme = Filmes.Where(f => f.FilmeId == locacao.FilmeId).FirstOrDefault().Nome;
                l.Usuario = usuarios.Where(u => u.Usuarioid == locacao.UsuarioId).FirstOrDefault().Nome;
                l.CPF = usuarios.Where(u => u.Usuarioid == locacao.UsuarioId).FirstOrDefault().CPF;
                locacaos.Add(l);
            }

            return View(locacaos.ToList());
        }

        [Authorize]
        // GET: Locacao/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocacaoModelView l = locacaoForlocacaoModel(id);
            if (l == null)
            {
                return HttpNotFound();
            }
            return View(l);
        }

        [Authorize]
        // GET: Locacao/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Locacao/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocacaoId,DataDevolucao,Filme,Usuario")] LocacaoModelView locacaoView)
        {
            Locacao locacao = locacaoModelForLocacao(locacaoView);
            _appService.Adicionar(locacao);
            return RedirectToAction("Index");

            return View(locacao);
        }

        [Authorize]
        // GET: Locacao/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocacaoModelView l = locacaoForlocacaoModel(id);
            if (l == null)
            {
                return HttpNotFound();
            }
            return View(l);
        }

        [Authorize]
        // POST: Locacao/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Locacaoid,DataDevolucao,Filme,Usuario")] LocacaoModelView LocacaoModelView)
        {
            var locacao = locacaoModelForLocacao(LocacaoModelView);
            _appService.Atualizar(locacao);
            return View();
        }

        [Authorize]
        // GET: Locacao/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocacaoModelView l = locacaoForlocacaoModel(id);
            if (l == null)
            {
                return HttpNotFound();
            }
            return View(l);
        }

        [Authorize]
        // POST: Locacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remover(id);
            return RedirectToAction("Index");
        }



        [Authorize]
        public LocacaoModelView locacaoForlocacaoModel(Guid id)
        {
            Locacao locacao = _appService.ObterPorId(id);
            Filme filmes = _appServiceFilme.ObterPorId(locacao.FilmeId);
            Usuario usuario = _appServiceUsuario.ObterPorId(locacao.UsuarioId);
            LocacaoModelView l = new LocacaoModelView();
            l.LocacaoId = locacao.LocacaoId;
            l.DataDevolucao = locacao.DataDevolucao;
            l.filmeId = locacao.FilmeId;
            l.usuarioId = locacao.UsuarioId;
            l.Filme = filmes.Nome;
            l.Usuario = usuario.Nome;
            l.CPF = usuario.CPF;
            return l;
        }

        [Authorize]
        public Locacao locacaoModelForLocacao(LocacaoModelView locacaoModelView)
        {

            var Filmes = _appServiceFilme.ObterTodos();
            var usuarios = _appServiceUsuario.ObterTodos();

            Locacao l = new Locacao();
            l.LocacaoId = locacaoModelView.LocacaoId;
            l.DataDevolucao = locacaoModelView.DataDevolucao;
            l.FilmeId = Filmes.Where(f => f.Nome == locacaoModelView.Filme).FirstOrDefault().FilmeId;
            l.UsuarioId = usuarios.Where(u => u.Nome == locacaoModelView.Usuario).FirstOrDefault().Usuarioid;
            return l;
        }
    }


}
