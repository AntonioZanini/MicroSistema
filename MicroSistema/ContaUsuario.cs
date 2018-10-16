using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MicroSistema
{

    public static class ContaUsuario
    {
        enum TiposLetras
        {
            Maiusculas,
            Minusculas,
            Numeros,
            Simbolos
        }

        private static List<string> listaDominios = new List<string>() { "@empresa.com.br" };

        public static Usuario UsuarioUtilizador { get; private set; }

        private static bool ValidarContaUsuario(string conta)
        {
            bool estadoRetorno = false;
            foreach (string dominio in listaDominios)
            {
                if (conta.EndsWith(dominio))
                {
                    estadoRetorno = true;
                    break;
                }
            }
            return estadoRetorno;
        }

        private static bool ValidarSenha(string senha)
        {
            bool[] regrasAtivas = { true, true, true, true };
            int tamanhoMinimo = 6;
            bool estadoRetorno = true;

            if (!senha.Any(char.IsLower) && regrasAtivas[(int)TiposLetras.Minusculas])
                estadoRetorno = false;
            if (!senha.Any(char.IsUpper) && regrasAtivas[(int)TiposLetras.Maiusculas])
                estadoRetorno = false;
            if (!senha.Any(char.IsDigit) && regrasAtivas[(int)TiposLetras.Numeros])
                estadoRetorno = false;
            if ((!senha.Any(char.IsSymbol) && !senha.Any(char.IsPunctuation)) && regrasAtivas[(int)TiposLetras.Simbolos])
                estadoRetorno = false;
            if (senha.Length < tamanhoMinimo)
                estadoRetorno = false;
            return estadoRetorno;
        }

        private static string CriptografarSenha(string senha)
        {
            // Intanciar objeto MD5, converter senha para array de char, calcular o hash da senha.
            MD5 md5 = MD5.Create();
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            byte[] hashSenha = md5.ComputeHash(senhaBytes);

            // Converter o array de bytes do hash da senha em uma string composta por hexadecimais maiúsculos.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashSenha.Length; i++)
            {
                sb.Append(hashSenha[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static object ListarUsuarios(int cdNA = 0)
        {

            using (MicroSistemaContext context = new MicroSistemaContext())
            {
                var lista = context.Usuario.Select(u => new { u.Nome, u.Email, NivelAcesso = u.NivelAcesso.Titulo, u.DataCadastro, u.CdUsuario });
                if (cdNA != 0)
                    lista = context.Usuario.Where(u => u.CdNivelAcesso == cdNA).Select(u => new { u.Nome, u.Email, NivelAcesso = u.NivelAcesso.Titulo, u.DataCadastro, u.CdUsuario });
                return lista.ToList();
            }
        }

        public static object ListarNiveisAcesso(string cabecalho = "")
        {
            using (MicroSistemaContext context = new MicroSistemaContext())
            {
                var lista = context.NivelAcesso.Select(n => new { n.CdNivelAcesso, n.Titulo }).ToList();
                if (cabecalho != "")
                    lista.Add(new { CdNivelAcesso = 0, Titulo = cabecalho });
                lista = lista.OrderBy(b => b.CdNivelAcesso).ToList();

                return lista;
            }
        }

        public static void AlterarUsuario(Usuario usuarioAlterar)
        {
            if (ValidarContaUsuario(usuarioAlterar.Email))
            {
                using (MicroSistemaContext context = new MicroSistemaContext())
                {
                    context.Entry(usuarioAlterar).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            else
                throw new ContaInvalidaException("Email do usuário não satisfaz critérios de validação.");
        }

        public static void NovoUsuario(string email, string nome, string senha, int cdNivelAcesso)
        {
            string senhaCripto;
            if (ValidarContaUsuario(email))
            {
                if (ValidarSenha(senha))
                {
                    senhaCripto = CriptografarSenha(senha);
                    Usuario usuario = new Usuario(email, nome, senhaCripto, cdNivelAcesso);
                    using (MicroSistemaContext context = new MicroSistemaContext())
                    {
                        context.Usuario.Add(usuario);
                        context.SaveChanges();
                    }
                }
                else
                    throw new SenhaInvalidaException("Senha do usuário não satisfaz critérios de validação.");
            }
            else
                throw new ContaInvalidaException("Email do usuário não satisfaz critérios de validação.");
                
        }

        public static Usuario BuscarUsuario(int cdUsuario)
        {
            Usuario usuario;
            using (MicroSistemaContext context = new MicroSistemaContext())
            {
                usuario = context.Usuario.Where(u => u.CdUsuario == cdUsuario).Single();
            }
            return usuario;
        }

        public static void Excluir(Usuario usuarioExcluir)
        {
            using (MicroSistemaContext context = new MicroSistemaContext())
            {
                Usuario usuario = context.Usuario.Where(u => u.CdUsuario == usuarioExcluir.CdUsuario).Single();
                context.Usuario.Remove(usuario);
                context.SaveChanges();
            }
        }

        public static void Login(string conta, string senha)
        {
            MicroSistemaContext context = new MicroSistemaContext();
            // Valores de teste: valdirsrios@empresa.com.br e $3nh4I-II-III "10CA25278C7CD10AA375D98EFAD44FBA"

            Usuario usuario = null;
            senha = CriptografarSenha(senha);
            usuario = context.Usuario.Where(x => x.Email.Equals(conta, StringComparison.InvariantCultureIgnoreCase) && x.Senha.Equals(senha) && x.Ativo == true).FirstOrDefault();
            UsuarioUtilizador = usuario;
        }

    }


    [Serializable]
    public class ContaInvalidaException : ArgumentException
    {
        public ContaInvalidaException() { }
        public ContaInvalidaException(string message) : base(message) { }
        public ContaInvalidaException(string message, Exception inner) : base(message, inner) { }
        protected ContaInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class SenhaInvalidaException : ArgumentException
    {
        public SenhaInvalidaException() { }
        public SenhaInvalidaException(string message) : base(message) { }
        public SenhaInvalidaException(string message, Exception inner) : base(message, inner) { }
        protected SenhaInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public partial class Usuario
    {
        public Usuario()
        {
            DataCadastro = DateTime.Today;
            Ativo = true;
        }
        public Usuario(string email, string nome, string senha, int cdNivelAcesso)
        {
            DataCadastro = DateTime.Today;
            Ativo = true;

            Email = email;
            Nome = nome;
            Senha = senha;
            CdNivelAcesso = cdNivelAcesso;
        }

    }
}
