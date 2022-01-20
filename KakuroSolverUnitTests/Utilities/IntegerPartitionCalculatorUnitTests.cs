using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KakuroSolver.Utilities.UnitTests
{
    [TestClass]
    public class IntegerPartitionCalculatorUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ThrowsExceptionIfMaximumValueGreaterThanNine()
        {
            IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(1u, 2u, 3u, 10u);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ThrowsExceptionIfMaximumValueLessThanOrEqualSum()
        {
            IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(5u, 2u, 3u, 5u);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ThrowsExceptionIfMinimumValueIsGreaterThanMaximumValue()
        {
            IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(1u, 2u, 6u, 4u);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ThrowsExceptionIfMaximumValueIsLessThanMinimumValue()
        {
            IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(10u, 2u, 3u, 2u);
        }

        [TestMethod]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ReturnsExpectedValue()
        {
            var sum = 5u;
            var partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, 2u, 1u, 4u);

            ValidatePartitions(partitions, sum);

            Assert.AreEqual(2, partitions.Count);
            CollectionAssert.AreEqual(new List<uint> { 1, 4, }, partitions[0]);
            CollectionAssert.AreEqual(new List<uint> { 2, 3, }, partitions[1]);
        }

        [TestMethod]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ReturnsOnlyPartitionsOfGivenLength()
        {
            var sum = 35u;
            var partitionLength = 6u;
            var partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, partitionLength);

            ValidatePartitions(partitions, sum);

            Assert.IsTrue(partitions.All(p => p.Count == partitionLength));

            // Change the length and try again.
            partitionLength = 5u;
            partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, partitionLength);

            ValidatePartitions(partitions, sum);

            Assert.IsTrue(partitions.All(p => p.Count == partitionLength));
        }

        [TestMethod]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ReturnsOnlyPartitionsWithValuesUsingMinimumValue()
        {
            var sum = 35u;
            var minValue = 2u;
            var partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, 6u, minValue);

            ValidatePartitions(partitions, sum);

            Assert.IsTrue(partitions.All(p => p.All(i => i >= minValue)));
        }

        [TestMethod]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ReturnsOnlyPartitionsWithValuesUsingMaximumValue()
        {
            var sum = 7u;
            var maxValue = 5u;
            var partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, 2u, 1u, maxValue);

            ValidatePartitions(partitions, sum);

            Assert.IsTrue(partitions.All(p => p.All(i => i <= maxValue)));
        }

        [TestMethod]
        public void IntegerPartitionCalulator_CalculateDistinctIntegerPartitions_ReturnsAnEmptyListIfUnableToFindPartitions()
        {
            var sum = 11u;
            var partitionLength = 2u;
            var maxValue = 5u;
            var partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(sum, partitionLength, 1u, maxValue);

            Assert.AreEqual(0, partitions.Count);
        }

        private void ValidatePartitions(List<List<uint>> partitions, uint sum)
        {
            // First check that the partitions isn't empty.
            Assert.IsTrue(partitions.Count > 0);

            // Every partition should add up to the expected total, only have
            // unique values and a unique combination of values compared to the
            // rest of the partitions.
            Assert.IsTrue(partitions.All(p => p.Sum() == sum));
            // Make sure each partition has unique numbers.
            Assert.IsTrue(partitions.All(p => p.Distinct().Count() == p.Count));

        }
    }
}
