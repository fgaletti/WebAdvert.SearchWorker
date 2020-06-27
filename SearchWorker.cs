using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using System;
using Nest;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    //31
    public class SearchWorker
    {
        // pass one instance 
        public SearchWorker(): this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance))
        {

        }

        private readonly IElasticClient _client;
        public SearchWorker(IElasticClient client)
        {
            _client = client;
        }
        public void Function(SNSEvent snsEvent, ILambdaContext context)
        {
            foreach (var record in snsEvent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);
            }
        }
    }
}
