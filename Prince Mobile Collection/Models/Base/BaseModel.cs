namespace PrinceApi.Models.Base
{
    public class BaseModel
    {
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
