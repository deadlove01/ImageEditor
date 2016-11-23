using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Models.Viralstyle
{

    public class ViralStyleRequestData
    {
        public string _token { get; set; }
        public Campaign campaign_data { get; set; }
    }

    public class ViralStyleRequestJsonData
    {
        public string _token { get; set; }
        public string campaign_data { get; set; }
    }

    public class Campaign
    {
        public bool isDraft { get; set; }
        public string campaignId { get; set; }
        public bool createSimilar { get; set; }
        public string campaignUniqueId { get; set; }
        public string imageIdentifier { get; set; }
        public int goal { get; set; }
        public Mainproduct mainProduct { get; set; }
        public Pricing pricing { get; set; }
        public Additionalproduct[] additionalProducts { get; set; }
        public string campaign_name { get; set; }
        public string campaign_description { get; set; }
        public string campaign_url { get; set; }
        public string[] campaign_tags { get; set; }
        public int campaign_length { get; set; }
        public string campaign_end_date { get; set; }
        public string campaign_end_date_obj { get; set; }
        public long campaign_end_date_utc { get; set; }
        public bool hide_marketplace { get; set; }
        public bool campaign_auto_relaunch { get; set; }
        public bool campaign_page_timer { get; set; }
        public bool campaign_show_goal { get; set; }
        public bool campaign_auto_extend { get; set; }
        public bool campaign_dtg_auto_goal_drop { get; set; }
        public bool campaign_show_back_default { get; set; }
        public object[] campaign_upsells { get; set; }
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

    public class Mainproduct
    {
        public Currentcolor currentColor { get; set; }
        public Product product { get; set; }
        public Front2 front { get; set; }
        public Back2 back { get; set; }
        public int product_id { get; set; }
    }

    public class Currentcolor
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public string ab_color { get; set; }
        public object sm_color { get; set; }
        public string hex { get; set; }
        public int active { get; set; }
        public object common_color_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Hsl hsl { get; set; }
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
        public Image image { get; set; }
        public string product_thumbnail_image { get; set; }
        public string product_image { get; set; }
        public int mock_index { get; set; }
        public int mock_id { get; set; }
        public string product_type { get; set; }
        public Dimensions dimensions { get; set; }
    }

    public class Image
    {
        public Front front { get; set; }
        public Back back { get; set; }
    }

    public class Front
    {
        public string original { get; set; }
        public string thumbnail { get; set; }
        public string large { get; set; }
    }

    public class Back
    {
        public string original { get; set; }
        public string thumbnail { get; set; }
        public string large { get; set; }
    }

    public class Dimensions
    {
        public Front1 front { get; set; }
        public Back1 back { get; set; }
    }

    public class Front1
    {
        public Offsets offsets { get; set; }
        public Image1 image { get; set; }
    }

    public class Offsets
    {
        public string height { get; set; }
        public string width { get; set; }
        public string left { get; set; }
        public string top { get; set; }
    }

    public class Image1
    {
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Back1
    {
        public Offsets1 offsets { get; set; }
        public Image2 image { get; set; }
    }

    public class Offsets1
    {
        public string height { get; set; }
        public string width { get; set; }
        public string left { get; set; }
        public string top { get; set; }
    }

    public class Image2
    {
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Front2
    {
        public Designeritem[] designerItems { get; set; }
    }

    public class Designeritem
    {
        public string type { get; set; }
        public string value { get; set; }
        public Imagedata imageData { get; set; }
        public string[] colors { get; set; }
        public bool allow_delete { get; set; }
        public Span span { get; set; }
        public Element element { get; set; }
        public float rotate { get; set; }
        public string id { get; set; }
        public int index { get; set; }
    }

    public class Imagedata
    {
        public string original_url { get; set; }
        public string thumbnail_url { get; set; }
        public string original_upload_url { get; set; }
        public float height { get; set; }
        public float width { get; set; }
        public float left { get; set; }
        public float top { get; set; }
    }

    public class Span
    {
        public float height { get; set; }
        public float width { get; set; }
        public float top { get; set; }
        public float left { get; set; }
        public int rotLeft { get; set; }
        public int rotTop { get; set; }
        public int index { get; set; }
    }

    public class Element
    {
        public float x { get; set; }
        public int y { get; set; }
    }

    public class Back2
    {
        public object[] designerItems { get; set; }
    }

    public class Pricing
    {
        public float basePrice { get; set; }
        public string sellingPrice { get; set; }
        public float dtgPrice { get; set; }
    }

    public class Colors
    {
        public Totalcolor[] totalColors { get; set; }
        public Totalfrontcolor[] totalFrontColors { get; set; }
        public object[] totalBackColors { get; set; }
    }

    public class Totalcolor
    {
        public string hex { get; set; }
        public int times { get; set; }
    }

    public class Totalfrontcolor
    {
        public string hex { get; set; }
        public int times { get; set; }
    }

    public class Design
    {
        public Front3 front { get; set; }
        public Back3 back { get; set; }
    }

    public class Front3
    {
        public string original { get; set; }
        public string upscaled { get; set; }
        public Offsets2 offsets { get; set; }
    }

    public class Offsets2
    {
        public float top { get; set; }
        public float left { get; set; }
    }

    public class Back3
    {
        public string original { get; set; }
        public string upscaled { get; set; }
        public Offsets3 offsets { get; set; }
    }

    public class Offsets3
    {
        public float top { get; set; }
        public float left { get; set; }
    }

    public class Fonts
    {
        public Front4[] front { get; set; }
        public Back4[] back { get; set; }
    }

    public class Front4
    {
        public string font { get; set; }
        public int times { get; set; }
    }

    public class Back4
    {
        public string font { get; set; }
        public int times { get; set; }
    }

    public class Purchases
    {
        public object[] products { get; set; }
        public Buyer buyer { get; set; }
        public Payment payment { get; set; }
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

    public class Payment
    {
        public Cc cc { get; set; }
    }

    public class Cc
    {
        public string token { get; set; }
        public string cc_bin { get; set; }
        public string currency { get; set; }
    }

    public class Additionalproduct
    {
        public int product { get; set; }
        public int color { get; set; }
        public string hex { get; set; }
        public string selling_price { get; set; }
        public string profit { get; set; }
        public float base_price { get; set; }
        public float dtg_price { get; set; }
        public string dtg_profit { get; set; }
    }

}
