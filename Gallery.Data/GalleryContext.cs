// <copyright file="GalleryContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Data
{
    using System;
    using System.Globalization;
    using Gallery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// GalleryContext class, creates database entities and fills database with data.
    /// </summary>
    public class GalleryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GalleryContext"/> class.
        /// </summary>
        public GalleryContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets Paintings table.
        /// </summary>
        public DbSet<Painting> Paintings { get; set; }

        /// <summary>
        /// Gets or sets People table.
        /// </summary>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets Exhibitions table.
        /// </summary>
        public DbSet<Exhibit> Exhibitions { get; set; }

        /// <summary>
        /// Connects to database using SQL input string.
        /// </summary>
        /// <param name="optionsBuilder">OptionsBuilder to be passed on to the method.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GalleryDatabase.mdf;Integrated Security = True");
            }
        }

        /// <summary>
        /// Creates database models.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder to be passed on to the method.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Person p1 = new Person() { BirthYear = 2000, Email = "johnsmith325@gmail.com", Name = "John Smith", PhoneNumber = "+36302368471", ZipCode = 2600, PersonId = 1 };
            Person p2 = new Person() { BirthYear = 1998, Email = "lenyyy140@gmail.com", Name = "Tom Leonard", PhoneNumber = "+36307868471", ZipCode = 1067, PersonId = 2 };
            Person p3 = new Person() { BirthYear = 1970, Email = "gmartyttt@hotmail.com", Name = "George McCarty", PhoneNumber = "+36203368471", ZipCode = 2120, PersonId = 3 };

            Painting painting1 = new Painting() { Title = "Mona Lisa", Painter = "Leonardo da Vinci", Condition = 90, Value = 300, YearPainted = 1800, ExhibitId = 1, PaintingId = 1, PersonId = 1 };
            Painting painting2 = new Painting() { Title = "Fire", Painter = "Giuseppe Arcimboldo", Condition = 85, Value = 200, YearPainted = 1700, ExhibitId = 1, PaintingId = 2, PersonId = 2 };
            Painting painting3 = new Painting() { Title = "The Female Musician and the Wolf", Painter = "Georges Braque", Condition = 90, Value = 300, YearPainted = 1990, ExhibitId = 2, PaintingId = 3, PersonId = 3 };
            Painting painting4 = new Painting() { Title = "I and the Village", Painter = "Marc Chagall", Condition = 80, Value = 200, YearPainted = 1970, ExhibitId = 3, PaintingId = 4, PersonId = 3 };
            Painting painting5 = new Painting() { Title = "The Lute Player", Painter = "James Carter", Condition = 32, Value = 300, YearPainted = 1850, ExhibitId = 2, PaintingId = 5, PersonId = 2 };
            Painting painting6 = new Painting() { Title = "Magic Flute", Painter = "George Costanza", Condition = 45, Value = 200, YearPainted = 1800, ExhibitId = 3, PaintingId = 6, PersonId = 3 };

            Exhibit x1 = new Exhibit() { Start = DateTime.Parse("10/20/2020", ci), End = null, EntryFee = 150, Rating = 20, Title = "Sunshine", ExhibitId = 1 };
            Exhibit x2 = new Exhibit() { Start = DateTime.Parse("09/01/2020", ci), End = DateTime.Now, EntryFee = 200, Rating = 97, Title = "Moonshine", ExhibitId = 2 };
            Exhibit x3 = new Exhibit() { Start = DateTime.Parse("08/02/2020", ci), End = DateTime.Parse("11/30/2020", ci), EntryFee = 350, Rating = 67, Title = "Doctor Who", ExhibitId = 3 };

            if (modelBuilder != null)
            {
                modelBuilder.Entity<Painting>()
                   .HasOne(painting => painting.Exhibit)
                   .WithMany(exhibit => exhibit.Paintings)
                   .HasForeignKey(painting => painting.ExhibitId)
                   .OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<Painting>()
                    .HasOne(painting => painting.Person)
                    .WithMany(person => person.Paintings)
                    .HasForeignKey(painting => painting.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Person>().Property(x => x.PersonId).ValueGeneratedOnAdd();
                modelBuilder.Entity<Exhibit>().Property(x => x.ExhibitId).ValueGeneratedOnAdd();
                modelBuilder.Entity<Painting>().Property(x => x.PaintingId).ValueGeneratedOnAdd();
                modelBuilder.Entity<Person>().HasData(p1, p2, p3);
                modelBuilder.Entity<Exhibit>().HasData(x1, x2, x3);
                modelBuilder.Entity<Painting>().HasData(painting1, painting2, painting3, painting4, painting5, painting6);
            }
        }
    }
}
