using ElevatorSimulator.Constants;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]

    public class ElevatorDelaysTests
    {
        [Test]
        public async Task TestElevatorDelays_ImplementsDelaysCorrectly()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await OperationDelays.PassengerElevator(null);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Assert.That(elapsedMs, Is.GreaterThanOrEqualTo(2000).And.LessThan(2100));
        }
    }
}
