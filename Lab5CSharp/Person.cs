namespace Lab5Persona
{

    // --    Створити  абстрактний  клас  Persona  з  методами, що дозволяють 
    // вивести  на  екран  інформацію  про  персону,  а  також  визначити  її  вік  (на 
    // момент  поточної дати). Створити похідні класи:  Абітурієнт (прізвище, 
    // дата  народження,  факультет),  Студент  (прізвище,  дата  народження, 
    // факультет,  курс),  Викладати  (прізвище,  дата  народження,  факультет, 
    // посада,  стаж),  зі своїми  методами  висновку інформації  на  екран,  і 
    // визначення  віку.  Створити  базу  (масив)  з  n  персон,  вивести  повну 
    // інформацію з бази на екран, а також організувати  пошук  персон, чий вік 
    // попадає в заданий діапазон. ++


    abstract class Persona
    {
        protected string lastName;
        protected DateOnly birthDate;

        public Persona(string lastName, DateOnly birthDate)
        {
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        public int Age()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        public abstract void Show();
    }

    class Applicant : Persona
    {
        private string faculty;

        public Applicant(string lastName, DateOnly birthDate, string faculty)
            : base(lastName, birthDate)
        {
            this.faculty = faculty;
        }

        public override void Show()
        {
            Console.WriteLine($"[Абітурієнт] {lastName}, " +
                              $"Дата народження: {birthDate:dd.MM.yyyy}, " +
                              $"Вік: {Age()}, " +
                              $"Факультет: {faculty}");
        }
    }

    class Student : Persona
    {
        private string faculty;
        private int course;

        public Student(string lastName, DateOnly birthDate, string faculty, int course)
            : base(lastName, birthDate)
        {
            this.faculty = faculty;
            this.course = course;
        }

        public override void Show()
        {
            Console.WriteLine($"[Студент]    {lastName}, " +
                              $"Дата народження: {birthDate:dd.MM.yyyy}, " +
                              $"Вік: {Age()}, " +
                              $"Факультет: {faculty}, " +
                              $"Курс: {course}");
        }
    }

    class Teacher : Persona
    {
        private string faculty;
        private string position;
        private int experience;

        public Teacher(string lastName, DateOnly birthDate,
                       string faculty, string position, int experience)
            : base(lastName, birthDate)
        {
            this.faculty = faculty;
            this.position = position;
            this.experience = experience;
        }

        public override void Show()
        {
            Console.WriteLine($"[Викладач]   {lastName}, " +
                              $"Дата народження: {birthDate:dd.MM.yyyy}, " +
                              $"Вік: {Age()}, " +
                              $"Факультет: {faculty}, " +
                              $"Посада: {position}, " +
                              $"Стаж: {experience} р.");
        }
    }

    public class PersonTest
    {
        public static void personatest()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Persona[] db =
            [
                new Applicant("Коваленко", new DateOnly(2006, 5, 12),  "Комп'ютерні науки"),
                new Applicant("Мельник",   new DateOnly(2007, 3, 22),  "Математика"),
                new Student(  "Бондаренко",new DateOnly(2004, 8, 1),   "Фізика", 2),
                new Student(  "Шевченко",  new DateOnly(2003, 11, 30), "Комп'ютерні науки", 3),
                new Student(  "Кравченко", new DateOnly(2002, 6, 15),  "Хімія", 4),
                new Teacher(  "Іваненко",  new DateOnly(1975, 4, 20),  "Математика",         "Доцент",    18),
                new Teacher(  "Петренко",  new DateOnly(1968, 9, 5),   "Фізика",             "Професор",  30),
                new Teacher(  "Сидоренко", new DateOnly(1990, 1, 17),  "Комп'ютерні науки",  "Асистент",   5),
            ];

            string line = new string('═', 60);

            Console.WriteLine(line);
            Console.WriteLine("  ПОВНА БАЗА ПЕРСОН");
            Console.WriteLine(line);
            foreach (var p in db)
                p.Show();

            Console.WriteLine();
            Console.WriteLine(line);
            Console.WriteLine("  ПОШУК ЗА ДІАПАЗОНОМ ВІКУ");
            Console.WriteLine(line);

            int minAge = 18;
            int maxAge = 25;

            Console.WriteLine($"  Вік від {minAge} до {maxAge} років:");
            Console.WriteLine(new string('-', 60));

            bool found = false;
            foreach (var p in db)
            {
                if (p.Age() >= minAge && p.Age() <= maxAge)
                {
                    p.Show();
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("  Персон у заданому діапазоні не знайдено.");

            Console.WriteLine(line);
        }
    }
}