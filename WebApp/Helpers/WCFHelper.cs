using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebApp.Helpers
{
    public static class WCFHelper
    {
        public static T CreateServiceClient<T>(string endpointURl)
        {
            EndpointAddress endpoint = new EndpointAddress(endpointURl);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, endpoint);
            return factory.CreateChannel();

        }
    }
}