using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.UnitTests
{
    public class ClassExampleTest
    {
        //The name of the method being tested.
        //The scenario under which it's being tested.
        //The expected behavior when the scenario is invoked
        [Fact]
        public void MethodName_Scenario_WhatGonnaHappen()
        {
            Assert.True(true);
            Assert.False(false);
            Assert.Equal(true, true);
            Assert.Equal(false, false);
        }

        //Theory
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 2, 7)]
        public void MethodName_ScenarioTheory_WhatGonnaHappen(int num1, int num2, int expected)
        {
            Assert.Equal(expected, num1 + num2);
        }

        //Fact doent expect parameters theory should expect
        [Fact]
        public void MethodName_ScenarioFact_WhatGonnaHappen()
        {
            Assert.Equal(5, 2 + 3);
            Assert.Equal(8, 5 + 3);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void Add_TwoNumbers_CorrectResult(int a, int b, int expected)
        {
            Math math = new Math();
            math.Add(a);
            math.Add(b);
            Assert.Equal(expected, math.Current);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_TwoNumbers_CorrectResultMemberData(int expected, params int[] values)
        {
            Math math = new Math();

            foreach (var item in values)
            {
                math.Add(item);
            }

            Assert.Equal(expected, math.Current);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 10, new int[] { 5, 5 } };
            yield return new object[] { 9, new int[] { 5, 4 } };
            yield return new object[] { -9, new int[] { -5, -4 } };
            yield return new object[] { -1, new int[] { -5, 4 } };
            yield return new object[] { 1, new int[] { 5, -4 } };
        }
        private class Math
        {
            public int Current { get; private set; } = 0;
            public int Add(int numberToAdd)
            {
                return Current += numberToAdd;
            }
        }
    }
}
