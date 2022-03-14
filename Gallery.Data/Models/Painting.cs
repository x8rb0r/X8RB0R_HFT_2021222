// <copyright file="Painting.cs" company="PlaceholderCompany">
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
    /// Paintings table and its properties.
    /// </summary>
    [Table("Paintings")]
    public class Painting
    {
        /// <summary>
        /// Gets or sets title of painting.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the painter.
        /// </summary>
        public string Painter { get; set; }

        /// <summary>
        /// Gets or sets the condition of the painting.
        /// </summary>
        public int Condition { get; set; }

        /// <summary>
        /// Gets or sets the year the painting was painted.
        /// </summary>
        public int YearPainted { get; set; }

        /// <summary>
        /// Gets or sets the estimated value of the painting.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the ID of the painting.
        /// </summary>
        [Key]
        public int PaintingId { get; set; }

        /// <summary>
        /// Gets or sets the person that this painting originates from.
        /// </summary>
        [NotMapped]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Person that this painting originates from.
        /// </summary>
        [ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }

        /// <summary>
        /// Gets or sets the exhibit that this painting is displayed in.
        /// </summary>
        [NotMapped]
        public virtual Exhibit Exhibit { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exhibit that this painting is displayed in.
        /// </summary>
        [ForeignKey(nameof(Exhibit))]
        public int? ExhibitId { get; set; }

        /// <summary>
        /// Gets Exhibit ID as string. If null returns "-", otherwise returns ID.
        /// </summary>
        public string ExhibitIdString
        {
            get
            {
                string exhibitId = "-";
                if (this.ExhibitId != null)
                {
                    exhibitId = this.ExhibitId.ToString();
                }

                return exhibitId;
            }
        }

        /// <summary>
        /// Gets Person ID as string. If null returns "-", otherwise returns ID.
        /// </summary>
        public string PersonIdString
        {
            get
            {
                string personId = "-";
                if (this.PersonId != null)
                {
                    personId = this.PersonId.ToString();
                }

                return personId;
            }
        }
    }
}