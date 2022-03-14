// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Gallery.Data;
    using Gallery.Logic;
    using Gallery.Logic.Classes;
    using Gallery.Repository;

    /// <summary>
    /// Factory class to make instances for all the classes.
    /// </summary>
    public class Factory
    {
        private static GalleryContext ctx = new GalleryContext();
        private static ExhibitRepository exhibitRepo = new ExhibitRepository(ctx);
        private static PersonRepository personRepo = new PersonRepository(ctx);
        private static PaintingRepository paintingRepo = new PaintingRepository(ctx);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.PersonL = new PersonLogic(personRepo);
            this.GalleryL = new GalleryLogic(paintingRepo, exhibitRepo);
        }

        /// <summary>
        /// Gets or sets the PersonLogic instance.
        /// </summary>
        public PersonLogic PersonL { get; set; }

        /// <summary>
        /// Gets or sets the GalleryLogic instance.
        /// </summary>
        public GalleryLogic GalleryL { get; set; }
    }
}
