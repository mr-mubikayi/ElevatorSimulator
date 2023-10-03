using ElevatorSimulator.Helpers;

namespace ElevatorSimulator.nUnitTests
{
    [TestFixture]
    public class ConsoleServiceTests
    {
        private ConsoleService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ConsoleService();
        }

        [Test]
        public void Write_WhenCalled_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _service.Write("Test"));
        }

        [Test]
        public void WriteLine_WhenCalled_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _service.WriteLine("Test"));
        }
    }
}