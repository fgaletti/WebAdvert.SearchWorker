﻿using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAdvert.SearchWorker
{
    // 32
   public static  class ElasticSearchHelper
    {
        private static IElasticClient _client;

        public static IElasticClient GetInstance(IConfiguration config)
        {
            if (_client == null)
            {
                var url = config.GetSection("ES").GetValue<string>("url");
                var settins = new ConnectionSettings(new Uri(url)).DefaultIndex("adverts")
                    .DefaultMappingFor<AdvertType>(m=> m.IdProperty(x=> x.Id)); //map if we want
                _client = new ElasticClient(settins);
            }

            return _client;
        }
    }
}
