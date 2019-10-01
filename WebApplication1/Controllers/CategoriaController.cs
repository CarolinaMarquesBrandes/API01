using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriaController : ApiController
    {
        public string Get() {
            using(var db = new TesteAppEntities())
            {
                return JsonConvert.SerializeObject(db.Categoria.ToList());
            }
        }

        [HttpPost]
        public void Post([FromBody]Categoria categoria)
        {
            if(categoria == null || categoria.sNome.Length <= 3)
            {
                return;
            }
            using(var db = new TesteAppEntities())
            {
                db.Categoria.Add(categoria);
                db.SaveChanges();
            }
        }


        public void Put(Categoria categoria)
        {
            using(var db = new TesteAppEntities())
            {
                var categ = db.Categoria.Find(categoria.idCategoria);
                categ.sNome = categoria.sNome;
                db.SaveChanges();
            }
        }

        public void Put(int id, string nome)
        {
            using (var db = new TesteAppEntities())
            {
                var categ = db.Categoria.Find(id);
                categ.sNome = nome;
                db.SaveChanges();
            }
        }

        public void Delete(Categoria categoria)
        {
            using(var db = new TesteAppEntities())
            {
                var categ = db.Categoria.Find(categoria.idCategoria);
                db.Categoria.Remove(categ);
                db.SaveChanges();
            }
        }
    }
}
