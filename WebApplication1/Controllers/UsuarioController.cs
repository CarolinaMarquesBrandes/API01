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
    public class UsuarioController : ApiController
    {
        public string Get()
        {
            using (var db = new TesteAppEntities())
            {
                // trazer os usuarios sem se preocupar com produto
                return JsonConvert.SerializeObject(db.Usuario.ToList(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            }
        }

        // facilitar o mapeamento desse metodo, para ficar mais facil pra ele ver q é um metodo post
[HttpPost]
        public void Post([FromBody]Usuario usuario)
        {
            if (usuario.sNome.Split(' ').Length <= 1)
            {
                return;
            }
            using(var db = new TesteAppEntities())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();

                //if(usuario.Telefone != null) {

                //    if(usuario.Telefone.Count > 0)
                //    {
                //        List<Telefone> LTel = usuario.Telefone.ToList();
                //        foreach (var item in LTel)
                //        {
                //            Telefone tel = new Telefone();
                //            tel.sTelefone = item.sTelefone;
                //            tel.idUsuario = usuario.idUsuario;

                //            db.Telefone.Add(tel);

                //            db.SaveChanges();
                //        }
                //    }
                //}
            }
        }

[HttpDelete]
        public void Delete([FromBody]Usuario usuario)
        {
            using(var db = new TesteAppEntities())
            {
                var _usuario = db.Usuario.Find(usuario.idUsuario);
                db.Usuario.Remove(_usuario);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void Put([FromBody]Usuario usuario)
        {
            using (var db = new TesteAppEntities())
            {
                var _usuario = db.Usuario.Find(usuario.idUsuario);
                _usuario.sNome = usuario.sNome;
                _usuario.sEmail = usuario.sEmail;

                db.SaveChanges();
            }
        }
    }
}
