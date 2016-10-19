using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViralStyleUploader.Models
{
    public class RequestData
    {
        [JsonProperty("campaign_data")]
        public string campaignData { get; set; }

        [JsonProperty("_token")]
        public string token { get; set; }
    }


    public class CampaignData
    {
        public bool isDraft { get; set; }
        public string campaignId { get; set; }
        public bool createSimilar { get; set; }
        public string campaignUniqueId { get; set; }
        public string imageIdentifier { get; set; }
        public int goal { get; set; }
        public MainProduct mainProduct { get; set; }

        public Pricing pricing { get; set; }

        public List<Product> additionalProducts { get; set; }
        public string campaign_name { get; set; }

        public string campaign_description { get; set; }
        public string campaign_url { get; set; }
        public List<string> campaign_tags { get; set; }
        public int campaign_length { get; set; }
        public string campaign_end_date { get; set; }
        public string campaign_end_date_obj { get; set; }
        public double campaign_end_date_utc { get; set; }
        public bool hide_marketplace { get; set; }
        public bool campaign_auto_relaunch { get; set; }
        public bool campaign_page_timer { get; set; }
        public bool campaign_show_goal { get; set; }
        public bool campaign_auto_extend { get; set; }
        public bool campaign_dtg_auto_goal_drop { get; set; }
        public bool campaign_show_back_default { get; set; }
        public string campaign_upsells { get; set; }

        public Colors colors { get; set; }
        public Design design { get; set; }
        public Fonts fonts { get; set; }
        public Purchases purchases { get; set; }
        public bool accept_terms { get; set; }
        public bool api_order { get; set; }
        public bool manual_order { get; set; }
        public string category { get; set; }
        public bool force_dtg { get; set; }
        public bool auto_import_to_shopify { get; set; }
        public bool auto_set_visibility { get; set; }
        public string shopify_collection { get; set; }
        public string shopifyDomain { get; set; }
    }


    public class MainProduct
    {
        public CurrentColor currentColor { get; set; }
        public DesignItems front { get; set; }
        public DesignItems back { get; set; }

        public ProductItem product { get; set; }
        public int product_id { get; set; }
    }

    public class DesignItem
    {
        public string type { get; set; }
        public string value { get; set; }
        public bool allow_delete { get; set; }
        public int index { get; set; }
        public string id { get; set; }
        public float rotate { get; set; }
        public Element element { get; set; }

        public List<string> colors { get; set; }
        public SpanItem span { get; set; }
        public ImageData imageData { get; set; }
   
    }

    public class DesignItems
    {
        public List<DesignItem> designerItems { get; set; }
    }

    public class ImageData
    {
        public string original_url { get; set; }
        public string thumbnail_url { get; set; }
        public string original_upload_url { get; set; }
        public float height { get; set; }
        public float width { get; set; }
        public float left { get; set; }
        public float top { get; set; }
    }

    public class SpanItem
    {
        public float height { get; set; }
        public float width { get; set; }
        public float top { get; set; }
        public float left { get; set; }
        public float rotLeft { get; set; }
        public float rotTop { get; set; }
        public float index { get; set; }
    }
    

    public class Element
    {
        public float x { get; set; }
        public float y { get; set; }

    }

    public class CurrentColor
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int name { get; set; }
        public string ab_color { get; set; }
        public string sm_color { get; set; }
        public string hex { get; set; }
        public int active { get; set; }
        public string common_color_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Hsl hsl { get; set; }
    }


    public class ProductItem
    {
        public Image image { get; set; }
        public int mock_index { get; set; }
        public int mock_id { get; set; }
        public string product_type { get; set; }
        public Dimensions dimensions { get; set; }
        public string product_image { get; set; }
        public string product_thumbnail_image { get; set; }
    }

    public class Image
    {
        public ImageDetail front { get; set; }
        public ImageDetail back { get; set; }

    }


    public class ImageDetail
    {
        public string original { get; set; }
        public string thumbnail { get; set; }
        public string large { get; set; }
    }
    public class Hsl
    {
        public float h { get; set; }
        public float s { get; set; }
        public float l { get; set; }
        public float a { get; set; }
    }
    public class Product
    {
        public int product { get; set; }
        public int color { get; set; }
        public string hex { get; set; }
        public string selling_price { get; set; }
        public string profit { get; set; }
        public string base_price { get; set; }
        public string dtg_price { get; set; }
        public string dtg_profit { get; set; }
    }

    public class Pricing
    {
        public float basePrice { get; set; }
        public string sellingPrice { get; set; }
        public float dtgPrice { get; set; }

    }

    public class ColorType
    {
        public string hex { get; set; }
        public int times { get; set; }
    }

    public class FontType
    {
        public string font { get; set; }
        public int times { get; set; }

    }

    public class DesignType
    {
        public string original { get; set; }
        public string upscaled { get; set; }
        public Offsets offsets { get; set; }
    }

    public class Offsets
    {
        public float top { get; set; }
        public float left { get; set; }

    }

    public class Dimensions
    {
        public DimensionFront front { get; set; }
        public DimensionBack back { get; set; }
    }

    public class DimensionBack
    {
        public OffsetString back { get; set; }
        public OffsetImage image { get; set; }
    }

    public class DimensionFront
    {
        public OffsetString back { get; set; }
        public OffsetImage image { get; set; }
    }

    public class OffsetString
    {
        public string height { get; set; }
        public string width { get; set; }
        public string left { get; set; }
        public string top { get; set; }
    }

    public class OffsetImage

    {
        public string height { get; set; }
        public string width { get; set; }
    }

    public class PaymentType
    {
        public string token { get; set; }
        public string cc_bin { get; set; }
        public string currency { get; set; }
    }

    public class Payment
    {
        public PaymentType cc { get; set; }
    }

    public class Buyer
    {
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string apt { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }

    }
    public class Purchases
    {
        public Buyer buyer { get; set; }
        public Payment payment { get; set; }

    }

    public class Fonts
    {
        public FontType front { get; set; }
        public FontType back { get; set; }

    }

    public class Design
    {
        public DesignType front { get; set; }
    }

    public class Colors
    {
        public List<ColorType> totalColors { get; set; }
        public List<ColorType> totalFrontColors { get; set; }
        public List<ColorType> totalBackColors { get; set; }
    }
}
