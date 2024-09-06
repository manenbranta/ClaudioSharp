namespace Claudio;

using System;

class Program
{
    static void Main()
    {
        string? optStr;
        int option; 
        string? retry = "";

        string[] menuOptions = [
            "Conta Letras",
            "Zenit Polar",
            "Letreiro",
            "Desliza Letras",
            "Formata Nomes",
            "Ordena Palavras",
            "Sair"
        ];

        do 
        {
            Window.drawBG();
            Window.draw(35,10,'d');
            Window.menu(menuOptions);
            Console.SetCursorPosition(Console.WindowWidth/2-19/2,Console.WindowHeight/2+6);
            Console.Write("Escolha uma opção: ");
            optStr = Console.ReadLine();
            option = int.Parse(optStr ?? "1");
            switch (option)
            {
                case 1: 
                {
                    string? input;
                    int[] result;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("CONTA LETRAS", -4);
                    Window.writeCenter("Esse programa conta quantas letras uma frase ou",-3);
                    Window.writeCenter("palavra tem, assim como quantas vogais e consoantes.",-2);
                    Window.writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = contaLetras(input ?? "ERRO: Referência a null.");
                    Window.clear(55,10);
                    Window.writeCenter("CONTA LETRAS: RESULTADO",-4);
                    Window.writeCenter("Foram identificados:",-3);
                    Window.writeCenter(result[0] + " vogais",-2);
                    Window.writeCenter(result[1] + " consoantes",-1);
                    Window.writeCenter(result[2] + " letras, no total",0);
                    Window.writeCenter(result[3] + " números",1);
                    Window.writeCenter("Frase: " + input,2);
                    Window.writeCenter("Deseja continuar? [S/n] ",3);
                    retry = Console.ReadLine();
                    break;
                }
                case 2:
                {
                    string? input,result;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("ZENIT POLAR", -4);
                    Window.writeCenter("Esse programa faz uma encriptação básica em qualquer",-3);
                    Window.writeCenter("frase ou palavra que você digite.",-2);
                    Window.writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = zenitpolar(input ?? "ERRO: Referência a null.");
                    Window.clear(55,10);
                    Window.writeCenter("ZENIT POLAR: RESULTADO",-4);
                    Window.writeCenter("Sua nova frase é:",-3);
                    Window.writeCenter(result,-2);
                    Window.writeCenter("Frase original: ",-1);
                    Window.writeCenter(input ?? "ERRO: Referência a null.",0);
                    Window.writeCenter("Deseja continuar? [S/n] ",1);
                    retry = Console.ReadLine();
                    break;
                }
                case 3: 
                {
                    string? input;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("LETREIRO", -4);
                    Window.writeCenter("Esse programa realiza um efeito no texto",-3);
                    Window.writeCenter("parecido com aqueles paineis led de lojas",-2);
                    Window.writeCenter("de informática",-1);
                    Window.writeCenter("Escreva algo:\n",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2+1);
                    input = Console.ReadLine();
                    Console.Clear();
                    Window.drawBG();
                    letreiro(input ?? "ERRO: Referência a null.");
                    Window.writeCenter("Deseja continuar? [S/n] ",4);
                    retry = Console.ReadLine();
                    break;
                }
                case 4: {
                    string? input;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("DESLIZA LETRAS", -4);
                    Window.writeCenter("Esse programa realiza um efeito no texto",-3);
                    Window.writeCenter("onde as letras vem de um lado da tela",-2);
                    Window.writeCenter("para completar a palavra no outro.",-1);
                    Window.writeCenter("Escreva algo:\n",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2+1);
                    input = Console.ReadLine();
                    Console.Clear();
                    Window.drawBG();
                    deslizaLetras(input ?? "ERRO: Referência a null.",100);
                    Window.writeCenter("Deseja continuar? [S/n] ",3);
                    retry = Console.ReadLine();
                    break;
                }
                case 5: {
                    string? input;
                    string result;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("FORMATA NOMES", -4);
                    Window.writeCenter("Esse programa formata os nomes corretamente,",-3);
                    Window.writeCenter("deixando as primeiras letras maiúsculas,",-2);
                    Window.writeCenter("exceto quando há um artigo no nome.",-1);
                    Window.writeCenter("Escreva um nome:\n",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2+1);
                    input = Console.ReadLine();
                    result = formatarNome(input ?? "ERRO: Referência a null");
                    Window.clear(55,10);
                    Window.writeCenter("FORMATA NOMES: RESULTADO",-4);
                    Window.writeCenter("O nome formatado fica:",-3);
                    Window.writeCenter(result,-2);
                    Window.writeCenter("Nome original: ",-1);
                    Window.writeCenter(input ?? "ERRO: Referência a null.",0);
                    Window.writeCenter("Deseja continuar? [S/n] ",1);
                    retry = Console.ReadLine();
                    break;
                }
                case 6: {
                    string? input;
                    string[]? result;
                    Console.Clear();
                    Window.drawBG();
                    Window.draw(55,10,'s');
                    Window.writeCenter("ORDENA NOMES", -4);
                    Window.writeCenter("Esse programa ordena uma lista de palavras",-3);
                    Window.writeCenter("em ordem alfabética ou desalfabética",-2);
                    Window.writeCenter("(abc ou zyx).",-1);
                    Window.writeCenter("Escreva a lista: ",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2+1);
                    input = Console.ReadLine();
                    result = alfabetico(input ?? "ERRO: Referência a null");
                    Window.clear(55,10);
                    Window.writeCenter("ORDENA NOMES: RESULTADO",-4);
                    Window.writeCenter("A nova lista:",-3);
                    foreach (string str in result)
                    {
                        Window.writeCenter(str ?? "ERRO: Referência a null.",-2);
                    }
                    Window.writeCenter("Lista original: ",-1);
                    foreach (string str in input)
                    {
                        Window.writeCenter(str ?? "ERRO: Referência a null.",-2);
                    }
                    Window.writeCenter("Deseja continuar? [S/n] ",1);
                    retry = Console.ReadLine();
                    break;
                }
                case 7:
                    Console.ResetColor();
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Console.WindowWidth/2-38/2, Console.WindowHeight/2+7);
                    Console.Write("ERRO: A Opção que escolheu é inválida!");
                    Console.SetCursorPosition(Console.WindowWidth/2-41/2, Console.WindowHeight/2+8);
                    Console.Write("Pressione ENTER para terminar o programa.");
                    Console.ReadLine();
                    Console.ResetColor();
                    Console.Clear();
                    Environment.Exit(1);
                    break;
            }
        } while(
            (string.Equals(retry.Trim(' '), "SIM", StringComparison.CurrentCultureIgnoreCase) || 
            string.Equals(retry.Trim(' '), "S", StringComparison.CurrentCultureIgnoreCase)) 
            && 
            (!string.Equals(retry.Trim(' '), "NÃO", StringComparison.CurrentCultureIgnoreCase) || 
            !string.Equals(retry.Trim(' '), "NAO", StringComparison.CurrentCultureIgnoreCase) || 
            !string.Equals(retry.Trim(' '), "N", StringComparison.CurrentCultureIgnoreCase))
        );
        Console.ResetColor();
        Console.Clear();
    }

    static int[] contaLetras(string str) 
    {
        int vogaisNum=0,consoantesNum=0,numeros=0,total=0;

        List<char> vogais = new List<char> {'A','a','E','e','I','i','O','o','U','u','Á','á','É','é','Í','í','Ó','ó','Ú','ú','Ã','ã'};
        List<char> num = new List<char> {'1','2','3','4','5','6','7','8','9','0'};
        List<char> simbolos = new List<char> {' ',':','!','?',',','.','&','-','+','=','_','#','$','@','%','*','(',')'};

        for (int i = 0; i<str.Length;i++) 
        {
            if (vogais.Contains(str[i]))
            {
                vogaisNum++;
            }
            else if (num.Contains(str[i]))
            {
                numeros++;
            }
            else if (!simbolos.Contains(str[i]))
            {
                consoantesNum++;
            }
        }
        total = vogaisNum+consoantesNum;
        return [vogaisNum,consoantesNum,total,numeros];
    }

    static string zenitpolar(string str)
    {
        char[] zenit = {'Z', 'E', 'N', 'I', 'T', 'z', 'e', 'n', 'i', 't', 'ê', 'é', 'î', 'í'};
        char[] polar = {'P', 'O', 'L', 'A', 'R', 'p', 'o', 'l', 'a', 'r', 'õ', 'ó', 'ã', 'á'};

        var map = new Dictionary<char, char>();

        for (int i = 0; i < zenit.Length; i++)
        {
            map[zenit[i]] = polar[i];
        }

        for (int i = 0; i < polar.Length; i++)
        {
            map[polar[i]] = zenit[i];
        }

        string result = "";

        foreach (char c in str)
        {
            if (map.ContainsKey(c))
            {
                result += map[c];
            }
            else
            {
                result += c;
            }
        }

        return result.ToString();
    }

    static void letreiro(string str)
    {
        string textpad = new string(' ',str.Length*3) + str;
        int width = str.Length + str.Length*3;

        int delay;

        if (str.Length <= 20){delay = 100;} else{delay = 50;}

        Window.draw(width,5,'s');
        do 
        {
            for (int i=0; i < width; i++)
            {
                Window.clear(width,3);
                Console.SetCursorPosition(Console.WindowWidth/2-width/2,Console.WindowHeight/2);
                Console.Write(textpad);
                textpad = textpad.Substring(1) + textpad.Substring(0, 1);
                Window.draw(width,5,'s');
                Window.writeCenter("Pressione ESPAÇO para continuar.", 3);
                Thread.Sleep(delay);
            }
        } while(Console.KeyAvailable == false);
    }

    static void deslizaLetras(string str, int delay=100)
    {
        string textpad = new string(' ',str.Length*3) + str;
        int width = str.Length + str.Length*3;

        Window.draw(width,5,'s');
        for (int i=0; i < width; i++)
        {
            for (int j=0; j <= width-str.Length; j++)
            {
                Window.clear(width,5);
                Console.SetCursorPosition(Console.WindowWidth/2-width/2,Console.WindowHeight/2);
                string line = new string(' ', width-str.Length-j);
                line += textpad.Substring(0, i) + textpad[i] + new string(' ', j);
                Console.Write(line);
                Thread.Sleep(delay);
            }
        }
    }

    static string formatarNome(string nome)
    {
        string[] palavras = nome.Split(" ");
        string[] naoNomes = [
            "do",
            "da",
            "de",
            "dos",
            "das",
            "e",
        ];
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

    static string[] alfabetico(string str, bool desalfabetico = false)
    {
        bool swapped = false;
        string aux;

        string[] palavras = str.Split(" ");

        do {
            for (int i=0; i<palavras.Length; i++)
            {
                if (string.Compare(palavras[i],palavras[i+1]) == 1 && !desalfabetico)
                {
                    aux = palavras[i];
                    palavras[i] = palavras[i+1];
                    palavras[i+1] = aux;
                    swapped = true;
                }
                else if (string.Compare(palavras[i],palavras[i+1]) == -1 && desalfabetico)
                {
                    aux = palavras[i];
                    palavras[i] = palavras[i-1];
                    palavras[i-1] = aux;
                    swapped = true;
                }
            }
        } while(swapped);

        return palavras;
    }
}