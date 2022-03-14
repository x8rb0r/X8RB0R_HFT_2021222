// <copyright file="ExhibitRepository.cs" company="PlaceholderCompany">
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
    /// Exhibit Repository manager class.
    /// </summary>
    public class ExhibitRepository : GenericRepository<Exhibit>, IExhibitRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExhibitRepository"/> class.
        /// Exhibit Repository constructor.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public ExhibitRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds exhibit to the table.
        /// </summary>
        /// <param name="newExhibit">New exhibit instance.</param>
        public void AddExhibit(Exhibit newExhibit)
        {
            this.ctx.Set<Exhibit>().Add(newExhibit);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Changes entry fee of exhibit based on ID.
        /// </summary>
        /// <param name="id">Id of exhibit instance.</param>
        /// <param name="newFee">Changes fee of exhibit instance.</param>
        public void ChangeEntryFee(int id, int newFee)
        {
            if (newFee < 0)
            {
                throw new InvalidChangeException("Fee must be 0 or greater!");
            }
            else
            {
                Exhibit exhibit = this.GetOne(id);
                exhibit.EntryFee = newFee;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes rating value of exhibit based on ID.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        /// <param name="newRating">New rating of exhibit instance.</param>
        public void ChangeRating(int id, int newRating)
        {
            if (newRating < 0 || newRating > 100)
            {
                throw new InvalidChangeException("Rating must be between 0 and 100!");
            }
            else
            {
                Exhibit exhibit = this.GetOne(id);
                exhibit.Rating = newRating;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes exhibit instance.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        public void DeleteExhibit(int id)
        {
            this.ctx.Set<Exhibit>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Checks if exhibit of requested ID exists in table.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        /// <returns>True if exists, false if not.</returns>
        public override bool Exists(int id)
        {
            List<Exhibit> exhibits = this.GetAll().ToList();
            foreach (var item in exhibits)
            {
                if (item.ExhibitId == id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a single exhibit instance by ID.
        /// </summary>
        /// <param name="id">Id of exhibit.</param>
        /// <returns>Exhibit instance based on input id parameter.</returns>
        public override Exhibit GetOne(int id)
        {
            Exhibit x = this.GetAll().SingleOrDefault(x => x.ExhibitId == id);
            if (x == null)
            {
                throw new NoInstanceFoundException("ID not found!");
            }
            else
            {
                return x;
            }
        }

     

        public void UpdateExhibit(Exhibit item)
        {
            var old = this.GetOne(item.ExhibitId);
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
