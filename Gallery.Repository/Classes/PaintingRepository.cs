// <copyright file="PaintingRepository.cs" company="PlaceholderCompany">
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
    /// Painting Repository manager class.
    /// </summary>
    public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaintingRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context as parameter.</param>
        public PaintingRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds painting to table.
        /// </summary>
        /// <param name="newPainting">New painting instance.</param>
        public void AddPainting(Painting newPainting)
        {
            this.ctx.Set<Painting>().Add(newPainting);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Changes condition of painting based on ID.
        /// </summary>
        /// <param name="id">Id of painting instance.</param>
        /// <param name="newCondition">New condition of requested painting.</param>
        public void ChangeCondition(int id, int newCondition)
        {
            if (newCondition < 0 || newCondition > 100)
            {
                throw new InvalidChangeException("Condition must be between 0 and 100!");
            }
            else
            {
                Painting painting = this.GetOne(id);
                painting.Condition = newCondition;
                this.ctx.SaveChanges();
            }
        }



        /// <summary>
        /// Changes value of painting based on ID.
        /// </summary>
        /// <param name="id">Id of painting instance.</param>
        /// <param name="newValue">New value of requested painting instance.</param>
        public void ChangeValue(int id, int newValue)
        {
            if (newValue < 0)
            {
                throw new InvalidChangeException("Invalid value change!");
            }
            else
            {
                Painting painting = this.GetOne(id);
                painting.Value = newValue;
                this.ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes painting instance.
        /// </summary>
        /// <param name="id">Id of painting.</param>
        public void DeletePainting(int id)
        {
            this.ctx.Set<Painting>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Checks to see if painting of requested ID exists.
        /// </summary>
        /// <param name="id">ID of painting.</param>
        /// <returns>True if exists, false if not.</returns>
        public override bool Exists(int id)
        {
            List<Painting> paintings = this.GetAll().ToList();
            foreach (var item in paintings)
            {
                if (item.PaintingId == id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a single painting instance by ID.
        /// </summary>
        /// <param name="id">Id of painting instance.</param>
        /// <returns>Returns requested painting instance by Id.</returns>
        public override Painting GetOne(int id)
        {
            Painting p = this.GetAll().SingleOrDefault(x => x.PaintingId == id);
            if (p == null)
            {
                throw new NoInstanceFoundException("ID not found!");
            }
            else
            {
                return p;
            }
        }

        public void UpdatePainting(Painting p)
        {
            var paintingToUpdate = GetOne(p.PaintingId);
            paintingToUpdate.Title = p.Title;
            paintingToUpdate.Painter = p.Painter;
            paintingToUpdate.Condition = p.Condition;
            paintingToUpdate.Value = p.Value;
            paintingToUpdate.YearPainted = p.YearPainted;
            ctx.SaveChanges();
        }
    }
}
