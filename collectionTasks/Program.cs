using System.Collections.Generic;

namespace collectionTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            /*   int[] numArray = { -2, 5, 0, 7 };
               MyMethod nums = new MyMethod();
               Console.WriteLine(nums.FindSumOfPositiveNumbers(numArray)); ;*/

            //Task2
            /* List<int> list = new List<int> { 2, 2, 3, 2, 4, 3};
             MyMethod method = new MyMethod();
             method.UniquePreserveOrder(list);*/

            //Task3
            /* List<string> list = new List<string> { "Fatima;-20", "Samaya;20", "20;Khanim", "Leman;20" };
             Person p = new Person();
             List<Person> people = p.ParsePeople(list);

             foreach (var person in people)
             {
                 Console.WriteLine($"{person.Name} - {person.Age}");
             }*/

            //Task4
            /* string sentence = "Salam salam salam, dünya";
             MyMethod method = new MyMethod();
             List<(string word, int count)> list = method.WordFrequency(sentence);

             foreach (var item in list)
             {
                 Console.WriteLine($"{item.word} - {item.count}");
             }*/

            //Task5
            /* Student a = new Student("Fatima");
             Student b = new Student("Leman");
             b.Grades.Add(100);
             Student c = new Student("Khanim");
             b.Grades.Add(70);

             List<Student> students = new List<Student> { a, b };

             Student student = new Student();
             List<Student> newStudents = student.FilterByAverage(students);

             foreach (var s in newStudents)
             {
                 Console.WriteLine($"Name: {s.Name}, GPA: {s.Grades.Average()}");
             }*/

            //Task6
            /* Console.Write("Enter letters: ");
             string letters = Console.ReadLine();

             MyMethod myMethod = new MyMethod();
             string result = myMethod.Compress(letters);
             Console.WriteLine(result);*/

            //Task7
            /* Product p1 = new Product(0, "apple", 2.00, 3);
             p1.AddStock(-1);
             p1.AddStock(2);
             Console.WriteLine($"Name: {p1.Name}, TotalValue:{p1.TotalValue()}, Stock: {p1.Stock}");

             Product p2 = new Product(1, "banana", 5.00, 10);
             p2.Sell(12);
             Console.WriteLine($"Name: {p2.Name}, TotalValue:{p2.TotalValue()}, Stock: {p2.Stock}");

             Product p3 = new Product(2, "cherry", 10.25, 4);
             Console.WriteLine($"Name: {p3.Name}, TotalValue:{p3.TotalValue()}, Stock: {p3.Stock}");*/
        }
    }
}
public class MyMethod
{
    //Task1
    public int FindSumOfPositiveNumbers(int[] nums)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            if (num > 0)
            {
                sum += num;
            }
        }
        return sum;
    }

    //Task2
    public void UniquePreserveOrder(List<int> list)
    {
        List<int> nums = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (!nums.Contains(list[i]))
            {
                nums.Add(list[i]);
            }
        }
        foreach (var num in nums)
        {
            Console.Write(num + " ");
        }
    }

    //Task4
    public List<(string word, int count)> WordFrequency(string sentence)
    {
        char[] chars = { ',', '.', '!', '?', ' ' };
        string[] parts = sentence.Split(chars, StringSplitOptions.RemoveEmptyEntries);

        List<(string word, int count)> words = new List<(string word, int count)>();
        int count = 1;

        foreach (var part in parts)
        {
            string word = part.Trim().ToLower();

            if (words.Contains((word, count)))
            {
                words.Remove((word, count));
                count++;
                words.Add((word, count));
            }
            else
            {
                words.Add((word, 1));
            }
        }

        return words;
    }

    //Task6
    public string Compress(string s)
    {
        char[] letters = s.ToCharArray();

        string word = " ";
        string newWord = " ";

        foreach (var letter in s)
        {
            if (!word.Contains(letter))
            {
                int count = 0;
                foreach (var l in s)
                {
                    if (l == letter)
                    {
                        count++;
                    }
                }
                newWord += $"{letter}{count}";
                word += letter;
            }
        }
        return newWord;
    }
}

//Task3
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public List<Person> ParsePeople(List<string> list)
    {
        List<Person> persons = new List<Person>();

        foreach (var item in list)
        {
            string[] parts = item.Split(';');

            string name = parts[0].Trim();
            string agePart = parts[1].Trim();

            if (int.TryParse(agePart, out int age))
            {
                if (age >= 0 && age <= 150)
                {
                    persons.Add(new Person { Name = name, Age = age });
                }
            }
        }

        return persons;
    }
}
//Task5
public class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; }

    public Student()
    {

    }
    public Student(string name)
    {
        Name = name;
        Grades = new List<int> { };
    }

    public List<Student> FilterByAverage(List<Student> students, double threshold = 70)
    {
        List<Student> result = new List<Student>();
        foreach (var student in students)
        {
            if (student.Grades.Count > 0)
            {
                if (student.Grades.Average() > threshold)
                {
                    result.Add(student);
                }
            }
        }
        return result;
    }
}

//Task7
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public double TotalValue()
    {
        return Price * Stock;
    }

    public void AddStock(int qty)
    {
        if (qty > 0)
        {
            Stock += qty;
        }
    }

    public int Sell(int qty)
    {
        if (qty < Stock)
        {
            Stock -= qty;
        }
        else
        {
            Stock = 0;
        }
        return Stock;
    }

}

