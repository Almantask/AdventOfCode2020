using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.D2
{
    public static class Day2
    {
        public static void Solve()
        {
            var passwordsAndPolicies = File.ReadAllLines("D2/Input.txt");

            Console.WriteLine("D2P1 answer: " + Part1.Solve(passwordsAndPolicies));
            Console.WriteLine("D2P2 answer: " + Part2.Solve(passwordsAndPolicies));
        }

        public static class Part1
        {
            /// <summary>
            /// How many passwords are valid according to their policies.
            /// </summary>
            public static int Solve(string[] passwordsAndPolicies) 
                => passwordsAndPolicies.Count(p => PasswordPolicy.IsValid(p));

            public readonly struct PasswordPolicy
            {
                public readonly int Min;
                public readonly int Max;
                public readonly char Character;

                public PasswordPolicy(int min, int max, char character)
                {
                    Min = min;
                    Max = max;
                    Character = character;
                }

                /// <summary>
                /// Character after first space (" ") must be between first and second numbers separated by a dash.
                /// Password is the last word, separated by ": ".
                /// </summary>
                public static (PasswordPolicy passwordPolicy, string password) Parse(string passwordAndPolicy)
                {
                    var passWordAndPolicy = passwordAndPolicy.Split(": ");
                    var password = passWordAndPolicy[1];

                    var policyParts = passwordAndPolicy.Replace('-', ' ').Split(' ');
                    var min = int.Parse(policyParts[0]);
                    var max = int.Parse(policyParts[1]);
                    var character = policyParts[2][0];
                    var passwordPolicy = new PasswordPolicy(min, max, character);

                    return (passwordPolicy, password);
                }

                /// <summary>
                /// Character after first space (" ") must be between first and second numbers separated by a dash.
                /// Password is the last word, separated by ": ".
                /// </summary>
                public static bool IsValid(string passwordAndPolicy)
                {
                    var (policy, password) = Parse(passwordAndPolicy);
                    var policyChar = password.Count(c => c == policy.Character);

                    return policyChar >= policy.Min && policyChar <= policy.Max;
                }
            }
        }

        public static class Part2
        {
            /// <summary>
            /// How many passwords are valid according to their policies.
            /// </summary>
            public static int Solve(string[] passwordsAndPolicies)
                => passwordsAndPolicies.Count(p => PasswordPolicy.IsValid(p));

            public readonly struct PasswordPolicy
            {
                public readonly int FirstIndex;
                public readonly int SecondIndex;
                public readonly char Character;

                public PasswordPolicy(int firstIndex, int secondIndex, char character)
                {
                    FirstIndex = firstIndex;
                    SecondIndex = secondIndex;
                    Character = character;
                }

                public static (PasswordPolicy passwordPolicy, string password) Parse(string passwordAndPolicy)
                {
                    var passWordAndPolicy = passwordAndPolicy.Split(": ");
                    var password = passWordAndPolicy[1];

                    var policyParts = passwordAndPolicy.Replace('-', ' ').Split(' ');
                    var min = int.Parse(policyParts[0]);
                    var max = int.Parse(policyParts[1]);
                    var character = policyParts[2][0];
                    var passwordPolicy = new PasswordPolicy(min, max, character);

                    return (passwordPolicy, password);
                }

                /// <summary>
                /// Character after first space (" ") must appear once in
                /// Password which is the last word, separated by ": ".
                /// It needs to appear exactly once at dash separated positions (2 positions).
                /// </summary>
                public static bool IsValid(string passwordAndPolicy)
                {
                    var (policy, password) = Parse(passwordAndPolicy);

                    int count = 0;
                    count += password[policy.FirstIndex - 1] == policy.Character ? 1 : 0;
                    count += password[policy.SecondIndex - 1] == policy.Character ? 1 : 0;

                    const int maxOcurences = 1;
                    return count == maxOcurences;
                }
            }
        }
    }
}
