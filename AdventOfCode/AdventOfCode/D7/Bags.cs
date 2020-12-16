using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D7
{
    public class Bags
    {
        private readonly IEnumerable<BagRules> _rules;

        public Bags(IEnumerable<BagRules> rules)
        {
            _rules = rules;
        }

        public int CountShinyGold() => _rules.Count(r => ContainsGold(r, _rules));

        private static bool ContainsGold(BagRules rule, IEnumerable<BagRules> rules)
        {
            if (!rule.CouldHold.Any())
            {
                return false;
            }
            else if (rule.CouldHold.Keys.Contains(Day7.ShinyGold))
            {
                return true;
            }
            else
            {
                return rules
                    .Where(r => rule.CouldHold.ContainsKey(r.Name))
                    .Any(r => ContainsGold(r, rules));
            }
        }
    }
}
