using OPSCAPI.Models.Database;

namespace OPSCAPI.Models
{
    public class User
    {
        public string UserId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public User(TblUser user)
        {
            UserId = user.UserId;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Password = user.Password;
        }

        public TblUser ConvertToEntity()
        {
            return new TblUser { UserId = UserId, Name = Name, Surname = Surname, Email = Email, Password = Password };
        }
    }

    public class UserInfo
    {
        public string UserId { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public double? WeightGoal { get; set; }

        public double CalorieWallet { get; set; }

        public double StepGoal { get; set; }

        public UserInfo(TblUserInfo userInfo)
        {
            UserId = userInfo.UserId;
            Height = userInfo.Height;
            Weight = userInfo.Weight;
            WeightGoal = userInfo.WeightGoal;
            CalorieWallet = userInfo.CalorieWallet;
            StepGoal = userInfo.StepGoal;
        }

        public TblUserInfo ConvertToEntity()
        {
            return new TblUserInfo { UserId = UserId, Height = Height, Weight = Weight, WeightGoal = WeightGoal, CalorieWallet = CalorieWallet, StepGoal = StepGoal };
        }
    }

    public class Ratios
    {
        public string UserId { get; set; } = null!;

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fibre { get; set; }

        public double Fat { get; set; }

        public Ratios(TblRatio ratio) 
        {
            UserId = ratio.UserId;
            Protein = ratio.Protein;
            Carbs = ratio.Carbs;
            Fat = ratio.Fat;
            Fibre = ratio.Fibre;
        }

        public TblRatio ConvertToEntity()
        {
            return new TblRatio { UserId = UserId, Protein = Protein, Carbs = Carbs, Fibre = Fibre, Fat = Fat };
        }
    }

    public class Day
    {
        public DateOnly Date { get; set; }

        public string UserId { get; set; } = null!;

        public int Steps { get; set; }

        public double Calories { get; set; }

        public double? Weight { get; set; }

        public int ActiveTime { get; set; }

        public double Water { get; set; }

        public Day(TblDay day)
        {
            Date = day.Date;
            UserId = day.UserId;
            Steps = day.Steps;
            Calories = day.Calories;
            Weight = day.Weight;
            ActiveTime = day.ActiveTime;
            Water = day.Water;
        }

        public TblDay ConvertToEntity()
        {
            return new TblDay { Date = Date, UserId = UserId, Steps = Steps, Calories = Calories, Weight = Weight, ActiveTime = ActiveTime };
        }
    }

    /*public class Steps
    {
        public string UserId { get; set; } = null!;

        public DateOnly Date { get; set; }

        public int Amount { get; set; }

        public TblStep ConvertToEntity()
        {
            return new TblStep { UserId = UserId, Date = Date, Amount = Amount };
        }
    }*/

    public class Workout
    {
        public string WorkoutId { get; set; } = null!;

        public DateOnly Date { get; set; }

        public string UserId { get; set; } = null!;

        public Workout(TblWorkout workout)
        {
            WorkoutId = workout.WorkoutId;
            Date = workout.Date;
            UserId = workout.UserId;
        }

        public TblWorkout ConvertToEntity()
        {
            return new TblWorkout { Date = Date, UserId = UserId, WorkoutId = WorkoutId };
        }
    }

    public class Exercise
    {
        public string ExerciseId { get; set; } = null!;

        public string WorkoutId { get; set; } = null!;

        public int MovementId { get; set; } = 0;

        public Exercise(TblExercise exercise)
        {
            ExerciseId = exercise.ExerciseId;
            WorkoutId = exercise.WorkoutId;
            MovementId = exercise.MovementId;
        }

        public TblExercise ConvertToEntity()
        {
            return new TblExercise { ExerciseId = ExerciseId, WorkoutId = WorkoutId, MovementId = MovementId };
        }
    }

    public class Cardio
    {
        public string ExerciseId { get; set; } = null!;

        public int Time { get; set; }

        public double Distance { get; set; }

        public Cardio(TblCardioExercise cardio)
        {
            ExerciseId = cardio.ExerciseId;
            Time = cardio.Time;
            Distance = cardio.Distance;
        }

        public TblCardioExercise ConvertToEntity()
        {
            return new TblCardioExercise { ExerciseId = ExerciseId, Time = Time, Distance = Distance };
        }
    }

    public class Strength
    {
        public string ExerciseId { get; set; } = null!;

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public bool Favourite { get; set; }

        public Strength(TblStrengthExercise strength)
        {
            ExerciseId = strength.ExerciseId;
            Sets = strength.Sets;
            Repetitions = strength.Repetitions;
            Favourite = strength.Favourite;
        }

