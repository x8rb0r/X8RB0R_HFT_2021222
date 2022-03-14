// <copyright file="IRepository{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using System.Linq;

    /// <summary>
    /// Mandatory Generic CRUD methods.
    /// </summary>
    /// <typeparam name="T">Generic Type T.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns a single instance by ID.
        /// </summary>
        /// <returns>Returns T Generic type based on Id.</returns>
        /// <param name="id">Id of Type T instance.</param>
        T GetOne(int id);

        /// <summary>
        /// Returns an IQueryable type of all the elements in a table.
        /// </summary>
        /// <returns>Returns Iqueryable generic type.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Mandatory Exists method to see if instance exists in table.
        /// </summary>
        /// <param name="id">Id of instance.</param>
        /// <returns>True if exhists, false if not.</returns>
        bool Exists(int id);
    }
}
