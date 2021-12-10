using System;
using System.Collections.Generic;

namespace SparseMatrix
{
     class Program
     {
          static void Main(string[] args)
          {
               SparseMatrix<int> sm = new SparseMatrix<int>(4, 4);
               sm[1, 1] = 2;
               sm[2, 1] = 3;
               sm[0, 1] = 1;
               List<int> lst = sm.Neighbour(3, 0);
               foreach (var e in lst)
               {
                    Console.Write($"{e} ");
               }
               Console.WriteLine();
               foreach (var e in sm)
               {
                    Console.Write($"{e} ");
               }
               
          }
     }
}