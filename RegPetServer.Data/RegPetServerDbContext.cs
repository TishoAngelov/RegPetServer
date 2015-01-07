namespace RegPetServer.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RegPetServer.Models;

    public class RegPetServerDbContext : IdentityDbContext<User>
    {
        public RegPetServerDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static RegPetServerDbContext Create()
        {
            return new RegPetServerDbContext();
        }

        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Tag> Tags { get; set; }

        // TODO: Add all models here without User.
    }
}