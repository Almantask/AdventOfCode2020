using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D7
{
    public class BagRules
    {
        public string Name { get; }
        public Dictionary<string, int> CouldHold { get; }

        public BagRules(string name, Dictionary<string, int> couldHold)
        {
            Name = name;
            CouldHold = couldHold;
        }

        public static BagRules Parse(string rule)
        {
            rule = rule
                .Replace("bags", "")
                .Replace("bag", "")
                .Replace(".", "");

            var bagAndContains = rule.Split("contain");
            var name = bagAndContains[0].Trim();

            var containedBags = bagAndContains[1].Split(',');

            Dictionary<string, int> canContain;
            if (containedBags[0].Trim() == "no other")
            {
                canContain = new Dictionary<string, int>();
            }
            else
            {
                canContain = containedBags
                    .Select(cb => cb.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    .ToDictionary(
                        b => $"{b[1]} {b[2]}",
                        b => int.Parse(b[0]));
            }

            var bag = new BagRules(name, canContain);

            return bag;
        }
    }
}