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

        [HttpGet("User/Email")]
        public User? GetUserByEmail(string email)
        {
            return manager.GetUserByEmail(email);
        }

        [HttpGet("User/All")]
        public List<User>? GetAllUsers()
        {
            return manager.GetAllUsers();
        }

        [HttpGet("UserInfo")]
        public UserInfo? GetUserInfo(string userId)
        {
            return manager.GetUserInfo(userId);
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
        public Exercise? GetExercise(int exerciseId)
        {
            return manager.GetExercise(exerciseId);
        }

        [HttpGet("Exercise/All")]
        public List<Exercise>? GetAllExercises()
        {
            return manager.GetAllExercises();
        }

        [HttpGet("Cardio")]
        public Cardio? GetCardio(int exerciseId)
        {
            return manager.GetCardio(exerciseId);
        }

        [HttpGet("Cardio/All")]
        public List<Cardio>? GetAllCardio()
        {
            return manager.GetAllCardio();
        }

        [HttpGet("Strength")]
        public Strength? GetStrength(int exerciseId)
        {
            return manager.GetStrength(exerciseId);
        }

        [HttpGet("Strength/All")]
        public List<Strength>? GetAllStrength()
        {
            return manager.GetAllStrength();
        }

        [HttpGet("Meal")]
        public Meal? GetMeal(int mealId)
        {
            return manager.GetMeal(mealId);
        }

        [HttpGet("Meal/All")]
        public List<Meal>? GetAllMeals(string mealId)
        {
            return manager.GetAllMeals();
        }
        [HttpGet("Meal/User")]
        public List<Meal>? GetMealsByUserId(string userId)
        {
            return manager.GetMealsByUID(userId);
        }
        [HttpGet("Meal/User/Date")]
        public List<Meal>? GetUserMealsByDate(string userId, DateOnly date)
        {
            return manager.GetUserMealsByDate(userId, date);
        }

        [HttpGet("Food")]
        public Food? GetFood(int foodId)
        {
            return manager.GetFood(foodId);
        }
        [HttpGet("Ratios")]
        public Ratios? GetRatios(string ratios)
        {
            return manager.GetRatios(ratios);
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
        public Workout? GetWorkout(int workoutId)
        {
            return manager.GetWorkout(workoutId);
        }

        [HttpGet("Workout/All")]
        public List<Workout>? GetAllWorkouts()
        {
            return manager.GetAllWorkouts();
        }

        [HttpGet("Workout/User/Date")]
        public List<Workout>? GetUserWorkoutsByDate(string userId, DateOnly date)
        {
            return manager.GetUserWorkoutsByDate(userId, date);
        }

        [HttpGet("Workout/User")]
        public List<Workout>? GetUserWorkouts(string userId)
        {
            return manager.GetUserWorkouts(userId);
        }

        [HttpGet("Exercise/Workout")]
        public List<Exercise>? GetExercisesByWorkout(int workoutId)
        {
            return manager.GetExercisesByWorkoutId(workoutId);
        }

        [HttpGet("Workout/Name")]
        public Workout? GetWorkoutByName(string name, DateOnly date)
        {
            return manager.GetWorkoutByName(name, date);
        }
        [HttpGet("Meal/Name")]
        public Meal? GetMealByName(string name, DateOnly date)
        {
            return manager.GetMealByName(name, date);
        }

        //GET Methods//

        //POST Methods//
        [HttpPost("User")]
        public string AddUser(User user)
        {
            return manager.AddUser(user);
        }

        [HttpPost("UserInfo")]
        public string AddUserInfo(UserInfo user)
        {
            return manager.AddUserInfo(user);
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

        [HttpPost("MealFood")]
        public string AddMealFood(MealFood mealfood)
        {
            return manager.AddMealFood(mealfood);
        }
        //POST Methods//

        //PUT Methods//
        [HttpPut("User")]
        public string UpdateUser(User user)
        {
            return manager.UpdateUser(user);
        }

        [HttpPut("UserInfo")]
        public string UpdateUserInfo(UserInfo user)
        {
            return manager.UpdateUserInfo(user);
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

        [HttpDelete("UserInfo")]
        public string DeleteUserInfo(string userId)
        {
            return manager.DeleteUserInfo(userId);
        }

        [HttpDelete("Day")]
        public string DeleteDay(DateOnly date, string userId)
        {
            return manager.DeleteDay(date, userId);
        }

        [HttpDelete("Workout")]
        public string DeleteWorkout(int workoutId)
        {
            return manager.DeleteWorkout(workoutId);
        }

        [HttpDelete("Meal")]
        public string DeleteMeal(int mealId)
        {
            return manager.DeleteMeal(mealId);
        }

        [HttpDelete("Food")]
        public string DeleteFood(int foodId)
        {
            return manager.DeleteFood(foodId);
        }

        [HttpDelete("Exercise")]
        public string DeleteExercise(int exerciseId)
        {
            return manager.DeleteExercise(exerciseId);
        }

        [HttpDelete("Cardio")]
        public string DeleteCardio(int cardioId)
        {
            return manager.DeleteCardio(cardioId);
        }

        [HttpDelete("Strength")]
        public string DeleteStrength(int strengthId)
        {
            return manager.DeleteStrength(strengthId);
        }

        [HttpDelete("Movement")]
        public string DeleteMovement(int movementId)
        {
            return manager.DeleteMovement(movementId);
        }
        //DELETE Methods//
    }
}
