using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SparseMatrix
{
     public class SparseMatrix<T>:IEnumerable<T>
     {
          private Dictionary<(int, int), T> Elem = new Dictionary<(int, int), T>();

          private int n;
          private int m;

          public int N => n;
          public int M => m;
          public SparseMatrix(int n, int m)
          {
               this.n = n;
               this.m = m;
          }

          public SparseMatrix(int n, int m, Dictionary<(int, int), T> dictionary)
          {
               this.n = n;
               this.m = m;
               Elem   = dictionary;
          }

          public T this[int i, int j]
          {
               get
               {
                    if (Elem.ContainsKey((((i%n)+n)%n, ((j%m)+m)%m)))
                         return Elem[(((i %n) +n) %n, ((j %m) +m) %m)];
                    return default;
               }
               set
               {
                    if (Elem.ContainsKey((((i %n) +n) %n, ((j %m) +m) %m)))
                         Elem[(((i %n) +n) %n, ((j %m) +m) %m)] = value;
                    else if (!value.Equals(default(T)))
                         Elem.Add((((i %n) +n) %n, ((j %m) +m) %m), value);
               }
          }

          public List<T> Neighbour(int row, int col)
          {
               List<T> lst = new List<T>();
               for (int i = -1; i <= 1; ++i)
               for (int j = -1; j <= 1; ++j)
               {
                    if (i == 0 && j == 0)
                         continue;
                    lst.Add(this[row + i, col + j]);
               }

               return lst;
          }


          public IEnumerator<T> GetEnumerator()
          {
               for (int i = 0; i < n; ++i)
               for (int j = 0; j < m; ++j)
                    yield return this[i, j];
          }
          

          IEnumerator IEnumerable.GetEnumerator()
          {
               return GetEnumerator();
          }
     }
}