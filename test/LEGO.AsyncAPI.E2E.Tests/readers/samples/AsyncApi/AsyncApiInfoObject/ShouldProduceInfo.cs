namespace LEGO.AsyncAPI.E2E.Tests.readers.samples.AsyncApi.AsyncApiInfoObject
{
    using AsyncAPI.Tests;
    using Models;
    using Xunit;

    public class ShouldProduceInfo: ShouldConsumeProduceBase<Info>
    {
        public ShouldProduceInfo(): base(typeof(ShouldProduceInfo))
        {
        }

        [Fact]
        public void ShouldProduceMinimalSpec()
        {
            Assert.Equal(GetString("Minimal.json"), _asyncApiWriter.Write(new Info("foo", "bar")));
        }
        
        [Fact]
        public void ShouldProduceCompleteSpec()
        {
            Assert.Equal(GetStringWithMockedExtensions("Complete.json"), _asyncApiWriter.Write(MockData.Info()));
        }
    }
}