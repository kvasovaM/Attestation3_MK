using MKLibrary;
using UsefulUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_1_5_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запускаем основной цикл приложения
            while (true)
            {

                int[,] trianglesPointsArray = StartProgram("Длина массива 6. Координаты точек вводятся в виде [X1 Y1 X2 Y2 X3 Y3]");

                TriangleUtils triangleUtils = new TriangleUtils(TriangleUtils.PointArrayToTriangles(trianglesPointsArray));

                triangleUtils.GetAnswer(out int[][] resultArr);
                string result = String.Empty;

                for (int i = 0; i < resultArr.Length; i++)
                {
                    result += new ArraysHelper().ArrayToStr<int>(resultArr[i], "; ") + "\n";
                }

                Console.WriteLine(result);

                // Спрашиваем у пользователя, желает ли он также сохранить
                // резульат работы программы в файл
                if (ConfirmAction("Желаете ли вы сохранить резултат работы программы в файл?"))
                {
                    SaveResultToFile(result);
                }

                // Спрашиваем, будет ли пользователь продолжать работу с программой
                if (ConfirmAction("Продолжить работу с программой?"))
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }

        private static int[,] StartProgram(string infoMessage = "")
        {
            Console.WriteLine("Добро пожаловать в программу!" +
                                    "" + Environment.NewLine + Environment.NewLine);

            // Объеявляем переменную для хранения массива
            int[,] arr;


            // Спрашиваем у пользователя, будет ли он читать данные из файла
            if (ConfirmAction("Желаете ли вы считать данные из файла?"))
            {
                arr = ReadArrFromFile();
            }
            else
            {
                if (infoMessage != "") Console.WriteLine(infoMessage);
                arr = ReadArrFromConsole();
            }
            return arr;
        }

        private static bool ConfirmAction(string question)
        {
            Console.Write(question + " (y/n): ");

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Y && keyInfo.Key != ConsoleKey.N);

            Console.WriteLine();

            return keyInfo.Key == ConsoleKey.Y;
        }

        // Читаем массив из файла
        private static int[,] ReadArrFromFile()
        {
            while (true)
            {
                try
                {
                    string filePath = IOUtils.ReadValueFromConsole<string>("путь к входному файлу");

                    // Пытаемся считать данные из файла, преобразовать их в массив
                    // и вернуть вызывающему коду
                    string arrText = FilesUtils.Read(filePath);
                    return ArraysHelper.StrToArray2D<int>(arrText);
                }
                catch (Exception e)
                {
                    // Если во время считывания из файла ошибка, то выводим её,
                    // а затем просим ввести путь ещё раз
                    IOUtils.ShowError("Невозможно считать данные из этого файла");
                }
            }
        }

        private static int[,] ReadArrFromConsole()
        {
            return IOUtils.ReadArray2DFromConsole<int>("массив чисел");
        }

        private static void SaveResultToFile(string answer)
        {
            while (true)
            {
                try
                {
                    string filePath = IOUtils.ReadValueFromConsole<string>("путь к выходному файлу");

                    // Пытаемся записать данные в файл и выйти из метода
                    FilesUtils.Write(filePath, answer);
                    return;
                }
                catch (Exception e)
                {
                    // Если во время считывания из файла ошибка, то выводим её,
                    // а затем просим ввести путь ещё раз
                    IOUtils.ShowError("Невозможно записать данные в этот файл");
                }
            }
        }
    }
}
