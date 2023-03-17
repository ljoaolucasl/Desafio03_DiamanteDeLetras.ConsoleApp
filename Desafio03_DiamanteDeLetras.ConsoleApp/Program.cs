namespace Desafio03_DiamanteDeLetras.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meio = 0, areaTotalDiamante = 0;

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] alfabeto = letras.ToCharArray();

            char letraEscolhida = ' ';

            while (true)
            {
                DescricaoDigiteUmaLetra();

                VerificaLetra(ref letraEscolhida);

                PegarMedidasDiamante(alfabeto, letraEscolhida, ref meio, ref areaTotalDiamante);

                CriaDiamante(meio, areaTotalDiamante, alfabeto);

                LimpaTela();
                
            }
        }

        private static void DescricaoDigiteUmaLetra()
        {
            Console.WriteLine("Digite uma letra para fazer um diamante!");
            Console.Write("Letra: ");
        }

        private static void VerificaLetra(ref char letraEscolhida)
        {
            bool testChar;
            bool testLetra;
            do
            {
                string entrada = Console.ReadLine();

                testChar = char.TryParse(entrada, out letraEscolhida);

                testLetra = entrada.All(char.IsLetter);

                if (!testChar || !testLetra)
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma letra para fazer um diamante!");
                    Console.WriteLine("Atenção, escreva apenas uma Letra!");
                    Console.Write("Letra: ");
                }
                else
                {
                    letraEscolhida = char.ToUpper(letraEscolhida);
                }

            } while (!testChar || !testLetra);
        }

        private static void PegarMedidasDiamante(char[] alfabeto, char letraEscolhida, ref int meio, ref int areaTotalDiamante)
        {
            for (int i = 0; i < alfabeto.Length; i++)
            {
                if (letraEscolhida == alfabeto[i])
                {
                    meio = i;
                    areaTotalDiamante = meio * 2 + 1;
                    break;
                }
            }
        }

        private static void CriaDiamante(int meio, int areaTotalDiamante, char[] alfabeto)
        {
            char[] construtorDiamante = new char[areaTotalDiamante];

            for (int i = 0; i <= meio; i++)
            {
                if (i == 0)
                {
                    PulaLinha();
                    construtorDiamante[meio] = alfabeto[i];
                }
                else if (i <= meio)
                {
                    construtorDiamante[meio + i] = alfabeto[i];
                    construtorDiamante[meio - i] = alfabeto[i];
                }

                foreach (char letra in construtorDiamante)
                {
                    if (letra != '\0' && letra == alfabeto[i])
                    {
                        Console.Write(letra);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                PulaLinha();
            }

            for (int i = meio - 1; i >= 0; i--)
            {

                foreach (char letra in construtorDiamante)
                {
                    if (letra != '\0' && letra == alfabeto[i])
                    {
                        Console.Write(letra);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                PulaLinha();
            }
        }

        private static void LimpaTela()
        {
            Console.WriteLine("\nTecle Enter para limpar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }

    }
}