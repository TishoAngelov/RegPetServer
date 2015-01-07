namespace RegPetServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}