using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OPSCAPI.Models;
using OPSCAPI.Models.Database;

namespace OPSCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitlessController : ControllerBase
    {
        DBManager manager = new DBManager();

        //GET Methods//
        [HttpGet("User")]
        public User? GetUser(string userId) 
        {
            return manager.GetUser(userId);
        }

        [HttpGet("User/All")]
        public List<User>? GetAllUsers()
        {
            return manager.GetAllUsers();
        }

        [HttpGet("Day")]
        public Day? GetDay(DateOnly date, string userId)
        {
            return manager.GetDay(date,userId);
        }

        [HttpGet("Day/All")]
        public List<Day>? GetAllDays()
        {
            return manager.GetAllDays();
        }

        [HttpGet("Exercise")]
        public Exercise? GetExercise(string exerciseId)
        {
            return manager.GetExercise(exerciseId);
        }

        [HttpGet("Exercise/All")]
        public List<Exercise>? GetAllExercises()
        {
            return manager.GetAllExercises();
        }

        [HttpGet("Cardio")]
        public Cardio? GetCardio(string exerciseId)
        {
            return manager.GetCardio(exerciseId);
        }

        [HttpGet("Cardio/All")]
        public List<Cardio>? GetAllCardio()
        {
            return manager.GetAllCardio();
        }

        [HttpGet("Strength")]
        public Strength? GetStrength(string exerciseId)
        {
            return manager.GetStrength(exerciseId);
        }

        [HttpGet("Strength/All")]
        public List<Strength>? GetAllStrength()
        {
            return manager.GetAllStrength();
        }

        [HttpGet("Meal")]
        public Meal? GetMeal(string mealId)
        {
            return manager.GetMeal(mealId);
        }

        [HttpGet("Meal/All")]
        public List<Meal>? GetAllMeals(string mealId)
        {
            return manager.GetAllMeals();
        }

        [HttpGet("Food")]
        public Food? GetFood(int foodId)
        {
            return manager.GetFood(foodId);
        }

        [HttpGet("Food/All")]
        public async Task<List<Food>> GetAllFoods(int pageNumber, int pageSize)
        {
            return await manager.GetAllFoods(pageNumber, pageSize);
        }

        [HttpGet("Food/Search")]
        public async Task<List<Food>> SearchForFoods(string strSearch)
        {
            return await manager.SearchForFoods(strSearch);
        }

        [HttpGet("Movement")]
        public Movement? GetMovement(int movementId)
        {
            return manager.GetMovement(movementId);
        }

        [HttpGet("Movement/All")]
        public async Task<List<Movement>> GetAllMovements(int pageNumber = 1, int pageSize = 100)
        {
            return await manager.GetAllMovements(pageNumber, pageSize);
        }

        [HttpGet("Movement/Search")]
        public async Task<List<Movement>> SearchForMovements(string strSearch)
        {
            return await manager.SearchForMovements(strSearch);
        }

        [HttpGet("Workout")]
        public Workout? GetWorkout(string workoutId)
        {
            return manager.GetWorkout(workoutId);
        }

        [HttpGet("Workout/All")]
        public List<Workout>? GetAllWorkouts()
        {
            return manager.GetAllWorkouts();
        }
        //GET Methods//

        //POST Methods//
        [HttpPost("User")]
        public string AddUser(User user)
        {
            return manager.AddUser(user);
        }

        [HttpPost("Day")]
        public string AddDay(Day day)
        {
            return manager.AddDay(day);
        }

        [HttpPost("Workout")]
        public string AddWorkout(Workout workout)
        {
            return manager.AddWorkout(workout);
        }

        [HttpPost("Meal")]
        public string AddMeal(Meal meal)
        {
            return manager.AddMeal(meal);
        }

        [HttpPost("Food")]
        public string AddFood(Food food)
        {
            return manager.AddFood(food);
        }

        [HttpPost("Exercise")]
        public string AddExercise(Exercise exercise)
        {
            return manager.AddExercise(exercise);
        }

        [HttpPost("Cardio")]
        public string AddCardio(Cardio cardio)
        {
            return manager.AddCardio(cardio);
        }

        [HttpPost("Strength")]
        public string AddStrength(Strength strength)
        {
            return manager.AddStrength(strength);
        }

        [HttpPost("Movement")]
        public string AddMovement(Movement movement)
        {
            return manager.AddMovement(movement);
        }
        //POST Methods//

        //PUT Methods//
        [HttpPut("User")]
        public string UpdateUser(User user)
        {
            return manager.UpdateUser(user);
        }

        [HttpPut("Day")]
        public string UpdateDay(Day day)
        {
            return manager.UpdateDay(day);
        }

        [HttpPut("Workout")]
        public string UpdateWorkout(Workout workout)
        {
            return manager.UpdateWorkout(workout);
        }

        [HttpPut("Meal")]
        public string UpdateMeal(Meal meal)
        {
            return manager.UpdateMeal(meal);
        }

        [HttpPut("Food")]
        public string UpdateFood(Food food)
        {
            return manager.UpdateFood(food);
        }

        [HttpPut("Exercise")]
        public string UpdateExercise(Exercise exercise)
        {
            return manager.UpdateExercise(exercise);
        }

        [HttpPut("Cardio")]
        public string UpdateCardio(Cardio cardio)
        {
            return manager.UpdateCardio(cardio);
        }

        [HttpPut("Strength")]
        public string UpdateStrength(Strength strength)
        {
            return manager.UpdateStrength(strength);
        }

        [HttpPut("Movement")]
        public string UpdateMovement(Movement movement)
        {
            return manager.UpdateMovement(movement);
        }
        //PUT Methods//

        //DELETE Methods//
        [HttpDelete("User")]
        public string DeleteUser(string userId)
        {
            return manager.DeleteUser(userId);
        }

        [HttpDelete("Day")]
        public string DeleteDay(DateOnly date, string userId)
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
        public string DeleteFood(int food)
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
        public string DeleteMovement(int movementId)
        {
            return manager.DeleteMovement(movementId);
        }
        //DELETE Methods//
    }
}
