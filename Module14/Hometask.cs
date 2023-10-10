namespace Module14;

public class Hometask
{
    public void Practice_14_3_3()
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