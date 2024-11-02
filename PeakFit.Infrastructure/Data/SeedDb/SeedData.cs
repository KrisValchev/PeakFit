using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PeakFit.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeakFit.Core.Constants.RoleConstants;

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

        //Exercises
        public Exercise HackSquat { get; set; }
        public Exercise BulgarianSplitSquat { get; set; }
        public Exercise Deadlift { get; set; }
        public Exercise LegPress { get; set; }

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
            SeedExercises();
            SeedPrograms();
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
                Role = AdminRole,
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
                Role = UserRole,
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
                Gender = "Female",
                Role = TrainerRole,
                ProfilePicture = "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png"
            };

            Trainer.PasswordHash =
            hasher.HashPassword(Trainer, "User1234");
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

        private void SeedExercises()
        {

            Deadlift = new Exercise
            {
                Id = 1,
                ExerciseName = "Deadlift",
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                CategoryId = Legs.Id
            };
            LegPress = new Exercise
            {
                Id = 2,
                ExerciseName = "Leg Press",
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                CategoryId = Legs.Id
            };
            HackSquat = new Exercise
            {
                Id = 3,
                ExerciseName = "Hack Squat",
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                CategoryId = Legs.Id
            };
            BulgarianSplitSquat = new Exercise
            {
                Id = 4,
                ExerciseName = "Bulgarian Split Squat",
                Reps = 10,
                Sets = 3,
                ProgramId = Program1.Id,
                CategoryId = Legs.Id
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

        private void SeedEvents()
        {
            Event1 = new Event
            {
                Id = 1,
                Title = "Marathon",
                Description = "The Marathon is an exhilarating long-distance running event, bringing together athletes, enthusiasts, and supporters for a memorable day of endurance and community spirit. Held in Plovdiv, this marathon offers participants a chance to challenge themselves across a scenic and well-marked route, catering to runners of all experience levels, from seasoned marathoners to those aiming to complete their first 42.195 kilometers.",
                StartDate = DateTime.Parse("10-11-2024"),
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
