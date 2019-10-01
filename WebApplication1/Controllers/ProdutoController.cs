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
    public class ProdutoController : ApiController
    {
        public void Post([FromBody]Produto produto)
        {
            using (var db = new TesteAppEntities())
            {
                db.Produto.Add(produto);
                db.SaveChanges();
            }
        }

        public string Get()
        {
            using (var db = new TesteAppEntities())
            {
                return JsonConvert.SerializeObject(db.Produto.ToList(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
        }

        [HttpPut]
        public void Put([FromBody]Produto produto)
        {
            using (var db = new TesteAppEntities())
            {
                var _produto = db.Produto.Find(produto.idProduto);
                _produto.nPreco = produto.nPreco;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete([FromBody]Produto produto)
        {
            using (var db = new TesteAppEntities())
            {
                var _produto = db.Produto.Find(produto.idProduto);
                db.Produto.Remove(_produto);
                db.SaveChanges();
            }
        }
    }
}
