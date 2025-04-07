using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyakorlo.Data
{
    public class Uzenetek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Nev { get; set; }
        [MaxLength(1000)]
        public string Uzenet { get; set; }

    }
}
