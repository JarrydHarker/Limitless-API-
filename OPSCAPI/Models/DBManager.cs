using Microsoft.EntityFrameworkCore;
using OPSCAPI.Models.Database;

namespace OPSCAPI.Models
{
    public class DBManager
    {
        LimitlessDbContext context = new LimitlessDbContext();

        //User
        //Create
        public string AddUser(User user)
        {
            try
            {
                context.TblUsers.Add(user.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddUser(string userID, string name, string surname, string email, string password, float? weightGoal = null, float? calorieWallet = null, int stepGoal = 10000)
        {
            TblUser user = new TblUser
            {
                UserId = userID,
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
            };

            try
            {
                context.TblUsers.Add(user);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public List<User>? GetAllUsers()
        {
            List<User> users = new List<User>();

            foreach (TblUser user in context.TblUsers.ToList())
            {
                users.Add(new User(user));
            }

            return users;
        }

        public User? GetUser(string userID)
        {
            var user = context.TblUsers.Find(userID);

            if (user != null)
            {
                return new User(user);
            }

            return null;
        }
        public User? GetUserByEmail(string email)
        {
            var user = context.TblUsers.Where(x => x.Email == email).FirstOrDefault();

            if (user != null)
            {
                return new User(user);
            }

            return null;
        }

        //Update
        public string UpdateUser(string userID, string? name = null, string? surname = null, string? email = null, string? password = null, float? weightGoal = null, float? calorieWallet = null, int? stepGoal = null)
        {
            var user = context.TblUsers.Find(userID);

            if (user != null)
            {
                if (name != null)
                {
                    user.Name = name;
                }

                if (surname != null)
                {
                    user.Surname = surname;
                }

                if (email != null)
                {
                    user.Email = email;
                }

                //TODO Add password hashing
                if (password != null)
                {
                    user.Password = password;
                }

                context.SaveChanges();
                return "Success";

            }

            return "User not found";
        }

        public string UpdateUser(User user)
        {
            try
            {
                var original = context.TblUsers.Where(x => x.UserId == user.UserId).FirstOrDefault();

                if (original != null)
                {
                    original = user.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "User not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteUser(string userID)
        {
            try
            {
                context.TblUsers.Where(x => x.UserId == userID).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //UserInfo
        //Create
        public string AddUserInfo(UserInfo user)
        {
            try
            {
                context.TblUserInfos.Add(user.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public UserInfo? GetUserInfo(string userID)
        {
            var user = context.TblUserInfos.Find(userID);

            if (user != null)
            {
                return new UserInfo(user);
            }

            return null;
        }

        //Update
        public string UpdateUserInfo(UserInfo user)
        {
            try
            {
                var original = context.TblUserInfos.Where(x => x.UserId == user.UserId).FirstOrDefault();

                if (original != null)
                {
                    original = user.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "User not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteUserInfo(string userID)
        {
            try
            {
                context.TblUserInfos.Where(x => x.UserId == userID).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Day
        //Create
        public string AddDay(Day day)
        {
            try
            {
                context.TblDays.Add(day.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddDay(DateOnly date, string userID, int steps, int calories, int activeTime, float water, float? weight = null)
        {
            TblDay day = new TblDay
            {
                Date = date,
                UserId = userID,
                Steps = steps,
                Calories = calories,
                Weight = weight,
                ActiveTime = activeTime,
                Water = water
            };

            try
            {
                context.TblDays.Add(day);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public List<Day>? GetAllDays()
        {
            List<Day> days = new List<Day>();

            foreach (TblDay day in context.TblDays.ToList())
            {
                days.Add(new Day(day));
            }

            return days;
        }

        public Day? GetDay(DateOnly date, string userID)
        {
            var day = context.TblDays.Find(date, userID);

            if (day != null)
            {
                return new Day(day);
            }

            return null;
        }

        public List<Day>? GetDaysByUID(string userId)
        {
            var days = new List<Day>();

            foreach (TblDay day in context.TblDays.Where(x => x.UserId == userId).ToList())
            {
                days.Add(new Day(day));
            }

            return days;
        }

        //Update
        public string UpdateDay(DateOnly date, string userID, int? steps = null, int? calories = null, int? activeTime = null, float? water = null, float? weight = null)
        {
            var day = context.TblDays.Find(userID, date);

            if (day != null)
            {
                if (steps != null)
                {
                    day.Steps = (int)steps;
                }

                if (calories != null)
                {
                    day.Calories = (int)calories;
                }

                if (activeTime != null)
                {
                    day.ActiveTime = (int)activeTime;
                }

                if (water != null)
                {
                    day.Water = (float)water;
                }

                if (weight != null)
                {
                    day.Weight = (float)weight;
                }

                context.SaveChanges();
                return "Success";
            }

            return "Day not found";
        }

        public string UpdateDay(Day day)
        {
            try
            {
                var original = context.TblDays.Where(x => x.UserId == day.UserId && x.Date == day.Date).FirstOrDefault();

                if (original != null)
                {
                    original = day.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Day not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteDay(DateOnly date, string userID)
        {
            try
            {
                context.TblDays.Where(x => x.UserId == userID && x.Date == date).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Workout
        //Create
        public string AddWorkout(Workout workout)
        {
            try
            {
                context.TblWorkouts.Add(workout.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddWorkout(int workoutID, DateOnly date, string userID)
        {
            try
            {
                TblWorkout workout = new TblWorkout
                {
                    WorkoutId = workoutID,
                    Date = date,
                    UserId = userID
                };

                context.TblWorkouts.Add(workout);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }

        }

        //Read
        public List<Workout>? GetAllWorkouts()
        {
            var workouts = new List<Workout>();

            foreach (TblWorkout workout in context.TblWorkouts.ToList())
            {
                workouts.Add(new Workout(workout));
            }

            return workouts;
        }

        public List<Workout>? GetWorkoutsByDate(DateOnly date)
        {
            var workouts = new List<Workout>();

            foreach (TblWorkout workout in context.TblWorkouts.Where(x => x.Date == date).ToList())
            {
                workouts.Add(new Workout(workout));
            }

            return workouts;
        }

        public List<Workout>? GetUserWorkoutsByDate(string userId, DateOnly date)
        {
            var workouts = new List<Workout>();

            foreach (TblWorkout workout in context.TblWorkouts.Where(x => x.UserId == userId && x.Date == date).ToList())
            {
                workouts.Add(new Workout(workout));
            }

            return workouts;
        }

        public List<Workout>? GetUserWorkouts(string userId)
        {
            var workouts = new List<Workout>();

            foreach (TblWorkout workout in context.TblWorkouts.Where(x => x.UserId == userId).ToList())
            {
                workouts.Add(new Workout(workout));
            }

            return workouts;
        }

        public Workout? GetWorkout(int workoutID)
        {
            var workout = context.TblWorkouts.Find(workoutID);

            if (workout != null)
            {
                return new Workout(workout);
            }

            return null;
        }

        public Workout? GetWorkoutByName(string name, DateOnly date)
        {
            var workouts = context.TblWorkouts.Where(x => x.Name == name).ToList();

            if (workouts.Count() > 1)
            {
                var workout = workouts.Where(x => x.Date == date).FirstOrDefault();

                if(workout != null)
                {
                    return new Workout(workout);
                }
            }else
            {
                return new Workout(workouts[0]);
            }

            return null;
        }

        public Ratios? GetRatios(string userID)
        {
            var ratio = context.TblRatios.Find(userID);

            if (ratio != null)
            {
                return new Ratios(ratio);
            }

            return null;
        }

        //Update
        public string UpdateWorkout(int workoutID, DateOnly? date = null, string? userID = null)
        {
            var workout = GetWorkout(workoutID);

            if (workout != null)
            {
                if (date != null)
                {
                    workout.Date = (DateOnly)date;
                }

                if (userID != null)
                {
                    workout.UserId = userID;
                }

                context.SaveChanges();

                return "Success";

            } else
            {
                return "Workout not found";
            }
        }

        public string UpdateWorkout(Workout workout)
        {
            try
            {
                var original = context.TblWorkouts.Where(x => x.UserId == workout.UserId).FirstOrDefault();

                if (original != null)
                {
                    original = workout.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Workout not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete  
        public string DeleteWorkout(int workoutID)
        {
            try
            {
                context.TblWorkouts.Where(x => x.WorkoutId == workoutID).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Cardio
        //Create
        public string AddExercise(Exercise exercise)
        {
            try
            {
                context.TblExercises.Add(exercise.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddExercise(int exerciseID, int workoutID, int movementID, int sets, int reps, bool favourite)
        {
            try
            {
                TblExercise exercise = new TblExercise
                {
                    ExerciseId = exerciseID,
                    WorkoutId = workoutID,
                    MovementId = movementID,
                };

                context.TblExercises.Add(exercise);
                context.SaveChanges();
                AddStrength(exerciseID, sets, reps, favourite);

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddExercise(int exerciseID, int workoutID, int movementID, int time, float distance)
        {
            try
            {
                TblExercise exercise = new TblExercise
                {
                    ExerciseId = exerciseID,
                    WorkoutId = workoutID,
                    MovementId = movementID,
                };

                context.TblExercises.Add(exercise);
                context.SaveChanges();

                AddCardio(exerciseID, time, distance);
                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddCardio(Cardio cardio)
        {
            try
            {
                context.TblCardioExercises.Add(cardio.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddCardio(int exerciseID, int time, float distance)
        {
            try
            {
                TblCardioExercise cardio = new TblCardioExercise
                {
                    ExerciseId = exerciseID,
                    Time = time,
                    Distance = distance
                };

                context.TblCardioExercises.Add(cardio);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }

        }

        public string AddStrength(Strength strength)
        {
            try
            {
                context.TblStrengthExercises.Add(strength.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddStrength(int exerciseID, int sets, int reps, bool favourite)
        {
            try
            {
                TblStrengthExercise strength = new TblStrengthExercise
                {
                    ExerciseId = exerciseID,
                    Sets = sets,
                    Repetitions = reps,
                    Favourite = favourite
                };

                context.TblStrengthExercises.Add(strength);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public List<Exercise>? GetAllExercises()
        {
            var exercises = new List<Exercise>();

            foreach (TblExercise exercise in context.TblExercises.ToList())
            {
                exercises.Add(new Exercise(exercise));
            }

            return exercises;
        }

        public List<Cardio>? GetAllCardio()
        {
            var cardios = new List<Cardio>();

            foreach (TblCardioExercise cardio in context.TblCardioExercises.ToList())
            {
                cardios.Add(new Cardio(cardio));
            }

            return cardios;
        }

        public List<Strength>? GetAllStrength()
        {
            var strengths = new List<Strength>();

            foreach (TblStrengthExercise strength in context.TblStrengthExercises.ToList())
            {
                strengths.Add(new Strength(strength));
            }

            return strengths;
        }

        public List<Exercise>? GetExercisesByWorkoutId(int workoutId)
        {
            var exercises = new List<Exercise>();

            foreach (TblExercise exercise in context.TblExercises.Where(x => x.WorkoutId == workoutId).ToList())
            {
                exercises.Add(new Exercise(exercise));
            }

            return exercises;
        }

        public List<Exercise>? GetExercisesByMovementId(int movementId)
        {
            var exercises = new List<Exercise>();

            foreach (TblExercise exercise in context.TblExercises.Where(x => x.MovementId == movementId).ToList())
            {
                exercises.Add(new Exercise(exercise));
            }

            return exercises;
        }

        public Exercise? GetExercise(int exerciseID)
        {
            var exercise = context.TblExercises.Find(exerciseID);

            if (exercise != null)
            {
                return new Exercise(exercise);
            }

            return null;
        }

        public Strength? GetStrength(int exerciseID)
        {
            var strength = context.TblStrengthExercises.Find(exerciseID);

            if (strength != null)
            {
                return new Strength(strength);
            }

            return null;
        }

        public Cardio? GetCardio(int exerciseID)
        {
            var cardio = context.TblCardioExercises.Find(exerciseID);

            if (cardio != null)
            {
                return new Cardio(cardio);
            }

            return null;
        }

        //Update
        public string UpdateExercise(int exerciseID, int? workoutID = null, int? movementID = null)
        {
            var exercise = context.TblExercises.Find(exerciseID);

            if (exercise != null)
            {
                if (workoutID != null)
                {
                    exercise.WorkoutId = (int)workoutID;
                }

                if (movementID != null)
                {
                    exercise.MovementId = (int)movementID;
                }

                return "Success";
            } else return "Cardio not found";
        }

        public string UpdateExercise(Exercise exercise)
        {
            try
            {
                var original = context.TblExercises.Where(x => x.ExerciseId == exercise.ExerciseId).FirstOrDefault();

                if (original != null)
                {
                    original = exercise.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Cardio not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string UpdateCardio(int exerciseID, int? time = null, float? distance = null)
        {
            var cardio = context.TblCardioExercises.Find(exerciseID);

            if (cardio != null)
            {
                if (time != null)
                {
                    cardio.Time = (int)time;
                }

                if (distance != null)
                {
                    cardio.Distance = (float)distance;
                }

                return "Success";
            }

            return "Cardio not found";
        }

        public string UpdateCardio(Cardio cardio)
        {
            try
            {
                var original = context.TblCardioExercises.Where(x => x.ExerciseId == cardio.ExerciseId).FirstOrDefault();

                if (original != null)
                {
                    original = cardio.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Cardio not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string UpdateStrength(int exerciseID, int? sets = null, int? reps = null, bool? favourite = null)
        {
            var strength = context.TblStrengthExercises.Find(exerciseID);

            if (strength != null)
            {
                if (sets != null)
                {
                    strength.Sets = (int)sets;
                }

                if (reps != null)
                {
                    strength.Repetitions = (int)reps;
                }

                if (favourite != null)
                {
                    strength.Favourite = (bool)favourite;
                }

                return "Success";
            }

            return "Strength not found";
        }

        public string UpdateStrength(Strength strength)
        {
            try
            {
                var original = context.TblStrengthExercises.Where(x => x.ExerciseId == strength.ExerciseId).FirstOrDefault();

                if (original != null)
                {
                    original = strength.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Strength not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteExercise(int exerciseID)
        {
            try
            {
                context.TblExercises.Where(x => x.WorkoutId == exerciseID).ExecuteDelete();
                DeleteCardio(exerciseID);
                DeleteStrength(exerciseID);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string DeleteStrength(int exerciseID)
        {
            try
            {
                var strength = context.TblStrengthExercises.Find(exerciseID);

                if (strength != null)
                {
                    context.TblStrengthExercises.Where(x => x.ExerciseId == exerciseID).ExecuteDelete();
                    context.SaveChanges();
                    return "Success";

                }
                return "Strength Cardio not found";

            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }

        }

        public string DeleteCardio(int exerciseID)
        {
            try
            {
                var cardio = context.TblCardioExercises.Find(exerciseID);

                if (cardio != null)
                {
                    context.TblCardioExercises.Where(x => x.ExerciseId == exerciseID).ExecuteDelete();
                    context.SaveChanges();
                }
                return "Cardio Cardio not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Food
        //Create
        public string AddFood(Food food)
        {
            try
            {
                context.TblFoods.Add(food.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddFood(string category, string description, int calories, string? mealID = null, float? weight = null, float? protein = null, float? carbs = null, float? fibre = null, float? fat = null, float? cholestrol = null, float? sugar = null, float? satFat = null, float? vitB12 = null, float? vitB6 = null, float? vitK = null, float? vitE = null, float? vitC = null, float? vitA = null, float? zinc = null, float? magnesium = null, float? sodium = null, float? potassium = null, float? iron = null, float? calcium = null)
        {
            TblFood food = new TblFood
            {
                Category = category,
                Description = description,
                Calories = calories,
            };

            food.Weight = weight != null ? weight : null;
            food.Protein = protein != null ? protein : null;
            food.Carbohydrates = carbs != null ? carbs : null;
            food.Fibre = fibre != null ? fibre : null;
            food.Fat = fat != null ? fat : null;
            food.Cholestrol = cholestrol != null ? cholestrol : null;
            food.Sugar = sugar != null ? sugar : null;
            food.SaturatedFat = satFat != null ? satFat : null;
            food.VitaminB12 = vitB12 != null ? vitB12 : null;
            food.VitaminB6 = vitB6 != null ? vitB6 : null;
            food.VitaminK = vitK != null ? vitK : null;
            food.VitaminE = vitE != null ? vitE : null;
            food.VitaminC = vitC != null ? vitC : null;
            food.VitaminA = vitA != null ? vitA : null;
            food.Zinc = zinc != null ? zinc : null;
            food.Sodium = sodium != null ? sodium : null;
            food.Magnesium = magnesium != null ? magnesium : null;
            food.Potassium = potassium != null ? potassium : null;
            food.Iron = iron != null ? iron : null;
            food.Calcium = calcium != null ? calcium : null;

            try
            {
                context.TblFoods.Add(food);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }


        }

        //Read
        public async Task<List<Food>> GetAllFoods(int pageNumber, int pageSize)
        {
            var tblfoods = await context.TblFoods
                        .Skip((pageNumber - 1) * pageSize) // Skip records for previous pages
                        .Take(pageSize)                   // Take the desired number of records
                        .ToListAsync();

            var foods = new List<Food>();

            foreach (TblFood food in tblfoods)
            {
                foods.Add(new Food(food));
            }

            return foods;
        }

        public Food? GetFood(int foodId)
        {
            var food = context.TblFoods.Find(foodId);

            if (food != null)
            {
                return new Food(food);
            }

            return null;
        }

        public List<Food>? GetFoodsByMealId(int mealId)
        {
            var foods = new List<Food>();

            foreach (TblMealFood mealfood in context.TblMealFoods.Where(x => x.MealId == mealId).ToList())
            {
                var food = context.TblFoods.Find(mealfood.FoodId);

                if (food != null)
                {
                    foods.Add(new Food(food));
                }
            }

            return foods;
        }

        public async Task<List<Food>> SearchForFoods(string strSearch)
        {
            var foods = new List<Food>();

            // Pagination logic: Skip the first (pageNumber - 1) * pageSize items and take pageSize items
            var paginatedFoods = await context.TblFoods
                .Where(x => x.Description != null && x.Description!.ToLower().Contains(strSearch.ToLower()))
                .Take(10)
                .ToListAsync();

            // Convert the entities to Movement objects
            foreach (var food in paginatedFoods)
            {
                foods.Add(new Food(food));
            }

            return foods;
        }

        //Update
        public string UpdateFood(int foodId, string? category = null, string? description = null, int? calories = null, string? mealID = null, float? weight = null, float? protein = null, float? carbs = null, float? fibre = null, float? fat = null, float? cholestrol = null, float? sugar = null, float? satFat = null, float? vitB12 = null, float? vitB6 = null, float? vitK = null, float? vitE = null, float? vitC = null, float? vitA = null, float? zinc = null, float? magnesium = null, float? sodium = null, float? potassium = null, float? iron = null, float? calcium = null)
        {
            var food = GetFood(foodId);

            if (food != null)
            {
                if (category != null)
                {
                    food.Category = category;
                }

                if (description != null)
                {
                    food.Description = description;
                }

                if (calories != null)
                {
                    food.Calories = (int)calories;
                }

                if (mealID != null)
                {
                    food.MealId = mealID;
                }

                if (protein != null)
                {
                    food.Protein = protein;
                }

                if (carbs != null)
                {
                    food.Carbohydrates = carbs;
                }

                if (fibre != null)
                {
                    food.Fibre = fibre;
                }

                if (fat != null)
                {
                    food.Fat = fat;
                }

                if (cholestrol != null)
                {
                    food.Cholestrol = cholestrol;
                }

                if (sugar != null)
                {
                    food.Sugar = sugar;
                }

                if (satFat != null)
                {
                    food.SaturatedFat = satFat;
                }

                if (vitB12 != null)
                {
                    food.VitaminB12 = vitB12;
                }

                if (vitB6 != null)
                {
                    food.VitaminB6 = vitB6;
                }

                if (vitK != null)
                {
                    food.VitaminK = vitK;
                }

                if (vitE != null)
                {
                    food.VitaminE = vitE;
                }

                if (vitC != null)
                {
                    food.VitaminC = vitC;
                }

                if (vitA != null)
                {
                    food.VitaminA = vitA;
                }

                if (zinc != null)
                {
                    food.Zinc = zinc;
                }

                if (magnesium != null)
                {
                    food.Magnesium = magnesium;
                }

                if (sodium != null)
                {
                    food.Sodium = sodium;
                }

                if (potassium != null)
                {
                    food.Potassium = potassium;
                }

                if (iron != null)
                {
                    food.Iron = iron;
                }

                if (calcium != null)
                {
                    food.Calcium = calcium;
                }

                context.SaveChanges();

                return "Success";
            }

            return "Food not found";
        }

        public string UpdateFood(Food food)
        {
            try
            {
                var original = context.TblFoods.Where(x => x.FoodId == food.FoodId).FirstOrDefault();

                if (original != null)
                {
                    original = food.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Food not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteFood(int foodId)
        {
            try
            {
                context.TblFoods.Where(x => x.FoodId == foodId).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Meal
        //Create
        public string AddMeal(Meal meal)
        {
            try
            {
                context.TblMeals.Add(meal.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddMeal(int mealId, string name, DateOnly? date = null, string? userId = null)
        {
            TblMeal meal = new TblMeal
            {
                MealId = mealId,
                Name = name,
            };

            try
            {
                context.TblMeals.Add(meal);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public List<Meal>? GetAllMeals()
        {
            var meals = new List<Meal>();

            foreach (TblMeal meal in context.TblMeals.ToList())
            {
                meals.Add(new Meal(meal));
            }

            return meals;
        }

        public Meal? GetMeal(int mealId)
        {
            var meal = context.TblMeals.Find(mealId);

            if (meal != null)
            {
                return new Meal(meal);
            }

            return null;
        }

        public List<Meal>? GetMealsByUID(string userId)
        {
            var meals = new List<Meal>();

            foreach (TblMealFood mealFood in context.TblMealFoods.Where(x => x.UserId == userId).ToList())
            {
                var meal = context.TblMeals.Find(mealFood.MealId);

                if(meal != null)
                {
                    meals.Add(new Meal(meal));
                }
            }

            return meals;
        }

        //Update
        public string UpdateMeal(int mealId, string? name = null, DateOnly? date = null, string? userId = null)
        {
            var meal = GetMeal(mealId);

            if (meal != null)
            {
                if (name != null)
                {
                    meal.Name = name;
                }

                if (date != null)
                {
                    meal.Date = date;
                }

                if (userId != null)
                {
                    meal.UserId = userId;
                }

                context.SaveChanges();

                return "Success";
            }

            return "Meal not found";
        }

        public string UpdateMeal(Meal meal)
        {
            try
            {
                var original = context.TblMeals.Where(x => x.MealId == meal.MealId).FirstOrDefault();

                if (original != null)
                {
                    original = meal.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Meal not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Delete
        public string DeleteMeal(int mealId)
        {
            try
            {
                context.TblMeals.Where(x => x.MealId == mealId).ExecuteDelete();
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Movement
        //Create
        public string AddMovement(Movement movement)
        {
            try
            {
                context.TblMovements.Add(movement.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddMovement(int movementId, string name, string type, string bodyPart, string equipment, string difficulty, string? description = null, float? max = null)
        {
            TblMovement movement = new TblMovement
            {
                MovementId = movementId,
                Name = name,
                Type = type,
                Bodypart = bodyPart,
                Equipment = equipment,
                DifficultyLevel = difficulty,
            };

            movement.Description = description != null ? description : null;

            try
            {
                context.TblMovements.Add(movement);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Read
        public Movement? GetMovement(int movementId)
        {
            var move = context.TblMovements.Find(movementId);

            if (move != null)
            {
                return new Movement(move);
            }

            return null;
        }

        public async Task<List<Movement>> GetAllMovements(int pageNumber, int pageSize)
        {
            var moves = new List<Movement>();

            // Pagination logic: Skip the first (pageNumber - 1) * pageSize items and take pageSize items
            var paginatedMoves = await context.TblMovements
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Convert the entities to Movement objects
            foreach (var move in paginatedMoves)
            {
                moves.Add(new Movement(move));
            }

            return moves;
        }

        public async Task<List<Movement>> SearchForMovements(string strSearch)
        {
            var moves = new List<Movement>();

            // Pagination logic: Skip the first (pageNumber - 1) * pageSize items and take pageSize items
            var paginatedMoves = await context.TblMovements
                .Where(x => x.Name.ToLower().Contains(strSearch.ToLower()))
                .Take(10)
                .ToListAsync();

            // Convert the entities to Movement objects
            foreach (var move in paginatedMoves)
            {
                moves.Add(new Movement(move));
            }

            return moves;
        }

        //Update
        public string UpdateMovement(int movementId, string? name = null, string? type = null, string? bodyPart = null, string? equipment = null, string? difficulty = null, string? description = null, float? max = null)
        {
            var movement = GetMovement(movementId);

            if (movement != null)
            {
                if (name != null)
                {
                    movement.Name = name;
                }

                if (type != null)
                {
                    movement.Type = type;
                }

                if (bodyPart != null)
                {
                    movement.Bodypart = bodyPart;
                }

                if (equipment != null)
                {
                    movement.Equipment = equipment;
                }

                if (difficulty != null)
                {
                    movement.DifficultyLevel = difficulty;
                }

                if (description != null)
                {
                    movement.Description = description;
                }

                context.SaveChanges();
                return "Success";
            }

            return "Movement not found";
        }

        public string UpdateMovement(Movement movement)
        {
            try
            {
                var original = context.TblMovements.Where(x => x.MovementId == movement.MovementId).FirstOrDefault();

                if (original != null)
                {
                    original = movement.ConvertToEntity();
                    context.SaveChanges();
                    return "Success";
                }

                return "Movement not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }
        //Delete
        public string DeleteMovement(int movementId)
        {
            try
            {
                context.TblMovements.Where(x => x.MovementId == movementId).ExecuteDelete();
                context.SaveChanges();
                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddMealFood(MealFood mealfood)
        {
            try
            {
                context.TblMealFoods.Add(mealfood.ConvertToEntity());
                context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public List<Meal>? GetUserMealsByDate(string userId, DateOnly date)
        {

            var meals = new List<Meal>();

            foreach (TblMealFood mealFood in context.TblMealFoods.Where(x => x.UserId == userId && x.Date == date).ToList())
            {
                var meal = context.TblMeals.Find(mealFood.MealId);

                if (meal != null)
                {
                    meals.Add(new Meal(meal));
                }
            }

            return meals;
        }
    }
}
