using AutoFixture;
using Common;
using Moq;
using Xunit;

namespace Implementation.UnitTests
{
    public class counting_valleys
    {
        private readonly MockRepository _mockRepository;

        public counting_valleys()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
        }

        [Theory]
        [InlineData(8, "UDDDUDUU", 1)]
        public void test_samples(int totalSteps, string steps, int expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(totalSteps.ToString())
                .Returns(steps);
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<CountingValleys>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }
    }
}