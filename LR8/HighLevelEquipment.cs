using System;

namespace LR8
{
    class HighLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You wear top class clothing");
        }
        public void Trainer()
        {
            Console.WriteLine("You are trained by the best coaches");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You train in expensive gyms");
        }
        public void Nutrition()
        {
            Console.WriteLine("You are following a diet designed for you");
        }
    }
}
