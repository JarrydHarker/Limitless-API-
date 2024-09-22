using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace OPSCAPI.Models
{
    public class DBManager
    {
        LimitlessDbContext context = new LimitlessDbContext();

        //User
        //Create
        public string AddUser(TblUser user)
        {
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

        public string AddUser(string userID, string name, string surname, string email, string password, float? weightGoal = null, float? calorieWallet = null, int stepGoal = 0)
        {
            TblUser user = new TblUser
            {
                UserId = userID,
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                WeightGoal = weightGoal,
                CalorieWallet = calorieWallet,
                StepGoal = stepGoal,
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
        public List<TblUser>? GetAllUsers()
        {
            return context.TblUsers.ToList();
        }

        public TblUser? GetUser(string userID)
        {
            return context.TblUsers.Find(userID);
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

                if (weightGoal != null)
                {
                    user.WeightGoal = weightGoal;
                }

                if (calorieWallet != null)
                {
                    user.CalorieWallet = calorieWallet;
                }

                if (stepGoal != null)
                {
                    user.StepGoal = (int)stepGoal;
                }

                context.SaveChanges();
                return "Success";

            }

            return "User not found";
        }

        public string UpdateUser(TblUser user)
        {
            try
            {
                var original = context.TblUsers.Where(x => x.UserId == user.UserId).FirstOrDefault();

                if (original != null)
                {
                    original = user;
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

        //Day
        //Create
        public string AddDay(TblDay day)
        {
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
        public List<TblDay>? GetAllDays()
        {
            return context.TblDays.ToList();
        }

        public TblDay? GetDay(DateOnly date, string userID)
        {
            return context.TblDays.Find(userID, date);
        }

        public List<TblDay>? GetDaysByUID(string userId)
        {
            return context.TblDays.Where(x => x.UserId == userId).ToList();
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

        public string UpdateDay(TblDay day)
        {
            try
            {
                var original = context.TblDays.Where(x => x.UserId == day.UserId && x.Date == day.Date).FirstOrDefault();

                if (original != null)
                {
                    original = day;
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
        public string AddWorkout(TblWorkout workout)
        {
            try
            {
                context.TblWorkouts.Add(workout);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddWorkout(string workoutID, DateOnly date, string userID)
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
        public List<TblWorkout>? GetAllWorkouts()
        {
            return context.TblWorkouts.ToList();
        }

        public List<TblWorkout>? GetWorkoutsByDate(DateOnly date)
        {
            return context.TblWorkouts.Where(x => x.Date == date).ToList();
        }

        public List<TblWorkout>? GetWorkoutsByUID(string userId)
        {
            return context.TblWorkouts.Where(x => x.UserId == userId).ToList();
        }

        public TblWorkout? GetWorkout(string workoutID)
        {
            return context.TblWorkouts.Find(workoutID);
        }

        //Update
        public string UpdateWorkout(string workoutID, DateOnly? date = null, string? userID = null)
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

        public string

        //Delete
        public string DeleteWorkout(string workoutID)
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

        //Exercise
        //Create
        public string AddExercise(TblExercise exercise)
        {
            try
            {
                context.TblExercises.Add(exercise);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddExercise(string exerciseID, string workoutID, string movementID, int sets, int reps, bool favourite)
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

        public string AddExercise(string exerciseID, string workoutID, string movementID, int time, float distance)
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

        public string AddCardio(TblCardioExercise cardio)
        {
            try
            {
                context.TblCardioExercises.Add(cardio);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddCardio(string exerciseID, int time, float distance)
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

        public string AddStrength(TblStrengthExercise strength)
        {
            try
            {
                context.TblStrengthExercises.Add(strength);
                context.SaveChanges();

                return "Success";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        public string AddStrength(string exerciseID, int sets, int reps, bool favourite)
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
        public List<TblExercise>? GetAllExercises()
        {
            return context.TblExercises.ToList();
        }

        public List<TblCardioExercise>? GetAllCardio()
        {
            return context.TblCardioExercises.ToList();
        }

        public List<TblStrengthExercise>? GetAllStrength()
        {
            return context.TblStrengthExercises.ToList();
        }

        public List<TblExercise>? GetExercisesByWorkoutId(string workoutId)
        {
            return context.TblExercises.Where(x => x.WorkoutId == workoutId).ToList();
        }

        public List<TblExercise>? GetExercisesByMovementId(string movementId)
        {
            return context.TblExercises.Where(x => x.MovementId == movementId).ToList();
        }

        public TblExercise? GetExercise(string exerciseID)
        {
            return context.TblExercises.Find(exerciseID);
        }

        public TblStrengthExercise? GetStrength(string exerciseID)
        {
            return context.TblStrengthExercises.Find(exerciseID);
        }

        public TblCardioExercise? GetCardio(string exerciseID)
        {
            return context.TblCardioExercises.Find(exerciseID);
        }

        //Update
        public string UpdateExercise(string exerciseID, string? workoutID = null, string? movementID = null)
        {
            var exercise = context.TblExercises.Find(exerciseID);

            if (exercise != null)
            {
                if (workoutID != null)
                {
                    exercise.WorkoutId = workoutID;
                }

                if (movementID != null)
                {
                    exercise.MovementId = movementID;
                }

                return "Success";
            } else return "Exercise not found";
        }

        public string UpdateCardio(string exerciseID, int? time = null, float? distance = null)
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

        public string UpdateStrength(string exerciseID, int? sets = null, int? reps = null, bool? favourite = null)
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

        //Delete
        public string DeleteExercise(string exerciseID)
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

        public string DeleteStrength(string exerciseID)
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
                return "Strength Exercise not found";

            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
            
        }

        public string DeleteCardio(string exerciseID)
        {
            try
            {
                var cardio = context.TblCardioExercises.Find(exerciseID);

                if (cardio != null)
                {
                    context.TblCardioExercises.Where(x => x.ExerciseId == exerciseID).ExecuteDelete();
                    context.SaveChanges();
                }
                return "Strength Exercise not found";
            } catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        //Food
        //Create
        public string AddFood(TblFood food)
        {
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

        public string AddFood(string foodId, string category, string description, int calories, string? mealID = null, float? weight = null, float? protein = null, float? carbs = null, float? fibre = null, float? fat = null, float? cholestrol = null, float? sugar = null, float? satFat = null, float? vitB12 = null, float? vitB6 = null, float? vitK = null, float? vitE = null, float? vitC = null, float? vitA = null, float? zinc = null, float? magnesium = null, float? sodium = null, float? potassium = null, float? iron = null, float? calcium = null)
        {
            TblFood food = new TblFood
            {
                FoodId = foodId,
                Category = category,
                Description = description,
                Calories = calories,
            };

            food.MealId = mealID != null ? mealID : null;
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
        public List<TblFood>? GetAllFoods()
        {
            return context.TblFoods.ToList();
        }

        public TblFood? GetFood(string foodId)
        {
            return context.TblFoods.Find(foodId);
        }

        public List<TblFood>? GetFoodsByMealId(string mealId)
        {
            return context.TblFoods.Where(x => x.MealId == mealId).ToList();
        }

        //Update
        public string UpdateFood(string foodId, string? category = null, string? description = null, int? calories = null, string? mealID = null, float? weight = null, float? protein = null, float? carbs = null, float? fibre = null, float? fat = null, float? cholestrol = null, float? sugar = null, float? satFat = null, float? vitB12 = null, float? vitB6 = null, float? vitK = null, float? vitE = null, float? vitC = null, float? vitA = null, float? zinc = null, float? magnesium = null, float? sodium = null, float? potassium = null, float? iron = null, float? calcium = null)
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

        //Delete
        public string DeleteFood(string foodId)
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
        public string AddMeal(TblMeal meal)
        {
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

        public string AddMeal(string mealId, string name, DateOnly? date = null, string? userId = null)
        {
            TblMeal meal = new TblMeal
            {
                MealId = mealId,
                Name = name,
            };

            meal.Date = date != null ? date : null;
            meal.UserId = userId != null ? userId : null;


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
        public List<TblMeal>? GetAllMeals()
        {
            return context.TblMeals.ToList();
        }

        public TblMeal? GetMeal(string mealId)
        {
            return context.TblMeals.Find(mealId);
        }

        public List<TblMeal>? GetMealsByUID(string userId)
        {
            return context.TblMeals.Where(x => x.UserId == userId).ToList();
        }

        //Update
        public string UpdateMeal(string mealId, string? name = null, DateOnly? date = null, string? userId = null)
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

        //Delete
        public string DeleteMeal(string mealId)
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
        public string AddMovement(TblMovement movement)
        {
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

        public string AddMovement(string movementId, string name, string type, string bodyPart, string equipment, string difficulty, string? description = null, float? max = null)
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
            movement.Max = max != null ? max : null;

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
        public List<TblMovement>? GetAllMovements()
        {
            return context.TblMovements.ToList();
        }

        public TblMovement? GetMovement(string movementId)
        {
            return context.TblMovements.Find(movementId);
        }

        //Update
        public string UpdateMovement(string movementId, string? name = null, string? type = null, string? bodyPart = null, string? equipment = null, string? difficulty = null, string? description = null, float? max = null)
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

                if (max != null)
                {
                    movement.Max = max;
                }

                context.SaveChanges();
                return "Success";
            }

            return "Movement not found";
        }

        //Delete
        public string DeleteMovement(string movementId)
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
    }
}
