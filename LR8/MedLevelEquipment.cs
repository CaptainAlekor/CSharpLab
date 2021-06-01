using System;

namespace LR8
{
    class MedLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You are wearing branded sportswear");
        }
        public void Trainer()
        {
            Console.WriteLine("You work with a personal coach");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You work out in the gym");
        }
        public void Nutrition()
        {
            Console.WriteLine("You are on a sports diet");
        }
    }
}
