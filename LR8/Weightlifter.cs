using System;

namespace LR8
{
    sealed class Weightlifter : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Weightlifter(string name, string surname, string patronymic, int age, string gender, string nationality, int weight) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.weight = weight;
        }
        public Weightlifter() : base() { }
        public Weightlifter(Human subject) : base(subject) { }


        public new int CompareTo(object s)
        {
            Weightlifter subject = s as Weightlifter;
            if (subject != null)
            {
                return this.weight.CompareTo(subject.weight);
            }
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            base.GetAllInfo();
            Console.WriteLine($"Weight: {weight}");
        }
        public override void SpecialTraining()
        {
            Console.WriteLine("You did a barbell workout");
        }
        public void Compete()
        {
            Random result = new Random();
            int totalWeight = result.Next(60, 250);
            int place;
            if (totalWeight > Convert.ToInt32(record))
            {
                Console.WriteLine($"Congratulations! You have set a new record: {totalWeight} kg!");
                record = totalWeight;
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
            else Console.WriteLine("The doping test has been passed. You are eligible to compete in weightlifting");
        }
    }
}
