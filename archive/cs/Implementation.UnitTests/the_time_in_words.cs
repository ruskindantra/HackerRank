using AutoFixture;
using Common;
using Moq;
using Xunit;

namespace Implementation.UnitTests
{
    public class the_time_in_words
    {
        private readonly MockRepository _mockRepository;

        public the_time_in_words()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
        }
        
        [Theory]
        [InlineData(3, 1, "one minute past three")]
        [InlineData(3, 2, "two minutes past three")]
        [InlineData(3, 12, "twelve minutes past three")]
        [InlineData(3, 13, "thirteen minutes past three")]      
        [InlineData(3, 14, "fourteen minutes past three")]
        
        [InlineData(3, 16, "sixteen minutes past three")]
        [InlineData(3, 46, "fourteen minutes to four")]
        [InlineData(12, 16, "sixteen minutes past twelve")]
        [InlineData(12, 46, "fourteen minutes to one")]
        [InlineData(12, 31, "twenty nine minutes to one")]
        
        [InlineData(3, 59, "one minute to four")]
        [InlineData(3, 58, "two minutes to four")]
        [InlineData(11, 58, "two minutes to twelve")]
        [InlineData(12, 58, "two minutes to one")]
        [InlineData(12, 59, "one minute to one")]
        [InlineData(12, 2, "two minutes past twelve")]
        public void other_times(int h, int m, string expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(h.ToString())
                .Returns(m.ToString());
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<TheTimeInWords>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }

        [Theory]
        [InlineData(1, 0, "one o' clock")]
        [InlineData(3, 0, "three o' clock")]
        [InlineData(12, 0, "twelve o' clock")]
        [InlineData(10, 0, "ten o' clock")]
        [InlineData(8, 0, "eight o' clock")]
        [InlineData(11, 0, "eleven o' clock")]
        public void exact_on_the_hour(int h, int m, string expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(h.ToString())
                .Returns(m.ToString());
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<TheTimeInWords>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }
        
        [Theory]
        [InlineData(3, 30, "half past three")]
        [InlineData(1, 30, "half past one")]
        [InlineData(12, 30, "half past twelve")]
        [InlineData(10, 30, "half past ten")]
        [InlineData(8, 30, "half past eight")]
        [InlineData(11, 30, "half past eleven")]
        public void half_past(int h, int m, string expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(h.ToString())
                .Returns(m.ToString());
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<TheTimeInWords>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }
        
        [Theory]
        [InlineData(1, 15, "quarter past one")]
        [InlineData(3, 15, "quarter past three")]
        [InlineData(12, 15, "quarter past twelve")]
        [InlineData(10, 15, "quarter past ten")]
        [InlineData(8, 15, "quarter past eight")]
        [InlineData(11, 15, "quarter past eleven")]
        [InlineData(3, 45, "quarter to four")]
        [InlineData(12, 45, "quarter to one")]
        [InlineData(10, 45, "quarter to eleven")]
        [InlineData(8, 45, "quarter to nine")]
        [InlineData(11, 45, "quarter to twelve")]
        public void quarter_past_and_to(int h, int m, string expectedOutput)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());


            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(h.ToString())
                .Returns(m.ToString());
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<TheTimeInWords>();
            sut.Solve();
            
            outputWriterMock.Verify(o => o.WriteLine(It.Is<string>(s => s == expectedOutput.ToString())), Times.Once);
        }
    }
}