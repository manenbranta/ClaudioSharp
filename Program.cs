namespace Claudio;

using System;

class Program
{
    static string[] menuOptions = [
        "Conta Letras",
        "Zenit Polar",
        "Letreiro",
        "Sair"
    ];
    static void Main()
    {
        string? optStr = "";
        int option; 
        string? retry = " ";

        do 
        {
            drawBG();
            drawWindow(35,10,'d');
            menu(menuOptions);
            Console.SetCursorPosition(Console.WindowWidth/2-19/2,Console.WindowHeight/2+6);
            Console.Write("Escolha uma opção: ");
            optStr = Console.ReadLine();
            option = Int32.Parse(optStr);
            switch (option)
            {
                case 1: 
                {
                    string? input;
                    int[] result;
                    drawBG();
                    drawWindow(55,10,'s');
                    writeCenter("CONTA LETRAS", -4);
                    writeCenter("Esse programa conta quantas letras uma frase ou",-3);
                    writeCenter("palavra tem, assim como quantas vogais e consoantes.",-2);
                    writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = contaLetras(input);
                    clearWindow(55,10);
                    writeCenter("CONTA LETRAS: RESULTADO",-4);
                    writeCenter("Foram identificados:",-3);
                    writeCenter(result[0] + " vogais",-2);
                    writeCenter(result[1] + " consoantes",-1);
                    writeCenter(result[2] + " letras, no total",0);
                    writeCenter(result[3] + " números",1);
                    writeCenter("Frase: " + input,2);
                    writeCenter("Deseja continuar? [S/n] ",3);
                    retry = Console.ReadLine();
                    break;
                }
                case 2:
                {
                    string? input,result;
                    Console.Clear();
                    drawBG();
                    drawWindow(55,10,'s');
                    writeCenter("ZENIT POLAR", -4);
                    writeCenter("Esse programa faz uma encriptação básica em qualquer",-3);
                    writeCenter("frase ou palavra que você digite.",-2);
                    writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = zenitpolar(input);
                    clearWindow(55,10);
                    writeCenter("ZENIT POLAR: RESULTADO",-4);
                    writeCenter("Sua nova frase é:",-3);
                    writeCenter(result,-2);
                    writeCenter("Frase original: ",-1);
                    writeCenter(input,0);
                    writeCenter("Deseja continuar? [S/n] ",1);
                    retry = Console.ReadLine();
                    break;
                }
                case 3: 
                {
                    string? input;
                    Console.Clear();
                    drawBG();
                    drawWindow(55,10,'s');
                    writeCenter("LETREIRO", -4);
                    writeCenter("Esse programa funciona de forma parecida com",-3);
                    writeCenter("aqueles letreiros led encontrados",-2);
                    writeCenter("em lojas de informática.",-1);
                    writeCenter("Escreva algo:\n",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    Console.Clear();
                    drawBG();
                    drawWindow(55,3,'s');
                    break;
                }
                case 4:
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
        } while((retry.ToUpper() == "SIM" || retry.ToUpper() == "S" || retry.ToUpper() == "") && (retry.ToUpper() != "NÃO" || retry.ToUpper() != "N"));
        Console.ResetColor();
        Console.Clear();
    }

    static void drawBG(ConsoleColor color = ConsoleColor.Blue) 
    {
        Console.BackgroundColor = color;

        for (int i = 0; i < Console.BufferWidth; i++)
        {
            for (int j = 0; j < Console.BufferHeight; j++)
            {
                Console.Write(" ");
            }
        }
    }

    static void drawWindow(int width, int height, char borda)
    {
        /**
        *   vl = vertical line
        *   hl = horizontal line
        *   trc = top-right corner
        *   tlc = top-left corner
        *   brc = bottom-right corner
        *   blc = bottom-left corner
        **/

        char vl = ' ', hl = ' ', trc = ' ', tlc = ' ', brc = ' ', blc = ' ';
        switch (borda)
        {
            case 'd':
                vl = '║';
                trc = '╗';
                brc = '╝';
                tlc = '╔';
                blc = '╚';
                hl = '═';
                break;
            case 's':
                vl = '│'; // 179
                trc = '┐'; //191
                brc = '┘'; //217
                tlc = '┌'; //218
                blc = '└'; // 192
                hl = '─'; // 196
                break;
            default:
                break;
        }

        //Top line
        Console.SetCursorPosition((Console.BufferWidth/2)-(width/2),Console.BufferHeight/2-height/2);
        for (int x = 0; x < width; x++) 
        {
            Console.Write(hl);
        }

        //Columns
        for (int y = 0; y < height; y++)
        {
            Console.SetCursorPosition(Console.BufferWidth/2-width/2,Console.BufferHeight/2-height/2+y); Console.Write(vl);
            Console.SetCursorPosition(Console.BufferWidth/2+width/2,Console.BufferHeight/2-height/2+y); Console.Write(vl);
        }

        //Bottom Line
        Console.SetCursorPosition(Console.BufferWidth/2-(width/2),Console.BufferHeight/2+height/2);
        for (int x = 0; x < width; x++) 
        {
            Console.Write(hl);
        }

        //Corners
        Console.SetCursorPosition(Console.BufferWidth/2-(width/2),Console.BufferHeight/2-height/2);
        Console.Write(tlc);
        Console.SetCursorPosition(Console.BufferWidth/2+width/2,Console.BufferHeight/2-height/2);
        Console.Write(trc);
        Console.SetCursorPosition(Console.BufferWidth/2-(width/2),Console.BufferHeight/2+height/2);
        Console.Write(blc);
        Console.SetCursorPosition(Console.BufferWidth/2+width/2,Console.BufferHeight/2+height/2);
        Console.Write(brc);
    }

    static void clearWindow(int windowWidth, int windowHeight)
    {   
        for (int le = 1; le<windowHeight; le++) 
        {
            Console.SetCursorPosition(Console.BufferWidth/2-windowWidth/2+1,Console.BufferHeight/2-windowHeight/2+le);
            for (int x = 0; x < windowWidth-2; x++) 
            {
                Console.Write(" ");
            }
        }
    }

    static void menu(string[] options)
    {
        for (int i=0; i<options.Length; i++)
        {
            Console.SetCursorPosition(Console.BufferWidth/2-10,Console.BufferHeight/2-1+i);
            Console.Write("["+(i+1)+"] - " + options[i]);
        }
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

    /*static void letreiro(string str, int areaWidth)
    {
        while (true)
        {

        }
    }*/

    static string zenitpolar(string str)
    {
        char[] zenit = { 'Z', 'E', 'N', 'I', 'T', 'z', 'e', 'n', 'i', 't', 'ê', 'é', 'î', 'í' };
        char[] polar = { 'P', 'O', 'L', 'A', 'R', 'p', 'o', 'l', 'a', 'r', 'õ', 'ó', 'ã', 'á' };

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

    static void writeCenter(string str, int yAdd)
    {
        Console.SetCursorPosition(Console.WindowWidth/2-str.Length/2,Console.WindowHeight/2+yAdd);
        Console.Write(str);
    }
}