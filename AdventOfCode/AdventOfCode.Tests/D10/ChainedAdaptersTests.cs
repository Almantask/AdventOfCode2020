using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.D10;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.D10
{
    public class ChainedAdaptersTests
    {
        [Fact]
        public void MaxVoltage_Returns_MaxPlus3()
        {
            int[] voltages = {1, 3};

            var chainedAdapters = new Day10.ChainedAdapters(voltages);

            chainedAdapters.MaxVoltage.Should().Be(6);
        }

        [Fact]
        public void Count1JJumps_Returns_CountOf1JJumps()
        {
            int[] voltages = { 1, 3, 2, 6};
            var chainedAdapters = new Day10.ChainedAdapters(voltages);

            var jumps = chainedAdapters.Count1jJumps();
                
            jumps.Should().Be(3, "It starts from 0");
        }

        [Fact]
        public void ThreeJJumps_Returns_CountOf3JJumps()
        {
            int[] voltages = { 1, 4, 5 };
            var chainedAdapters = new Day10.ChainedAdapters(voltages);

            var jumps = chainedAdapters.Count3jJumps();

            jumps.Should().Be(2, "There is always at least one +3 j (your own device)");
        }
    }
}
