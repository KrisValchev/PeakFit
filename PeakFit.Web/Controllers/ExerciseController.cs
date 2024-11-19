using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;

namespace PeakFit.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ExerciseController(IExerciseService exerciseService) : Controller
    {
        //GET: api/Exercise/GetByCategory
        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetExercisesByCategory(int categoryId)
        {

            var exercises = await exerciseService.GetExercisesByCategoryAsync(categoryId);

            var exercisesDto=exercises.Select(e => new
            {
               e.ExerciseName,
               e.Category.CategoryName,   
               e.CategoryId,   
               e.Id
            });
            if (exercises == null)
            {
                return NotFound("No exercises found for the selected category.");
            }

            return Ok(exercisesDto);
        }
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAllExercises()
        //{



        //    //var exercisesDto = exercises.Select(e => new
        //    //{
        //    //    e.ExerciseName,
        //    //    e.Category.CategoryName,
        //    //    e.CategoryId,
        //    //    e.Id
        //    //});
        //    //if (exercises == null)
        //    //{
        //    //    return NotFound("No exercises found for the selected category.");
        //    //}

        //    //return Ok(exercisesDto);


        //}
    }
}
