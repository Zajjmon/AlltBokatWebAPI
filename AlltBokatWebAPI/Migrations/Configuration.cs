namespace AlltBokatWebAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AlltBokatWebAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(AlltBokatWebAPI.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                AddUser1(context);
                AddUser2(context);
                AddUser3(context);
                AddUser4(context);

            }

            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        public void AddUser1(AlltBokatWebAPI.Models.ApplicationDbContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "zajjmon@gmail.com", UserName = "Zajjmon01", FirstName = "Simon", LastName = "Lindquist" };
            um.Create(user, "!123Damp");
            var bookingTimeSlot1 = new BookingTimeSlotModels
            {
                
                startTime = new DateTime(2017, 3, 22, 10, 0, 0),
                endTime = new DateTime(2017, 3, 22, 11, 0, 0)
            };
            var bookingTimeSlot2 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 23, 8, 0, 0),
                endTime = new DateTime(2017, 3, 23, 9, 0, 0)
            };
            context.BookingTimeSlots.Add(bookingTimeSlot1);
            context.BookingTimeSlots.Add(bookingTimeSlot2);
            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot1,
                BookingTimeSlotModelsId = bookingTimeSlot1.Id,
                CustomerEmail = "testmail1@test.com",
                CustomerName = "testcustomer1",
                description = "Simons first test booking."
            });

            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot2,
                BookingTimeSlotModelsId = bookingTimeSlot2.Id,
                CustomerEmail = "testmail2@test.com",
                CustomerName = "testcustomer2",
                description = "Simons second test booking."
            });
        }
        // user 2's grejor
        public void AddUser2(AlltBokatWebAPI.Models.ApplicationDbContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "johanz@gmail.com", UserName = "Johanz96", FirstName = "Johan", LastName = "Persson" };
            um.Create(user, "!123Damp");
            var bookingTimeSlot1 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 24, 15, 0, 0),
                endTime = new DateTime(2017, 3, 24, 16, 0, 0)
            };
            var bookingTimeSlot2 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 23, 14, 0, 0),
                endTime = new DateTime(2017, 3, 23, 15, 0, 0)
            };
            context.BookingTimeSlots.Add(bookingTimeSlot1);
            context.BookingTimeSlots.Add(bookingTimeSlot2);
            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot1,
                BookingTimeSlotModelsId = bookingTimeSlot1.Id,
                CustomerEmail = "testmail1@test.com",
                CustomerName = "testcustomer1",
                description = "testcust1's test booking."
            });

            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot2,
                BookingTimeSlotModelsId = bookingTimeSlot2.Id,
                CustomerEmail = "testmail2@test.com",
                CustomerName = "testcustomer2",
                description = "Johans  second test booking."
            });
        }
        // user 3's gunk
        public void AddUser3(AlltBokatWebAPI.Models.ApplicationDbContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "davidnyq@gmail.com", UserName = "Dejvid1337", FirstName = "David", LastName = "Nyquist" };
            um.Create(user, "!123Damp");
            var bookingTimeSlot1 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 24, 13, 0, 0),
                endTime = new DateTime(2017, 3, 24, 14, 0, 0)
            };
            var bookingTimeSlot2 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 23, 10, 0, 0),
                endTime = new DateTime(2017, 3, 23, 11, 0, 0)
            };
            context.BookingTimeSlots.Add(bookingTimeSlot1);
            context.BookingTimeSlots.Add(bookingTimeSlot2);
            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot1,
                BookingTimeSlotModelsId = bookingTimeSlot1.Id,
                CustomerEmail = "testmail1@test.com",
                CustomerName = "testcustomer1",
                description = "testcust1's first booking on David."
            });

            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot2,
                BookingTimeSlotModelsId = bookingTimeSlot2.Id,
                CustomerEmail = "testmail2@test.com",
                CustomerName = "Testmaster2000",
                description = "Davids  second test booking."
            });
        }
        // user 4's grejor
        public void AddUser4(AlltBokatWebAPI.Models.ApplicationDbContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "Dundermannen@gmail.com", UserName = "Dunder91", FirstName = "Dunder", LastName = "Mannen" };
            um.Create(user, "!123Damp");
            var bookingTimeSlot1 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 28, 11, 0, 0),
                endTime = new DateTime(2017, 3, 24, 12, 0, 0)
            };
            var bookingTimeSlot2 = new BookingTimeSlotModels
            {

                startTime = new DateTime(2017, 3, 26, 12, 0, 0),
                endTime = new DateTime(2017, 3, 23, 13, 0, 0)
            };
            context.BookingTimeSlots.Add(bookingTimeSlot1);
            context.BookingTimeSlots.Add(bookingTimeSlot2);
            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot1,
                BookingTimeSlotModelsId = bookingTimeSlot1.Id,
                CustomerEmail = "testmail1@test.com",
                CustomerName = "testcustomer1",
                description = "unders test booking."
            });

            context.Bookings.Add(new BookingModels
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                BookingTimeSlotModels = bookingTimeSlot2,
                BookingTimeSlotModelsId = bookingTimeSlot2.Id,
                CustomerEmail = "testmail2@test.com",
                CustomerName = "testcustomer2",
                description = "Dunders egna stund med kund."
            });
        }

    }
}
