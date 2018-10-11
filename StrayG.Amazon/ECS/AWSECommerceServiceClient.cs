using StrayG.Amazon.ECS.AddOns;
using System.ServiceModel;

namespace StrayG.Amazon.ECS
{
    /// <summary>
    /// This is an implementation of <see cref="AWSECommerceServicePortTypeClient"/>
    /// so that I can dispense with some of the crap that I would have to do every time. Super simple.
    /// </summary>
    public class AWSECommerceServiceClient : AWSECommerceServicePortTypeClient
    {
        public AWSECommerceServiceClient() : 
            base(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport)
                {
                    MaxReceivedMessageSize = int.MaxValue,
                },
                new EndpointAddress(AmazonInformation.GetECSSOAPEndpoint()))
        {
            //set the Access Key ID and Secret Access Key
            ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(AmazonInformation.GetAccessKeyID(), AmazonInformation.GetSecretAccessKey()));
        }
    }
}
