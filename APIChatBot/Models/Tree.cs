using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIChatBot.Models
{
    public class Tree
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Tree1")]
        public int? ParentId { get; set; }
        public Tree Tree1 { get; set; }
    }
}
