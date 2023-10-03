using ElevatorSimulator.Constants;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class ElevatorMaxWeightsTests
    {
        [Test]
        public void PassengerElevator_EnsureCorrectMaxWeight()
        {
            Assert.That(ElevatorMaxWeights.PassengerElevator, Is.EqualTo(8));
        }
    }
}
