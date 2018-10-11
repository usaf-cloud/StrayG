using Newtonsoft.Json;

namespace StrayG.Walmart.Data.Contracts.Response.Models
{
    /// <summary>
    /// See <see cref="https://developer.walmartlabs.com/docs/read/Item_Field_Description"/>
    /// </summary>
    public class ItemFull : ItemBase
    {
        /// <summary>
        /// Gets or sets Item Id of the base version for this item. 
        /// This is present only if item is a variant of the base version, 
        /// such as a different color or size.
        /// </summary>
        [JsonProperty("parentItemId")]
        public int ParentItemId { get; set; }

        /// <summary>
        /// Gets or sets category id for the category of this item. 
        /// This value can be passed to APIs to pull this item's category level information.
        /// </summary>
        [JsonProperty("categoryNode")]
        public string CategoryNode { get; set; }

        /// <summary>
        /// Gets or sets short description for the item. Contains escaped html formatting tags.
        /// </summary>
        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets item's brand.
        /// </summary>
        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets URL for the medium size image for the item in jpeg format 
        /// with dimensions 180 x 180 pixels.
        /// </summary>
        [JsonProperty("mediumImage")]
        public string MediumImage { get; set; }

        /// <summary>
        /// Gets or sets URL for the large size image for the item in jpeg format 
        /// with dimensions 450 x 450 pixels.
        /// </summary>
        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        /// <summary>
        /// Gets or sets whether the item qualifies for 97 cent shipping.
        /// </summary>
        [JsonProperty("ninetySevenCentShipping")]
        public bool NinetySevenCentShipping { get; set; }

        /// <summary>
        /// Gets or sets the expedited shipping rate for this item (2 to 3 business days).
        /// </summary>
        [JsonProperty("twoThreeDayShippingRate")]
        public string TwoThreeDayShippingRate { get; set; }

        /// <summary>
        /// Gets or sets the rush shipping rate for this item (1 business day).
        /// </summary>
        [JsonProperty("overnightShippingRate")]
        public string OvernightShippingRate { get; set; }

        /// <summary>
        /// Gets or sets the size attribute for the item.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the color attribute for the item.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the name of the marketplace seller, applicable only for marketplace items.
        /// </summary>
        [JsonProperty("sellerInfo")]
        public string SellerInfo { get; set; }

        /// <summary>
        /// Gets or sets whether the item can be shipped to the nearest Walmart store.
        /// </summary>
        [JsonProperty("shipToStore")]
        public bool ShipToStore { get; set; }

        /// <summary>
        /// Gets or sets whether the item qualifies for free shipping to the nearest Walmart store.
        /// </summary>
        [JsonProperty("freeShipToStore")]
        public bool FreeShipToStore { get; set; }

        /// <summary>
        /// Gets or sets the model number attribute for the item.
        /// </summary>
        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// Gets or sets indicator of quantity of the item available online. 
        /// Possible values are [Available, Limited Supply, Last few items, Not available]. 
        /// Limited supply: can go out of stock in the near future, 
        /// so needs to be refreshed for availability more frequently. 
        /// Last few items: can go out of stock very quickly, 
        /// so could be avoided in case you only need to show available items to your users.
        /// </summary>
        [JsonProperty("stock")]
        public string Stock { get; set; }

        /// <summary>
        /// Gets or sets whether the item is price is a Rollback price on Walmart.com.
        /// </summary>
        [JsonProperty("rollBack")]
        public bool RollBack { get; set; }

        /// <summary>
        /// Gets or sets whether the item is a Special Buy item on Walmart.com.
        /// </summary>
        [JsonProperty("specialBuy")]
        public bool specialBuy { get; set; }

        /// <summary>
        /// Gets or sets the average customer rating out of 5.
        /// </summary>
        [JsonProperty("customerRating")]
        public string CustomerRating { get; set; }

        /// <summary>
        /// Gets or sets the customer rating image.
        /// </summary>
        [JsonProperty("customerRatingImage")]
        public string CustomerRatingImage { get; set; }

        /// <summary>
        /// Gets or sets the number of customer reviews available on this item on Walmart.com.
        /// </summary>
        [JsonProperty("numReviews")]
        public int NumReviews { get; set; }

        /// <summary>
        /// Gets or sets whether the item is on clearance on Walmart.com.
        /// </summary>
        [JsonProperty("clearance")]
        public bool Clearance { get; set; }

        /// <summary>
        /// Gets or sets whether this item is available on pre-order on Walmart.com.
        /// </summary>
        [JsonProperty("preOrder")]
        public bool PreOrder { get; set; }

        /// <summary>
        /// Gets or sets the date the item will ship on if it is a pre-order item.
        /// </summary>
        [JsonProperty("preOrderShipsOn")]
        public string PreOrderShipsOn { get; set; }

        /// <summary>
        /// Gets or sets whether the item is sold ONLINE_ONLY , ONLINE_AND_STORE, STORE_ONLY.
        /// </summary>
        [JsonProperty("offerType")]
        public string offerType { get; set; }
    }
}
