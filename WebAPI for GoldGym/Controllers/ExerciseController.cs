using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebAPI_for_GoldGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CheckExercise([FromBody] List<Exercise> exs)
        {
            int count = 0;
            foreach (Exercise ex in exs)
            {
                count++;
            }
            return Ok(count);
        }
    }
}
