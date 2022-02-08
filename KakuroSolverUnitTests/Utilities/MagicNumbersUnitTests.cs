using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KakuroSolver.Utilities.UnitTests
{
    [TestClass]
    public class MagicNumbersUnitTests
    {
        [TestMethod]
        public void MagicNumbers_ValidateMagicNumbers()
        {
            // To ensure no typos were made double check that the magic number
            // values add up to the correct value. Do this in a loop so that we
            // can determine which value was wrong, if any.
            foreach (var mn in MagicNumbers.MagicNumberValues)
            {
                Assert.IsTrue(mn.Values[0].Sum(v => v) == mn.Total, $"{mn.Total} - {mn.PartitionLength}");
            }
        }
    }
}
