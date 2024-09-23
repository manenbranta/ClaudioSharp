namespace Claudio;

class Forca
{
    static void main()
    {
        string[] listaPalavras = [
            "amarelo",
            "miserável",
            "caatinga",
            "transeunte",
            "quarentena",
        ];

        Random rng = new();

        // Palavra escolhida pro jogo de forca
        string palavra;

        //Hashmap com as dicas para cada palavra
        Dictionary<string,string> dicas = new Dictionary<string,string>();
        dicas.Add("amarelo", "Cor do maior astro próximo da terra");
        dicas.Add("miserável", "Antônimo da palavra pobre");
        dicas.Add("caatinga", "Bioma brasileiro");
        dicas.Add("transeunte", "Aquele ou aquilo em constante movimento");
        dicas.Add("quarentena", "Sinônimo de isolação");

        palavra = listaPalavras[rng.Next(0,listaPalavras.Length)];
    }

    static string fmt(string str) 
    {
        return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
    }
}