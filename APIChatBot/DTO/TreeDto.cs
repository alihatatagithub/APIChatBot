using System.ComponentModel.DataAnnotations.Schema;

namespace APIChatBot.DTO
{
    public class TreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public bool HasChildren { get; set; }
    }
}
