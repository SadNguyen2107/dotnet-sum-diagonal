using System.Collections;
using System.Data;

namespace MyProgram
{
    public class MyProgram
    {
        private static void Print2DArray<T>(T[,] array2D)
        {
            Console.WriteLine("Array: ");

            Int32 col_size = array2D.GetLength(0);
            for (int col_index = 0; col_index < col_size; col_index++)
            {
                Int32 row_size = array2D.GetLength(1);
                for (int row_index = 0; row_index < row_size; row_index++)
                {
                    Console.Write(array2D[col_index, row_index] + "\t");
                }

                Console.WriteLine();
            }
        }

        private static Int32 AskIntInput(string prompt, Predicate<int>? predicate = null)
        {
            int result;

            // If no predicate is provided, always true
            predicate ??= x => true;

        // Ask User Input
        askIntInput:
            Console.Write(prompt);
            bool isValid = Int32.TryParse(Console.ReadLine(), out result);
            if (!isValid && !predicate(result))
            {
                Console.WriteLine("Invalid Input!");
                goto askIntInput;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Int32[,] squareArray2D;

            // Ask Column Size
            Int32 size = AskIntInput("Enter Size: ", (int num) => num > 0);
            
            // Populate the value in 2DArray 
            squareArray2D = new Int32[size, size];

            // Ask User To Input the Value
            for (int col_index = 0; col_index < size; col_index++)
            {
                for (int row_index = 0; row_index < size; row_index++)
                {
                    squareArray2D[col_index, row_index] = AskIntInput($"Enter Square Array2D at position[{col_index}, {row_index}]: ");
                }
            }

            Print2DArray<Int32>(squareArray2D);

            // Find The Sum Of the Diagonal of 2D Array
            Int32 sum = 0;
            for (int col_index = 0; col_index < size; col_index++)
            {
                // O(N) Algorithm
                sum += squareArray2D[col_index, col_index];
            }

            Console.WriteLine($"Sum of the Diagonal: {sum}");
        }
    }
}