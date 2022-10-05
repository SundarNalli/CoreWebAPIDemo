using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreWebAPIDemo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWebAPIDemo.Data;
using CoreWebAPIDemo.Model;

namespace CoreWebAPIDemo.Controllers.Tests
{
    [TestClass()]
    public class MyTaskControllerTests
    {
        private readonly IMyTaskContextRepo context;
        private readonly MyTaskController controller;
        private BL.Validators validator;

        public MyTaskControllerTests()
        {
            context = new FakeMyTaskContextRepo();
            controller = new MyTaskController(context);
        }

        [TestMethod]
        public void GetTasks_Success()
        {
            var task = controller.GetTasksAsync();
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void POSTTasks_Success()
        {
            MyTask task = new MyTask()
            {
                Id = 1,
                Name = "Dummy Task",
                Description = "Dummy Task",
                DueDate = new System.DateTime().AddDays(20),
                StartDate = new System.DateTime().AddDays(1),
                EndDate = new System.DateTime().AddDays(30),
                Priority = IMyTask.Priorities.Medium,
                Status = IMyTask.Statuses.New
            };
            validator = new BL.Validators(context);
            var newTask = controller.PostTaskAsync(task, validator);
            Assert.IsNotNull(newTask);
            Assert.IsTrue(newTask.Result.Name == "Dummy Task");
        }
    }
}