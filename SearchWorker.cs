using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using System;
using Nest;
using Newtonsoft.Json;
//using AdvertApi.Models.Fg.Messages;
using System.Threading.Tasks;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    //31
    public class SearchWorker
    {
        // pass one instance 
        // call to the other constructor, (constructor chaining)
        public SearchWorker(): this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance))
        {

        }

        private readonly IElasticClient _client;
        public SearchWorker(IElasticClient client)
        {
            _client = client;
        }
       //  public async Task Function(SNSEvent snsEvent, ILambdaContext context)
         public string Function(SNSEvent snsEvent, ILambdaContext context)
        {
            foreach (var record in snsEvent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);

                var message = JsonConvert.DeserializeObject<AdvertConfirmedMessage>(record.Sns.Message);
                var advertDocument = MappingHelper.Map(message); //map, AdvertConfirmedMessage does not have TimeCreated 
                //await _client.IndexDocumentAsync(advertDocument); // add to Elastic search
                 _client.IndexDocument(advertDocument); // add to Elastic search
                
            }
            return "Ok";
        }
      
    }
}
