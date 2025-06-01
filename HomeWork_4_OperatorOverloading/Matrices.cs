using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_OperatorOverloading
{
    public class Matrices
    {
        public int[,] matrixA = new int[5, 5]; // 5x5 matrix
        //public int[,] matrixB = new int[5, 5]; // 5x5 matrix 

        public int[,] MatrixA { get { return matrixA; } set { matrixA = value; } }
        //public int[,] MatrixB { get { return matrixB; } set { matrixB = value; } }



        public static Matrices operator +(Matrices m1, Matrices m2)
        {
            Matrices resultAdd = new Matrices();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    resultAdd.matrixA[i, j] = m1.matrixA[i, j] + m2.matrixA[i, j];
                }
            }
            return resultAdd;
        }
        public static Matrices operator -(Matrices m1, Matrices m2)
            {
            Matrices resultSub = new Matrices();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    resultSub.matrixA[i, j] = m1.matrixA[i, j] - m2.matrixA[i, j];
                }
            }
            return resultSub;
        }
        public static Matrices operator *(Matrices m1, Matrices m2)
        {
            Matrices resultMultiply = new Matrices();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    resultMultiply.matrixA[i, j] = m1.matrixA[i, j] * m2.matrixA[i, j];
                }
            }
            return resultMultiply;
        }

        public static bool operator ==(Matrices m1, Matrices m2)
        {            
            //Matrices resultEqual = new Matrices();
            int sumMatrix1 = 0, sumMatrix2 = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                  sumMatrix1 += m1.matrixA[i, j];
                  sumMatrix2 += m2.matrixA[i, j];
                  //resultEqual.matrixA[i, j] = m1.matrixA[i, j] == m2.matrixA[i, j] ? 1 : 0;


                }
            }
            if (sumMatrix1 == sumMatrix2)
            {
                return true; /*resultEqual = m1.MatrixA == m2.MatrixA ? 1 : 0;*/
                //return resultEqual; // If both matrices are zero, return an empty matrix

            }

            else
            {
                return false; /*resultEqual; // If both matrices are not zero, return an empty matrix*/
            }
            //return resultEqual;
        }
       
        public static bool operator !=(Matrices m1, Matrices m2)
        {
            int sumMatrix1 = 0, sumMatrix2 = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sumMatrix1 += m1.matrixA[i, j];
                    sumMatrix2 += m2.matrixA[i, j];
                    //resultEqual.matrixA[i, j] = m1.matrixA[i, j] == m2.matrixA[i, j] ? 1 : 0;


                }
            }
            if (sumMatrix1 != sumMatrix2)
            {
                return true; /*resultEqual = m1.MatrixA == m2.MatrixA ? 1 : 0;*/
                //return resultEqual; // If both matrices are zero, return an empty matrix

            }

            else
            {
                return false; /*resultEqual; // If both matrices are not zero, return an empty matrix*/
            }
            //return resultEqual;
        }
            //return !(m1 == m2);

        


        public void MatrixInfo()
        {
            //int[,] matrixResult = new int[5,5]; // Create an instance of the Matrices class
            //MatrixA = MatrixAddContent(); // Fill the first matrix with random numbers
            //MatrixB = MatrixAddContent(); // Fill the second matrix with random numbers
            //matrixResult = MatrixA + MatrixB; // Add the two matrices together
            // Display the matrices
            //Console.WriteLine("Matrix");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,4}", matrixA[i, j]);
                }
                Console.WriteLine();

            }
            Console.WriteLine("--------------------\n");

            //Console.WriteLine("MatrixB");

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.Write("{0,4}", MatrixB[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("--------------------");


        }
        public int[,] MatrixAddContent()
        {
            int[,] matrix = new int[5, 5]; // Create a matrix of size i x j
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = rand.Next(0, 100); // Fill the matrix with random numbers between 1 and 10
                }
            }
            return matrix;
        }
       
    }// End of Matrices class
} 


