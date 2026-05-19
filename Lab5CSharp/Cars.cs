namespace Lab5Cars
{
    //  --   Структура "Автомобіль": 
    // - Марка; 
    // - Рік випуску; 
    // - ціна; 
    // - Колір. 
    // Видалити всі елементи, у яких рік випуску менше заданого, додати елемент 
    // на початок масиву. ++

    public struct CarStruct
    {
        public string Brand;
        public int Year;
        public double Price;
        public string Color;

        public CarStruct(string brand, int year, double price, string color)
            => (Brand, Year, Price, Color) = (brand, year, price, color);

        public override string ToString() =>
            $"  {Brand,-15} | {Year,4} | {Price,12:N0} | {Color}";
    }

    public record Car(string Brand, int Year, double Price, string Color)
    {
        public override string ToString() =>
            $"  {Brand,-15} | {Year,4} | {Price,12:N0} | {Color}";
    }

    public class CarTest
    {
        static void TableHeader()
        {
            Console.WriteLine($"  {"Марка",-15} | {"Рік",4} | {"Ціна",12} | Колір");
            Console.WriteLine("  " + new string('-', 53));
        }

        static void Section(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('═', 54));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 54));
        }

        public static void Cartest()
        {


            const int MIN_YEAR = 2014;
            const string NEW_BRAND = "Honda";
            const int NEW_YEAR = 2023;
            const double NEW_PRICE = 780_000;
            const string NEW_COLOR = "Зелений";

            (string Brand, int Year, double Price, string Color)[] SeedData() =>
                new (string, int, double, string)[]
                {
        ("Toyota",     2015,   620_000, "Білий"),
        ("BMW",        2010,   850_000, "Чорний"),
        ("Volkswagen", 2019,   730_000, "Сірий"),
        ("Ford",       2008,   390_000, "Синій"),
        ("Mercedes",   2021, 1_200_000, "Чорний"),
        ("Skoda",      2013,   480_000, "Червоний"),
        ("Audi",       2017,   950_000, "Білий"),
                };





            Section("1 struct");

            List<CarStruct> structs = SeedData()
                .Select(d => new CarStruct(d.Brand, d.Year, d.Price, d.Color))
                .ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));
            structs.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));
            structs.Insert(0, new CarStruct(NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR));
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            structs.ForEach(c => Console.WriteLine(c));

            Section("2 ValueTuple");

            static string TupleLine((string Brand, int Year, double Price, string Color) c) =>
                $"  {c.Brand,-15} | {c.Year,4} | {c.Price,12:N0} | {c.Color}";

            List<(string Brand, int Year, double Price, string Color)> tuples =
                SeedData().ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            tuples.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            tuples.Insert(0, (NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR));
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            tuples.ForEach(c => Console.WriteLine(TupleLine(c)));

            var (brand, year, price, color) = tuples[0];
            Console.WriteLine($"\n> Brand={brand}, Year={year}, Price={price:N0}, Color={color}");


            Section("3 record");

            List<Car> records = SeedData()
                .Select(d => new Car(d.Brand, d.Year, d.Price, d.Color))
                .ToList();

            Console.WriteLine("\n> START:");
            TableHeader();
            records.ForEach(Console.WriteLine);

            records.RemoveAll(c => c.Year < MIN_YEAR);
            Console.WriteLine($"\n> видалення (рік < {MIN_YEAR}):");
            TableHeader();
            records.ForEach(Console.WriteLine);

            var newCar = new Car(NEW_BRAND, NEW_YEAR, NEW_PRICE, NEW_COLOR);
            records.Insert(0, newCar);
            Console.WriteLine($"\n> додавання «{NEW_BRAND}» на початок:");
            TableHeader();
            records.ForEach(Console.WriteLine);

            Console.WriteLine("\n> with:");
            Car modified = newCar with { Color = "Жовтий", Price = 800_000 };
            Console.WriteLine($"  Оригінал : {newCar}");
            Console.WriteLine($"  Копія    : {modified}");
            Console.WriteLine($"  ?   : {newCar == modified}");

            Console.WriteLine("\n> Pattern matching:");
            foreach (var c in records)
            {
                string label = c switch
                {
                    { Year: >= 2020 } => "Новий",
                    { Year: >= 2015, Price: > 700_000 } => "Сучасний / дорогий",
                    { Year: >= 2015 } => "Сучасний / бюджетний",
                    _ => "Старий",
                };
                Console.WriteLine($"  {c.Brand,-15} ({c.Year}) -> {label}");
            }
        }
    }
}