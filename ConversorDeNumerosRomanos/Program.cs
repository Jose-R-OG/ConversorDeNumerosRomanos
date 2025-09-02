namespace ConversorDeNumerosRomanos
{
    using System;

    public class ConvertidoDeNumerosRomanos
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----Conversor de Numeros Romanos a Decimales-----\n");
            Console.Write("Ingresa un numero romano: ");
            string numeroRomano = Console.ReadLine();

            if (ValidarNumeroRomano(numeroRomano))
            {
                int numdecimal = RomanoADecimal(numeroRomano);
                Console.WriteLine($"El valor decimal de {numeroRomano} es: {numdecimal}");
            }
            else
            {
                Console.WriteLine($"{numeroRomano} no es un numero romano valido.");
            }
        }

        public static int RomanoADecimal(string numeroRomano)
        {
            numeroRomano = numeroRomano.ToUpper();

            int resultado = 0;
            int valorPrevio = 0;

            for (int i = numeroRomano.Length - 1; i >= 0; i--)
            {
                char charRomano = numeroRomano[i];
                int valorActual = ValorLetra(charRomano);

                if (valorActual < valorPrevio)
                {
                    resultado -= valorActual;
                }
                else
                {
                    resultado += valorActual;
                }

                valorPrevio = valorActual;
            }

            return resultado;
        }

        private static int ValorLetra(char romanChar)
        {
            switch (romanChar)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        public static bool ValidarNumeroRomano(string numeroRomano)
        {

            numeroRomano = numeroRomano.ToUpper();

            foreach (char c in numeroRomano)
            {
                if (ValorLetra(c) == 0)
                    return false;
            }

            string[] noMasDeTres = { "IIII", "XXXX", "CCCC", "MMMM" };
            foreach (string invalido in noMasDeTres)
            {
                if (numeroRomano.Contains(invalido))
                    return false;
            }

            return true;

            for (int i = 0; i < numeroRomano.Length - 1; i++)
            {
                int actual = ValorLetra(numeroRomano[i]);
                int siguiente = ValorLetra(numeroRomano[i + 1]);

                if (actual < siguiente)
                {
                    if (numeroRomano[i] == 'I' && !(numeroRomano[i + 1] == 'V' || numeroRomano[i + 1] == 'X'))
                        return false;
                    if (numeroRomano[i] == 'X' && !(numeroRomano[i + 1] == 'L' || numeroRomano[i + 1] == 'C'))
                        return false;
                    if (numeroRomano[i] == 'C' && !(numeroRomano[i + 1] == 'D' || numeroRomano[i + 1] == 'M'))
                        return false;
                    if (numeroRomano[i] == 'V' || numeroRomano[i] == 'L' || numeroRomano[i] == 'D')
                        return false;
                }
            }
        }
    }
}
