using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OPSCAPI.Models;

namespace OPSCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitlessController : ControllerBase
    {
        DBManager manager = new DBManager();

        //GET Methods//
        [HttpGet("User")]
        public TblUser? GetUser(string userId) 
        {
            return manager.GetUser(userId);
        }

        [HttpGet("User/All")]
        public List<TblUser>? GetAllUsers()
        {
            return manager.GetAllUsers();
        }

        [HttpGet("Day")]
        public TblDay? GetDay(DateOnly date, string userId)
        {
            return manager.GetDay(date,userId);
        }

        [HttpGet("Day/All")]
        public List<TblDay>? GetAllDays()
        {
            return manager.GetAllDays();
        }

        [HttpGet("Exercise")]
        public TblExercise? GetExercise(string exerciseId)
        {
            return manager.GetExercise(exerciseId);
        }

        [HttpGet("Exercise/All")]
        public List<TblExercise>? GetAllExercises()
        {
            return manager.GetAllExercises();
        }

        [HttpGet("Cardio")]
        public TblCardioExercise? GetCardio(string exerciseId)
        {
            return manager.GetCardio(exerciseId);
        }

        [HttpGet("Cardio/All")]
        public List<TblCardioExercise>? GetAllCardio()
        {
            return manager.GetAllCardio();
        }

        [HttpGet("Strength")]
        public TblStrengthExercise? GetStrength(string exerciseId)
        {
            return manager.GetStrength(exerciseId);
        }

        [HttpGet("Strength/All")]
        public List<TblStrengthExercise>? GetAllStrength()
        {
            return manager.GetAllStrength();
        }

        [HttpGet("Meal")]
        public TblMeal? GetMeal(string mealId)
        {
            return manager.GetMeal(mealId);
        }

        [HttpGet("Meal/All")]
        public List<TblMeal>? GetAllMeals(string mealId)
        {
            return manager.GetAllMeals();
        }

        [HttpGet("Food")]
        public TblFood? GetFood(string foodId)
        {
            return manager.GetFood(foodId);
        }

        [HttpGet("Food/All")]
        public List<TblFood>? GetAllFoods()
        {
            return manager.GetAllFoods();
        }

        [HttpGet("Movement")]
        public TblMovement? GetMovement(string movementId)
        {
            return manager.GetMovement(movementId);
        }

        [HttpGet("Movement/All")]
        public List<TblMovement>? GetAllMovements()
        {
            return manager.GetAllMovements();
        }

        [HttpGet("Workout")]
        public TblWorkout? GetWorkout(string workoutId)
        {
            return manager.GetWorkout(workoutId);
        }

        [HttpGet("Workout/All")]
        public List<TblWorkout>? GetAllWorkouts()
        {
            return manager.GetAllWorkouts();
        }
        //GET Methods//

        //POST Methods//
        [HttpPost("User")]
        public string AddUser(TblUser user)
        {
            return manager.AddUser(user);
        }

        [HttpPost("Day")]
        public string AddDay(TblDay day)
        {
            return manager.AddDay(day);
        }

        [HttpPost("Workout")]
        public string AddWorkout(TblWorkout workout)
        {
            return manager.AddWorkout(workout);
        }

        [HttpPost("Meal")]
        public string AddMeal(TblMeal meal)
        {
            return manager.AddMeal(meal);
        }

        [HttpPost("Food")]
        public string AddFood(TblFood food)
        {
            return manager.AddFood(food);
        }

        [HttpPost("Exercise")]
        public string AddExercise(TblExercise exercise)
        {
            return manager.AddExercise(exercise);
        }

        [HttpPost("Cardio")]
        public string AddCardio(TblCardioExercise cardio)
        {
            return manager.AddCardio(cardio);
        }

        [HttpPost("Strength")]
        public string AddStrength(TblStrengthExercise strength)
        {
            return manager.AddStrength(strength);
        }

        [HttpPost("Movement")]
        public string AddMovement(TblMovement movement)
        {
            return manager.AddMovement(movement);
        }
        //POST Methods//

        //PUT Methods//
        [HttpPut("User")]
        public string UpdateUser(TblUser user)
        {
            return manager.AddUser(user);
        }

        [HttpPut("Day")]
        public string UpdateDay(TblDay day)
        {
            return manager.AddDay(day);
        }

        [HttpPut("Workout")]
        public string UpdateWorkout(TblWorkout workout)
        {
            return manager.AddWorkout(workout);
        }

        [HttpPut("Meal")]
        public string UpdateMeal(TblMeal meal)
        {
            return manager.AddMeal(meal);
        }

        [HttpPut("Food")]
        public string UpdateFood(TblFood food)
        {
            return manager.AddFood(food);
        }

        [HttpPut("Exercise")]
        public string UpdateExercise(TblExercise exercise)
        {
            return manager.AddExercise(exercise);
        }

        [HttpPut("Cardio")]
        public string UpdateCardio(TblCardioExercise cardio)
        {
            return manager.AddCardio(cardio);
        }

        [HttpPut("Strength")]
        public string UpdateStrength(TblStrengthExercise strength)
        {
            return manager.AddStrength(strength);
        }

        [HttpPut("Movement")]
        public string UpdateMovement(TblMovement movement)
        {
            return manager.AddMovement(movement);
        }
        //PUT Methods//

        //DELETE Methods//
        [HttpDelete("User")]
        public string DeleteUser(string userId)
        {
            return manager.DeleteUser(userId);
        }

        [HttpDelete("Day")]
        public string DeleteDay(string userId, DateOnly date)
        {
            return manager.DeleteDay(date, userId);
        }

        [HttpDelete("Workout")]
        public string DeleteWorkout(string workout)
        {
            return manager.DeleteWorkout(workout);
        }

        [HttpDelete("Meal")]
        public string DeleteMeal(string meal)
        {
            return manager.DeleteMeal(meal);
        }

        [HttpDelete("Food")]
        public string DeleteFood(string food)
        {
            return manager.DeleteFood(food);
        }

        [HttpDelete("Exercise")]
        public string DeleteExercise(string exercise)
        {
            return manager.DeleteExercise(exercise);
        }

        [HttpDelete("Cardio")]
        public string DeleteCardio(string cardio)
        {
            return manager.DeleteCardio(cardio);
        }

        [HttpDelete("Strength")]
        public string DeleteStrength(string strength)
        {
            return manager.DeleteStrength(strength);
        }

        [HttpDelete("Movement")]
        public string DeleteMovement(string movement)
        {
            return manager.DeleteMovement(movement);
        }
        //DELETE Methods//
    }
}
