namespace MarketPlaceIntegration.Services.Hepsiburada.ServerModels
{
    public class RootCategory
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public string message { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public bool last { get; set; }
        public List<Category> data { get; set; }
    }
    public class Category
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public int parentCategoryId { get; set; }
        public List<string> paths { get; set; }
        public bool leaf { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string sortId { get; set; }
        public object imageURL { get; set; }
        public bool available { get; set; }
        public List<ProductType> productTypes { get; set; }
        public bool merge { get; set; }
    }

    public class ProductType
    {
        public string name { get; set; }
        public int productTypeId { get; set; }
    }
}
