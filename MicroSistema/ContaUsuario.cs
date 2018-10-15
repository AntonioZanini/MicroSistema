using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MicroSistema
{

    class ContaUsuario
    {
        enum TiposLetras
        {
            Maiusculas,
            Minusculas,
            Numeros,
            Simbolos
        }

        private List<string> listaDominios = new List<string>() { "@empresa.com.br" };

        public static Usuario UsuarioUtilizador { get; private set; }

        private bool ValidarContaUsuario(string conta)
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

        private bool ValidarSenha(string senha)
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
            if (!senha.Any(char.IsSymbol) && regrasAtivas[(int)TiposLetras.Simbolos])
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



        public bool DefinirNovaContaUsuario(string conta)
        {
            if (ValidarContaUsuario(conta))
            {
                UsuarioUtilizador.Email = conta;
                return true;
            }
            return false;
        }

        public static void Login(string conta, string senha)
        {
            MicroSistemaContext context = new MicroSistemaContext();
            // Valores de teste: valdirsrios@empresa.com.br e $3nh4I-II-III "10CA25278C7CD10AA375D98EFAD44FBA"

            Usuario usuario = null;
            senha = CriptografarSenha(senha);
            usuario = context.Usuario.Where(x => x.Email.Equals(conta, StringComparison.InvariantCultureIgnoreCase) && x.Senha.Equals(senha)).FirstOrDefault();
            UsuarioUtilizador = usuario;
        }
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
