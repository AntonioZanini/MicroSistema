//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MicroSistema
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int CdUsuario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; protected set; }
        public System.DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public int CdNivelAcesso { get; set; }
    
        public virtual NivelAcesso NivelAcesso { get; set; }
    }
}
