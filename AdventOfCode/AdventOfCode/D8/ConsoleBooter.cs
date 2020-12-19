using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using static AdventOfCode.D8.ConsoleBooter.Instructions;

namespace AdventOfCode.D8
{
    public class ConsoleBooter
    {
        public static class Instructions
        {
            /// <summary>
            /// Do nothing. Ignore number after
            /// </summary>
            public const string Ignore = "nop";
            /// <summary>
            /// Jump to next instruction indicated by a number next to 
            /// </summary>
            public const string Jump = "jmp";
            /// <summary>
            /// Add to global accumulator.
            /// </summary>
            public const string Increment = "acc";
        }

        public int Accumulator { get; private set; }
        public Instruction CurrentInstruction => _instructions[_currentInstructionIndex];
        public bool IsTerminated { get; private set; }

        private readonly Instruction[] _instructions;
        private readonly IReadOnlyDictionary<string, Action<int>> _actions;
        private int _currentInstructionIndex;
        private int _tamperedAt = -1;

        public ConsoleBooter(Instruction[] instructions, int accumulator = 0)
        {
            _instructions = instructions;
            _actions = new Dictionary<string, Action<int>>
            {
                {Ignore, a => GoToNext()},
                {Jump, JumpForward},
                {Increment, Accumulate}
            };

            Accumulator = accumulator;
        }

        /// <summary>
        /// Changes nop to jmp or jmp to np
        /// </summary>
        public void SwapAt(int atIndex)
        {
            _instructions[atIndex].Swap();
            _tamperedAt = atIndex;
        }

        public void Reset()
        {
            foreach (var instruction in _instructions)
            {
                instruction.Reset();
            }

            _instructions[_tamperedAt].Swap();

            _tamperedAt = 0;
            _currentInstructionIndex = 0;
            Accumulator = 0;
        }

        public void NextInstruction()
        {
            IsTerminated = _currentInstructionIndex == _instructions.Length - 1;
            ExecuteInstruction(CurrentInstruction);
        }

        private void GoToNext()
        {
            JumpForward(1);
        }

        private void Accumulate(int a)
        {
            Accumulator += a;
            JumpForward(1);
        }

        private void JumpForward(int a)
        {
            if (a < 0)
            {
                _currentInstructionIndex= Math.Abs((_currentInstructionIndex + a) % _instructions.Length);
            }
            else
            {
                _currentInstructionIndex = (_currentInstructionIndex + a) % _instructions.Length;
            }
        }

        private void ExecuteInstruction(Instruction instruction)
        {
            CurrentInstruction.Visit();
            _actions[instruction.Name](instruction.Arg);
        }
    }
}
