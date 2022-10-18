using Microsoft.AspNetCore.Identity;

namespace SzerverOf_5het.Models
{
	public class SiteUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int MinSal { get; set; }
	}
}
