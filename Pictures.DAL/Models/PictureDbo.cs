using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Pictures.DAL.Models
{
    [Table("Pictures")]
    public class PictureDbo
    {
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(Order = 2)]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)", Order = 3)]
        public string Image { get; set; }
    }
}
