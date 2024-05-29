using Microsoft.EntityFrameworkCore;
using StajyerTakipSistemi.Web.Models;
using System.Linq;
using Xunit;

namespace StajyerTakipSistemi.Tests
{
    public class StajyerTakipSistemiDbContextTests
    {
        

        [Fact]
        public void Test_Application_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {

                var application = new SApplication
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    BirthDate = new DateTime(1990, 1, 1),
                    Address = "123 Main St, City, Country",
                    DesiredField = "Software Development",
                    Explanation = "I am passionate about programming and eager to learn.",
                    ApprovalStatus = "Pending", 
                    Cv = "cv_file_path.pdf", 
                    ApplicationDate = DateTime.Now
                };

                context.SApplications.Add(application);
                context.SaveChanges();

                var retrievedApplication = context.SApplications.FirstOrDefault(a => a.Id == application.Id);
                Assert.NotNull(retrievedApplication);

                context.SApplications.Remove(retrievedApplication);
                context.SaveChanges();
                Assert.Null(context.SApplications.FirstOrDefault(a => a.Id == application.Id));
            }
        }

        

        [Fact]
        public void Test_AssignedTask_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };

                var taskDetail = new STaskDetail
                {
                    Contents = "Write a report about the latest project meeting.",
                    Subject = "Project Meeting Report"
                };

                context.SInterns.Add(intern);
                context.STaskDetails.Add(taskDetail);
                context.SaveChanges();

                var assignedTask = new SAssignedTask
                {
                    InternId = intern.Id,
                    TaskId = taskDetail.Id,
                    AssignmentDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                };

                context.SAssignedTasks.Add(assignedTask);
                context.SaveChanges();

                var retrievedAssignedTask = context.SAssignedTasks.FirstOrDefault(a => a.Id == assignedTask.Id);
                var testIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                var testTask = context.STaskDetails.FirstOrDefault(a => a.Id == taskDetail.Id);
                Assert.NotNull(retrievedAssignedTask);

                context.SAssignedTasks.Remove(retrievedAssignedTask);
                context.SaveChanges();
                Assert.Null(context.SAssignedTasks.FirstOrDefault(a => a.Id == assignedTask.Id));

                // Intern nesnesini kaldır
                context.SInterns.Remove(testIntern);
                context.SaveChanges();
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));

                // TaskDetail nesnesini kaldır
                context.STaskDetails.Remove(testTask);
                context.SaveChanges();
                Assert.Null(context.STaskDetails.FirstOrDefault(a => a.Id == taskDetail.Id));
            }
        }


        [Fact]
        public void Test_DailyReport_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                context.SInterns.Add(intern);
                context.SaveChanges();

                var dailyReport = new SDailyReport
                {
                    InternId = intern.Id,
                    FileName = "example.pdf",
                    ContentType = "application/pdf",
                    Data = new byte[] { 0x12, 0x34, 0x56, 0x78 },
                    UnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    internGuid = Guid.NewGuid(),
                    FilePath = "C:\\example\\example.pdf"
                };
                context.SDailyReports.Add(dailyReport);
                context.SaveChanges();

                var retrievedDailyReport = context.SDailyReports.FirstOrDefault(a => a.Id == dailyReport.Id);
                var testIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                Assert.NotNull(retrievedDailyReport);

                context.SDailyReports.Remove(retrievedDailyReport);
                context.SInterns.Remove(testIntern);
                context.SaveChanges();
                Assert.Null(context.SDailyReports.FirstOrDefault(a => a.Id == dailyReport.Id));
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));
            }
        }



        [Fact]
        public void Test_Intern_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                context.SInterns.Add(intern);
                context.SaveChanges();
                 
                var retrievedIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                Assert.NotNull(retrievedIntern); 
                 
                context.SInterns.Remove(retrievedIntern);
                context.SaveChanges();
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));
            }
        }

        [Fact]
        public void Test_InternToManager_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                var manager = new SManager
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    Username = "johndoe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };

                context.SInterns.Add(intern);
                context.SManagers.Add(manager);
                context.SaveChanges();
                var internToManager = new SInternToManager
                {
                    InternId = intern.Id,
                    ManagerId = manager.Id
                };

                context.SInternToManagers.Add(internToManager);
                context.SaveChanges();

                var retrievedInternToManager = context.SInternToManagers.FirstOrDefault(a => a.Id == internToManager.Id);
                var testIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                var testManager = context.SManagers.FirstOrDefault(a => a.Id == manager.Id);
                Assert.NotNull(retrievedInternToManager);


                context.SInternToManagers.Remove(retrievedInternToManager);
                context.SaveChanges();
                Assert.Null(context.SInternToManagers.FirstOrDefault(a => a.Id == internToManager.Id));

                context.SInterns.Remove(testIntern);
                context.SManagers.Remove(testManager);
                context.SaveChanges();
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));
                Assert.Null(context.SManagers.FirstOrDefault(a => a.Id == manager.Id));
            }
        }


        [Fact]
        public void Test_Manager_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var manager = new SManager
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    Username = "johndoe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                context.SManagers.Add(manager);
                context.SaveChanges();

                // Read
                var retrievedManager = context.SManagers.FirstOrDefault(a => a.Id == manager.Id);
                Assert.NotNull(retrievedManager);

                 
                context.SManagers.Remove(retrievedManager);
                context.SaveChanges();
                Assert.Null(context.SManagers.FirstOrDefault(a => a.Id == manager.Id));
            }
        }

        //[Fact]
        //public void Test_Messagesforintern_Crud_Operations()
        //{
        //    var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
        //        .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
        //        .Options;

        //    using (var context = new StajyerTakipSistemiDbContext(options))
        //    { 
        //        var messagesForIntern = new SMessagesforintern
        //        {
                    
        //        };
        //        context.SMessagesforinterns.Add(messagesForIntern);
        //        context.SaveChanges();
                 
        //        var retrievedMessagesForIntern = context.SMessagesforinterns.FirstOrDefault(a => a.Id == messagesForIntern.Id);
        //        Assert.NotNull(retrievedMessagesForIntern);

                 
        //        context.SMessagesforinterns.Remove(retrievedMessagesForIntern);
        //        context.SaveChanges();
        //        Assert.Null(context.SMessagesforinterns.FirstOrDefault(a => a.Id == messagesForIntern.Id));
        //    }
        //}

        //[Fact]
        //public void Test_Messagesformanager_Crud_Operations()
        //{
        //    var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
        //        .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
        //        .Options;

        //    using (var context = new StajyerTakipSistemiDbContext(options))
        //    { 
        //        var messageForManager = new SMessagesformanager
        //        { 
        //        };
        //        context.SMessagesformanagers.Add(messageForManager);
        //        context.SaveChanges();
                 
        //        var retrievedMessageForManager = context.SMessagesformanagers.FirstOrDefault(a => a.Id == messageForManager.Id);
        //        Assert.NotNull(retrievedMessageForManager);

                 
        //        context.SMessagesformanagers.Remove(retrievedMessageForManager);
        //        context.SaveChanges();
        //        Assert.Null(context.SMessagesformanagers.FirstOrDefault(a => a.Id == messageForManager.Id));
        //    }
        //}

        [Fact]
        public void Test_TaskDetail_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {

                var taskDetail = new STaskDetail
                {
                    Contents = "Write a report about the latest project meeting.",
                    Subject = "Project Meeting Report"
                };
                context.STaskDetails.Add(taskDetail);
                context.SaveChanges();
                 
                var retrievedTaskDetail = context.STaskDetails.FirstOrDefault(a => a.Id == taskDetail.Id);
                Assert.NotNull(retrievedTaskDetail);

               
                context.STaskDetails.Remove(retrievedTaskDetail);
                context.SaveChanges();
                Assert.Null(context.STaskDetails.FirstOrDefault(a => a.Id == taskDetail.Id));
            }
        }
        [Fact]
        public void Test_NewMessages_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            { 
                var newMessage = new NewMessages
                { 
                };
                context.NewMessages.Add(newMessage);
                context.SaveChanges();
                 
                var retrievedNewMessage = context.NewMessages.FirstOrDefault(a => a.Id == newMessage.Id);
                Assert.NotNull(retrievedNewMessage);
                 
                context.NewMessages.Remove(retrievedNewMessage);
                context.SaveChanges();
                Assert.Null(context.NewMessages.FirstOrDefault(a => a.Id == newMessage.Id));
            }
        }

        [Fact]
        public void Test_Message_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            { 
                var message = new Message
                { 
                };
                context.Messages.Add(message);
                context.SaveChanges();
                 
                var retrievedMessage = context.Messages.FirstOrDefault(a => a.MessageId == message.MessageId);
                Assert.NotNull(retrievedMessage);

                 
                context.Messages.Remove(retrievedMessage);
                context.SaveChanges();
                Assert.Null(context.Messages.FirstOrDefault(a => a.MessageId == message.MessageId));
            }
        }

        [Fact]
        public void Test_Admin_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                 
                var admin = new Sadmin
                {
                    Username = "admin",
                    Password = "password",
                    Guid = Guid.NewGuid(),
                    Email = "admin@example.com"
                };
                context.admin.Add(admin);
                context.SaveChanges();

                 
                var retrievedAdmin = context.admin.FirstOrDefault(a => a.Id == admin.Id);
                Assert.NotNull(retrievedAdmin);

                 
                context.admin.Remove(retrievedAdmin);
                context.SaveChanges();
                Assert.Null(context.admin.FirstOrDefault(a => a.Id == admin.Id));
            }
        }


        [Fact]
        public void Test_Final_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                context.SInterns.Add(intern);
                context.SaveChanges();

                var final = new SFinal
                {
                    InternId = intern.Id,
                    RelatedDocuments = "related_documents.pdf",
                    GitHubLink = "https://github.com/stajyer",
                    YouTubeLink = "https://www.youtube.com/stajyer",
                    EvaluationStatus = true,
                    SubmitDate = DateTime.Now
                };

                context.SFinal.Add(final);
                context.SaveChanges();

                var retrievedFinal = context.SFinal.FirstOrDefault(a => a.Id == final.Id);
                var testIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                Assert.NotNull(retrievedFinal);

                context.SFinal.Remove(retrievedFinal);
                context.SInterns.Remove(testIntern);
                context.SaveChanges();
                Assert.Null(context.SFinal.FirstOrDefault(a => a.Id == final.Id));
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));
            }
        }


        [Fact]
        public void Test_AbsenceInformation_Crud_Operations()
        {
            var options = new DbContextOptionsBuilder<StajyerTakipSistemiDbContext>()
                .UseSqlServer("Data Source=DESKTOP-SMOAMK0\\SQLEXPRESS;Initial Catalog=StajyerTakipSistemi;Integrated Security=True;TrustServerCertificate=true")
                .Options;

            using (var context = new StajyerTakipSistemiDbContext(options))
            {
                var intern = new SIntern
                {
                    FirstName = "Johnn",
                    LastName = "Dodde",
                    Email = "john.doe@example.com",
                    BirthDate = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(90),
                    Username = "johnn_doe",
                    Password = "password123",
                    Guid = Guid.NewGuid()
                };
                context.SInterns.Add(intern);
                context.SaveChanges();

                var absenceInfo = new SAbsenceInformation
                {
                    InternId = intern.Id,
                    AbsenceDate = new DateTime(2024, 4, 25)
                };

                context.SAbsenceInformations.Add(absenceInfo);
                context.SaveChanges();

                var retrievedAbsenceInfo = context.SAbsenceInformations.FirstOrDefault(a => a.Id == absenceInfo.Id);
                var testIntern = context.SInterns.FirstOrDefault(a => a.Id == intern.Id);
                Assert.NotNull(retrievedAbsenceInfo);

                context.SAbsenceInformations.Remove(retrievedAbsenceInfo);
                context.SInterns.Remove(testIntern);
                context.SaveChanges();
                Assert.Null(context.SAbsenceInformations.FirstOrDefault(a => a.Id == absenceInfo.Id));
                Assert.Null(context.SInterns.FirstOrDefault(a => a.Id == intern.Id));
            }
        }

    }
}