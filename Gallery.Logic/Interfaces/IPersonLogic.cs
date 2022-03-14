// <copyright file="IPersonLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Gallery.Data.Models;

    /// <summary>
    /// Iperson Logic mandatory methods.
    /// </summary>
    public interface IPersonLogic
    {
        /// <summary>
        /// Mandatory Person logic methods.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <returns>Person instance by Id.</returns>
        Person GetPersonById(int id);

        /// <summary>
        /// Changes phone number of requested person.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <param name="newNumber">New phone number of person.</param>
        void ChangePhoneNumber(int id, string newNumber);
        public IQueryable<Person> ReadAll();

        /// <summary>
        /// Changes email of person.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <param name="newEmail">New email of person.</param>
        void ChangeEmail(int id, string newEmail);

        /// <summary>
        /// Changes zipcode of person.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <param name="newZipCode">New zipcode of person.</param>
        void ChangeZipCode(int id, int newZipCode);

        /// <summary>
        /// Mandatory implemntation.
        /// </summary>
        /// <returns>IList of all people.</returns>
      

        /// <summary>
        /// Deletes person instance.
        /// </summary>
        /// <param name="id">Id of person.</param>
        void DeletePerson(int id);

        /// <summary>
        /// Adds new person to table.
        /// </summary>
        /// <param name="newPerson">New person instance.</param>
        void AddPerson(Person newPerson);

        /// <summary>
        /// Checks if person of requested ID exists in table or not.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <returns>True if exists, false if not.</returns>
        bool PersonExists(int id);

        void UpdatePerson(Person p);
    }
}
