using ElevatorSimulator.Constants;
using System.Diagnostics;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class OperationDelaysTests
    {
        [Test]
        public async Task PassengerElevator_DefaultDelay_Is2000Milliseconds()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await OperationDelays.PassengerElevator(null);

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            Assert.IsTrue(elapsedMilliseconds >= 1900 && elapsedMilliseconds <= 2100, $"Expected around 2000ms but was {elapsedMilliseconds}ms");
        }

        [Test]
        public async Task PassengerElevator_WithMultiplier_IsCorrectlyMultiplied()
        {
            var multiplier = 3;
            var expectedDelay = 2000 * multiplier;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await OperationDelays.PassengerElevator(multiplier);

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            Assert.IsTrue(elapsedMilliseconds >= (expectedDelay - 100) && elapsedMilliseconds <= (expectedDelay + 100), $"Expected around {expectedDelay}ms but was {elapsedMilliseconds}ms");
        }
    }
}
