using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using student_API.Controllers;
using student_API.Models;
using student_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentApiTest
{
    [TestClass]
     public class StudentControllerTest
    {
        private Mock<Istudent> _studentRepoMock;
        private Fixture _fixture;

        private studentController _controller;

        public StudentControllerTest()
        {
            _fixture = new Fixture();
            _studentRepoMock = new Mock<Istudent>();
        }

        [TestMethod]
        public async Task getAllStudent()
        {
            var  students = _fixture.CreateMany<Student>(3).ToList();

            _studentRepoMock.Setup(repo => repo.getAllStudent()).Returns(students);

            _controller = new studentController(_studentRepoMock.Object);

            var result = await _controller.GetAllStudent();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task Get_Student_ThrowException()
        {
            _studentRepoMock.Setup(repo => repo.getAllStudent()).Throws(new Exception());

            _controller = new studentController(_studentRepoMock.Object);

            var result = await _controller.GetAllStudent();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task addStudent()
        {
            var student = _fixture.CreateMany<Student>();
            _studentRepoMock.Setup(repo => repo.registerStudent(It.IsAny<Student>())).Returns(student);

            _controller = new studentController(_studentRepoMock.Object);
            var result = await _controller.registerStudent(student);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task updateStudent()
        {
            var student = _fixture.CreateMany<Student>();
            _studentRepoMock.Setup(repo => repo.registerStudent(It.IsAny<Student>())).Returns(student);

            _controller = new studentController(_studentRepoMock.Object);
            var result = await _controller.UpdateStudent(student);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task deleteStudent()
        {
            _studentRepoMock.Setup(repo => repo.deleteStudent(It.IsAny<Guid>())).Returns(true);

            _controller = new studentController(_studentRepoMock.Object);
            var result = await _controller.deleteStudent(It.IsAny<Guid>());
            var obj = result as ObjectResult;

            Assert.AreEqual(204, obj.StatusCode);
        }

    }
}
