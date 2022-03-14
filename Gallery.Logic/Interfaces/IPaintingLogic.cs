// <copyright file="IGalleryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Gallery.Data.Models;

    /// <summary>
    /// Gallery logic interface that consists of painting and exhibit repos.
    /// </summary>
    public interface IPaintingLogic
    {



        /// <summary>
        /// Returns a single painting instance by ID, forwarded to the repository.
        /// </summary>
        /// <param name="id">Id of painting.</param>
        /// <returns>Painting instance by Id.</returns>
        Painting GetPainting(int id);

        /// <summary>
        /// Adds new painting instance.
        /// </summary>
        /// <param name="newPainting">New painting instance.</param>
        void AddPainting(Painting newPainting);

        void DeletePainting(int id);


        public IQueryable<Painting> ReadAll();


        bool PaintingExists(int id);


        void UpdatePainting(Painting p);

      
    }
}
