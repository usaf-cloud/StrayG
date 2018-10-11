using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.IO;
using System.ServiceModel;
using StrayG.Amazon.ECS.AddOns;
using StrayG.Amazon.ECS;
using System.Diagnostics;
using StrayG.Core.Extensions;

namespace StrayG.Test
{
    [TestClass]
    public class AmazonTest
    {
        /*public const string QF_AMAZON_MARKETPLACE = "webservices.amazon.com";
        public const string QF_AMAZON_ASSOCIATE_TAG = "StrayG-20";
        public const string QF_AMAZON_ACCESS_KEY_ID = "AKIAI3VLHRUGE3KXH64Q";
        public const string QF_AMAZON_SECRET_ACCESS_KEY = "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";*/

        [TestMethod]
        public async Task ItemSearch()
        {
            //create a WCF Amazon ECS client
            AWSECommerceServiceClient client = new AWSECommerceServiceClient();

            //prepare an ItemSearchRequest to search for
            ItemSearchRequest requestPage1 = new ItemSearchRequest()
            {
                SearchIndex = SearchIndex.All.ToString(),
                Keywords = "AbilityOne",
                ItemPage = "20",
                ResponseGroup = new string[]
                {
                    //ResponseGroup.Images.ToString(),
                    ResponseGroup.ItemAttributes.ToString(),
                    //ResponseGroup.Offers.ToString()
                },
            };
            ItemSearchRequest requestPage2 = new ItemSearchRequest()
            {
                SearchIndex = SearchIndex.All.ToString(),
                Keywords = "AbilityOne",
                ItemPage = "21",
                ResponseGroup = new string[]
                {
                    //ResponseGroup.Images.ToString(),
                    ResponseGroup.ItemAttributes.ToString(),
                    //ResponseGroup.Offers.ToString()
                },
            };

            //prepare an ItemSearch
            ItemSearch itemSearch = new ItemSearch()
            {
                Request = new ItemSearchRequest[] { requestPage1, requestPage2 },
                AssociateTag = AmazonInformation.GetAssociateTag(),
                AWSAccessKeyId = AmazonInformation.GetAccessKeyID(),
            };

            // issue the ItemSearch request
            ItemSearchResponse response = client.ItemSearch(itemSearch);

            /*itemSearch.Request[0].Keywords = "7920-00-543-6492";

            ItemSearchResponse response2 = client.ItemSearch(itemSearch);*/
        }

        [TestMethod]
        public async Task ItemLookup()
        {
            //create a WCF Amazon ECS client
            AWSECommerceServiceClient client = new AWSECommerceServiceClient();

            //prepare an ItemLookupRequest
            ItemLookupRequest request = new ItemLookupRequest()
            {
                IdType = ItemLookupRequestIdType.ASIN,
                ItemId = new string[] { "B002NF0KI2" },
            };

            //prepare an ItemLookup
            ItemLookup itemLookup = new ItemLookup()
            {
                Request = new ItemLookupRequest[] { request },
                AssociateTag = AmazonInformation.GetAssociateTag(),
                AWSAccessKeyId = AmazonInformation.GetAccessKeyID(),
            };

            // issue the ItemLookup request
            ItemLookupResponse response = client.ItemLookup(itemLookup);

            if (response.Items[0].Request.Errors.Length > 0)
            {
                foreach (ErrorsError error in response.Items[0].Request.Errors)
                {
                    Debug.WriteLine(error.Message);
                }
            }
            else
            {
                foreach (var item in response.Items[0].Item)
                {
                    Debug.WriteLine(item.ItemAttributes.Title);
                }
            }
        }
    }
}
