using System;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using GreenPipes.Pipes;
using NSubstitute;
using NUnit.Framework;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Filters.TextProcessing;
using StringsProcessor.Application.Input;
using StringsProcessor.Application.Settings;

namespace StringsProcessor.Application.UnitTests.Filters
{
    public class TextProcessingFilterTests
    {
        [Test]
        public async Task ExtractTextFilter_Use_InputProvider_Correctly()
        {
            string expected = "res";

            var inputSub = Substitute.For<IInputProvider>();
            inputSub.GetAsync().Returns(Task.FromResult(expected));

            var filter = new ExtractTextFilter(inputSub);

            var context = new TextProcessingContext();

            await filter.Send(context, new EmptyPipe<TextProcessingContext>());

            Assert.AreEqual(expected, context.SourceText);
        }

        [Test]
        public async Task SplitByLinesFilter_Perform_Spliting_Correctly()
        {
            string[] expected = new string[] {"1", "2", "asdasd"};
            string text = string.Join(Environment.NewLine, expected);

            var filter = new SplitByLinesFilter();

            var context = new TextProcessingContext
            {
                SourceText = text
            };

            await filter.Send(context, new EmptyPipe<TextProcessingContext>());

            CollectionAssert.AreEquivalent(expected, context.RawLines);
        }

        [Test]
        public async Task ProcessLinesConcurrentFilter_Call_Pipe_With_Correct_Args()
        {
            var context = new TextProcessingContext
            {
                RawLines = new string[] { "1, 2, 3" }
            };

            var pipeSub = new MockPipe(processingContext =>
            {
                Assert.AreEqual(context.RawLines.First(), processingContext.ProcessedLine);
            });

            var filter = new ProcessLinesConcurrentFilter(pipeSub, new ConcurrencySettings
            {
                DegreeOfParallelism = 1
            });

            await filter.Send(context, new EmptyPipe<TextProcessingContext>());
        }

        private class MockPipe : IPipe<LineProcessingContext>
        {
            private Action<LineProcessingContext> _onExecution;

            public MockPipe(Action<LineProcessingContext> onExecution)
            {
                _onExecution = onExecution;
            }

            public Task Send(LineProcessingContext context)
            {
                _onExecution(context);
                return Task.CompletedTask;
            }

            public void Probe(ProbeContext context) {}
        }
    }
}
