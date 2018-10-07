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
        private string nome;
        private string senha;
        private string conta;
        private List<string> listaDominios = new List<string>();

        enum TiposLetras
        {
            Maiusculas,
            Minusculas,
            Numeros,
            Simbolos
        }

        public string Nome
        {
            get
            {
                return Nome;
            }
        }

        public string Senha
        {
            set
            {
                nome = CriptografarSenha(value);
            }
        }

        public string Conta
        {
            set
            {
                conta = value;
            }
            get
            {
                return conta;
            }
        }

        public ContaUsuario()
        {
            listaDominios.Add("@empresa.com.br");
            
        }

        private bool ValidarContaUsuario(string conta)
        {
            bool estadoRetorno = false;
            foreach (string dominio in listaDominios)
            {
                if (conta.EndsWith(dominio)) {
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

        private string CriptografarSenha(string senha)
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

        public bool DefinirNovaSenha(string senha)
        {
            bool senhaValida;

            senhaValida = ValidarSenha(senha);

            if (senhaValida)
                Senha = senha;

            return senhaValida;
        }

        public bool DefinirNovaContaUsuario(string conta)
        {
            bool contaValida;

            contaValida = ValidarContaUsuario(senha);

            if (contaValida)
                Conta = conta;

            return contaValida;
        }
    }
}
