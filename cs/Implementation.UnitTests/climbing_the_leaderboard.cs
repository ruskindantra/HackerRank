using System;
using System.Collections.Generic;
using Xunit;
using AutoFixture;
using Common;
using FluentAssertions;
using Moq;

namespace Implementation.UnitTests
{
    public class climbing_the_leaderboard
    {
        private readonly MockRepository _mockRepository;

        public climbing_the_leaderboard()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
        }
        
        [Theory]
        [InlineData("7", "4", "100 100 50 40 40 20 10", "5 25 50 120", new[] {"6", "4", "2", "1"})]
        [InlineData("6", "5", "100 90 90 80 75 60", "50 65 77 90 102", new[] {"6", "5", "4", "2", "1"})]
        public void sample_test_cases(string m, string n, string scores, string alice, string[] expected)
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());

            var actualOutput = new List<string>();

            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns(m)
                .Returns(scores)
                .Returns(n)
                .Returns(alice);
            outputWriterMock.Setup(o => o.WriteLine(It.IsAny<string>())).Callback<string>(s => actualOutput.Add(s));
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<ClimbingTheLeaderboard>();
            sut.Solve();
            
            actualOutput.Should().BeEquivalentTo(expected).And.BeInDescendingOrder();            
        }
        
        [Fact]
        public void custom_1()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());

            var actualOutput = new List<string>();

            var inputReaderMock = _mockRepository.Create<IInputReader>();
            var outputWriterMock = _mockRepository.Create<IOutputWriter>();

            inputReaderMock.SetupSequence(i => i.ReadLine())
                .Returns("10")
                .Returns("200 200 185 180 160 150 150 150 150 140")
                .Returns("5")
                .Returns("140 150 160 170 180");
            outputWriterMock.Setup(o => o.WriteLine(It.IsAny<string>())).Callback<string>(s => actualOutput.Add(s));
            
            fixture.Inject(inputReaderMock);
            fixture.Inject(outputWriterMock);
            
            var sut = fixture.Create<ClimbingTheLeaderboard>();
            sut.Solve();
            
            actualOutput.Should().BeEquivalentTo(new[] {"6", "5", "4", "4", "3"}).And.BeInDescendingOrder();            
        }
    }
}