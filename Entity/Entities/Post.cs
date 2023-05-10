using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    [Table("TB_POST")]
    public class Post : Notifies
    {
        [Column("POST_ID")]
        public int Id { get; set; }

        [Column("POST_TITLE")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("POST_ACTIVE")]
        public bool Active { get; set; }

        [Column("POST_CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("POST_MODIFIED_DATE")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
