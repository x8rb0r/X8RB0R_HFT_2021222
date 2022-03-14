// <copyright file="IPersonRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using Gallery.Data.Models;

    /// <summary>
    /// Mandatory Person CRUD methods.
    /// </summary>
    public interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Changes phone number of person based on ID.
        /// </summary>
        /// <param name="id">Id of Person instance.</param>
        /// <param name="newNumber">New phone number of Person instance.</param>
        void ChangePhoneNumber(int id, string newNumber);

        /// <summary>
        /// Changes e-mail address of person based on ID.
        /// </summary>
        /// <param name="id">Id of Person instance.</param>
        /// <param name="newEmail">New e-mail address of Person instance.</param>
        void ChangeEmail(int id, string newEmail);

        /// <summary>
        /// Changes zip code of person based on ID.
        /// </summary>
        /// <param name="id">Id of Person instance.</param>
        /// <param name="newZipCode">New e-mail address of Person instance.</param>
        void ChangeZipCode(int id, int newZipCode);

        /// <summary>
        /// Adds a new person to the table.
        /// </summary>
        /// <param name="newPerson">New person instance.</param>
        void AddPerson(Person newPerson);

        /// <summary>
        /// Deletes person instance.
        /// </summary>
        /// <param name="id">Id of person.</param>
        void DeletePerson(int id);

        void UpdatePerson(Person p);
    }
}
