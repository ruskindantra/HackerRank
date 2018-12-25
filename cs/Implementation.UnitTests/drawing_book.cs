using AutoFixture;
using Common;
using Moq;
using Xunit;

namespace Implementation.UnitTests
{
    public class drawing_book
    {
        private readonly MockRepository _mockRepository;

        public drawing_book()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
        }

        [Theory]
        [InlineData(5, 4, 0)]
        [InlineData(6, 2, 1)]
        public void test_samples(int numberOfPages, int pageToGetTo, int expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(numberOfPages.ToString())
                .Returns(pageToGetTo.ToString());
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<DrawingBook>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }
    }
}