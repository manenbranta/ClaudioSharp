using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace arquivos;

class Program
{
    static void Main()
    {

    }
}

struct DadosUsuario
{
    string nome;
    DateTime nascimento;
    string telefone;
    string email;

    public DadosUsuario(string nome, DateTime nascimento, string telefone, string email)
    {
        this.nome = nome;
        this.nascimento = nascimento;
        this.telefone = telefone;
        this.email = email;
    }

    public DadosUsuario Format()
    {
        DadosUsuario usuario = new DadosUsuario(nome, nascimento, telefone, email);
        usuario.nome = fmtNome(usuario.nome);
        usuario.telefone = fmtTel(usuario.telefone);

        return usuario;
    }

    string fmtNome(string nome)
    {
        string[] palavras = nome.Split(' ');
        string[] naoNomes = {
            "do",
            "da",
            "de",
            "dos",
            "das",
            "e"
        };
        string resultado = "";

        foreach (string str in palavras)
        {
            bool isNaoNome = false;
            
            foreach (string nn in naoNomes)
            {
                if (string.Equals(str, nn, StringComparison.CurrentCultureIgnoreCase))
                {
                    resultado += str.ToLower() + " ";
                    isNaoNome = true;
                    break;
                }
            }

            if (!isNaoNome) 
            {
                resultado += str[0].ToString().ToUpper() + str.Substring(1).ToLower() + " ";
            }
        }

        return resultado;
    }

    string fmtTel(string tel) 
    {
        string resultado = Regex.Replace(tel, @"/\D/g", "");

        if (resultado.Length > 2) resultado = $"({resultado.Substring(0,2)}) {resultado.Substring(2)}";
        if (resultado.Length > 9) resultado = $"{resultado.Substring(0,9)}-{resultado.Substring(9)}";

        return resultado;
    }
}