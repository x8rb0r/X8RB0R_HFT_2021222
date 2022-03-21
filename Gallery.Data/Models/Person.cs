// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using System.Text.Json.Serialization;

    /// <summary>
    /// People table and its properties.
    /// </summary>
    [Table("People")]
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class and the paintings set.
        /// </summary>
        public Person()
        {
            this.Paintings = new HashSet<Painting>();
        }

        /// <summary>
        /// Gets or sets the name of a person that gave a painting.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number of a person that gave a painting.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address of a person that gave a painting.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the birth year of a person that gave a painting.
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Gets or sets the zip code of a person that gave a painting.
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the ID of a person that gave a painting.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets the paintings that a person gave to the gallery.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Painting> Paintings { get; }
        public override string ToString()
        {
            return "Name: " + Name + " Email: " + Email + " Phone#: " + PhoneNumber + " Birth year: " + BirthYear + " ZipCode: " + ZipCode;
        }

    }
}
