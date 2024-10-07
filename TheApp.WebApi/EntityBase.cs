using System.ComponentModel.DataAnnotations;

namespace TheApp.WebApi
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        
        // Note: If you comment next 4 lines then the issue is going away
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}