using System;

namespace LR8
{
    sealed class Athlete : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public Athlete(string name, string surname, string patronymic, int age, string gender, string nationality, string specialization) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.specialization = specialization;
        }
        public Athlete() : base() { }
        public Athlete(Human subject) : base(subject) { }

        public new int CompareTo(object s)
        {
            Athlete subject = s as Athlete;
            if (subject != null)
                return this.specialization.CompareTo(subject.specialization);
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            if (specialization == null) throw new Exception("You haven't set the athlet's specialization\n");
            base.GetAllInfo();
            Console.WriteLine($"Athlete's specialization: {specialization}");
        }
        public override void SpecialTraining()
        {
            if (specialization == "None")
            {
                Console.WriteLine("You have practiced athletics");
            }
            else
            {
                Console.WriteLine($"You hone your {specialization} skills");
            }
        }
        public void Compete()
        {
            if (specialization == null) throw new Exception("You haven't set the athlet's specialization\n");
            Random result = new Random();
            double distance = 60 * result.NextDouble();
            int place;
            if (distance > Convert.ToDouble(record))
            {
                Console.WriteLine($"Congratulations! You have set a new record: {distance} meters!");
                record = distance;
                place = 1;
            }
            else
            {
                place = result.Next(1, 16);
            }
            Console.WriteLine($"You took {place} place");
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
            else Console.WriteLine("The doping test has been passed. You are eligible to compete in athletics");
        }
    }
}
