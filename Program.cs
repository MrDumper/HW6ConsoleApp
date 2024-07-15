while (true)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1 - Вывести данные на экран");
    Console.WriteLine("2 - Заполнить данные и добавить новую запись");
    Console.Write("Ваш выбор: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayEmployees();
    }
    else if (choice == "2")
    {
        AddEmployee();
    }
    else
    {
        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
    }

    Console.WriteLine();
}

static void DisplayEmployees()
{
    string filename = "employees.txt";
    if (!File.Exists(filename))
    {
        Console.WriteLine("Файл не существует.");
        return;
    }

    string[] lines = File.ReadAllLines(filename);
    if (lines.Length == 0)
    {
        Console.WriteLine("Файл пуст.");
        return;
    }

    Console.WriteLine("Сотрудники:");
    foreach (string line in lines)
    {
        string[] data = line.Split('#');
        Console.WriteLine($"ID: {data[0]}");
        Console.WriteLine($"Дата и время добавления записи: {data[1]}");
        Console.WriteLine($"Ф. И. О.: {data[2]}");
        Console.WriteLine($"Возраст: {data[3]}");
        Console.WriteLine($"Рост: {data[4]}");
        Console.WriteLine($"Дата рождения: {data[5]}");
        Console.WriteLine($"Место рождения: {data[6]}");
        Console.WriteLine();
    }
}

static void AddEmployee()
{
    string filename = "employees.txt";

    Console.WriteLine("Введите данные нового сотрудника:");

    Console.Write("ID: ");
    string id = Console.ReadLine();

    Console.Write("Ф. И. О.: ");
    string fullName = Console.ReadLine();

    Console.Write("Возраст: ");
    string age = Console.ReadLine();

    Console.Write("Рост: ");
    string height = Console.ReadLine();

    Console.Write("Дата рождения: ");
    string birthDate = Console.ReadLine();

    Console.Write("Место рождения: ");
    string birthPlace = Console.ReadLine();

    string record = $"{id}#{DateTime.Now:dd.MM.yyyy HH:mm}#{fullName}#{age}#{height}#{birthDate}#{birthPlace}";

    using (StreamWriter writer = File.AppendText(filename))
    {
        writer.WriteLine(record);
    }

    Console.WriteLine("Данные сотрудника добавлены.");
}
