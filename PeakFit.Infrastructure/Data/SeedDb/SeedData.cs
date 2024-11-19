using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        //Users
        public ApplicationUser User { get; set; }
        public ApplicationUser Trainer { get; set; }
        public ApplicationUser Admin { get; set; }

        //Categories
        public Category Core { get; set; }
        public Category Arms { get; set; }
        public Category Back { get; set; }
        public Category Chest { get; set; }
        public Category Legs { get; set; }
        public Category Shoulders { get; set; }

        //ProgramExercises
        public ProgramExercise HackSquatProgram { get; set; }
        public ProgramExercise BulgarianSplitSquatProgram { get; set; }
        public ProgramExercise DeadliftProgram { get; set; }
        public ProgramExercise LegPressProgram { get; set; }
        //Exercises
        //Legs
        public Exercise HackSquat{ get; set; }
        public Exercise BulgarianSplitSquat { get; set; }
        public Exercise Deadlift { get; set; }
        public Exercise LegPress{ get; set; }
        public Exercise Squat { get; set; }
        public Exercise Lunge { get; set; }
        public Exercise CalfRaise { get; set; }
        //Arms
        public Exercise BicepCurl { get; set; }
        public Exercise TricepDip { get; set; }
        public Exercise HammerCurl { get; set; }
        public Exercise OverheadTricepExtension { get; set; }
        public Exercise ConcentrationCurl { get; set; }
        public Exercise CloseGripBenchPress { get; set; }
        //Core
        public Exercise Plank { get; set; }
        public Exercise Crunch { get; set; }
        public Exercise RussianTwist { get; set; }
        public Exercise MountainClimbers { get; set; }
        public Exercise LegRaises { get; set; }
        public Exercise SidePlank { get; set; }
        //Back
        public Exercise PullUp { get; set; }
        public Exercise LatPulldown { get; set; }
        public Exercise BarbellRow { get; set; }
        public Exercise TBarRow { get; set; }
        public Exercise SeatedCableRow { get; set; }
        //Chest
        public Exercise BenchPress { get; set; }
        public Exercise InclineBenchPress { get; set; }
        public Exercise ChestFly { get; set; }
        public Exercise PushUp { get; set; }
        public Exercise DumbbellPullover { get; set; }
        public Exercise CableCrossover { get; set; }
        //Shoulders
        public Exercise OverheadPress { get; set; }
        public Exercise ArnoldPress { get; set; }
        public Exercise LateralRaise { get; set; }
        public Exercise FrontRaise { get; set; }
        public Exercise FacePull { get; set; }
        public Exercise UprightRow { get; set; }

        //TrainingPrograms
        public TrainingProgram Program1 { get; set; }

        //Events
        public Event Event1 { get; set; }
        //Comments
        public Comment Comment1 { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCategories();
            SeedPrograms();
            SeedExercises();
            SeedProgramExercises();
            SeedEvents();
            SeedComments();
        }
        
        private void SeedUsers()
        {
            //Admin
            var hasher = new PasswordHasher<ApplicationUser>();
            
            Admin = new ApplicationUser()
            {
                Id = "e4fe197a-ffd1-45ec-ac7b-a203a82aa523",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                Gender = "Male",
                ProfilePicture = "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png"
            };

            Admin.PasswordHash =
            hasher.HashPassword(Admin, "Admin1234");
            //User
            User = new ApplicationUser()
            {
                Id = "3ca894f3-b3ef-493f-a694-8c3ef2b2c855",
                UserName = "user@gmail.com",
                NormalizedUserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com",
                FirstName = "User",
                LastName = "User",
                Gender = "Male",
                ProfilePicture = "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg"
            };

            User.PasswordHash =
            hasher.HashPassword(User, "User1234");

            //Trainer
            Trainer = new ApplicationUser()
            {
                Id = "59c4ebcd-35ca-4c88-aa6e-7a356eddc926",
                UserName = "trainer@gmail.com",
                NormalizedUserName = "trainer@gmail.com",
                Email = "trainer@gmail.com",
                NormalizedEmail = "trainer@gmail.com",
                FirstName = "Trainer",
                LastName = "Trainer",
                PhoneNumber= "0878080808",
                Gender = "Female",
                ProfilePicture = "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png"
            };

            Trainer.PasswordHash =
            hasher.HashPassword(Trainer, "Trainer1234");
        }

        private void SeedCategories()
        {
            Core = new Category
            {
                Id = 1,
                CategoryName = "Core"
            };
            Arms = new Category
            {
                Id = 2,
                CategoryName = "Arms"
            };
            Back = new Category
            {
                Id = 3,
                CategoryName = "Back"
            };
            Chest = new Category
            {
                Id = 4,
                CategoryName = "Chest"
            };
            Legs = new Category
            {
                Id = 5,
                CategoryName = "Legs"
            };
            Shoulders = new Category
            {
                Id = 6,
                CategoryName = "Shoulders"
            };
        }
        private void SeedPrograms()
        {
            Program1 = new TrainingProgram
            {
                Id = 1,
                UserId = Trainer.Id,
                CategoryId = Legs.Id,
                IsDeleted = false,
                ImageUrl = "https://athleanx.com/wp-content/uploads/2022/09/LEG-WORKOUTS.png",
                Ratings = new List<double> { 3, 3.5, 5 }
            };
        }
        private void SeedExercises()
        {
            //Legs
            Deadlift = new Exercise
            {
                Id = 1,
                ExerciseName = "Deadlift",
                CategoryId = Legs.Id
            };
            LegPress = new Exercise
            {
                Id = 2,
                ExerciseName = "LegPress",
                CategoryId = Legs.Id
            };
            HackSquat = new Exercise
            {
                Id = 3,
                ExerciseName = "HackSquat",
                CategoryId = Legs.Id
            };
            BulgarianSplitSquat = new Exercise
            {
                Id = 4,
                ExerciseName = "Bulgarian Split Squat",
                CategoryId = Legs.Id
            };
            Squat = new Exercise
            {
                Id = 5,
                ExerciseName = "Squat",
                CategoryId = Legs.Id
            };
            Lunge = new Exercise
            {
                Id = 6,
                ExerciseName = "Lunge",
                CategoryId = Legs.Id
            };
            CalfRaise = new Exercise
            {
                Id = 7,
                ExerciseName = "Calf Raise",
                CategoryId = Legs.Id
            };
            //Arms
            BicepCurl=new Exercise
            {
                Id = 8,
                ExerciseName = "Bicep Curl",
                CategoryId = Arms.Id
            };
            TricepDip= new Exercise
            {
                Id = 9,
                ExerciseName = "Tricep Dip",
                CategoryId = Arms.Id
            };
            HammerCurl = new Exercise
            {
                Id = 10,
                ExerciseName = "Hammer Curl",
                CategoryId = Arms.Id
            };
            OverheadTricepExtension = new Exercise
            {
                Id = 11,
                ExerciseName = "Overhead Tricep Extension",
                CategoryId = Arms.Id
            };
            ConcentrationCurl = new Exercise
            {
                Id = 12,
                ExerciseName = "Concentration Curl",
                CategoryId = Arms.Id
            };
            CloseGripBenchPress = new Exercise
            {
                Id = 13,
                ExerciseName = "Close Grip Bench Press",
                CategoryId = Arms.Id
            };
            //Core
            Plank = new Exercise
            {
                Id = 14,
                ExerciseName = "Plank",
                CategoryId = Core.Id
            };
            Crunch = new Exercise
            {
                Id = 15,
                ExerciseName = "Crunch",
                CategoryId = Core.Id
            };
            RussianTwist = new Exercise
            {
                Id = 16,
                ExerciseName = "Russian Twist",
                CategoryId = Core.Id
            };
            MountainClimbers = new Exercise
            {
                Id = 17,
                ExerciseName = "Mountain Climbers",
                CategoryId = Core.Id
            };
            LegRaises = new Exercise
            {
                Id = 18,
                ExerciseName = "Leg Raises",
                CategoryId = Core.Id
            };
            SidePlank = new Exercise
            {
                Id = 19,
                ExerciseName = "Side Plank",
                CategoryId = Core.Id
            };
            //Back
            PullUp = new Exercise
            {
                Id = 20,
                ExerciseName = "Pull Up",
                CategoryId = Back.Id
            };
            LatPulldown = new Exercise
            {
                Id = 21,
                ExerciseName = "Lat Pulldown",
                CategoryId = Back.Id
            };
            BarbellRow = new Exercise
            {
                Id = 22,
                ExerciseName = "Barbell Row",
                CategoryId = Back.Id
            };
            TBarRow = new Exercise
            {
                Id = 23,
                ExerciseName = "T-Bar Row",
                CategoryId = Back.Id
            };
            SeatedCableRow = new Exercise
            {
                Id = 24,
                ExerciseName = "Seated Cable Row",
                CategoryId = Back.Id
            };
            //Chest
            BenchPress = new Exercise
            {
                Id = 25,
                ExerciseName = "Bench Press",
                CategoryId = Chest.Id
            };
            InclineBenchPress = new Exercise
            {
                Id = 26,
                ExerciseName = "Incline Bench Press",
                CategoryId = Chest.Id
            };
            ChestFly = new Exercise
            {
                Id = 27,
                ExerciseName = "Chest Fly",
                CategoryId = Chest.Id
            };
            PushUp = new Exercise
            {
                Id = 28,
                ExerciseName = "Push Up",
                CategoryId = Chest.Id
            };
            DumbbellPullover = new Exercise
            {
                Id = 29,
                ExerciseName = "Dumbbell Pullover",
                CategoryId = Chest.Id
            };
            CableCrossover = new Exercise
            {
                Id = 30,
                ExerciseName = "Cable Crossover",
                CategoryId = Chest.Id
            };
            //Shoulders
            OverheadPress = new Exercise
            {
                Id = 31,
                ExerciseName = "Overhead Press",
                CategoryId = Shoulders.Id
            };
            ArnoldPress = new Exercise
            {
                Id = 32,
                ExerciseName = "Arnold Press",
                CategoryId = Shoulders.Id
            };
            LateralRaise = new Exercise
            {
                Id = 33,
                ExerciseName = "Lateral Raise",
                CategoryId = Shoulders.Id
            };
            FrontRaise = new Exercise
            {
                Id = 34,
                ExerciseName = "Front Raise",
                CategoryId = Shoulders.Id
            };
            FacePull = new Exercise
            {
                Id = 35,
                ExerciseName = "Face Pull",
                CategoryId = Shoulders.Id
            };
            UprightRow = new Exercise
            {
                Id = 36,
                ExerciseName = "Upright Row",
                CategoryId = Shoulders.Id
            };


        }
        private void SeedProgramExercises()
        {

            DeadliftProgram = new ProgramExercise
            {
                Id = 1,
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                ExerciseId = Deadlift.Id
            };
            LegPressProgram = new ProgramExercise
            {
                Id = 2,
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                ExerciseId= LegPress.Id
            };
            HackSquatProgram = new ProgramExercise
            {
                Id = 3,
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                ExerciseId = HackSquat.Id
            };
            BulgarianSplitSquatProgram = new ProgramExercise
            {
                Id = 4,
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                ExerciseId = BulgarianSplitSquat.Id
            };

        }


        private void SeedEvents()
        {
            Event1 = new Event
            {
                Id = 1,
                Title = "Marathon",
                Description = "The Marathon is an exhilarating long-distance running event, bringing together athletes, enthusiasts, and supporters for a memorable day of endurance and community spirit. Held in Plovdiv, this marathon offers participants a chance to challenge themselves across a scenic and well-marked route, catering to runners of all experience levels, from seasoned marathoners to those aiming to complete their first 42.195 kilometers.",
                StartDate = DateTime.Parse("25-12-2024"),
                StartHour = DateTime.Parse("10:00"),
                UserId = Trainer.Id,
                IsDeleted = false,
                ImageUrl = "https://raceid.com/organizer/wp-content/uploads/2022/08/cost-marathon-featured-image-blog-10.png"
            };
        }

        private void SeedComments()
        {
            Comment1 = new Comment
            {
                Id = 1,
                Title = "Big excitement",
                Description = "I can't wait untill the beginning of the event. It's going to be awesome!",
                PostedOn = DateTime.Parse("01-11-2024"),
                UserId = User.Id,
                EventId = Event1.Id,
                IsDeleted = false,
            };
        }

    }
}
