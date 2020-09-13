using System;
using System.Collections.Generic;
using System.Text;
//using AdvertApi.Models.Fg.Messages; // update package 1.0.1

namespace WebAdvert.SearchWorker
{

    // 32
    public static class MappingHelper
    {

        // map/convert AdvertConfirmedMessage into AdvertType
        public static AdvertType Map(AdvertConfirmedMessage message)
        {
            var doc = new AdvertType
            {
                Id = message.Id,
                Title = message.Title,
                CreationDateTime = DateTime.UtcNow
            };
            return doc;
        }
    }
}
