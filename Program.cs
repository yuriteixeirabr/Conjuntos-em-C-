using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Program
    {
        private static int[] Conjunto = new int[0];
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            int[] A = new int[] { 2, 3, 5, 6, 8 };
            int[] B = new int[] { 6, 8 };
            var temp = Uniao(A, B);
            ImprimirConjuntoList(temp);
        }

        private static int[] AdicionarElemento(int[] conjunto, int elemento)
        {
            if (conjunto.Length == 0)
            {
                conjunto = new int[1];
                conjunto[0] = elemento;
                return conjunto;
            }
            else
            {
                int[] a = new int[conjunto.Length + 1];
                for (int i = 0; i < a.Length; i++)
                {
                    if (i < conjunto.Length)
                        a[i] = conjunto[i];
                    else
                        a[i] = elemento;
                }
                return a;
            }
        }

        private static int[] RemoverElemento(int[] conjunto, int elemento)
        {
            int[] a = new int[conjunto.Length - 1];
            bool passou = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (conjunto[i] != elemento)
                {
                    if (!passou)
                        a[i] = conjunto[i];
                    else
                        a[i] = conjunto[i + 1];
                }
                else
                {
                    a[i] = conjunto[i + 1];
                    passou = true;
                }
            }
            return a;
        }

        private static bool Pertinencia(int[] conjunto, int elemento)
        {
            for (int i = 0; i < conjunto.Length; i++)
            {
                if (conjunto[i] == elemento)
                    return true;
            }

            return false;
        }

        private static bool Continencia(int[] conjuntoA, int[] conjuntoB)
        {
            int cont = 0;
            if (conjuntoA.Length <= conjuntoB.Length)
            {
                for (int i = 0; i < conjuntoA.Length; i++)
                {
                    for (int x = 0; x < conjuntoB.Length; x++)
                    {
                        if (conjuntoB[x] == conjuntoA[i])
                            cont++;
                    }
                }
            }

            if (cont == conjuntoA.Length)
                return true;

            return false;
        }

        private static bool Disjuncao(int[] conjuntoA, int[] conjuntoB)
        {
            int cont = 0;
            if (conjuntoA.Length <= conjuntoB.Length)
            {
                for (int i = 0; i < conjuntoA.Length; i++)
                {
                    for (int x = 0; x < conjuntoB.Length; x++)
                    {
                        if (conjuntoB[x] == conjuntoA[i])
                            cont++;
                    }
                }
            }

            if (cont == 0)
                return true;

            return false;
        }

        private static List<string> UniaoDisjunta(UniaoDisjunta conjuntoA, UniaoDisjunta conjuntoB)
        {
            List<string> C = new List<string>();

            for (int i = 0; i < conjuntoA.Conjunto.Length; i++)
            {
                C.Add(conjuntoA.Conjunto[i] + conjuntoA.NomeConjunto);
            }

            for (int i = 0; i < conjuntoB.Conjunto.Length; i++)
            {
                C.Add(conjuntoB.Conjunto[i] + conjuntoB.NomeConjunto);
            }

            return C;
        }

        private static List<int> Uniao(int[] conjuntoA, int[] conjuntoB)
        {
            List<int> A = new List<int>();

            for (int i = 0; i < conjuntoA.Length; i++)
            {
                A.Add(conjuntoA[i]);
            }

            bool temp = false;
            for (int i = 0; i < conjuntoB.Length; i++)
            {
                for (int x = 0; x < A.Count; x++)
                {
                    if (conjuntoB[i] == A[x])
                    {
                        temp = true;
                        break;
                    }
                }

                if (!temp)
                    A.Add(conjuntoB[i]);
            }

            return A;
        }

        private static List<int> Diferenca(int[] A, int[] B)
        {
            List<int> listaTemp = new List<int>();

            for (int i = 0; i < B.Length; i++)
            {
                bool temp = false;
                for (int x = 0; x < A.Length; x++)
                {
                    if (A[x] == B[i])
                        temp = true;
                }

                if (!temp)
                    listaTemp.Add(B[i]);
            }

            for (int i = 0; i < A.Length; i++)
            {
                bool temp = false;
                for (int x = 0; x < B.Length; x++)
                {
                    if (A[i] == B[x])
                        temp = true;
                }

                if (!temp)
                    listaTemp.Add(A[i]);
            }

            return listaTemp;
        }

        private static List<int[]> ConjuntoDasPartes(int[] A)
        {
            List<int[]> listaTemp = new List<int[]>();

            for (int i = 0; i < A.Length; i++)
            {
                listaTemp.Add(new int[] { A[i] });
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int x = A.Length - 1; x >= 0; x--)
                {
                    if (A[i] != A[x])
                        listaTemp.Add(new int[] { A[i], A[x] });
                }
            }

            return listaTemp;
        }

        private static List<int> Complemento(int[] A, int[] B)
        {
            List<int> C = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                C.Add(A[i]);
            }

            bool temp = false;
            for (int i = 0; i < B.Length; i++)
            {
                for (int x = 0; x < C.Count; x++)
                {
                    if (B[i] == C[x])
                    {
                        C.RemoveAt(x);
                        break;
                    }
                    else
                        temp = true;
                }

                if (!temp)
                    C.Add(B[i]);
            }

            return C;
        }

        private static void ImprimirConjuntoList(List<int> conjunto)
        {
            for (int i = 0; i < conjunto.Count; i++)
                Console.WriteLine(conjunto[i]);
        }

        private static void ImprimirConjunto(int[] conjunto)
        {
            for (int i = 0; i < conjunto.Length; i++)
                Console.WriteLine(conjunto[i]);
        }
    }

    public class UniaoDisjunta
    {
        public string NomeConjunto { get; set; }
        public int[] Conjunto { get; set; }

        public UniaoDisjunta(string nomeConjunto, int[] conjunto)
        {
            this.NomeConjunto = nomeConjunto;
            this.Conjunto = conjunto;
        }
    }
}
