// <copyright file="Application.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG3_2020_2_X8RB0R
{
    using System;
    using System.Globalization;
    using System.Linq;
    using ConsoleTools;
    using Gallery.Data;
    using Gallery.Data.Models;
    using Gallery.Logic;
    using Gallery.Logic.Classes;
    using Gallery.Program;
    using Gallery.Repository;

    /// <summary>
    /// Main class used for calling Console functions (highest layer).
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Main method used for calling Console functions.
        /// </summary>
        private static void Main()
        {
            Factory factory = new Factory();
            ConsoleCommands commands = new ConsoleCommands(factory);
        }
    }
}
