// <copyright file="IPaintingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using Gallery.Data.Models;

    /// <summary>
    /// Mandatory Painting CRUD methods.
    /// </summary>
    public interface IPaintingRepository : IRepository<Painting>
    {
        /// <summary>
        /// Changes condition of painting based on ID.
        /// </summary>
        /// <param name="id">Id of Painting instance.</param>
        /// <param name="newCondition">New condition of Painting instance.</param>
        void ChangeCondition(int id, int newCondition);

        /// <summary>
        /// Changes value of painting based on ID.
        /// </summary>
        /// <param name="id">Id of Painting instance.</param>
        /// <param name="newValue">New value of Painting instance.</param>
        void ChangeValue(int id, int newValue);

        /// <summary>
        /// Adds new painting to table.
        /// </summary>
        /// <param name="newPainting">New painting instance.</param>
        void AddPainting(Painting newPainting);

        /// <summary>
        /// Deletes painting instance.
        /// </summary>
        /// <param name="id">Id of painting.</param>
        void DeletePainting(int id);

        void UpdatePainting(Painting p);
    }
}
