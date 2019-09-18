using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Asp_Net001.Models;

namespace Asp_Net001.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicaos = new List<Instituicao>()
      {
          new Instituicao()
          {
              InstituicaoID = 1,
              Nome = "UniParaná",
              Endereco = "Paraná"
          },
          new Instituicao()
          {
              InstituicaoID = 2,
              Nome = "UniSanta",
              Endereco = "Santa Catarina"
          },
          new Instituicao()
          {
              InstituicaoID = 3,
              Nome = "UniSãoPaulo",
              Endereco = "São Paulo"
          },
          new Instituicao()
          {
              InstituicaoID = 4,
              Nome = "UniKinshasa",
              Endereco = "Kinshasa"
          },
          new Instituicao()
          {
              InstituicaoID = 5,
              Nome = "UniCarioca",
              Endereco = "Rio de Janeiro"
          }
        };

        public IActionResult Index()
        {
            return View(instituicaos.OrderBy(i => i.Nome));
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            instituicaos.Add(instituicao);
            instituicao.InstituicaoID = instituicaos.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicaos.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicaos.Remove(instituicaos.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            instituicaos.Add(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(instituicaos.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(instituicaos.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int instituicaoId)
        {
            _ = instituicaos.Remove(instituicaos.Where(i => i.InstituicaoID == instituicaoId).First());
            return RedirectToAction("Index");
        }
    }
}