using static AdventOfCode.D8.ConsoleBooter.Instructions;

namespace AdventOfCode.D8
{
    public class Instruction
    {
        public string Name { get; private set; }
        public int Arg { get; }
        public bool IsVisited { get; private set; }

        public Instruction(string name, int arg)
        {
            Name = name;
            Arg = arg;
        }

        public static Instruction Parse(string input)
        {
            var instructionParts = input.Split(" ");
            var name = instructionParts[0];
            var arg = int.Parse(instructionParts[1]);

            return new Instruction(name, arg);
        }

        public void Visit() => IsVisited = true;
        public void Reset() => IsVisited = false;

        /// <summary>
        /// Swaps Nop with Jmp.
        /// </summary>
        public void Swap()
        {
            switch (Name)
            {
                case Jump:
                    Name = Ignore;
                    break;
                case Ignore:
                    Name = Jump;
                    break;
                case Increment:
                    break;
            }
        }
    }
}
