// <copyright file="IExhibitRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using Gallery.Data.Models;

    /// <summary>
    /// Mandatory Exhibit CRUD methods.
    /// </summary>
    public interface IExhibitRepository : IRepository<Exhibit>
    {
        /// <summary>
        /// Changes rating value of exhibit based on ID.
        /// </summary>
        /// <param name="id">Id of Exhibit.</param>
        /// <param name="newRating">Rating of Exhibit.</param>
        void ChangeRating(int id, int newRating);

        /// <summary>
        /// Changes entry fee of exhibit based on ID.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        /// <param name="newFee">New fee of Exhibit.</param>
        void ChangeEntryFee(int id, int newFee);

        /// <summary>
        /// Add new Exhibit.
        /// </summary>
        /// <param name="newExhibit">New exhibit instance.</param>
        void AddExhibit(Exhibit newExhibit);

        /// <summary>
        /// Deletes exhibit instance.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        void DeleteExhibit(int id);

        void UpdateExhibit(Exhibit x);
    }
}
