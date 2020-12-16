//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.D7
//{
//    public class Bag
//    {
//        public string Name { get; }
//        public IEnumerable<Bag> Bags { get; }

//        public Bag(string name, IEnumerable<Bag> bags)
//        {
//            Name = name;
//            Bags = bags;
//        }

//        public bool CanHold()
//        {
//            return Bags.Any(b => 
//                b.Name == Day7.ShinyGold ||
//                b.CanHold());
//        }
//    }
//}