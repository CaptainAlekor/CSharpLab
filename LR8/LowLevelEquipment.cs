using System;

namespace LR8
{
    class LowLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You wear normal clothes");
        }
        public void Trainer()
        {
            Console.WriteLine("You don't have your own coach");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You train at home or on the sports ground");
        }
        public void Nutrition()
        {
            Console.WriteLine("Your diet is no different from usual diet");
        }
    }
}
