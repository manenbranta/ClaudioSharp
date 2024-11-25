using System;
using System.Net.Mail;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace arquivos;

class Program
{
    static List<DadosUsuario> registros = new List<DadosUsuario>();
    static void Main()
    {
        string[] menuOptions = {
            "Novo registro", 
            "Listar registros", 
            "Sair"
        };

        string optStr;
        int opt;
        bool repetir;

        do 
        {
            Console.WriteLine("-----CADASTRO-----");
            Console.WriteLine("O que deseja fazer?");
            menu(menuOptions);
            optStr = Console.ReadLine();
            opt = int.Parse(optStr ?? "1");

            repetir = false;
            switch (opt)
            {
                case 1:
                    do
                    {
                        registros.Add(registro());
                        Console.Write("Deseja adicionar mais um registro? [S/n] ");
                        string temp = Console.ReadLine().Trim(' ');
                        repetir = 
                            string.Equals(temp, "S", StringComparison.CurrentCultureIgnoreCase) || 
                            string.Equals(temp, "SIM", StringComparison.CurrentCultureIgnoreCase);
                    } while(repetir);
                    Console.Clear();
                    break;
                case 2:
                    foreach (var usr in registros)
                    {
                        Console.WriteLine(usr.ToString());
                    }
                    Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.ResetColor();
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: A Opção que escolheu é inválida!");
                    Console.WriteLine("Pressione ENTER para terminar o programa.");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    Environment.Exit(1);
                    break;
            }
        } while(true);
    }

    public static DadosUsuario registro()
    {
        Console.Clear();
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a data de nascimento: ");
        DateTime data = DateTime.Parse(Console.ReadLine(), new CultureInfo("pt-BR"));
        Console.Write("Digite o telefone: ");
        string tel = Console.ReadLine();
        string email = "";
        bool emailError;
        do
        {
            emailError = false;
            Console.Write("Digite o email: ");
            string addr = Console.ReadLine();
            try {
                email = new MailAddress(addr).Address;
            } catch(FormatException) {
                emailError = true;
            }
        } while(emailError);

        return new DadosUsuario(nome, data, tel, email);
    }

    public static void menu(string[] options)
    {
        for (int i=0; i<options.Length; i++)
        {
            Console.WriteLine($"[{i+1}] - {options[i]}");
        }
    }
}

struct DadosUsuario
{
    string nome { get; set; }
    DateTime nascimento { get; set; }
    string telefone { get; set; }
    string email { get; set; }

    public DadosUsuario(string nome, DateTime nascimento, string telefone, string email)
    {
        this.nome = nome;
        this.nascimento = nascimento;
        this.telefone = telefone;
        this.email = email;

        Format();
    }

    public void Format()
    {
        nome = fmtNome(nome);
        telefone = fmtTel(telefone);
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

        resultado = resultado.TrimStart().TrimEnd();

        return resultado;
    }

    string fmtTel(string tel) 
    {
        string resultado = Regex.Replace(tel, @"\D", "");

        if (resultado.Length > 2) resultado = $"({resultado.Substring(0,2)}) {resultado.Substring(2)}";
        if (resultado.Length > 9) resultado = $"{resultado.Substring(0,9)}-{resultado.Substring(9)}";

        return resultado;
    }

    public override string ToString()
    {
        return $"Nome: {nome}, Nascimento: {nascimento:dd/MM/yyyy}, Telefone: {telefone}, Email: {email}";
    }
}