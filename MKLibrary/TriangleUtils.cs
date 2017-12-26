using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKLibrary
{
    public class TriangleUtils
    {
        public List<Triangle> Triangles { get; set; }


        public TriangleUtils(List<Triangle> triangles)
        {
            Triangles = triangles;
        }

        /// <summary>
        /// Получить список множеств подобных треугольников и список множеств 
        /// индексов этих треугольников в исходном списке
        /// </summary>
        /// <param name="indexesList"></param>
        /// <returns>Список множеств подобных треугольников</returns>
        public List<List<Triangle>> GetAnswer(out int[][] indexes)
        {
            List<int> counted = new List<int>();                                        //список уже посчитанных эелементов
            List<List<Triangle>> result = new List<List<Triangle>>();                   //список для вывода результата
            List<List<int>> indexesList = new List<List<int>>();                        //список для вывода индексов треугольников
            
            for (int i = 0; i < Triangles.Count; i++)                                  
            {
                List<Triangle> tmpTriangleList = new List<Triangle>();
                List<int> tmp_indexes = new List<int>();

                if (!counted.Contains(i))                                               //Если еще не посчитан, добавлям текущий треугольник первым в множестве
                {
                    tmpTriangleList.Add(Triangles[i]);
                    tmp_indexes.Add(i);
                    counted.Add(i);
                }

                for (int j = i; j < Triangles.Count; j++)                               //Для всех последующих проверяем подобие и добавляем (если не был посчитан ранее)
                {
                    if (Triangles[i].AreSimilar(Triangles[j]) && !counted.Contains(j))
                    {
                        tmpTriangleList.Add(Triangles[j]);
                        counted.Add(j);
                        tmp_indexes.Add(j);
                    }
                }

                if (tmpTriangleList.Count != 0)                                         //Если есть что добавлять в результат, то добавляем
                {
                    result.Add(tmpTriangleList);
                    indexesList.Add(tmp_indexes);
                }
            }

            indexes = TriangleIndexesList2DToIntArray(indexesList);
            return result;
        }

        public static List<Triangle> PointArrayToTriangles(int[,] array)
        {
            if (array.GetLength(1) == 6)
            {
                List<Triangle> lst = new List<Triangle>();

                for (int r = 0; r < array.GetLength(0); r++)
                {
                    int X1 = array[r, 0];
                    int Y1 = array[r, 1];
                    int X2 = array[r, 2];
                    int Y2 = array[r, 3];
                    int X3 = array[r, 4];
                    int Y3 = array[r, 5];
                    lst.Add(new Triangle(new Point(X1, Y1), new Point(X2, Y2), new Point(X3, Y3)));
                }
                return lst;
            }
            else
            {
                throw new Exception("Invalid array");
            }
        }

        /*---------------------------------------------------------------------------
         * Converter
         *---------------------------------------------------------------------------*/
        public static int[][] TriangleIndexesList2DToIntArray(List<List<int>> indexes)
        {
            int[][] result = new int[indexes.Count][];
            for (int i = 0; i < indexes.Count; i++)
            {
                result[i] = indexes[i].ToArray();
            }
            return result;
        }

    }
}
