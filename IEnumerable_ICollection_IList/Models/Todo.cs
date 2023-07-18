using System.ComponentModel.DataAnnotations;

namespace IEnumerable_ICollection_IList.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
    }
}
