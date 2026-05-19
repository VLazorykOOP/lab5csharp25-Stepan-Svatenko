using Lab5Ships2;
using Lab5Ships1;
using Lab5Persona;
using Lab5Cars;

namespace Lab5CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 4 CSharp");
            // int n = Convert.ToInt32(Console.ReadLine());
            int n = 0;
            do
            {
                Console.WriteLine("Enter number of task: ");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Boats1.testboats1();
                        break;
                    case 2:
                        Boats2.testboats2();
                        break;
                    case 3:
                        PersonTest.personatest();
                        break;
                    case 4:
                        CarTest.Cartest();
                        break;
                }
            } while (n != 0);
        }
    }
}