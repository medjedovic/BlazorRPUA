using BlazorRPUA.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRPUA.Server.Hubs
{
    public class KorisnikIdHub : Hub
	{
		public KorisnikIdHub(RoleManager<IdentityRole> rm, UserManager<IdentityUser> um, ILogger<KorisnikIdHub> logger)
		{
			_rm = rm;
			_um = um;
			_logger = logger;
		}

		private readonly RoleManager<IdentityRole> _rm;
		private readonly UserManager<IdentityUser> _um;
		private readonly ILogger<KorisnikIdHub> _logger;

		public async Task GetRoles() =>
			await Clients.Caller.SendAsync("RecRoles", _rm.Roles.Select(r => r.Name).ToList());

		public async Task Register(Korisnik k)
		{
			var greske = new List<string>();

			var user = new IdentityUser { Email = k.Mail, UserName = k.Korisnicko };
			var rez = await _um.CreateAsync(user, k.Sifra);

			if (rez.Succeeded)
			{
				var roleRez = await _um.AddToRoleAsync(user, k.Rola);
				greske = roleRez.Errors.Select(err => err.Description).ToList();
				await Clients.Caller.SendAsync("RegResult", roleRez.Succeeded, greske);
				return;
			}

			greske = rez.Errors.Select(err => err.Description).ToList();
			await Clients.Caller.SendAsync("RegResult", rez.Succeeded, greske);
		}

		[Authorize]
		public void Auth()
		{
			_logger.LogInformation("Call authorized");
		}

		[Authorize(Roles = "Admin")]
		public void AuthAdmin()
		{
			_logger.LogInformation("Call authorized, admin");
		}

	}
}
