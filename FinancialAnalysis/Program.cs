using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAnalysis
{
    class Program
    {
        /// <summary>
        /// Вывод ноиера задания
        /// </summary>
        /// <param name="task"></param>
        static void PrintLabelTask(int task)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ЗАДАНИЕ {task}");
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод строки по центру строки экрана
        /// </summary>
        public static void PrintCenterString(string text)
        {
            if((Console.WindowWidth - text.Length) >= 0)
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            //Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        /// <summary>
        /// Вывод финансов  на экран
        /// </summary>
        /// <param name="matrix">Двумерная матрица с финансами</param>
        static void PrintMatrixfinancials( int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine($"{matrix[i, 0],2} {matrix[i, 1],5} {matrix[i, 2],5} {matrix[i, 3],7}");
            }
        }
        /// <summary>
        /// Вывод матрцы на консоль
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],15} ");
                Console.WriteLine();
            }
                
        }
        /// <summary>
        /// Изменить размерность мптрицы
        /// </summary>
        /// <param name="matrix"></param>
        static void ResizeMatrix(ref int[,] matrix)
        {
            Console.Write(" Кол-во строк: ");
            int matrixRow = insertInt(0, 1000);
            Console.SetCursorPosition(30, Console.CursorTop-1);
            Console.Write(" Кол-во столбцов: ");
            int matrixCol = insertInt(0, 1000);
            matrix = new int[matrixRow, matrixCol];
        }
        /// <summary>
        /// Заполнение матрицы рандомными значениями
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rand"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        static void GenerateRandomMatrixElements(ref int[,] matrix,Random rand, int begin, int end)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rand.Next(begin, end);

        }
        /// <summary>
        /// Ввод данных матрицы с клавиатуры
        /// </summary>
        /// <param name="matrix"></param>
        static void EnteringValuesMatrix(ref int[,] matrix)
        {
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int paddingLeft = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = insertInt(int.MinValue, int.MaxValue);
                    paddingLeft += 15;
                    Console.SetCursorPosition(paddingLeft, Console.CursorTop - 1);
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if(matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        matrix3[i, j] = matrix1[i,j] + matrix2[i, j];
            return matrix3;
        }
        /// <summary>
        /// Вычетание матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        matrix3[i, j] =matrix1[i,j] - matrix2[i, j];
            return matrix3;
        }
        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                        for(int r = 0; r < matrix1.GetLength(1); r++)
                        matrix3[i, j] += matrix1[i, r]*matrix2[r,j];
            return matrix3;
        }
        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int[,] MatrixMultiplicationNumber(int[,] matrix, int number)
        {
            int[,] matrix3 = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix3[i, j] = matrix[i,j] * number;
            return matrix3;
        }


        /// <summary>
        /// Возврощает кол-во месяцев с положительной прибылью
        /// </summary>
        /// <param name="matrix">Ссылка на двумерную матрицу</param>
        /// <returns>Кол-во месяцев с положительной прибылью</returns>
        static int GetLengthTrueProfit(ref int[,] matrix)
        {
            int lengthProfit = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 3] > 0)
                    lengthProfit++;
                else continue;
            }
            return lengthProfit;
        }
        /// <summary>
        /// Вывод 3 месяцев с наименьшей прибылью, при этом месяцы с одинаковой прибылью считаются за один
        /// </summary>
        /// <param name="profit">Прибыль за год</param>
        /// <param name="nomerMonth">Месяцы соответсвующие прибыли</param>
        static void PrintFalseProfit3(int [] profit, int [] nomerMonth)
        {
            Array.Sort(profit, nomerMonth);
            int step = 0;

            for(int i = 0; i < profit.Length; i++)
            {
                if (step > 2) break;
                int begin = Array.IndexOf(profit, profit[i]);
                int end = Array.LastIndexOf(profit, profit[i]);
                if (begin != end)
                {
                    for(int j = i; j < end; j++)
                        Console.Write($"{nomerMonth[j],2} ");
                    i = end;
                }
                    
                step++;
                Console.Write($"{nomerMonth[i],2} ");
            }
        }
        /// <summary>
        /// Генерация треугольника Паскаля
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int[][] PascalsTriangle(int n)
        {
            int[][] result = new int[n][];
            result[0] = new int[] { 1 };
            for (int i = 1; i < n; i++)
            {
                result[i] = new int[i + 1];
                int left = 0;
                for (int j = 0; j < i; j++)
                {
                    result[i][j] = result[i - 1][j] + left;
                    left = result[i - 1][j];
                }
                result[i][i] = left;
            }
            return result;
        }

        static int insertInt(int min, int max)
        {
            int number;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                    if (number >= min && number <= max)
                        break;
            }
            return number;
        }
        static int Main(string[] args)
        {
            #region ЗАДАНИЕ 1
            PrintLabelTask(1);

            //financials[][0] - номер месяца
            //financials[][1] - доход
            //financials[][2] - расход
            //financials[][3] - прибыль
            int[,] financials = new int[12, 4];

            Random random = new Random();
            Console.Write("Сгенерировать данные о доходе от 0 до ");
            int incomeMax = insertInt(int.MinValue, int.MaxValue);
            Console.Write("Сгенерировать данные о расходе от 0 до ");
            int expenditureMax = insertInt(int.MinValue, int.MaxValue);
            //Заполнение данных о финансах
            for (int i = 0; i < financials.GetLength(0); i++)
            {
                financials[i, 0] = i + 1;
                financials[i, 1] = random.Next(0, incomeMax);
                financials[i, 2] = random.Next(0, expenditureMax);
                financials[i, 3] = financials[i, 1] - financials[i, 2];
            }

            //Вывод данных о финансах
            Console.WriteLine($"{"№",2} {"доход",5} {"расход",5} {"прибыль",7}");
            PrintMatrixfinancials(financials);

            int[] nomerMonth = new int[12];
            int[] profit = new int[12];
            //Копирование данных о прибыли и месяцах в 2 новых массива из массива с данными о финансах
            for (int i = 0; i < financials.GetLength(0); i++)
            {
                nomerMonth[i] = financials[i, 0];
                profit[i] = financials[i, 3];
            }

            //Вывод месяцев с наименьшей прибылью
            Console.Write("Месяцы с наименьшей прибылью: ");
            PrintFalseProfit3(profit, nomerMonth);

            //Вывод кол-ва месяцев с положительной прибылью
            Console.WriteLine($"\nКол-во месяцев с положительной прибылью: {GetLengthTrueProfit(ref financials)}");

            Console.ReadKey();
            Console.Clear();
            #endregion
            #region ЗАДАНИЕ 2
            PrintLabelTask(2);

            Console.Write("Введите кол-во строк треугольника паскаля: ");
            int[][] pasckal = PascalsTriangle(insertInt(int.MinValue, int.MaxValue));
            const int cellWidth = 5;
            int col = cellWidth * pasckal.GetLength(0);
            for (int i = 0; i < pasckal.GetLength(0); i++)
            {
                for(int j = 0; j <= i; j++ )
                {
                    if((col-5)>=0 && (col-5)<Console.BufferWidth)
                     Console.SetCursorPosition(col-5, i+2);
                    Console.Write($"{pasckal[i][j],cellWidth}");
                    col += cellWidth * 2;
                }
                col = cellWidth * pasckal.GetLength(0) - cellWidth * (i + 1);
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();
            #endregion
            #region ЗАДАНИЕ 3

            int[,] matrixA = new int[0, 0];
            int[,] matrixB = new int[0, 0];
            bool pravilo = false;
            Random rand = new Random();
            while (true)
            {
                PrintLabelTask(3);
                Console.Write("Матрица1: \n");
                PrintMatrix(matrixA);
                Console.Write("Матрица2: \n");
                PrintMatrix(matrixB);
                Console.WriteLine("1.Ввести размерность матрицы 1 и 2");
                Console.WriteLine("2.Ввести матрицу 1 и 2");
                Console.WriteLine("3.Ввести рандомные значения в матрицу 1 и 2");
                Console.WriteLine("4.Вывести матрицу 1 и 2");
                Console.WriteLine("5.Умножить матрицу 1 на на число");
                Console.WriteLine("6.Сложить матрицу 1 и 2");
                Console.WriteLine("7.Вычесть матрицу 2 из матрицы 1");
                Console.WriteLine("8.Умножить матрицу 1 на матрицу 2");
                Console.WriteLine("9.Выход");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Матрица1: \n");
                        ResizeMatrix(ref matrixA);
                        Console.Write("Матрица2: \n");
                        ResizeMatrix(ref matrixB);
                        break;
                    case 2:
                        Console.Write("Матрица1: \n");
                        EnteringValuesMatrix(ref matrixA);
                        Console.Write("Матрица2: \n");
                        EnteringValuesMatrix(ref matrixB);
                        break;
                    case 3:
                        GenerateRandomMatrixElements(ref matrixA, rand, 0, 101);
                        GenerateRandomMatrixElements(ref matrixB, rand, 0, 101);
                        break;
                    case 4:
                        Console.Write("Матрица1: \n");
                        PrintMatrix(matrixA);
                        Console.Write("Матрица2: \n");
                        PrintMatrix(matrixB);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Умножить матрицу1 на число ");
                        int number = insertInt(int.MinValue, int.MaxValue);
                        PrintMatrix(MatrixMultiplicationNumber(matrixA, number));
                        Console.ReadKey();
                        break;
                    case 6:
                        pravilo = (matrixA.GetLength(0) == matrixB.GetLength(0)) && (matrixA.GetLength(1) == matrixB.GetLength(1));
                        if (pravilo)
                            PrintMatrix(MatrixAddition(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для суммы");
                        Console.ReadKey();
                        break;
                    case 7:
                        pravilo = (matrixA.GetLength(0) == matrixB.GetLength(0)) && (matrixA.GetLength(1) == matrixB.GetLength(1));
                        if (pravilo)
                            PrintMatrix(MatrixSubtraction(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для разности");
                        Console.ReadKey();
                        break;
                    case 8:
                        pravilo = matrixA.GetLength(1) == matrixB.GetLength(0);
                        if(pravilo)
                            PrintMatrix(MatrixMultiplication(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для умножения");
                        Console.ReadKey();
                        break;
                    case 9:
                        return 0;
                }

                Console.Clear();
            }

            #endregion
        }
    }
}
