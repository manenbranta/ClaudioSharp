﻿namespace Claudio;

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
            "Sair"
        ];

        do 
        {
            Window.drawBG();
            Window.drawWindow(35,10,'d',ConsoleColor.Red);
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
                    Window.drawWindow(55,10,'s');
                    Window.writeCenter("CONTA LETRAS", -4);
                    Window.writeCenter("Esse programa conta quantas letras uma frase ou",-3);
                    Window.writeCenter("palavra tem, assim como quantas vogais e consoantes.",-2);
                    Window.writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = contaLetras(input ?? "ERRO: Referência a null.");
                    Window.clearWindow(55,10);
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
                    Window.drawWindow(55,10,'s');
                    Window.writeCenter("ZENIT POLAR", -4);
                    Window.writeCenter("Esse programa faz uma encriptação básica em qualquer",-3);
                    Window.writeCenter("frase ou palavra que você digite.",-2);
                    Window.writeCenter("Escreva algo:\n",-1);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2);
                    input = Console.ReadLine();
                    result = zenitpolar(input ?? "ERRO: Referência a null.");
                    Window.clearWindow(55,10);
                    Window.writeCenter("ZENIT POLAR: RESULTADO",-4);
                    Window.writeCenter("Sua nova frase é:",-3);
                    Window.writeCenter(result,-2);
                    Window.writeCenter("Frase original: ",-1);
                    Window.writeCenter(input ?? "ERRO: Referência a null.",0);
                    Window.writeCenter("Deseja continuar? [S/n] ",1);
                    retry = Console.ReadLine();
                    break;
                }
                /*case 3: 
                {
                    string? input;
                    Console.Clear();
                    drawBG();
                    drawWindow(55,10,'s');
                    writeCenter("DESLIZA LETRAS", -4);
                    writeCenter("Esse programa realiza um efeito no texto",-3);
                    writeCenter("onde as letras vem de um lado da janela",-2);
                    writeCenter("até a palavra para completa-lá",-1);
                    writeCenter("Escreva algo:\n",0);
                    Console.SetCursorPosition(Console.WindowWidth/2-55/2+1,Console.WindowHeight/2+1);
                    input = Console.ReadLine();
                    Console.Clear();
                    drawBG();
                    drawWindow(55,3,'s');
                    deslizaLetras(input ?? "ERRO: Referência a null.",55);
                    writeCenter("Deseja continuar? [S/n] ",0);
                    retry = Console.ReadLine();
                    break;
                }*/
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
        } while(
            (string.Equals(retry, "SIM", StringComparison.CurrentCultureIgnoreCase) || 
            string.Equals(retry, "S", StringComparison.CurrentCultureIgnoreCase)) 
            && 
            (!string.Equals(retry, "NÃO", StringComparison.CurrentCultureIgnoreCase) || 
            !string.Equals(retry, "NAO", StringComparison.CurrentCultureIgnoreCase) || 
            !string.Equals(retry, "N", StringComparison.CurrentCultureIgnoreCase))
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

    static void letreiro(string str, int delay=100)
    {
        string strpad = new string(' ',str.Length*3) + str;

        do
        {   
            Console.SetCursorPosition(Console.BufferWidth/2-strpad.Length,Console.BufferHeight/2);
            Console.Write(strpad);
            strpad.Split();
        } while(Console.KeyAvailable == false);
    }

    /* static void deslizaLetras(string str, int areaWidth)
    {
        string str_pad = new string(' ', areaWidth) + str;
        for (int i = 0; i < str_pad.Length; i++)
        {
            str_pad = str_pad.Remove(i);
            Console.Write(str_pad);
            Thread.Sleep(1000);
        }
    } */

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
}