using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Models.Viralstyle
{

    public class ViralStyleProduct
    {
        public List<ViralStyleProductData> ProductData { get; set; }

        public ViralStyleProduct()
        {
            ProductData = new List<ViralStyleProductData>();
        }
    }

    public class ViralStyleProductData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon_class { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<Category_Products> category_products { get; set; }
    }

    public class Category_Products
    {
        public int id { get; set; }
        public int category { get; set; }
        public int product { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Products products { get; set; }
    }

    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string append_description { get; set; }
        public int group_id { get; set; }
        public int shipping_group { get; set; }
        public string brand { get; set; }
        public string sku { get; set; }
        public string distributor { get; set; }
        public string style_code { get; set; }
        public string alpha_style_code { get; set; }
        public string sanmar_style_code { get; set; }
        public string avg_cost { get; set; }
        public string sizes { get; set; }
        public int ppi { get; set; }
        public string front_preview { get; set; }
        public string front_base { get; set; }
        public string front_mask { get; set; }
        public int front_left { get; set; }
        public int front_top { get; set; }
        public int front_height { get; set; }
        public int front_width { get; set; }
        public string front_base_large { get; set; }
        public string back_preview { get; set; }
        public string back_base { get; set; }
        public string back_mask { get; set; }
        public int back_left { get; set; }
        public int back_top { get; set; }
        public int back_height { get; set; }
        public int back_width { get; set; }
        public string back_base_large { get; set; }
        public int front_image_width { get; set; }
        public int front_image_height { get; set; }
        public int back_image_width { get; set; }
        public int back_image_height { get; set; }
        public int printer { get; set; }
        public string product_unique_id { get; set; }
        public string back_view { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string weights { get; set; }
        public string upcharges { get; set; }
        public int add_shipping { get; set; }
        public string sizing_json { get; set; }
        public int non_additional { get; set; }
        public int special_printing { get; set; }
        public int sublimation { get; set; }
        public int is_phone_case { get; set; }
        public int is_embroidery { get; set; }
        public string render_type { get; set; }
        public int dtg_drop_is_locked { get; set; }
        public int active { get; set; }
        public int exclude_left { get; set; }
        public int exclude_top { get; set; }
        public int exclude_height { get; set; }
        public int exclude_width { get; set; }
        public int is_non_apparel { get; set; }
        public string suggested_price { get; set; }
        public string actual_cost { get; set; }
        public int allow_api_orders { get; set; }
        public string special_print_setup_costs { get; set; }
        public string sublimation_single_side_price { get; set; }
        public string sublimation_double_side_price { get; set; }
        public string single_side_api_price { get; set; }
        public string double_side_api_price { get; set; }
        public int upload_dimension_limit { get; set; }
        public int has_perspectives { get; set; }
        public string perspective_details { get; set; }
        public string back_thumbnail_text { get; set; }
        public string notes { get; set; }
        public string sizing_image { get; set; }
        public string product_type { get; set; }
        public string sex { get; set; }
        public List<Product_Colors> product_colors { get; set; }
        public List<Products_Mocks> products_mocks { get; set; }
        public string base_url { get; set; }
    }

    public class Product_Colors
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public string ab_color { get; set; }
        public string sm_color { get; set; }
        public string hex { get; set; }
        public int active { get; set; }
        public string common_color_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class Products_Mocks
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string front_preview { get; set; }
        public string front_base { get; set; }
        public string front_base_large { get; set; }
        public string front_mask { get; set; }
        public int front_left { get; set; }
        public int front_top { get; set; }
        public int front_width { get; set; }
        public int front_height { get; set; }
        public int front_image_width { get; set; }
        public int front_image_height { get; set; }
        public string back_preview { get; set; }
        public string back_base { get; set; }
        public string back_base_large { get; set; }
        public string back_mask { get; set; }
        public int back_left { get; set; }
        public int back_top { get; set; }
        public int back_width { get; set; }
        public int back_height { get; set; }
        public int back_image_width { get; set; }
        public int back_image_height { get; set; }
        public int exclude_left { get; set; }
        public int exclude_top { get; set; }
        public int exclude_height { get; set; }
        public int exclude_width { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string base_url { get; set; }
    }

}
