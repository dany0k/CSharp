class Program
{
    static void Main(string[] args)
    {
        Interface();
    }

    static int[,] GetEmptyMatrix(int rowCount)
    {
        return new int[rowCount, rowCount];    
    }
    

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void CountMonotonicSequences(int[,] matrix)
    {
        int monotonicSequencesCounter = 0;
        int currEl = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int prevEl = matrix[i, 0];
            int rowCounter = 0;
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                currEl = matrix[i, j];
                if (currEl > prevEl) 
                {
                    prevEl = currEl;
                    rowCounter++;
                    if (rowCounter == matrix.GetLength(0) - 1)
                    {
                        monotonicSequencesCounter++;
                    }
                }
            }
        }
        Console.WriteLine(monotonicSequencesCounter);
    }

    static int Scanner()
    {
        int num = 0;
        while (true)
        {
            string str = Console.ReadLine();
            try
            {
                int.TryParse(str, out num);
                num = Convert.ToInt32(str); 
                return num;
            } catch (Exception e)
            {
                Console.WriteLine("Input numbers!");
            }
        }
    }

    static void Interface()
    {
        Console.WriteLine("Please, input matrix size");
        int matrixSize = Scanner();
        Console.WriteLine("Size {0}", matrixSize);
        int[,] matrix = new int[matrixSize, matrixSize];
        PrintMatrix(matrix);

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.WriteLine("Input [{0}, {1}] element", i, j);
                int element = Scanner();
                matrix[i,j] = element;
            }
        }
        Console.WriteLine("Your Matrix:");
        PrintMatrix(matrix);
        Console.Write("Monotonic sequences in the matrix is ");
        CountMonotonicSequences(matrix);
    }
}