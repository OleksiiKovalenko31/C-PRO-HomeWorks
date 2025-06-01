using System.Runtime.CompilerServices;

namespace HomeWork_4_OperatorOverloading
{
    internal class Program
    {
        static void Main()
        {
            Employee(); // Uncomment this line to run the Employee example

            City(); // Uncomment this line to run the City example

            Matrices(); // Uncomment this line to run the Matrices example

        }

        static void Employee()
        {

            Accountant Alice = new("Alice", "Accountant", 30, 5000.00, 0, 0);
            Accountant Bob = new("Bob", "Accountant", 32, 5000.00, 2, 1);

            Manager BobM = new("Bob", "Manager", 40, 7000.00, 3, 3);

            Developer Charlie = new("Charlie", "Developer", 35, 6000.00, 6, 2);

            Alice.DisplayInfo();

            Bob.DisplayInfo();
            BobM.DisplayInfo();
            Charlie.DisplayInfo();
        }

        static void City()
        {
            City city1 = new("CityA", 1000000, 500.0);
            City city2 = new("CityB", 500000, 300.0);
            City combinedCity = city1 + city2;
            City reducedCity = city1 - city2;
            City equalas = city1 > city2 ? city1 : city2; // Using the > operator to determine which city has a larger population
            City equalas2 = city1 < city2 ? city1 : city2; // Using the < operator to determine which city has a smaller population
            City equalas3 = city1 == city2 ? city1 : city2; // Using the == operator to check if they are equal
            City equalas4 = city1 != city2 ? city1 : city2; // Using the != operator to check if they are not equal


            Console.WriteLine(combinedCity);
            Console.WriteLine(reducedCity);
            Console.WriteLine($"The city with the larger population is: {equalas}"); // Display the city with the larger population
            Console.WriteLine($"The city with the smaller population is: {equalas2}"); // Display the city with the smaller population
            Console.WriteLine($"The cities are equal: {equalas3}"); // Display if the cities are equal
            Console.WriteLine($"The cities are not equal: {equalas4}"); // Display if the cities are not equal
        }

        static void Matrices()
        {

            // Example usage of Matrices class can be added here
            // For now, this method is empty as the Matrices class implementation is not provided
            Matrices matrix1 = new Matrices();
            Matrices matrix2 = new Matrices();
            Console.WriteLine("MatrixA");
            matrix1.MatrixA = matrix1.MatrixAddContent(); // Fill the first matrix with random numbers
            matrix1.MatrixInfo(); // Display the first matrix
            Console.WriteLine("MatrixB");
            matrix2.MatrixA = matrix2.MatrixAddContent(); // Fill the second matrix with random numbers
            matrix2.MatrixInfo(); // Display the second matrix

            Console.WriteLine("Result of MatrixA + MatrixB:");
            Matrices resultMatrix = matrix1 + matrix2; // Add the two matrices together
            resultMatrix.MatrixInfo(); // Display the result of the addition

            Console.WriteLine("Result of MatrixA - MatrixB:");
            Matrices resultEqual = matrix1 - matrix2; // Subtract the two matrices
            resultEqual.MatrixInfo();
          
            Console.WriteLine("Result of MatrixA * MatrixB:");
            Matrices result = matrix1 * matrix2; // Multiply the two matrices
            resultMatrix.MatrixInfo();

            Console.WriteLine("Result of MatrixA == MatrixB:");
            bool areEqual = matrix1 == matrix2; // Check if the two matrices are equal
            Console.WriteLine($"Are the summa matrices equal? {areEqual}"); // Display if the matrices are equal
        }



    }
}
