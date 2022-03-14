// <copyright file="Exhibit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Exhibitions table and its properties.
    /// </summary>
    [Table("Exhibitions")]
    public class Exhibit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exhibit"/> class and creates a new instance of the Paintings set.
        /// </summary>
        public Exhibit()
        {
            this.Paintings = new HashSet<Painting>();
        }

        /// <summary>
        /// Gets or sets the start-date of the exhibition.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end-date of the exhibition (null if the end-date has not been decided).
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Gets or sets the title of the exhibition.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the rating of the exhibition (from 0-9).
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the entry fee of the exhibiton.
        /// </summary>
        public int EntryFee { get; set; }

        /// <summary>
        /// Gets the collection of paintings displayed in the exhibition.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Painting> Paintings { get; }

        /// <summary>
        /// Gets or sets the ID of the exhibition.
        /// </summary>
        [Key]
        public int ExhibitId { get; set; }

        /// <summary>
        /// Gets end date, if string is not null return date, if it is null returns "Undefined".
        /// </summary>
        public string EndDateString
        {
            get
            {
                string endDateString = "Undefined";
                if (this.End != null)
                {
                    endDateString = this.End?.ToShortDateString();
                }

                return endDateString;
            }
        }

        /// <summary>
        /// Gets start date.
        /// </summary>
        public string StartDateString
        {
            get
            {
                return this.Start.ToShortDateString();
            }
        }
    }
}
