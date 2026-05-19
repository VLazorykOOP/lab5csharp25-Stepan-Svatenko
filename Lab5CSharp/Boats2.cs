// -- До побудованої ієрархії класів з завдання 1 додати
// конструктори та деструктори в який виводити повідомлення в консоль.
// Продемонструвати порядок виклику конструкторів та деструкторів. У класах
// передбачити не менше 3 (трьох) конструкторів. ++

namespace Lab5Ships2
{
    abstract class Ship
    {
        protected string name;
        protected int speed;

        public Ship()
        {
            name = "Невідомо";
            speed = 0;
            Console.WriteLine($"  [Ship] конструктор без параметрів → name={name}");
        }

        public Ship(string name)
        {
            this.name = name;
            speed = 0;
            Console.WriteLine($"  [Ship] конструктор(name) → name={name}");
        }

        public Ship(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
            Console.WriteLine($"  [Ship] конструктор(name, speed) → name={name}, speed={speed}");
        }

        ~Ship()
        {
            Console.WriteLine($"  [~Ship] деструктор → name={name}");
        }

        public abstract void Show();
    }

    class Steamship : Ship
    {
        private int power;

        public Steamship() : base()
        {
            power = 0;
            Console.WriteLine($"  [Steamship] конструктор без параметрів → power={power}");
        }

        public Steamship(string name) : base(name)
        {
            power = 0;
            Console.WriteLine($"  [Steamship] конструктор(name) → power={power}");
        }

        public Steamship(string name, int speed, int power) : base(name, speed)
        {
            this.power = power;
            Console.WriteLine($"  [Steamship] конструктор(name, speed, power) → power={power}");
        }

        ~Steamship()
        {
            Console.WriteLine($"  [~Steamship] деструктор → name={name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Пароплав] Назва: {name}, Швидкість: {speed}, Потужність: {power}");
        }
    }

    class Sailboat : Ship
    {
        private int sails;

        public Sailboat() : base()
        {
            sails = 0;
            Console.WriteLine($"  [Sailboat] конструктор без параметрів → sails={sails}");
        }

        public Sailboat(string name) : base(name)
        {
            sails = 0;
            Console.WriteLine($"  [Sailboat] конструктор(name) → sails={sails}");
        }

        public Sailboat(string name, int speed, int sails) : base(name, speed)
        {
            this.sails = sails;
            Console.WriteLine($"  [Sailboat] конструктор(name, speed, sails) → sails={sails}");
        }

        ~Sailboat()
        {
            Console.WriteLine($"  [~Sailboat] деструктор → name={name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Вітрильник] Назва: {name}, Швидкість: {speed}, Вітрила: {sails}");
        }
    }

    class Corvette : Ship
    {
        private int weapon;

        public Corvette() : base()
        {
            weapon = 0;
            Console.WriteLine($"  [Corvette] конструктор без параметрів → weapon={weapon}");
        }

        public Corvette(string name) : base(name)
        {
            weapon = 0;
            Console.WriteLine($"  [Corvette] конструктор(name) → weapon={weapon}");
        }

        public Corvette(string name, int speed, int weapon) : base(name, speed)
        {
            this.weapon = weapon;
            Console.WriteLine($"  [Corvette] конструктор(name, speed, weapon) → weapon={weapon}");
        }

        ~Corvette()
        {
            Console.WriteLine($"  [~Corvette] деструктор → name={name}");
        }

        public override void Show()
        {
            Console.WriteLine($"[Корвет] Назва: {name}, Швидкість: {speed}, Зброя: {weapon}");
        }
    }

    public class Boats2
    {
        public static void testboats2()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string line = new string('─', 50);

            Console.WriteLine(line);
            Console.WriteLine("1. Конструктор без параметрів (Steamship)");
            Console.WriteLine(line);
            var s1 = new Steamship();
            s1.Show();

            Console.WriteLine(line);
            Console.WriteLine("2. Конструктор з одним параметром (Sailboat)");
            Console.WriteLine(line);
            var b1 = new Sailboat("Слава");
            b1.Show();

            Console.WriteLine(line);
            Console.WriteLine("3. Конструктор з повними параметрами (Corvette)");
            Console.WriteLine(line);
            var c1 = new Corvette("Гетьман", 30, 8);
            c1.Show();

            Console.WriteLine(line);
            Console.WriteLine("4. Масив — поліморфний Show()");
            Console.WriteLine(line);
            Ship[] fleet =
            [
                new Steamship("Леся", 18, 12000),
                new Sailboat("Надія", 14, 3),
                new Corvette("Козак", 32, 6),
            ];
            foreach (var ship in fleet)
                ship.Show();

            Console.WriteLine(line);
            Console.WriteLine("5. Демонстрація деструкторів через GC.Collect()");
            Console.WriteLine(line);
            {
                var temp = new Steamship("Тимчасовий", 10, 500);
                temp.Show();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(line);
            Console.WriteLine("Завершення Main — деструктори решти об'єктів");
            Console.WriteLine(line);
        }
    }
}