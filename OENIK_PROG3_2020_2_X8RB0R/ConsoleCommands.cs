// <copyright file="ConsoleCommands.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gallery.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using ConsoleTools;
    using Gallery.Data.Models;
    using Gallery.Logic;
    using Gallery.Logic.Classes;
    using Gallery.Repository.Exceptions;

    /// <summary>
    /// Class used for displaying console.
    /// </summary>
    public class ConsoleCommands
    {
        private readonly Factory f;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleCommands"/> class.
        /// </summary>
        /// <param name="f">Factory instance.</param>
        public ConsoleCommands(Factory f)
        {
            this.f = f;

            Console.SetWindowSize(150, 50);
            Console.Title = "Gallery Database";
            this.MainMenu();
        }

        private static bool PersonExists(PersonLogic personLogic, int id)
        {
            return personLogic.PersonExists(id);
        }

        private static bool ExhibitExists(GalleryLogic galleryLogic, int id)
        {
            return galleryLogic.ExhibitExists(id);
        }

        private static bool PaintingExists(GalleryLogic galleryLogic, int id)
        {
            return galleryLogic.PaintingExists(id);
        }

        private static void ListAllExhibits(GalleryLogic exhibitLogic, string header)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string id = "[ID]";
            string title = "[TITLE]";
            string start = "[START]";
            string end = "[END]";
            string fee = "[FEE]";
            string rating = "[RATING]";
            Console.WriteLine("{0, -5} {1, -20} {2, -10}    {3, -10}   {4, -10} {5, -3}", id, title, start, end, fee, rating);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            foreach (var item in exhibitLogic.GetAllExhibits().ToList())
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -10}    {3, -10}   {4, -10} {5, -3}", item.ExhibitId, item.Title, item.StartDateString, item.EndDateString, item.EntryFee, item.Rating);
            }

            Console.ReadKey();
        }

        private static void ListAllPeople(PersonLogic personLogic, string header)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(header);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            string id = "[ID]";
            string name = "[NAME]";
            string birth = "[YOB]";
            string zip = "[ZIP CODE]";
            string phone = "[PHONE NO.]";
            string email = "[E-MAIL]";
            Console.WriteLine("{0, -5} {1, -35} {2, -10}    {3, -10}   {4, -10}     {5, -3}", id, name, birth, zip, phone, email);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            foreach (var item in personLogic.GetAllPeople().ToList())
            {
                Console.WriteLine("{0, -5} {1, -35} {2, -10}    {3, -10}   {4, -10}    {5, -3}", item.PersonId, item.Name, item.BirthYear, item.ZipCode, item.PhoneNumber, item.Email);
            }

            Console.ReadKey();
        }

        private static void ListAllPaintings(GalleryLogic paintingLogic, string header)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(header);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            string id = "[ID]";
            string title = "[TITLE]";
            string painter = "[PAINTER]";
            string year = "[YEAR PAINTED]";
            string cond = "[CONDIITON]";
            string value = "[VALUE]";
            string pId = "[P. ID]";
            string xId = "[X. ID]";
            Console.WriteLine("{0, -5} {1, -50} {2, -35}    {3, -4} {4, 11} {5, 2} {6, 5} {7, 5}", id, title, painter, year, cond, value, pId, xId);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            foreach (var item in paintingLogic.GetAllPaintings().ToList())
            {
                Console.WriteLine("{0, -5} {1, -50} {2, -35}      {3, -4} {4, 11}          {5, 2} {6, 5}   {7, 5}  ", item.PaintingId, item.Title, item.Painter, item.YearPainted, item.Condition, item.Value, item.PersonIdString, item.ExhibitIdString);
            }

            Console.ReadKey();
        }

        private static void ExhibitSubMenu(GalleryLogic exhibitLogic)
        {
            string validIdText = "Please enter a valid ID!";
            string header = "******************************  [EXHIBITS]  ******************************";

            var menu = new ConsoleMenu()
                .Add(">> LIST ALL", () => ListAllExhibits(exhibitLogic, header))
                .Add(">> GET ONE", () => GetOneExhibit(exhibitLogic, validIdText, header))
                .Add(">> ADD EXHIBIT", () => AddExhibit(exhibitLogic, validIdText, "Title", "Fee", "Start date", "End date", "Rating", "String cannot be null or empty!", "Fee must be 0 or greater!", "Please enter a valid date! (YYYY.MM.DD)", "Rating must be between 0 and 100!"))
                .Add(">> CHANGE ENTRY FEE", () => ChangeEntryFee(exhibitLogic, validIdText, "Enter a new entry fee!"))
                .Add(">> CHANGE RATING", () => ChangeRating(exhibitLogic, validIdText, "Enter a new rating!"))
                .Add(">> DELETE", () => DeleteExhibit(exhibitLogic, validIdText))
                .Add(">> RETURN", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PaintingsSubMenu(GalleryLogic galleryLogic, PersonLogic personLogic)
        {
            string validIdText = "Please enter a valid ID!";
            string header = "******************************************************************  [PAINTINGS]  ******************************************************************";

            var menu = new ConsoleMenu()
            .Add(">> LIST ALL", () => ListAllPaintings(galleryLogic, header))
            .Add(">> GET ONE", () => GetOnePainting(galleryLogic, validIdText, header))
            .Add(">> ADD PAINTING", () => AddPainting(galleryLogic, validIdText, "Title", "Painter", "Value", "Condition", "Year painted", "Exhibit ID", "Person ID", "Cannot be null or empty!", personLogic, "Value must be at least 0!", "Condition must be between 0 and 100!", "Please enter a valid number!"))
            .Add(">> CHANGE VALUE", () => ChangePaintingValue(galleryLogic, validIdText, "Enter a new value!"))
            .Add(">> CHANGE CONDITION", () => ChangePaintingCondition(galleryLogic, validIdText, "Enter a new condition!"))
            .Add(">> DELETE", () => DeletePainting(galleryLogic, validIdText))
            .Add(">> RETURN", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PersonSubMenu(PersonLogic personLogic)
        {
            string validIdText = "Please enter a valid ID!";
            string header = "*************************************************  [PEOPLE]  *************************************************";

            var menu = new ConsoleMenu()
           .Add(">> LIST ALL", () => ListAllPeople(personLogic, header))
           .Add(">> GET ONE", () => GetOnePerson(personLogic, validIdText, header))
           .Add(">> ADD PERSON", () => AddPerson(personLogic, validIdText, "Year of birth", "Email", "Phone No.", "Zip code", "Name", "String cannot be null or empty!", "Please enter a valid number!", "E-mail address must contain '@' symbol!"))
           .Add(">> CHANGE EMAIL", () => ChangeEmail(personLogic, validIdText, "Please enter a new e-mail address!"))
           .Add(">> CHANGE PHONE NUMBER", () => ChangePhoneNumber(personLogic, validIdText, "Please enter a new phone number!"))
           .Add(">> CHANGE ZIP CODE", () => ChangeZipCode(personLogic, validIdText, "Please enter a new zip code!"))
           .Add(">> DELETE", () => DeletePerson(personLogic, validIdText))
           .Add(">> RETURN", ConsoleMenu.Close);
            menu.Show();
        }

        private static void AddPerson(PersonLogic personLogic, string askId, string askBirth, string askEmail, string askPhone, string askZipCode, string askName, string nullOrEmpty, string notValidNumber, string invalidEmail)
        {
            Person p = new Person();

            Console.WriteLine(askId);
            bool validId;
            do
            {
                string id_s = Console.ReadLine();
                validId = int.TryParse(id_s, out int id) && !PersonExists(personLogic, id) && id >= 1;
                if (!validId)
                {
                    Console.WriteLine(askId);
                }
                else
                {
                    p.PersonId = id;
                }
            }
            while (!validId);

            Console.WriteLine(askName);
            do
            {
                p.Name = Console.ReadLine();
                if (string.IsNullOrEmpty(p.Name))
                {
                    Console.WriteLine(nullOrEmpty);
                }
            }
            while (string.IsNullOrEmpty(p.Name));

            Console.WriteLine(askBirth);
            bool validBirth;
            do
            {
                string birth_s = Console.ReadLine();
                validBirth = int.TryParse(birth_s, out int birth);
                if (!validBirth)
                {
                    Console.WriteLine(notValidNumber);
                }
                else
                {
                    p.BirthYear = birth;
                }
            }
            while (!validBirth);

            bool validEmail;
            Console.WriteLine(askEmail);
            do
            {
                p.Email = Console.ReadLine();
                System.StringComparison s = System.StringComparison.CurrentCulture;

                validEmail = !string.IsNullOrEmpty(p.Email) && p.Email.Contains('@', s);
                if (!validEmail)
                {
                    Console.WriteLine(invalidEmail);
                }
            }
            while (!validEmail);

            Console.WriteLine(askPhone);
            bool validPhone;
            do
            {
                p.PhoneNumber = Console.ReadLine();
                validPhone = !string.IsNullOrEmpty(p.PhoneNumber) && p.PhoneNumber.Length >= 7;
                if (!validPhone)
                {
                    Console.WriteLine(nullOrEmpty + " (must be at least 7 digits long)");
                }
            }
            while (!validPhone);

            Console.WriteLine(askZipCode);
            bool validZip;
            do
            {
                string zip_s = Console.ReadLine();
                validZip = int.TryParse(zip_s, out int zip) && zip >= 0;
                if (!validZip)
                {
                    Console.WriteLine(notValidNumber + " (must be at 0 or greater)");
                }
                else
                {
                    p.ZipCode = zip;
                }
            }
            while (!validZip);

            personLogic.AddPerson(p);
        }

        private static void AddExhibit(GalleryLogic exhibitLogic, string askId, string askTitle, string askFee, string askStart, string askEnd, string askRating, string nullOrEmpty, string invalidFee, string invalidDate, string invalidRating)
        {
            Exhibit x = new Exhibit();
            Console.WriteLine(askId);
            bool validId;
            do
            {
                string id_s = Console.ReadLine();
                validId = int.TryParse(id_s, out int id) && !ExhibitExists(exhibitLogic, id) && id >= 1;
                if (!validId)
                {
                    Console.WriteLine(askId);
                }
                else
                {
                    x.ExhibitId = id;
                }
            }
            while (!validId);

            Console.WriteLine(askTitle);
            do
            {
                x.Title = Console.ReadLine();
                if (string.IsNullOrEmpty(x.Title))
                {
                    Console.WriteLine(nullOrEmpty);
                }
            }
            while (string.IsNullOrEmpty(x.Title));

            Console.WriteLine(askFee);
            bool validFee;
            do
            {
                string fee_s = Console.ReadLine();
                validFee = int.TryParse(fee_s, out int fee) && fee >= 0;
                if (!validFee)
                {
                    Console.WriteLine(invalidFee);
                }
                else
                {
                    x.EntryFee = fee;
                }
            }
            while (!validFee);

            Console.WriteLine(askStart);
            bool validStart;
            do
            {
                string start_s = Console.ReadLine();
                validStart = DateTime.TryParse(start_s, out DateTime start);
                if (!validStart)
                {
                    Console.WriteLine(invalidDate);
                }
                else
                {
                    x.Start = start;
                }
            }
            while (!validStart);

            Console.WriteLine(askEnd);
            bool validEnd;
            string end_s = Console.ReadLine();
            validEnd = DateTime.TryParse(end_s, out DateTime end);
            if (!validEnd)
            {
                x.End = null;
            }
            else
            {
                x.End = end;
            }

            Console.WriteLine(askRating);
            bool validRating;
            do
            {
                string rating_s = Console.ReadLine();
                validRating = int.TryParse(rating_s, out int rating) && rating >= 0 && rating <= 100;
                if (!validRating)
                {
                    Console.WriteLine(invalidRating);
                }
                else
                {
                    x.Rating = rating;
                }
            }
            while (!validRating);

            exhibitLogic.AddExhibit(x);
        }

        private static void AddPainting(GalleryLogic galleryLogic, string askId, string askTitle, string askPainter, string askValue, string askCondition, string askYearPainted, string askExhibit, string askPerson, string nullOrEmpty, PersonLogic personLogic, string invalidValue, string invalidCondition, string invalidNumber)
        {
            Painting p = new Painting();

            Console.WriteLine(askId);
            bool validId;
            do
            {
                string id_s = Console.ReadLine();
                validId = int.TryParse(id_s, out int id) && !PaintingExists(galleryLogic, id) && id >= 1;
                if (!validId)
                {
                    Console.WriteLine(askId);
                }
                else
                {
                    p.PaintingId = id;
                }
            }
            while (!validId);

            Console.WriteLine(askTitle);
            bool validTitle;
            do
            {
                p.Title = Console.ReadLine();
                validTitle = !string.IsNullOrEmpty(p.Title);
                if (!validTitle)
                {
                    Console.WriteLine(nullOrEmpty);
                }
            }
            while (!validTitle);

            Console.WriteLine(askPainter);
            bool validPainter;
            do
            {
                p.Painter = Console.ReadLine();
                validPainter = !string.IsNullOrEmpty(p.Painter);
                if (!validPainter)
                {
                    Console.WriteLine(nullOrEmpty);
                }
            }
            while (!validPainter);

            Console.WriteLine(askValue);
            bool validValue;
            do
            {
                string value_s = Console.ReadLine();
                validValue = int.TryParse(value_s, out int value) && value >= 0;
                if (!validValue)
                {
                    Console.WriteLine(invalidValue);
                }
                else
                {
                    p.Value = value;
                }
            }
            while (!validValue);

            Console.WriteLine(askCondition);
            bool validCondition;
            do
            {
                string condition_s = Console.ReadLine();
                validCondition = int.TryParse(condition_s, out int condition) && condition >= 0 && condition <= 100;
                if (!validCondition)
                {
                    Console.WriteLine(invalidCondition);
                }
                else
                {
                    p.Condition = condition;
                }
            }
            while (!validCondition);

            Console.WriteLine(askYearPainted);
            bool validYear;
            do
            {
                string year_s = Console.ReadLine();
                validYear = int.TryParse(year_s, out int year);
                if (!validYear)
                {
                    Console.WriteLine(invalidNumber);
                }
                else
                {
                    p.YearPainted = year;
                }
            }
            while (!validYear);

            Console.WriteLine(askExhibit);

            bool validExhibitId;
            do
            {
                string id_s = Console.ReadLine();
                validExhibitId = int.TryParse(id_s, out int id) && id >= 1 && ExhibitExists(galleryLogic, id);
                if (!validExhibitId)
                {
                    Console.WriteLine(askId + " (exhibit ID)");
                }
                else
                {
                    p.ExhibitId = id;
                }
            }
            while (!validExhibitId);

            Console.WriteLine(askPerson);
            bool validPersonId;
            do
            {
                string id_s = Console.ReadLine();
                validPersonId = int.TryParse(id_s, out int id) && id >= 1 && PersonExists(personLogic, id);
                if (!validPersonId)
                {
                    Console.WriteLine(askId + " (person ID)");
                }
                else
                {
                    p.PersonId = id;
                }
            }
            while (!validPersonId);

            galleryLogic.AddPainting(p);
        }

        private static void GetOnePainting(GalleryLogic paintingLogic, string askId, string header)
        {
            Console.WriteLine(askId);
            bool validId;
            try
            {
                string id_s = Console.ReadLine();
                validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Painting p = paintingLogic.GetPainting(id);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(header);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                string id_text = "[ID]";
                string title = "[TITLE]";
                string painter = "[PAINTER]";
                string year = "[YEAR PAINTED]";
                string cond = "[CONDIITON]";
                string value = "[VALUE]";
                string pId = "[P. ID]";
                string xId = "[X. ID]";
                Console.WriteLine("{0, -5} {1, -50} {2, -35}    {3, -4} {4, 11} {5, 2} {6, 5} {7, 5}", id_text, title, painter, year, cond, value, pId, xId);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("{0, -5} {1, -50} {2, -35}    {3, -4} {4, 11}           {5, 2} {6, 5}   {7, 5}", p.PaintingId, p.Title, p.Painter, p.YearPainted, p.Condition, p.Value, p.PersonIdString, p.ExhibitIdString);
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void GetOneExhibit(GalleryLogic exhibitLogic, string askId, string header)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Exhibit x = exhibitLogic.GetExhibit(id);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(header);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string id_text = "[ID]";
                string title = "[TITLE]";
                string start = "[START]";
                string end = "[END]";
                string fee = "[FEE]";
                string rating = "[RATING]";
                Console.WriteLine("{0, -5} {1, -20} {2, -10}    {3, -10}   {4, -10} {5, -3}", id_text, title, start, end, fee, rating);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("{0, -5} {1, -20} {2, -10}    {3, -10}   {4, -10} {5, -3}", x.ExhibitId, x.Title, x.StartDateString, x.EndDateString, x.EntryFee, x.Rating);
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void GetOnePerson(PersonLogic personLogic, string askId, string header)
        {
            Console.WriteLine(askId);
            bool validId;
            try
            {
                string id_s = Console.ReadLine();
                validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Person p = personLogic.GetPersonById(id);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(header);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                string id_text = "[ID]";
                string name = "[NAME]";
                string birth = "[YOB]";
                string zip = "[ZIP CODE]";
                string phone = "[PHONE NO.]";
                string email = "[E-MAIL]";
                Console.WriteLine("{0, -5} {1, -35} {2, -10}    {3, -10}   {4, -10}     {5, -3}", id_text, name, birth, zip, phone, email);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("{0, -5} {1, -35} {2, -10}    {3, -10}   {4, -10}    {5, -3}", p.PersonId, p.Name, p.BirthYear, p.ZipCode, p.PhoneNumber, p.Email);
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void DeletePainting(GalleryLogic paintingLogic, string askId)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                paintingLogic.DeletePainting(id);
                Console.WriteLine("ID " + id + " deleted!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void DeletePerson(PersonLogic personLogic, string askId)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                personLogic.DeletePerson(id);
                Console.WriteLine("ID " + id + " deleted!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void DeleteExhibit(GalleryLogic exhibitLogic, string askId)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                exhibitLogic.DeleteExhibit(id);
                Console.WriteLine("ID " + id + " deleted!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangePaintingCondition(GalleryLogic paintingLogic, string askId, string askCondition)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askCondition);
                string condition_s = Console.ReadLine();
                bool validCondition = int.TryParse(condition_s, out int condition);
                if (!validCondition)
                {
                    condition = -1;
                }

                paintingLogic.ChangePaintingCondition(id, condition);
                Console.WriteLine("Condition of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangePaintingValue(GalleryLogic paintingLogic, string askId, string askValue)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askValue);
                string value_s = Console.ReadLine();
                bool validValue = int.TryParse(value_s, out int value);
                if (!validValue)
                {
                    value = -1;
                }

                paintingLogic.ChangePaintingValue(id, value);
                Console.WriteLine("Value of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangeEmail(PersonLogic personLogic, string askId, string askEmail)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askEmail);
                string email = Console.ReadLine();

                personLogic.ChangeEmail(id, email);
                Console.WriteLine("Email of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangePhoneNumber(PersonLogic personLogic, string askId, string askPhoneNo)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askPhoneNo);
                string phoneNo = Console.ReadLine();

                personLogic.ChangePhoneNumber(id, phoneNo);
                Console.WriteLine("Phone number of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangeZipCode(PersonLogic personLogic, string askId, string askZipCode)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askZipCode);
                string zip_s = Console.ReadLine();
                bool validZip = int.TryParse(zip_s, out int zip);
                if (!validZip)
                {
                    zip = -1;
                }

                personLogic.ChangeZipCode(id, zip);
                Console.WriteLine("Zip code of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangeRating(GalleryLogic exhibitLogic, string askId, string askRating)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askRating);
                string rating_s = Console.ReadLine();
                bool validRating = int.TryParse(rating_s, out int rating);
                if (!validRating)
                {
                    rating = -1;
                }

                exhibitLogic.ChangeExhibitRating(id, rating);
                Console.WriteLine("Rating of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void ChangeEntryFee(GalleryLogic exhibitLogic, string askId, string askFee)
        {
            Console.WriteLine(askId);
            try
            {
                string id_s = Console.ReadLine();
                bool validId = int.TryParse(id_s, out int id);
                if (!validId)
                {
                    id = -1;
                }

                Console.WriteLine(askFee);
                string fee_s = Console.ReadLine();
                bool validFee = int.TryParse(fee_s, out int fee);
                if (!validFee)
                {
                    fee = -1;
                }

                exhibitLogic.ChangeExhibitEntryFee(id, fee);
                Console.WriteLine("Entry fee of ID " + id + " successfully changed!");
            }
            catch (NoInstanceFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidChangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void GmailUsers(PersonLogic personLogic)
        {
            int count = 1;
            foreach (var item in personLogic.GmailUsers())
            {
                Console.WriteLine(count + ". Name: " + item.Name + "\t E-mail: " + item.Email);
            }

            Console.ReadKey();
        }

        private static void GmailUsersAsync(PersonLogic personLogic)
        {
            int count = 1;
            var result = personLogic.GmailUsersAsync().Result;
            foreach (var item in result)
            {
                Console.WriteLine(count + ". Name: " + item.Name + "\t E-mail: " + item.Email);
                count++;
            }

            Console.ReadKey();
        }

        private static void DisplayedPaintingsInSunShineExhibit(GalleryLogic galleryL)
        {
            int count = 1;
            foreach (var item in galleryL.PaintingsInSunshineExhibit())
            {
                Console.WriteLine(count + ". Name of painting: " + item.NAME);
                count++;
            }

            Console.ReadKey();
        }

        private static void DisplayedPaintingsInSunShineExhibitAsync(GalleryLogic galleryL)
        {
            int count = 1;
            var result = galleryL.PaintingsInSunshineExhibitAsync().Result;
            foreach (var item in result)
            {
                Console.WriteLine(count + ". Name of painting: " + item.NAME);
                count++;
            }

            Console.ReadKey();
        }

        private static void MostExpensivePaintingAndItsExhibit(GalleryLogic galleryL)
        {
            int count = 1;

            foreach (var item in galleryL.MostExpensivePaintingAndItsExhibit())
            {
                Console.WriteLine(count + ". Exhibit: " + item.EXHIBIT + ", Painting name: " + item.PAINTING);
                count++;
            }

            Console.ReadKey();
        }

        private static void MostExpensivePaintingAndItsExhibitAsync(GalleryLogic galleryL)
        {
            int count = 1;
            var result = galleryL.MostExpensivePaintingAndItsExhibitAsync().Result;
            foreach (var item in result)
            {
                Console.WriteLine(count + ". Exhibit: " + item.EXHIBIT + ", Painting name: " + item.PAINTING);
                count++;
            }

            Console.ReadKey();
        }

        private static void ExhibitsAndTheNumberofPaintingsItHasAsync(GalleryLogic galleryL)
        {
            int count = 1;
            var result = galleryL.ExhibitsAndTheNumberofPaintingsItHasAsync().Result;
            foreach (var item in result)
            {
                Console.WriteLine(count + ". Exhibit name: " + item.EXHIBIT + ";      Number of paintings: " + item.NUMBER_OF_PAINTINGS);
                count++;
            }

            Console.ReadKey();
        }

        private static void ExhibitsAndTheNumberofPaintingsItHas(GalleryLogic galleryL)
        {
            int count = 1;
            var result = galleryL.ExhibitsAndTheNumberofPaintingsItHas();
            foreach (var item in result)
            {
                Console.WriteLine(count + ". Exhibit name: " + item.EXHIBIT + ";      Number of paintings: " + item.NUMBER_OF_PAINTINGS);
                count++;
            }

            Console.ReadKey();
        }

        private void MainMenu()
        {
            var menu = new ConsoleMenu()
            .Add(">> EXHIBITS", () => ExhibitSubMenu(this.f.GalleryL))
            .Add(">> PEOPLE", () => PersonSubMenu(this.f.PersonL))
            .Add(">> PAINTINGS", () => PaintingsSubMenu(this.f.GalleryL, this.f.PersonL))
            .Add(">> LIST PAINTINGS IN SUNSHINE EXHIBIT", () => DisplayedPaintingsInSunShineExhibit(this.f.GalleryL))
            .Add(">> LIST EXHIBITS AND THE NUMBER OF PAINTINGS THEY HAVE DISPLAYED IN THEM", () => ExhibitsAndTheNumberofPaintingsItHas(this.f.GalleryL))
            .Add(">> GMAIL USERS", () => GmailUsers(this.f.PersonL))
            .Add(">> MOST EXPENSIVE PAINTING AND ITS EXHIBIT", () => MostExpensivePaintingAndItsExhibit(this.f.GalleryL))
            .Add(">> LIST PAINTINGS IN SUNSHINE EXHIBIT (ASYNC)", () => DisplayedPaintingsInSunShineExhibitAsync(this.f.GalleryL))
            .Add(">> MOST EXPENSIVE PAINTING AND ITS EXHIBIT (ASYNC)", () => MostExpensivePaintingAndItsExhibitAsync(this.f.GalleryL))
            .Add(">> LIST EXHIBITS AND THE NUMBER OF PAINTINGS THEY HAVE DISPLAYED IN THEM (ASYNC)", () => ExhibitsAndTheNumberofPaintingsItHasAsync(this.f.GalleryL))
            .Add(">> GMAIL USERS (ASYNC)", () => GmailUsersAsync(this.f.PersonL))
            .Add(">> EXIT", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
