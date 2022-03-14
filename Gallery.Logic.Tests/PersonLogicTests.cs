// <copyright file="PersonLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Gallery.Data.Models;
    using Gallery.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests class used for testing the person logic.
    /// </summary>
    [TestFixture]
    public class PersonLogicTests
    {
        /// <summary>
        /// Verifies the ChangeEmail() method of the person logic class is run.
        /// </summary>
        [Test]
        public void ChangeEmail_Test()
        {
            // Arrange
            Mock<IPersonRepository> personRepoMock = new Mock<IPersonRepository>(MockBehavior.Loose);

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Person One", PersonId = 1, Email = "test1@test.com" },
                new Person() { Name = "Person Two", PersonId = 2, Email = "test2@test.com" },
            };

            personRepoMock.Setup(repo => repo.GetAll()).Returns(people.AsQueryable());

            PersonLogic logic = new PersonLogic(personRepoMock.Object);

            // Act
            logic.ChangeEmail(1, "newemail@test.com");
            logic.ChangeEmail(2, "newemail2@test.hu");

            // Verify
            personRepoMock.Verify(repo => repo.ChangeEmail(1, "newemail@test.com"), Times.Exactly(1));
            personRepoMock.Verify(repo => repo.ChangeEmail(2, "newemail2@test.hu"), Times.Exactly(1));
        }

        /// <summary>
        /// Verifies the GetOnePerson() method of the person logic class is run.
        /// </summary>
        [Test]
        public void GetOnePerson_Test()
        {
            // Arrange
            Mock<IPersonRepository> personRepoMock = new Mock<IPersonRepository>(MockBehavior.Loose);

            Person p = new Person() { Name = "Person One", PersonId = 1 };

            personRepoMock.Setup(repo => repo.GetOne(1)).Returns(p);

            PersonLogic logic = new PersonLogic(personRepoMock.Object);

            // Act
            logic.GetPersonById(1);
            logic.GetPersonById(1);

            // Verify
            personRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Exactly(2));
        }
    }
}
