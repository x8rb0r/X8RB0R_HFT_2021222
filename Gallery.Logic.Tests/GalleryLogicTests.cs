// <copyright file="GalleryLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/*namespace Gallery.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Gallery.Data.Models;
    using Gallery.Logic.Classes;
    using Gallery.Logic.QueryGroups;
    using Gallery.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests run on Gallery logic.
    /// </summary>
    [TestFixture]
    public class GalleryLogicTests
    {
        /// <summary>
        /// Verifies the GetAll() Exhibits method is run.
        /// </summary>
        [Test]
        public void GetAllExhibits_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            List<Exhibit> exhibits = new List<Exhibit>()
            {
                new Exhibit() { ExhibitId = 1, Title = "Exhibit 1" },
                new Exhibit() { ExhibitId = 2, Title = "Exhibit 2" },
            };

            exhibitRepoMock.Setup(repo => repo.GetAll()).Returns(exhibits.AsQueryable());
            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            var result = logic.GetAllExhibits();

            // Verify
            exhibitRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            exhibitRepoMock.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Verifies the add painting method is run.
        /// </summary>
        [Test]
        public void AddPainting_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            Painting painting = new Painting() { PaintingId = 1, Title = "Painting 1" };

            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            logic.AddPainting(painting);
            logic.AddPainting(painting);

            // Verify
            paintingRepoMock.Verify(repo => repo.AddPainting(painting), Times.Exactly(2));
        }

        /// <summary>
        /// Verifies the delete painting method is run.
        /// </summary>
        [Test]
        public void DeletePainting_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            List<Painting> paintings = new List<Painting>()
            {
                new Painting() { PaintingId = 1, Title = "Painting 1" },
                new Painting() { PaintingId = 2, Title = "Painting 2" },
            };

            paintingRepoMock.Setup(repo => repo.GetAll()).Returns(paintings.AsQueryable());
            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            logic.DeletePainting(1);
            logic.DeletePainting(2);

            // Verify
            paintingRepoMock.Verify(repo => repo.DeletePainting(1), Times.Exactly(1));
            paintingRepoMock.Verify(repo => repo.DeletePainting(2), Times.Exactly(1));
            paintingRepoMock.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Asserts and verifies the PaintingsInSunshineExhibit Non-CRUD method.
        /// </summary>
        [Test]
        public void PaintingsInSunshineExhibit_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            List<Painting> paintings = new List<Painting>()
            {
                new Painting() { PaintingId = 1, Title = "Painting 1", ExhibitId = 1 },
                new Painting() { PaintingId = 2, Title = "Painting 2", ExhibitId = 1 },
            };
            List<Exhibit> exhibits = new List<Exhibit>()
            {
                new Exhibit() { ExhibitId = 1, Title = "Sunshine" },
            };

            paintingRepoMock.Setup(repo => repo.GetAll()).Returns(paintings.AsQueryable());
            exhibitRepoMock.Setup(repo => repo.GetAll()).Returns(exhibits.AsQueryable());

            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            List<PaintingsInSunshineGroup> result = logic.PaintingsInSunshineExhibit().ToList();
            List<PaintingsInSunshineGroup> expectedResult = new List<PaintingsInSunshineGroup>()
            {
                new PaintingsInSunshineGroup() { NAME = "Painting 1" },
                new PaintingsInSunshineGroup() { NAME = "Painting 2" },
            };

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));

            // Verify
            paintingRepoMock.Verify(repo => repo.GetAll(), Times.Exactly(1));
            exhibitRepoMock.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }

        /// <summary>
        /// Asserts and verifies the Non-CRUD method that determines which painting is the most expensive and which exhibit it is displayed in.
        /// </summary>
        [Test]
        public void MostExpensivePaintingAndItsExhibit_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            List<Painting> paintings = new List<Painting>()
            {
                new Painting() { PaintingId = 1, Title = "Painting 1", ExhibitId = 1, Value = 100 },
                new Painting() { PaintingId = 2, Title = "Painting 2", ExhibitId = 1, Value = 0 },
            };

            List<Exhibit> exhibits = new List<Exhibit>()
            {
                new Exhibit() { ExhibitId = 1, Title = "Sunshine" },
            };

            paintingRepoMock.Setup(repo => repo.GetAll()).Returns(paintings.AsQueryable());
            exhibitRepoMock.Setup(repo => repo.GetAll()).Returns(exhibits.AsQueryable());

            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            List<MostExpensivePaintingAndItsExhibitGroup> result = logic.MostExpensivePaintingAndItsExhibit().ToList();

            List<MostExpensivePaintingAndItsExhibitGroup> expectedResult = new List<MostExpensivePaintingAndItsExhibitGroup>()
            {
                new MostExpensivePaintingAndItsExhibitGroup() { EXHIBIT = "Sunshine", PAINTING = "Painting 1" },
            };

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));

            // Verify
            paintingRepoMock.Verify(repo => repo.GetAll(), Times.Exactly(1));
            exhibitRepoMock.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }

        /// <summary>
        /// Asserts and verifies the Non-CRUD method that determines how many paintings an exhibit has.
        /// </summary>
        [Test]
        public void ExhibitsAndCountPaintings_Test()
        {
            // Arrange
            Mock<IExhibitRepository> exhibitRepoMock = new Mock<IExhibitRepository>(MockBehavior.Loose);
            Mock<IPaintingRepository> paintingRepoMock = new Mock<IPaintingRepository>(MockBehavior.Loose);

            List<Painting> paintings = new List<Painting>()
            {
                new Painting() { PaintingId = 1, Title = "Painting 1", ExhibitId = 1 },
                new Painting() { PaintingId = 2, Title = "Painting 2", ExhibitId = 1 },
                new Painting() { PaintingId = 3, Title = "Painting 3", ExhibitId = 1 },
                new Painting() { PaintingId = 4, Title = "Painting 4", ExhibitId = 2 },
            };
            List<Exhibit> exhibits = new List<Exhibit>()
            {
                new Exhibit() { ExhibitId = 1, Title = "Exhibit 1" },
                new Exhibit() { ExhibitId = 2, Title = "Exhibit 2" },
            };

            paintingRepoMock.Setup(repo => repo.GetAll()).Returns(paintings.AsQueryable());
            exhibitRepoMock.Setup(repo => repo.GetAll()).Returns(exhibits.AsQueryable());

            GalleryLogic logic = new GalleryLogic(paintingRepoMock.Object, exhibitRepoMock.Object);

            // Act
            List<ExhibitsAndCountPaintingsGroup> result = logic.ExhibitsAndTheNumberofPaintingsItHas().ToList();

            List<ExhibitsAndCountPaintingsGroup> expectedResult = new List<ExhibitsAndCountPaintingsGroup>()
            {
                new ExhibitsAndCountPaintingsGroup() { EXHIBIT = "Exhibit 1", NUMBER_OF_PAINTINGS = 3 },
                new ExhibitsAndCountPaintingsGroup() { EXHIBIT = "Exhibit 2", NUMBER_OF_PAINTINGS = 1 },
            };

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));

            // Verify
            paintingRepoMock.Verify(repo => repo.GetAll(), Times.Once);
            exhibitRepoMock.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
*/