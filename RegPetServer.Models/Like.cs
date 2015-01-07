namespace RegPetServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}