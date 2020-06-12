using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RI.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RI.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly DataContext _context;
        public VideosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {

            var videos = await _context.Videos.ToListAsync(); 
            return Ok(videos);
        }

    }
}