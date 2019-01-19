using EdjCase.JsonRpc.Router;
using Microsoft.Extensions.Logging;
using TestJsonRpc.Model;

namespace TestJsonRpc
{
    public class TestController /*: RpcController*/
    {
        private readonly ILogger<TestController> logger;

        public TestController(ILogger<TestController> logger)
        {
            this.logger = logger;
        }

        public TestModel CreateModel(TestModel model)
        {
            logger.LogInformation($"{nameof(CreateModel)} --> {model}");

            return model;
        }

        public TestModel CreateAnotherModel(int id, string name)
        {
            var model = new TestModel
            {
                Id = id,
                Name = name,
            };

            logger.LogInformation($"{nameof(CreateAnotherModel)} --> {model}");

            return model;
        }
    }
}
