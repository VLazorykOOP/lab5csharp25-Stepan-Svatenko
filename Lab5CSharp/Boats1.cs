namespace Lab5Ships1
{
    // --    Варіанти задач. Побудувати ієрархію класів відповідно до варіанта 
    // завдання. Згідно завдання вибрати базовий клас та похідні. В класах задати поля, 
    // які характерні для кожного класу. Для всіх класів розробити  метод Show(), який 
    // виводить дані про об’єкт класу. 
    // Корабель, пароплав, вітрильник, корвет.++
    abstract class Ship
    {
        protected string name;
        protected int speed;

        public Ship(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        public abstract void Show();
    }

    class Steamship : Ship
    {
        private int power; // потужність двигуна

        public Steamship(string name, int speed, int power)
            : base(name, speed)
        {
            this.power = power;
        }

        public override void Show()
        {
            Console.WriteLine($"[Пароплав] Назва: {name}, Швидкість: {speed}, Потужність: {power}");
        }
    }
    class Sailboat : Ship
    {
        private int sails;
        public Sailboat(string name, int speed, int sails) : base(name, speed)
        {
            this.sails = sails;
        }

        public override void Show()
        {
            Console.WriteLine($"[Корвет] Назва: {name}, Швидкість: {speed}, Паруси: {sails}");
        }
    }
    class Corvet : Ship
    {
        private int weapon;
        public Corvet(string name, int speed, int weapon) : base(name, speed)
        {
            this.weapon = weapon;
        }

        public override void Show()
        {
            Console.WriteLine($"[Корабель] Назва: {name}, Швидкість: {speed}, Збруя: {weapon}");
        }
    }

    public class Boats1
    {
        public static void testboats1()
        {
            Ship[] ships = new Ship[6];

            FillArray(ships);

            Console.WriteLine("До:\n");
            ShowAll(ships);

            ships = ships.OrderBy(s => s.GetType().Name).ToArray();

            Console.WriteLine("\nCортування за типом:\n");
            ShowAll(ships);
        }

        static void FillArray(Ship[] ships)
        {
            ships[0] = new Steamship("Titanic", 40, 5000);
            ships[1] = new Sailboat("Pearl", 30, 5);
            ships[2] = new Corvet("Defender", 60, 20);
            ships[3] = new Sailboat("Wind", 25, 3);
            ships[4] = new Steamship("Atlas", 45, 6000);
            ships[5] = new Corvet("Guardian", 55, 15);
        }

        static void ShowAll(Ship[] ships)
        {
            foreach (var ship in ships)
            {
                ship.Show();
            }
        }
    }
}