using System;
using System.Numerics;
using System.Threading.Tasks;

namespace FloydWarshall
{
    public class Program
    {
        private const int NoEdge = int.MaxValue / 2 - 1;

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, shortest path!");

            // i = row * row_size + col;
            // where row      - cell row index,
            //       col      - cell column index, 
            //       row_size - number of cells in a row.

            // Number of edges in graphs is around 80% of possible maximum which for directed, acyclic graphs can be calculated as:
            // var max = v * (v - 1)) / 2;
            // where v - is a number of vertexes in a graph.
        }

        /// <summary>
        /// Base implementation with three loops
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public void FloydWarshall_00(int[] matrix, int size)
        {
            // iterates over all vertixes in a graph
            // k represents a vertex we are searching paths through
            for (var k = 0; k < size; ++k)
            {
                // iterates over all vertixes in a graph
                // i represents a vertex we are searching paths from
                for (var i = 0; i < size; ++i)
                {
                    // iterates over all vertixes in a graph
                    // j represents a vertex we are searching paths to
                    for (var j = 0; j < size; ++j)
                    {
                        var distance = matrix[i * size + k] + matrix[k * size + j];

                        if (matrix[i * size + j] > distance)
                        {
                            matrix[i * size + j] = distance;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Implementation with knowledge of sparse graphs
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public void FloydWarshall_01(int[] matrix, int size)
        {
            for (var k = 0; k < size; ++k)
            {
                for (var i = 0; i < size; ++i)
                {
                    // skip non-adjacent vertices if there is no path from i to k (DAGs)
                    if (matrix[i * size + k] == NoEdge)
                    {
                        continue;
                    }

                    for (var j = 0; j < size; ++j)
                    {
                        var distance = matrix[i * size + k] + matrix[k * size + j];

                        if (matrix[i * size + j] > distance)
                        {
                            matrix[i * size + j] = distance;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Implementation with knowledge of parallelism
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public void FloydWarshall_02(int[] matrix, int size)
        {
            for (var k = 0; k < size; ++k)
            {
                var k1 = k;

                // on each iteration, i loop reads data from k and updated i row
                Parallel.For(0, size, i =>
                {
                    if (matrix[i * size + k1] == NoEdge)
                    {
                        // no-op
                    }

                    for (var j = 0; j < size; ++j)
                    {
                        var distance = matrix[i * size + k1] + matrix[k1 * size + j];

                        if (matrix[i * size + j] > distance)
                        {
                            matrix[i * size + j] = distance;
                        }
                    }
                });
            }
        }

        /// <summary>
        /// SIMD ¯\_(ツ)_/¯
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public void FloydWarshall_03(int[] matrix, int size)
        {
            for (var k = 0; k < size; ++k)
            {
                for (var i = 0; i < size; ++i)
                {
                    if (matrix[i * size + k] == NoEdge)
                    {
                        continue;
                    }

                    // create a vector of i->k path
                    var ikVec = new Vector<int>(matrix[i * size + k]);

                    var j = 0;

                    // simultaneously calculate paths from vertix i to vertext j...
                    for (; j < size - Vector<int>.Count; j += Vector<int>.Count)
                    {
                        // load weight matrix information
                        var ijVec = new Vector<int>(matrix, i * size + j);
                        var ikjVec = new Vector<int>(matrix, k * size + j) + ikVec;

                        var ltVec = Vector.LessThan(ijVec, ikjVec);

                        if (ltVec == new Vector<int>(-1))
                        {
                            continue;
                        }

                        // compare and write
                        var rVec = Vector.ConditionalSelect(ltVec, ijVec, ikjVec);
                        rVec.CopyTo(matrix, i * size + j);
                    }

                    for (; j < size; ++j)
                    {
                        var distance = matrix[i * size + k] + matrix[k * size + j];

                        if (matrix[i * size + j] > distance)
                        {
                            matrix[i * size + j] = distance;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Vectorization and parallelization
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        public void FloydWarshall_04(int[] matrix, int size)
        {
            for (var k = 0; k < size; ++k)
            {
                var k1 = k;

                Parallel.For(0, size, i =>
                {
                    if (matrix[i * size + k1] == NoEdge)
                    {
                        return;
                    }

                    // create a vector of i->k path
                    var ikVec = new Vector<int>(matrix[i * size + k1]);

                    var j = 0;

                    // simultaneously calculate paths from vertix i to vertext j...
                    for (; j < size - Vector<int>.Count; j += Vector<int>.Count)
                    {
                        // load weight matrix information
                        var ijVec = new Vector<int>(matrix, i * size + j);
                        var ikjVec = new Vector<int>(matrix, k1 * size + j) + ikVec;

                        var ltVec = Vector.LessThan(ijVec, ikjVec);

                        if (ltVec == new Vector<int>(-1))
                        {
                            continue;
                        }

                        // compare and write
                        var rVec = Vector.ConditionalSelect(ltVec, ijVec, ikjVec);
                        rVec.CopyTo(matrix, i * size + j);
                    }

                    for (; j < size; ++j)
                    {
                        var distance = matrix[i * size + k1] + matrix[k1 * size + j];

                        if (matrix[i * size + j] > distance)
                        {
                            matrix[i * size + j] = distance;
                        }
                    }
                });
            }
        }
    }
}