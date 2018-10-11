using Newtonsoft.Json;

namespace StrayG.Walmart.Data.Contracts.Response.Models
{
    /// <summary>
    /// See <see cref="https://developer.walmartlabs.com/docs/read/Item_Field_Description"/>
    /// </summary>
    public class ItemBase
    {
        /// <summary>
        /// Gets or sets the positive integer that uniquely identifies an item.
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the standard name of the item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer suggested retail price.
        /// </summary>
        [JsonProperty("msrp")]
        public string MSRP { get; set; }

        /// <summary>
        /// Gets or sets the selling price for the item in USD.
        /// </summary>
        [JsonProperty("salePrice")]
        public string SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the Unique Product Code.
        /// </summary>
        [JsonProperty("upc")]
        public string UPC { get; set; }

        /// <summary>
        /// Gets or sets the Breadcrumb for the item. 
        /// This string describes the category level hierarchy that the item falls under.
        /// </summary>
        [JsonProperty("categoryPath")]
        public string CategoryPath { get; set; }

        /// <summary>
        /// Gets or sets long description for the item. 
        /// Contains escaped html formatting tags.
        /// </summary>
        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        /// <summary>
        /// Gets or sets the URL for the small size image for the item in jpeg format 
        /// with dimensions 100 x 100 pixels.
        /// </summary>
        [JsonProperty("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        /// <summary>
        /// Gets or sets the Deep linked URL that directly links to the product page of this item 
        /// on walmart.com, and uniquely identifies the affiliate sending this request via a linkshare 
        /// tracking id |LSNID|. The LSNID parameter needs to be replaced with your linkshare tracking id, 
        /// and is used by us to correctly attribute the sales from your channel on walmart.com. 
        /// Actual commission numbers will be made available through your linkshare account.
        /// </summary>
        [JsonProperty("productTrackingUrl")]
        public string ProductTrackingUrl { get; set; }

        /// <summary>
        /// Gets or sets the shipping rate for this item for standard shipping (3 to 5 business days).
        /// </summary>
        [JsonProperty("standardShipRate")]
        public string StandardShipRate { get; set; }

        /// <summary>
        /// Gets or sets the whether this item is from one of the Walmart marketplace sellers. 
        /// In this case, the item cannot be returned back to Walmart stores or walmart.com. 
        /// It must be returned to the marketplace seller in accordance with their returns policy.
        /// </summary>
        [JsonProperty("marketplace")]
        public string Marketplace { get; set; }

        /// <summary>
        /// Gets or sets the Walmart.com url for the item.
        /// </summary>
        [JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the item is currently available for sale on Walmart.com.
        /// </summary>
        [JsonProperty("availableOnline")]
        public bool AvailableOnline { get; set; }

        /// <summary>
        /// Gets or sets whether the item is sold ONLINE_ONLY , ONLINE_AND_STORE, STORE_ONLY.
        /// </summary>
        [JsonProperty("offerType")]
        public string OfferType { get; set; }

        /// <summary>
        /// Gets or sets whether boolean flag indicating whether the item is eligible for shipping pass or not.
        /// </summary>
        [JsonProperty("shippingPassEligible")]
        public bool ShippingPassEligible { get; set; }
    }
}
