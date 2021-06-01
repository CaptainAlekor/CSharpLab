using System;

namespace LR8
{
    abstract class Sportsman : Human
    {
        static protected object record = 0;
        protected int careerLength;
        protected int goldMedals = 0;
        protected int silverMedals = 0;
        protected int bronzeMedals = 0;
        protected int salary;
        protected int category;

        public IEquipment Equipment { get; set; }
        public int CareerLength
        {
            get { return careerLength; }
            set { careerLength = value; }
        }
        public int GoldMedals
        {
            get { return goldMedals; }
            set { goldMedals = value; }
        }
        public int SilverMedals
        {
            get { return silverMedals; }
            set { silverMedals = value; }
        }
        public int BronzeMedals
        {
            get { return bronzeMedals; }
            set { bronzeMedals = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public void SetCategory()
        {
            Console.WriteLine("Enter a category:\n>> ");
            switch (ValidWordInput())
            {
                case "None":
                    category = Convert.ToInt32(Category.None);
                    break;
                case "Third":
                    category = Convert.ToInt32(Category.Third);
                    break;
                case "Second":
                    category = Convert.ToInt32(Category.First);
                    break;
                case "Candidate":
                    category = Convert.ToInt32(Category.Candidate);
                    break;
                case "Master":
                    category = Convert.ToInt32(Category.Master);
                    break;
                case "InternationalMaster":
                    category = Convert.ToInt32(Category.InternationalMaster);
                    break;
            }
        }
        public void GetCategory()
        {
            switch (category)
            {
                case 0:
                    Console.WriteLine("None");
                    break;
                case 1:
                    Console.WriteLine("Third youth rank");
                    break;
                case 2:
                    Console.WriteLine("Second youth rank");
                    break;
                case 3:
                    Console.WriteLine("First youth rank");
                    break;
                case 4:
                    Console.WriteLine("Сandidate to master sport");
                    break;
                case 5:
                    Console.WriteLine("Master of sport");
                    break;
                case 6:
                    Console.WriteLine("International master of sports");
                    break;
            }
        }

        public enum Category
        {
            None = 0,
            Third = 1,
            Second = 2,
            First = 3,
            Candidate = 4,
            Master = 5,
            InternationalMaster = 6
        }

        protected Sportsman(string name, string surname, string patronymic, int age, string gender, string nationality) : base(name, surname, patronymic, age, gender, nationality)
        {

        }
        protected Sportsman(Human subject)
        {
            amountOfObjects++;
            this.name = subject.Name;
            this.surname = subject.Surname;
            this.patronymic = subject.Patronymic;
            this.age = subject.Age;
            this.gender = subject.Gender;
            this.nationality = subject.Nationality;
        }
        protected Sportsman() : base() { }

        virtual public void GetAllInfo()
        {
            this.ShowInfo();
            Console.WriteLine($"Career: {careerLength} years\nGold medals: {goldMedals}\nSilver medals: {silverMedals}\n" +
                $"Bronze medals: {bronzeMedals}\nSalary: {salary} conventional units\nCategory: ");
            this.GetCategory();
        }
        public void GoJogging()
        {
            Console.WriteLine("You went for a jogging");
        }
        public void GoToGym()
        {
            Console.WriteLine("You went to the gym");
        }
        abstract public void SpecialTraining();
        public void GetSalary()
        {
            Console.WriteLine($"You received a salary of {salary} conventional units");
        }
    }
}
