namespace LibraryToDocs.Model
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}