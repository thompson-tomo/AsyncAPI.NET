using System.Collections.Generic;
using System.Collections.Immutable;
using LEGO.AsyncAPI.Models;
using LEGO.AsyncAPI.Models.Bindings.MessageBindings;
using LEGO.AsyncAPI.Models.Interfaces;
namespace LEGO.AsyncAPI.E2E.Tests.readers.samples.AsyncApi.AsyncApiMessageObject
{
    using AsyncAPI.Tests;
    using Xunit;

    public class ShouldProduceMessage : ShouldConsumeProduceBase<Message>
    {
        public ShouldProduceMessage() : base(typeof(ShouldProduceMessage))
        {
        }

        [Fact]
        public void ShouldProduceMinimalSpec()
        {
            Assert.Equal(GetString("Minimal.json"), _asyncApiWriter.Write(new Message()));
        }

        [Fact]
        public void ShouldProduceCompleteSpec()
        {
            Assert.Equal(GetString("Complete.json"), _asyncApiWriter.Write(new Message
            {
                Name = "UserSignup",
                Title = "User signup",
                Summary = "Action to sign a user up.",
                Description = "A longer description",
                ContentType = "application/json",
                Headers = new Schema(),
                Payload = MockData.Payload(),
                SchemaFormat = "application/vnd.aai.asyncapi;version=2.3.0",
                CorrelationId = new CorrelationId("foo"),
                Traits = new List<MessageTrait>(),
                ExternalDocs = new ExternalDocumentation(),
                Tags = ImmutableArray<Tag>.Empty,
                Bindings = MockData.MessageBindings(),
                Examples = ImmutableList<MessageExample>.Empty
            }));
        }
    }
}