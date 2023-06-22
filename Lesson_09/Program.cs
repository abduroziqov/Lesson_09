using System.IO;

namespace Lesson_09
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            while (true)
            {
                Console.Write("Enter a number => ");
                double inputNumber = double.Parse(Console.ReadLine());

                if(inputNumber == 0) break;
                Thread thread = new Thread(() => SortOddNumbers(inputNumber, "Odd number", Directory.GetCurrentDirectory()));
                Thread thread1 = new Thread(() => SortEvenNumbers(inputNumber, "Even number", Directory.GetCurrentDirectory()));

                thread.Start();
                thread1.Start();
            }
        }
        public static void SortOddNumbers(double inputNumber, string name,string path)
        {
            path = Directory.GetCurrentDirectory() + inputNumber +  "OddNum.txt";
            double counter = 0;

            if (File.Exists(path));
            else
            {
                File.Create(path).Close();
                using (StreamWriter txtWriter = new StreamWriter(path))
                {
                    for (double i = 1; i <= inputNumber; i += 2)
                    {
                        Console.WriteLine($"Odd number => {counter++} : {i}");
                        Thread.Sleep(1000);
                        txtWriter.WriteLine($"Odd number => {counter} : {i}");
                    }
                }
                Console.WriteLine("Thread #1 is complete!");
                Console.WriteLine("File has been succesfully created.");
            } 
        }
        public static void SortEvenNumbers(double inputNumber,string name,string path)
        {
            path = Directory.GetCurrentDirectory() + inputNumber + "EvenNum.txt";
            double counter = 0;

            if (File.Exists(path))
            {
                Console.WriteLine("This file is already available in this folder.");
            }
            else
            {
                File.Create(path).Close();
                using (StreamWriter txtWriter = new StreamWriter(path))
                {
                    for (double i = 2; i <= inputNumber; i += 2)
                    {
                        Console.WriteLine($"Even number => {counter++} : {i}");
                        Thread.Sleep(1000);
                        txtWriter.WriteLine($"Even number => {counter} : {i}");
                    }
                }
                Console.WriteLine("Thread #2 is complete!");
            }
        }
    }
}