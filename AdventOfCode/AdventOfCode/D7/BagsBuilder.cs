//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.D7
//{
//    public static class BagsBuilder
//    {
//        public static IEnumerable<Bag> Build(string rules)
//        {
//            var bagRules = rules
//                .Split(Environment.NewLine)
//                .Select(r => BagRules.Parse(r));

//            return bagRules
//                .Select(br => BuildSingle(br, bagRules));
//        }

//        private static Bag BuildSingle(BagRules bagRules, IEnumerable<BagRules> allRules)
//        {
//            if(!bagRules.CouldHold.Any()) return new Bag(bagRules.Name, Enumerable.Empty<Bag>());

//            var belongingBags = allRules
//                .Where(r => bagRules.CouldHold.Keys.Contains(r.Name))
//                .Select(br => BuildSingle(br, allRules));

//            return new Bag(bagRules.Name, belongingBags);
//        }
//    }
//}