namespace BookStore.Dto
{
    public class DtoCategory
    {
        public Guid CATEGORY_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string CATEGORY_SUMMARY { get; set; }
        public bool IS_MAIN_CATEGORY { get; set; }
    }
}