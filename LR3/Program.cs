using System;
using System.Text;

namespace LR3
{
    class Human
    {
        protected static int amountOfObjects = 0;
        protected string name;
        protected string surname;
        protected string patronymic;
        protected int age;
        protected string gender;
        protected string nationality;
        private string phoneNumber;
        private string emailAddress;
        private string vkAddress;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public Human() 
        {
            amountOfObjects++;
            Console.Write("Enter name:\n>> ");
            this.Name = Human.ValidWordInput();
            Console.Write("Enter surname:\n>> ");
            this.Surname = Human.ValidWordInput();
            Console.Write("Enter patronymic:\n>> ");
            this.Patronymic = Human.ValidWordInput();
            Console.Write("Enter age:\n>> ");
            do
            {
                this.Age = Human.ValidIntInput();
            } while (Human.CheckInput(this.age));
            Console.Write("Enter gender (Male/Female):\n>> ");
            do
            {
                this.Gender = Human.ValidWordInput();
            } while (Human.CheckInput(this.gender));
            Console.Write("Enter nationality:\n>> ");
            this.Nationality = Human.ValidWordInput();
        }
        public Human(string name, string surname, string patronymic, int age, string gender, string nationality)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.age = age;
            this.gender = gender;
            this.nationality = nationality;
        }
        
        public static string ValidWordInput()
        {
            string input;
            StringBuilder str = new StringBuilder();
            do
            {
                bool error = false;
                input = Console.ReadLine();
                if (input.Length == 0)
                {
                    Console.Write("You haven't typed anythyng. Try again:\n>> ");
                    continue;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsLetter(input[i]))
                    {
                        Console.Write("You have entered invalid symbols. Try again:\n>> ");
                        error = true;
                        break;
                    }
                }
                if (error) continue;
                else break;
            } while (true);
            str.Append(input.ToLower());
            str[0] = char.ToUpper(str[0]);
            return str.ToString();
        }
        public static int ValidIntInput()
        {
            string input;
            int result;
            while (true)
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out result))
                {
                    Console.Write("You have entered invalid symbols or you haven't typed anything. Try again:\n>> ");
                    continue;
                }
                else break;
            }
            return result;
        }
        public static double ValidDoubleInput()
        {
            string input;
            double result;
            while (true)
            {
                input = Console.ReadLine();
                if (!double.TryParse(input, out result))
                {
                    Console.Write("You have entered invalid symbols or you haven't typed anything. Try again:\n>> ");
                    continue;
                }
                else break;
            }
            return result;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{this.surname} {this.name} {this.patronymic}\n" +
                $"Age: {this.age} years\nGender: {this.gender}\nNationality: {this.nationality}");
        }
        public void ShowContacts()
        {
            Console.WriteLine($"Phone number: {this["phone"]}\nEmail address: {this["email"]}\nVK address: {this["vk"]}");
        }
        public static bool CheckInput(int age)
        {
            if (age <= 0)
            {
                Console.Write("Age must be positive. Try again:\n>> ");
                return true;
            }
            else if (age < 11)
            {
                Console.Write("Age must be greater than 11. Try again:\n>> ");
                return true;
            }
            else if (age > 125)
            {
                Console.Write("Age must be less than 125. Try again:\n>> ");
                return true;
            }
            else return false;
        }   
        public static bool CheckInput(string gender)
        {
            if (gender != "Male" && gender != "Female")
            {
                Console.Write("Gender must be male or female. Try again:\n>> ");
                return true;
            }
            else return false;
        }
        public void WatchMovie()
        {
            Console.WriteLine("You watched the movie");
        }
        public void WatchMovie(string movie)
        {
            Console.WriteLine($"You watched the movie \"{movie}\"");
        }
        public void GrowUp()
        {
            this.age++;
        }

        public string this[string index]
        {
            get
            {
                switch (index)
                {
                    case "phone":
                        return phoneNumber;
                    case "email":
                        return emailAddress;
                    case "vk":
                        return vkAddress;
                    default:
                        return null;
                }
            }
            set
            {
                switch (index)
                {
                    case "phone":
                        phoneNumber = value;
                        break;
                    case "email":
                        emailAddress = value;
                        break;
                    case "vk":
                        vkAddress = value;
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human example = new Human();
            example.ShowInfo();
            bool exit = true;
            while (exit)
            {
                Console.Write("\nWhat do you want to do? You can:\nWatch movies\nWatch a movie\nAdd phone number\nAdd email address\nAdd vk address\n" +
                    "Edit surname\nGrow up\nShow information\nShow contacts\nExit\n>> ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "Watch movies":
                        example.WatchMovie();
                        break;
                    case "Watch a movie":
                        Console.Write("What movie do you want to watch?\n>> ");
                        choice = Console.ReadLine();
                        example.WatchMovie(choice);
                        break;
                    case "Add phone number":
                        Console.Write(">> ");
                        example["phone"] = Console.ReadLine();
                        break;
                    case "Add email address":
                        Console.Write(">> ");
                        example["email"] = Console.ReadLine();
                        break;
                    case "Add vk address":
                        Console.Write(">> ");
                        example["vk"] = Console.ReadLine();
                        break;
                    case "Edit surname":
                        Console.Write(">> ");
                        example.Surname = Human.ValidWordInput();
                        break;
                    case "Grow up":
                        example.GrowUp();
                        break;
                    case "Show information":
                        example.ShowInfo();
                        break;
                    case "Show contacts":
                        example.ShowContacts();
                        break;
                    case "Exit":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("I cant understand you. Try again.");
                        break;
                }
            }
        }
    }
}