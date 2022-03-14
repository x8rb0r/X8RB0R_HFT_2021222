// <copyright file="PersonRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Gallery.Data.Models;
    using Gallery.Repository.Exceptions;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Person Repository manager class.
    /// </summary>
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public PersonRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds person to table.
        /// </summary>
        /// <param name="newPerson">New person instance.</param>
        public void AddPerson(Person newPerson)
        {
            this.ctx.Set<Person>().Add(newPerson);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Changes e-mail address of person based on ID.
        /// </summary>
        /// <param name="id">Target's Id.</param>
        /// <param name="newEmail">Target Id's e-mail address.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            if (newEmail != null && !newEmail.Contains('@'))
            {
                throw new InvalidChangeException("Email missing '@' symbol!");
            }
            else
            {
                Person person = this.GetOne(id);
                person.Email = newEmail;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes phone number of person based on ID.
        /// </summary>
        /// <param name="id">Target's Id.</param>
        /// <param name="newNumber">Target Id's new phone number.</param>
        public void ChangePhoneNumber(int id, string newNumber)
        {
            if (newNumber != null && newNumber.Length < 7)
            {
                throw new InvalidChangeException("Phone number must contain at least 7 digits!");
            }
            else
            {
                Person person = this.GetOne(id);
                person.PhoneNumber = newNumber;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes zip code of person based on ID.
        /// </summary>
        /// <param name="id">Target's Id.</param>
        /// <param name="newZipCode">Target Id's new zip code.</param>
        public void ChangeZipCode(int id, int newZipCode)
        {
            if (newZipCode < 0)
            {
                throw new InvalidChangeException("Invalid zip code!");
            }
            else
            {
                Person person = this.GetOne(id);
                person.ZipCode = newZipCode;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes person instance.
        /// </summary>
        /// <param name="id">Id of person.</param>
        public void DeletePerson(int id)
        {
            this.ctx.Set<Person>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Checks if person of requested ID exists in table.
        /// </summary>
        /// <param name="id">Id of person.</param>
        /// <returns>True if exists, false if not.</returns>
        public override bool Exists(int id)
        {
            List<Person> people = this.GetAll().ToList();
            foreach (var item in people)
            {
                if (item.PersonId == id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a single person instance by ID.
        /// </summary>
        /// <param name="id">Target's Id.</param>
        /// <returns>Returns Person instance.</returns>
        public override Person GetOne(int id)
        {
            Person p = this.GetAll().SingleOrDefault(x => x.PersonId == id);
            if (p == null)
            {
                throw new NoInstanceFoundException("ID not found!");
            }
            else
            {
                return p;
            }
        }

        public void UpdatePerson(Person item)
        {
            var old = this.GetOne(item.PersonId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }

            this.ctx.SaveChanges();
        }

 
    }
}
