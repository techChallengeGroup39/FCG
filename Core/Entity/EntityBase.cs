namespace Core.Entity
{
    public class EntityBase
    {
        public Guid Guid { get; set; }
        public DateTime dataCriacao { get; set; }
        public required string CriadoPor { get; set; }
        public int Status { get; set; }
    }
}
