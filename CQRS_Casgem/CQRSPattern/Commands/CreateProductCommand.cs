namespace CQRS_Casgem.CQRSPattern.Commends
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}
