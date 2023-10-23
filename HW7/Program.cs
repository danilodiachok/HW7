using System.Text.RegularExpressions;

namespace HW7


{
    class Program
    {
        static void Main()
        {


            using (StreamWriter writer = new StreamWriter("phones.txt"))
            {
                writer.WriteLine("danilo-8012345678");
                writer.WriteLine("diana-8011111111");
                writer.WriteLine("mikola-8022222222");
                writer.WriteLine("tamara-8033333333");
                writer.WriteLine("valik-8044444444");
                writer.WriteLine("olena-8055555555");
                writer.WriteLine("daniloG-8066666666");
                writer.WriteLine("vita-8077777777");
                writer.WriteLine("dimon-8088888888");
               
            }

            //створення і заповнення словника
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader("phones.txt"))
            {
                for (int i = 0; i < 9; i++)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] parts = line.Split('-');
                        if (parts.Length == 2)
                        {
                            PhoneBook[parts[0]] = parts[1];
                        }
                    }
                }
            }



            //пошук номера
            Console.Write("Введіть ім'я для пошуку номера телефону: ");
           string searchName = Console.ReadLine();
           if (PhoneBook.ContainsKey(searchName))
           {
                
                Console.WriteLine($"Номер телефону для {searchName}: {PhoneBook[searchName]}");
           }
           else
           {
                Console.WriteLine($"Номер телефону для {searchName} не знайдено.");
           }

            //зміна формату і запис в файл
            Dictionary<string, string> updatedPhoneBook = new Dictionary<string, string>();
            foreach (var entry in PhoneBook)
            {
                string formattedNumber = FormatPhoneNumber(entry.Value);
                updatedPhoneBook[entry.Key] = formattedNumber;
            }



            //Console.WriteLine($"Номер телефону для {searchName}: {PhoneBook[searchName]}");


            using (StreamWriter writer = new StreamWriter("New.txt"))
            {
                foreach (var entry in updatedPhoneBook)
                {
                    writer.WriteLine($"{entry.Key}-{entry.Value}");


                }
            }


            Console.WriteLine("Вміст файлу 'New.txt':");
            using (StreamReader reader = new StreamReader("New.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

        //метод зміни формату
        static string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10 && phoneNumber.StartsWith("80"))
            {
                return "+380" + phoneNumber.Substring(2);
            }
            return phoneNumber;
        }

    }
}