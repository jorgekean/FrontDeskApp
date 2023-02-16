namespace API.Model
{
    public class BoxStorageStatus
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StorageAreaId { get; set; }
        public string BoxSize { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
