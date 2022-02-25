using System;
using System.IO;

namespace PMatriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            string opc = "a";
            bool preenchida = false;
            do
            {
                Console.Clear();
                opc = Menu();

                switch (opc)
                {
                    case "1":
                        LerMatriz();
                        break;
                    case "2":
                        ImprimirCompleta();
                        break;
                    case "3":
                        ImprimirLinha();
                        break;
                    case "4":
                        ImprimirColuna();
                        break;
                    case "5":
                        Buscar();
                        break;
                    case "6":
                        OrdenarLinha();
                        break;
                    case "7":
                        GravarArq();
                        break;
                    case "8":
                        LerArq();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opcao nao valida");
                        Console.ReadKey();
                        break;
                }
            } while (opc != "0");

            void OrdenarLinha()
            {

                if (preenchida == false)
                {
                    Console.WriteLine("Matriz de nomes nao preenchida");
                }
                else
                {
                    Console.WriteLine("Qual linha deseja ordenar");
                    int ordenar = int.Parse(Console.ReadLine());
                    {

                        for (int referencia = 0; referencia < matriz.GetLength(1); referencia++)
                        {
                            for (int comparacao = referencia + 1; comparacao < matriz.GetLength(1); comparacao++)
                            {
                                if (string.Compare(matriz[ordenar, referencia], matriz[ordenar, comparacao]) > 0)
                                {
                                    string troca = matriz[ordenar, referencia];
                                    matriz[ordenar, referencia] = matriz[ordenar, comparacao];
                                    matriz[ordenar, comparacao] = troca;

                                }
                            }
                            Console.WriteLine(matriz[ordenar, referencia]);
                        }
                    }
                }
                Console.ReadKey();
            }
            void GravarArq()
            {
                try
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\matheus\\Test.txt");
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            sw.WriteLine("{0}", matriz[linha, coluna]);

                        }

                    }

                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Arquivo Gravado!!!!");
                }
                Console.ReadKey();
            }
            void LerArq()
            {
                string line;
                try
                {
                    StreamReader sr = new StreamReader("C:\\Users\\matheus\\Test.txt");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        for (int linha = 0; linha < matriz.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                            {
                                matriz[linha, coluna] = line;
                                line = sr.ReadLine();
                            }

                        }
                    }
                    sr.Close();
                    preenchida = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Leitura do Arquivo Concluida");
                    Console.ReadLine();
                }

            }
            void ImprimirLinha()
            {
                if (preenchida == false)
                {
                    Console.WriteLine("Matriz de nomes nao preenchida");
                }
                else
                {
                    Console.WriteLine("Qual Linha Deseja Imprimir");
                    int imprimirLinha = int.Parse(Console.ReadLine());

                    for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                    {
                        Console.Write("matriz[{0},{1}]={2}\t", imprimirLinha, coluna, matriz[imprimirLinha, coluna]);
                    }
                }
                Console.ReadKey();
            }
            void ImprimirColuna()
            {
                if (preenchida == false)
                {
                    Console.WriteLine("Matriz de nomes nao preenchida");
                }
                else
                {
                    Console.WriteLine("Qual Coluna Deseja Imprimir");
                    int imprimirColuna = int.Parse(Console.ReadLine());
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        Console.WriteLine("matriz[{0},{1}]={2}\t", linha, imprimirColuna, matriz[linha, imprimirColuna]);

                    }
                }
                Console.ReadKey();
            }
            void Buscar()
            {
                bool verificar = false;
                if (preenchida == false)
                {
                    Console.WriteLine("Matriz de nomes nao preenchida");
                }
                else
                {
                    Console.WriteLine("Qual nome deseja buscar");
                    string buscar = Console.ReadLine();
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            if (matriz[linha, coluna].ToLower().Contains(buscar))
                            {
                                Console.Write("matriz[{0},{1}]={2}\t", linha, coluna, matriz[linha, coluna]);
                                verificar = true;
                            }
                        }
                    }
                    if (!verificar)
                    {
                        Console.WriteLine("Nenhum Nome Encontrado");
                    }
                }
                Console.ReadKey();
            }
            void LerMatriz()
            {
                if (!preenchida)
                {
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            Console.WriteLine("Informe o Nome");
                            matriz[linha, coluna] = Console.ReadLine();
                            preenchida = true;

                        }

                    }
                }
                else
                {
                    Console.WriteLine("Matriz ja preenchida");
                }
                Console.ReadKey();
            }
            void ImprimirCompleta()
            {
                if (preenchida == false)
                {
                    Console.WriteLine("Matriz de nomes nao preenchida");
                }
                else
                {
                    for (int linha = 0; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            Console.Write("matriz[{0},{1}]={2}\t", linha, coluna, matriz[linha, coluna]);


                        }
                        Console.WriteLine();

                    }
                }
                Console.ReadKey();
            }
            string Menu()
            {
                Console.WriteLine("*****Menu*****");
                Console.WriteLine("[1] Ler Matriz");
                Console.WriteLine("[2] Imprimir Matriz Completa");
                Console.WriteLine("[3] Imprimir Determinando Linha");
                Console.WriteLine("[4] Imprimir Determinando Coluna");
                Console.WriteLine("[5] Procurar Nome");
                Console.WriteLine("[6] Ordenar Nomes Determinada Linha");
                Console.WriteLine("[7] Gravar um Arquivo da Matriz");
                Console.WriteLine("[8] Ler Arquivo Matriz");
                Console.WriteLine("[0] Sair");
                return Console.ReadLine();

            }
        }
    }
}
