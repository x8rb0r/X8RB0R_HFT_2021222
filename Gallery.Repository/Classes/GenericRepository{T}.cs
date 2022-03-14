// <copyright file="GenericRepository{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Generic Repository manager class.
    /// </summary>
    /// <typeparam name="T">Generic Type T repository.</typeparam>
    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Database context provided by constructor.
        /// </summary>
        private protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// Recieves database context.
        /// </summary>
        /// <param name="ctx">Database context recieved as parameter.</param>
        public GenericRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }


        /// <summary>
        /// Returns an IQueryable type of all the elements in a table.
        /// </summary>
        /// <returns>Returns IQueryable<typeparamref name="T"/>.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Returns a single instance by ID.
        /// </summary>
        /// <param name="id">Returns a single T type by Id.</param>
        /// <returns>Generic type T.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Checks if instance exists in table.
        /// </summary>
        /// <param name="id">Id of instance.</param>
        /// <returns>True if exists, false if not.</returns>
        public abstract bool Exists(int id);
    }
}
