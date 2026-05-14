using HabitFlow.API.DTOs;
using HabitFlow.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase 
    {
        private readonly AppDbContext _context;
        public ProfileController (AppDbContext appDb)
        {
            _context = appDb;
        }

        [Authorize]
        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile() {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var profile = await _context.Profiles.FirstOrDefaultAsync(u => u.UserId == userId);
            if (profile == null) { 
                return NotFound("Профиль не найден");
            }
            var dto = new ProfileDto
            {
                DisplayName = profile.DisplayName,
                Bio = profile.Bio,
                AvatarUrl = profile.AvatarUrl,
                CreatedAt = profile.CreatedAt
            };
            return Ok(dto);
            
        }

        [Authorize]
        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfile)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var profile = await _context.Profiles.FirstOrDefaultAsync(u => u.UserId == userId);
            if (profile == null)
            {
                return NotFound("Профиль не найден");
            }
            profile.DisplayName = updateProfile.DisplayName;
            profile.Bio = updateProfile.Bio;
            profile.AvatarUrl = updateProfile.AvatarUrl;
            await _context.SaveChangesAsync();
            return Ok(new ProfileDto
            {
                DisplayName = profile.DisplayName,
                Bio= profile.Bio,
                AvatarUrl= profile.AvatarUrl,
                CreatedAt = profile.CreatedAt
            });

        }

        
    }
}
