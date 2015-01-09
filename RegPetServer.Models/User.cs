namespace RegPetServer.Models
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Pet> pets;

        public User ()
	    {
            this.pets = new HashSet<Pet>();
	    }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
    }
}