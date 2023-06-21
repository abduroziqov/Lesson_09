namespace Lesson_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>  DisplayNumbers());

            thread.Start();
        }
        public static void DisplayNumbers()
        {
            Console.Write("Enter a number => ");

            int counter = 1;

            double inputNumber = double.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                Console.WriteLine($"Thread name: {counter++} => {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine("Thread is complete!");
        }
    }
}