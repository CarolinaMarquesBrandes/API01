//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        public int idProduto { get; set; }
        public string sNome { get; set; }
        public string sDescricao { get; set; }
        public decimal nPreco { get; set; }
        public Nullable<int> idCategoria { get; set; }
        public Nullable<int> idUsuarioCadastro { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
