using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class OrderModel
    {
        /// <summary>
        /// 	The order id. Will usually be 6 hex characters, but can also be 9 hex characters if the site has a very large number of orders. Randomly assigned.
        /// </summary>
        [JsonProperty("orderId")] public string OrderId { get; set; }

        /// <summary>
        /// One of “pending”, “unfulfilled”, “fulfilled”, “disputed”, “dispute-lost”, or “refunded”
        /// </summary>
        [JsonProperty("status")] public string Status { get; set; }

        /// <summary>
        /// A comment string for this order editable by API user (not used by Webflow).
        /// </summary>
        [JsonProperty("comment")] public string Comment { get; set; }

        /// <summary>
        /// A comment that the customer left when making their order
        /// </summary>
        [JsonProperty("orderComment")] public string OrderComment { get; set; }

        /// <summary>
        /// 	The ISO8601 timestamp that an order was placed.
        /// </summary>
        [JsonProperty("acceptedOn")] public DateTimeOffset AcceptedOn { get; set; }

        /// <summary>
        /// 	If an order was disputed by the customer, then this key will be set with the ISO8601 timestamp that Stripe notifies Webflow. Null if not disputed.
        /// </summary>
        [JsonProperty("disputedOn")] public string DisputedOn { get; set; }

        /// <summary>
        /// 	If an order was disputed by the customer, then this key will be set with the ISO8601 timestamp of the last time that we got an update. Null if not disputed.
        /// </summary>
        [JsonProperty("disputeUpdatedOn")] public string DisputeUpdatedOn { get; set; }

        /// <summary>
        /// 	If an order was disputed by the customer, then this key will be set with the dispute’s status.
        /// </summary>
        [JsonProperty("disputeLastStatus")] public string DisputeLastStatus { get; set; }

        /// <summary>
        /// 	If an order was marked as ‘fulfilled’, then this is the ISO8601 timestamp when that happened.
        /// </summary>
        [JsonProperty("fulfilledOn")] public string FulfilledOn { get; set; }

        /// <summary>
        /// 	If an order was refunded, this is the ISO8601 of when that happened.
        /// </summary>
        [JsonProperty("refundedOn")] public string RefundedOn { get; set; }

        /// <summary>
        /// This is the amount of money that a customer was charged, extracted from the Stripe charge. This is an object with three keys: value, unit and string.
        /// </summary>
        [JsonProperty("customerPaid")] public CustomerPaid CustomerPaid { get; set; }

        /// <summary>
        /// 	This is the amount of money that the site owner receives, extracted from the Stripe charge and minus all fees. This is an object with three keys: value, unit and string.
        /// </summary>
        [JsonProperty("netAmount")] public CustomerPaid NetAmount { get; set; }

        /// <summary>
        /// 	A string editable by the API user to note the shipping provider used (not used by Webflow).
        /// </summary>
        [JsonProperty("shippingProvider")] public string ShippingProvider { get; set; }

        /// <summary>
        /// 	A string editable by the API user to note the shipping tracking number for the order (not used by Webflow).
        /// </summary>
        [JsonProperty("shippingTracking")] public string ShippingTracking { get; set; }

        /// <summary>
        /// 	An object with the keys: fullName, and email.
        /// </summary>
        [JsonProperty("customerInfo")] public CustomerInfo CustomerInfo { get; set; }

        /// <summary>
        /// 	All addresses provided by the customer during the ordering flow, with keys: type (“shipping” or “billing”), japanType (null, “kana”, or “kanji”), addressee, line1, line2, city, state, country, and postalCode.
        /// </summary>
        [JsonProperty("allAddresses")] public List<Address> AllAddresses { get; set; }

        /// <summary>
        /// 	The shipping address associated with the order in the shape from allAddresses
        /// </summary>
        [JsonProperty("shippingAddress")] public Address ShippingAddress { get; set; }

        /// <summary>
        /// 	The billing address associated with the order in the shape from allAddresses
        /// </summary>
        [JsonProperty("billingAddress")] public Address BillingAddress { get; set; }

        /// <summary>
        /// 	An array of all things that the customer purchased.
        /// </summary>
        [JsonProperty("purchasedItems")] public List<PurchasedItem> PurchasedItems { get; set; }

        /// <summary>
        /// 	The sum of all 'count’ fields in purchasedItems
        /// </summary>
        [JsonProperty("purchasedItemsCount")] public long PurchasedItemsCount { get; set; }

        /// <summary>
        /// 	An object with various Stripe IDs, useful for linking into the stripe dashboard.
        /// </summary>
        [JsonProperty("stripeDetails")] public StripeDetails StripeDetails { get; set; }

        /// <summary>
        /// 	Details on the card used to fulfill this order, if this order was finalized with Stripe.
        /// </summary>
        [JsonProperty("stripeCard")] public StripeCard StripeCard { get; set; }

        /// <summary>
        /// 	An object describing various pricing totals.
        /// </summary>
        [JsonProperty("totals")] public Totals Totals { get; set; }

        /// <summary>
        /// 	An array of additional inputs for custom order data gathering. Each object in the array represents an input with a name, and a textInput, textArea, or checkbox value.
        /// </summary>
        [JsonProperty("customData")] public List<CustomDatum> CustomData { get; set; }
    }

    public class Address
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("addressee")] public string Addressee { get; set; }

        [JsonProperty("line1")] public string Line1 { get; set; }

        [JsonProperty("line2")] public string Line2 { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }
    }

    public class CustomDatum
    {
        [JsonProperty("textInput", NullValueHandling = NullValueHandling.Ignore)]
        public string TextInput { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("textArea", NullValueHandling = NullValueHandling.Ignore)]
        public string TextArea { get; set; }

        [JsonProperty("checkbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Checkbox { get; set; }
    }

    public class CustomerInfo
    {
        [JsonProperty("fullName")] public string FullName { get; set; }

        [JsonProperty("email")] public string Email { get; set; }
    }

    public class CustomerPaid
    {
        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("value")] public long Value { get; set; }

        [JsonProperty("string")] public string String { get; set; }
    }

    public class PurchasedItem
    {
        /// <summary>
        /// Number of item purchased.
        /// </summary>
        [JsonProperty("count")] public long Count { get; set; }

        /// <summary>
        /// Total price of this row. (count * price…)
        /// </summary>
        [JsonProperty("rowTotal")] public CustomerPaid RowTotal { get; set; }

        /// <summary>
        /// 	Name of the product.
        /// </summary>
        [JsonProperty("productName")] public string ProductName { get; set; }

        /// <summary>
        /// 	Slug of the product.
        /// </summary>
        [JsonProperty("productSlug")] public string ProductSlug { get; set; }

        /// <summary>
        /// 	Name of the variant. (SKU)
        /// </summary>
        [JsonProperty("variantName")] public string VariantName { get; set; }

        /// <summary>
        /// 	Slug of the variant. (SKU)
        /// </summary>
        [JsonProperty("variantSlug")] public string VariantSlug { get; set; }

        /// <summary>
        /// 	Image object for the variant. (SKU)
        /// </summary>
        [JsonProperty("variantImage")] public VariantImage VariantImage { get; set; }

        /// <summary>
        /// 	Price object for the variant. (SKU)
        /// </summary>
        [JsonProperty("variantPrice")] public CustomerPaid VariantPrice { get; set; }
    }

    public class VariantImage
    {
        [JsonProperty("fileId")] public string FileId { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }
    }

    public class StripeCard
    {
        [JsonProperty("last4")]
        public long Last4 { get; set; }

        [JsonProperty("brand")] public string Brand { get; set; }

        [JsonProperty("ownerName")] public string OwnerName { get; set; }

        [JsonProperty("expires")] public Expires Expires { get; set; }
    }

    public class Expires
    {
        [JsonProperty("year")] public long Year { get; set; }

        [JsonProperty("month")] public long Month { get; set; }
    }

    public class StripeDetails
    {
        [JsonProperty("refundReason")] public string RefundReason { get; set; }

        /// <summary>
        /// 	String Stripe refund ID, or null.
        /// </summary>
        [JsonProperty("refundId")] public string RefundId { get; set; }

        /// <summary>
        /// 	String Stripe dispute ID, or null.
        /// </summary>
        [JsonProperty("disputeId")] public string DisputeId { get; set; }

        /// <summary>
        /// 	String Stripe charge ID, or null.
        /// </summary>
        [JsonProperty("chargeId")] public string ChargeId { get; set; }

        /// <summary>
        /// 	String Stripe customer ID, or null.
        /// </summary>
        [JsonProperty("customerId")] public string CustomerId { get; set; }
    }

    public class Totals
    {
        [JsonProperty("subtotal")] public CustomerPaid Subtotal { get; set; }

        [JsonProperty("extras")] public List<Extra> Extras { get; set; }

        [JsonProperty("total")] public CustomerPaid Total { get; set; }
    }

    public class Extra
    {
        /// <summary>
        /// 	The type of extra item this is. Either “shipping” or “tax”
        /// </summary>
        [JsonProperty("type")] public string Type { get; set; }

        /// <summary>
        /// 	A human-readable (but english) name for this extra charge.
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// 	A human-readable (but english) description of this extra charge.
        /// </summary>
        [JsonProperty("description")] public string Description { get; set; }

        /// <summary>
        /// 	How much this extra charge costs.
        /// </summary>
        [JsonProperty("price")] public CustomerPaid Price { get; set; }
    }
}