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
	public class LogoutController : ControllerBase
	{
		private readonly ILogger<LogoutController> _logger;
		private readonly SignInManager<IdentityUser> _sim;

		public LogoutController(ILogger<LogoutController> logger, SignInManager<IdentityUser> sim)
		{
			_logger = logger;
			_sim = sim;
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			_logger.LogInformation("Logging out user");
			await _sim.SignOutAsync();
			return Ok();
		}
	}
}
