namespace MarketPlaceIntegration.Services.Hepsiburada.ServerModels
{
    public class RootCategoryAttributes
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public string message { get; set; }
        public CategoryAttributes data { get; set; }
    }

    public class VariantAttribute
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool mandatory { get; set; }
        public string type { get; set; }
        public bool multiValue { get; set; }
    }
    public class Attribute
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool mandatory { get; set; }
        public string type { get; set; }
        public bool multiValue { get; set; }
    }

    public class BaseAttribute
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool mandatory { get; set; }
        public string type { get; set; }
        public bool multiValue { get; set; }
    }

    public class CategoryAttributes
    {
        public List<BaseAttribute> baseAttributes { get; set; }
        public List<Attribute> attributes { get; set; }
        public List<VariantAttribute> variantAttributes { get; set; }
    }
}
