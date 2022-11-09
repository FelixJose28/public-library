namespace Library.Core.Entities
{
    public class Alert : BaseEntity
    {
        public int AlertId { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
