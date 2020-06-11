using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RI.api.Data;
using Microsoft.EntityFrameworkCore;

namespace RI.api.Controllers
{

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