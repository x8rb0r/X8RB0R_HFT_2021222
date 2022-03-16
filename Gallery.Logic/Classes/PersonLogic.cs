// <copyright file="PersonLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Gallery.Data.Models;
    using Gallery.Repository;

    /// <summary>
    /// Person logic class.
    /// </summary>
    public class PersonLogic : IPersonLogic
    {
        private readonly IPersonRepository personRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonLogic"/> class.
        /// Person logic class constructor, receives repo instance.
        /// </summary>
        /// <param name="repo">IPersonRepository instance.</param>
        public PersonLogic(IPersonRepository repo)
        {
            this.personRepo = repo;
        }

        /// <summary>
        /// Adds new person to table.
        /// </summary>
        /// <param name="newPerson">New person instance.</param>
        public void AddPerson(Person newPerson)
        {
            this.personRepo.AddPerson(newPerson);
        }

        /// <summary>
        /// Changes e-mail address of person based on ID, forwarded to the repository.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <param name="newEmail">New email of person.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            this.personRepo.ChangeEmail(id, newEmail);
        }

        /// <summary>
        /// Changes phone number of person based on ID, forwarded to the repository.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <param name="newNumber">New number of person instance.</param>
        public void ChangePhoneNumber(int id, string newNumber)
        {
            this.personRepo.ChangePhoneNumber(id, newNumber);
        }

        /// <summary>
        /// Changes zip code of person based on ID, forwarded to the repository.
        /// </summary>
        /// <param name="id">If of person.</param>
        /// <param name="newZipCode">New zipcode of person instance.</param>
        public void ChangeZipCode(int id, int newZipCode)
        {
            this.personRepo.ChangeZipCode(id, newZipCode);
        }

        /// <summary>
        /// Deletes person instance.
        /// </summary>
        /// <param name="id">Id of person.</param>
        public void DeletePerson(int id)
        {
            this.personRepo.DeletePerson(id);
        }

        /// <summary>
        /// Returns a list of all the people, forwarded to the repository.
        /// </summary>
        /// <returns>Ilist of all people.</returns>
        public IQueryable<Person> ReadAll()
        {
            return this.personRepo.GetAll();
        }

        /// <summary>
        /// Returns a single person instance by ID, forwarded to the repository.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <returns>Returns requested person instance.</returns>
        public Person GetPersonById(int id)
        {
            return this.personRepo.GetOne(id);
        }

        /// <summary>
        /// Checks to see if the person of requested ID is present in the table.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <returns>True if person exists, false if not.</returns>
        public bool PersonExists(int id)
        {
            return this.personRepo.Exists(id);
        }

        /// <summary>
        /// Returns the @gmail.com domain users.
        /// </summary>
        /// <returns>List of gmail users.</returns>
        public IList<Person> GmailUsers()
        {
            var q = from x in this.personRepo.GetAll()
                    where x.Email.Contains("@gmail.com")
                    select x;
            return q.ToList();
        }
       

        /// <summary>
        /// Returns the @gmail.com domain users.
        /// </summary>
        /// <returns>List of gmail users.</returns>
        public Task<IList<Person>> GmailUsersAsync()
        {
            return Task.Run(() => this.GmailUsers());
        }

        public void UpdatePerson(Person p)
        {
            this.personRepo.UpdatePerson(p);
        }
    }
}
