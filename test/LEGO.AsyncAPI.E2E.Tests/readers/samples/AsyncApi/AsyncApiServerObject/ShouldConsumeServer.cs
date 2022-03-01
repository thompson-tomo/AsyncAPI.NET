namespace LEGO.AsyncAPI.E2E.Tests.readers.samples.AsyncApi.AsyncApiServerObject
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Any;
    using Models.Interfaces;
    using Xunit;

    public class ShouldConsumeServer : ShouldConsumeProduceBase<Server>
    {
        public ShouldConsumeServer() : base(typeof(ShouldConsumeServer))
        {
        }

        [Fact]
        public void ShouldConsumeMinimalSpec()
        {
            var output = _asyncApiAsyncApiReader.Read(GetStream("Minimal.json"));

            Assert.Equal(new Uri("https://lego.com"), output.Url);
            Assert.Equal("http", output.Protocol);
        }

        [Fact]
        public void ShouldConsumeCompleteSpec()
        {
            var output = _asyncApiAsyncApiReader.Read(GetStreamWithMockedExtensions("Complete.json"));

            Assert.Equal(new Uri("https://lego.com"), output.Url);
            Assert.Equal("http", output.Protocol);
            Assert.Equal("0.0.1", output.ProtocolVersion);
            Assert.Equal("foo", output.Description);
            Assert.IsType<Dictionary<string, ServerVariable>>(output.Variables);
            Assert.IsType<List<SecurityRequirement>> (output.Security);
            Assert.IsType<Dictionary<string, IServerBinding>>(output.Bindings);
            Assert.IsAssignableFrom<IDictionary<string, IAny>>(output.Extensions);
        }
    }
}