        public TblStrengthExercise ConvertToEntity()
        {
            return new TblStrengthExercise { ExerciseId = ExerciseId, Sets = Sets, Repetitions = Repetitions, Favourite = Favourite };
        }
    }

    public class Meal
    {
        public string MealId { get; set; } = null!;

        public DateOnly? Date { get; set; }

        public string? UserId { get; set; }

        public string Name { get; set; } = null!;

        public Meal(TblMeal meal)
        {
            MealId = meal.MealId;
            Date = meal.Date;
            UserId = meal.UserId;
            Name = meal.Name;
        }

        public TblMeal ConvertToEntity()
        {
            return new TblMeal { MealId = MealId, Date = Date, UserId = UserId, Name = Name };
        }
    }

    public class Food
    {
        public int FoodId { get; set; }

        public string? MealId { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public double? Weight { get; set; }

        public int Calories { get; set; }

        public double? Protein { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Fibre { get; set; }

        public double? Fat { get; set; }

        public double? Cholestrol { get; set; }

        public double? Sugar { get; set; }

        public double? SaturatedFat { get; set; }

        public double? VitaminB12 { get; set; }

        public double? VitaminB6 { get; set; }

        public double? VitaminK { get; set; }

        public double? VitaminE { get; set; }

        public double? VitaminC { get; set; }

        public double? VitaminA { get; set; }

        public double? Zinc { get; set; }

        public double? Magnesium { get; set; }

        public double? Sodium { get; set; }

        public double? Potassium { get; set; }

        public double? Iron { get; set; }

        public double? Calcium { get; set; }

        public Food(TblFood food)
        {
            FoodId = food.FoodId;
            MealId = food.MealId;
            Category = food.Category;
            Description = food.Description;
            Weight = food.Weight;
            Calories = food.Calories;
            Protein = food.Protein;
            Carbohydrates = food.Carbohydrates;
            Fibre = food.Fibre;
            Fat = food.Fat;
            Cholestrol = food.Cholestrol;
            Sugar = food.Sugar;
            SaturatedFat = food.SaturatedFat;
            VitaminA = food.VitaminA;
            VitaminB12 = food.VitaminB12;
            VitaminB6 = food.VitaminB6;
            VitaminC = food.VitaminC;
            VitaminE = food.VitaminE;
            VitaminK = food.VitaminK;
            Zinc = food.Zinc;
            Magnesium = food.Magnesium;
            Sodium = food.Sodium;
            Potassium = food.Potassium;
            Iron = food.Iron;
            Calcium = food.Calcium;
        }

        public TblFood ConvertToEntity()
        {
            return new TblFood { FoodId = FoodId, MealId = MealId, Category = Category, Description = Description, Calcium = Calcium, Calories = Calories, Carbohydrates = Carbohydrates, Cholestrol = Cholestrol, Fat = Fat, Fibre = Fibre, Iron = Iron, Magnesium = Magnesium, Potassium = Potassium, Protein = Protein, SaturatedFat = SaturatedFat, Sodium = Sodium, Sugar = Sugar, VitaminA = VitaminA, VitaminB12 = VitaminB12, VitaminB6 = VitaminB6, VitaminC = VitaminC, VitaminE = VitaminE, VitaminK = VitaminK, Weight = Weight, Zinc = Zinc };

        }
    }

    public class MealFood
    {
        public string MealId { get; set; } = null!;

        public int FoodId { get; set; }

        public MealFood(TblMealFood mealFood)
        {
            MealId = mealFood.MealId;
            FoodId = mealFood.FoodId;
        }

        public TblMealFood ConvertToEntity()
        {
            return new TblMealFood { MealId = MealId, FoodId = FoodId };
        }
    }

    public class Movement
    {
        public int MovementId { get; set; } = 0;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Type { get; set; } = null!;

        public string Bodypart { get; set; } = null!;

        public string Equipment { get; set; } = null!;

        public string DifficultyLevel { get; set; } = null!;

        public Movement(TblMovement movement) 
        {
            MovementId = movement.MovementId;
            Name = movement.Name;
            Description = movement.Description;
            Type = movement.Type;
            Bodypart = movement.Bodypart;
            Equipment = movement.Equipment;
            DifficultyLevel = movement.DifficultyLevel;
        }

        public TblMovement ConvertToEntity()
        {
            return new TblMovement { MovementId = MovementId, Description = Description, Name = Name, Type = Type, Bodypart = Bodypart, Equipment = Equipment, DifficultyLevel = DifficultyLevel};
        }
    }
}
