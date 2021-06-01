using System;

namespace LR8
{
    sealed class Footballer : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private string club = "None";
        private int scoredGoals;

        public string Club
        {
            get { return club; }
            set { club = value; }
        }
        public int ScoredGoals
        {
            get { return scoredGoals; }
            set { scoredGoals = value; }
        }

        public Footballer(string name, string surname, string patronymic, int age, string gender, string nationality, string club, int scoredGoals) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.club = club;
            this.scoredGoals = scoredGoals;
        }
        public Footballer() : base() { }
        public Footballer(Human subject) : base(subject) { }

        public new int CompareTo(object s)
        {
            Footballer subject = s as Footballer;
            if (subject != null)
                return this.scoredGoals.CompareTo(subject.scoredGoals);
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            base.GetAllInfo();
            Console.WriteLine($"Player's club: {club}");
        }
        public override void SpecialTraining()
        {
            Console.WriteLine("You had a training session with renowned football coaches");
        }
        public void Compete()
        {
            Random result = new Random();
            int place = result.Next(1, 16);
            Console.WriteLine($"Your team took {place} place");
            if (place == 1)
            {
                Console.WriteLine("You received a gold medal!");
                goldMedals++;
                salary += 150;
            }
            else if (place == 2)
            {
                Console.WriteLine("You received a silver medal!");
                silverMedals++;
                salary += 100;
            }
            else if (place == 3)
            {
                Console.WriteLine("You received a bronze medal!");
                bronzeMedals++;
                salary += 50;
            }
            SalaryNotify?.Invoke(salary);
            MedalNotify?.Invoke(bronzeMedals, silverMedals, goldMedals);
        }
        public void DopingTest()
        {
            Random result = new Random();
            if (result.Next(1, 20) == 10) throw new Exception("You failed the doping test\n");
            else Console.WriteLine("The doping test has been passed. You are admitted to the tournament");
        }
    }
}
