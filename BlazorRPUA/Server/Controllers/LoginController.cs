using BlazorRPUA.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRPUA.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly SignInManager<IdentityUser> _sim;

		public LoginController(ILogger<LoginController> logger, SignInManager<IdentityUser> sim)
		{
			_logger = logger;
			_sim = sim;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] Korisnik reg)
		{
			_logger.LogInformation($"Got request for: {reg.Korisnicko}");
			var rez = await _sim.PasswordSignInAsync(reg.Korisnicko, reg.Sifra, false, false);
			if (!rez.Succeeded)
			{
				_logger.LogWarning($"Failed to log in");
				return Ok(false);
			}
			_logger.LogInformation("Logged in user.");
			return Ok(true);
		}


	}
}
