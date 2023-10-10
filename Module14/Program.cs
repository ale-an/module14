namespace Module14
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task_4();
            Task_8();
            Task_14_1_1();
            Task_14_1_2();
            Task_14_1_5();
            Task_14_1_6();
            Task_14_2_1();
            Task_14_2_3();
            Task_14_2_4();
            Task_14_2_5();
            Task_14_2_10();
        }

        private static void Task_4()
        {
            string[] people = {"Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян"};
            var list = new List<string>();
            foreach (var person in people)
            {
                if (person[0] == 'А')
                {
                    list.Add(person);
                }
            }

            list.Sort();
        }

        private static void Task_8()
        {
            var objects = new List<object>()
            {
                1,
                "Сергей ",
                "Андрей ",
                300,
            };

            foreach (var element in objects.Where(x => x is string).OrderBy(x => x.ToString()).ToArray())
                Console.WriteLine(element);
        }

        private static void Task_14_1_1()
        {
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var cities = russianCities
                .Where(y => y.Name.Length <= 10)
                .OrderBy(y => y.Name.Length);
            foreach (var city in cities)
            {
                Console.WriteLine(city.Name);
            }
        }

        private static void Task_14_1_2()
        {
            string[] text =
            {
                "Раз два три",
                "четыре пять шесть",
                "семь восемь девять"
            };

            var words = text.SelectMany(x => x.Split(' '));

            foreach (var word in words)
                Console.WriteLine(word);
        }

        private static void Task_14_1_5()
        {
            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] {"Mobile", "Desktop"});
            companies.Add("Samsung", new[] {"Mobile"});
            companies.Add("IBM", new[] {"Desktop"});

            var mobileCompanies = companies.Where(x => x.Value.Contains("Mobile"));

            foreach (var mobileCompany in mobileCompanies)
                Console.WriteLine(mobileCompany.Key);
        }

        private static void Task_14_1_6()
        {
            var numsList = new List<int[]>()
            {
                new[] {2, 3, 7, 1},
                new[] {45, 17, 88, 0},
                new[] {23, 32, 44, -6},
            };

            var newList = numsList.SelectMany(x => x).OrderBy(x => x);

            foreach (var element in newList)
            {
                Console.WriteLine(element);
            }
        }

        private static void Task_14_2_1()
        {
            string[] words = {"Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха"};
            var animals = words.Select(x => new
            {
                Name = x,
            }).OrderBy(x => x.Name.Length);

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
            }
        }

        private static void Task_14_2_3()
        {
            List<Student> students = new List<Student>
            {
                new Student {Name = "Андрей", Age = 23, Languages = new List<string> {"английский", "немецкий"}},
                new Student {Name = "Сергей", Age = 27, Languages = new List<string> {"английский", "французский"}},
                new Student {Name = "Дмитрий", Age = 29, Languages = new List<string> {"английский", "испанский"}},
                new Student {Name = "Василий", Age = 24, Languages = new List<string> {"испанский", "немецкий"}}
            };

            var applications = from s in students
                where s.Age < 27
                let yearOfBirth = DateTime.Now.Year - s.Age
                select new Application()
                {
                    Name = s.Name,
                    YearOfBirth = yearOfBirth
                };
            foreach (var sApplication in applications)
            {
                Console.WriteLine(sApplication.Name + ", " + sApplication.YearOfBirth);
            }
        }

        private static void Task_14_2_4()
        {
            var students = new List<Student>
            {
                new Student {Name = "Андрей", Age = 23, Languages = new List<string> {"английский", "немецкий"}},
                new Student {Name = "Сергей", Age = 27, Languages = new List<string> {"английский", "французский"}},
                new Student {Name = "Дмитрий", Age = 29, Languages = new List<string> {"английский", "испанский"}}
            };

            var coarses = new List<Coarse>
            {
                new Coarse {Name = "Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                new Coarse {Name = "Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var studentsWithCoarses = from stud in students
                where stud.Age < 29
                where stud.Languages.Contains("английский")
                let yearOfBirth = DateTime.Now.Year - stud.Age
                from coarse in coarses
                where coarse.Name == "Язык программирования C#"
                select new
                {
                    Name = stud.Name, CoarseName = coarse.Name, YearOfBirth = yearOfBirth
                };

            foreach (var stud in studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");
        }

        private static void Task_14_2_5()
        {
            var contacts = new List<Contact1>()
            {
                new Contact1() {Name = "Андрей", Phone = 7999945005},
                new Contact1() {Name = "Сергей", Phone = 799990455},
                new Contact1() {Name = "Иван", Phone = 79999675},
                new Contact1() {Name = "Игорь", Phone = 8884994},
                new Contact1() {Name = "Анна", Phone = 665565656},
                new Contact1() {Name = "Василий", Phone = 3434}
            };

            while (true)
            {
                var keyChar = Console.ReadLine();

                var page = Convert.ToInt32(keyChar);

                var pagedContacts = contacts.Skip(page * 2 - 2).Take(2);

                foreach (var contact in pagedContacts)
                {
                    Console.WriteLine(contact.Name);
                }
            }
        }

        private static void Task_14_2_10()
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList(); // сортировка по имени, а потом по фамилии
            
            while (true)
            {
                var keyChar = Console.ReadLine();

                var page = Convert.ToInt32(keyChar);

                var pagedContacts = phoneBook.Skip(page * 2 - 2).Take(2);

                foreach (var record in pagedContacts)
                    Console.WriteLine(record.Name + " " + record.LastName + ": " + record.PhoneNumber);
            }
        }
    }
}