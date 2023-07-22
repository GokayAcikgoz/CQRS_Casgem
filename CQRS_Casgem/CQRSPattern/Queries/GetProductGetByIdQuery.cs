namespace CQRS_Casgem.CQRSPattern.Queries
{
    public class GetProductGetByIdQuery
    {
        public GetProductGetByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
