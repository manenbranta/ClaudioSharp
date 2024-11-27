using System;
using System.IO;
using System.Xml;
using System.Net.Mail;
using System.Globalization;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace arquivos;

class Program
{
    static Dados registros;
    static void Main()
    {
        string[] menuOptions = {
            "Novo registro", 
            "Listar registros", 
            "Sair"
        };

        string optStr;
        string path = "./res/dados.xml";
        int opt;
        bool repetir;

        registros.usuarios = Array.Empty<Usuario>();

        XmlSerializer x = new XmlSerializer(typeof(Dados));

        if (File.Exists(path) && !(new FileInfo(path).Length == 0))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                registros = (Dados)x.Deserialize(reader);
            }
        }
        

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
                        var reg = registro();
                        AddUsuario(reg);
                        x.Serialize(Console.Out,registros);
                        Console.WriteLine();
                        Console.Write("Deseja adicionar mais um registro? [S/n] ");
                        string temp = Console.ReadLine().Trim(' ');
                        repetir = 
                            string.Equals(temp, "S", StringComparison.CurrentCultureIgnoreCase) || 
                            string.Equals(temp, "SIM", StringComparison.CurrentCultureIgnoreCase);
                    } while(repetir);
                    Console.Clear();
                    break;
                case 2:
                    foreach (var usr in registros.usuarios)
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
                    SaveReg(path, x);
                    Environment.Exit(0);
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: A Opção que escolheu é inválida!");
                    Console.WriteLine("Pressione ENTER para terminar o programa.");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    SaveReg(path, x);
                    Environment.Exit(1);
                    break;
            }
        } while(true);
    }

    static void AddUsuario(Usuario usr)
    {
        int len = registros.usuarios.Length;
        Array.Resize(ref registros.usuarios, len+1);
        registros.usuarios[len] = usr;
    }

    static void SaveReg(string path, XmlSerializer ser)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            ser.Serialize(writer, registros);
        }
    }

    public static Usuario registro()
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

        return new Usuario(nome, data, tel, email);
    }

    public static void menu(string[] options)
    {
        for (int i=0; i<options.Length; i++)
        {
            Console.WriteLine($"[{i+1}] - {options[i]}");
        }
    }
}

[Serializable()]
[XmlRoot("Dados")]
public struct Dados
{
    [XmlArray("Usuarios")]
    [XmlArrayItem("Usuario", typeof(Usuario))]
    public Usuario[] usuarios;
}

[Serializable()]
public struct Usuario
{
    [XmlElement("Nome")]
    public string nome { get; set; }
    [XmlElement("DataDeNascimento")]
    public DateTime nascimento { get; set; }
    [XmlElement("Telefone")]
    public string telefone { get; set; }
    [XmlElement("Email")]
    public string email { get; set; }

    public Usuario(string nome, DateTime nascimento, string telefone, string email)
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
        if (resultado.Length > 10) resultado = $"{resultado.Substring(0,10)}-{resultado.Substring(10)}";

        return resultado;
    }

    public override string ToString()
    {
        return $"Nome: {nome}, Nascimento: {nascimento:dd/MM/yyyy}, Telefone: {telefone}, Email: {email}";
    }
}