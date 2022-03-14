// <copyright file="IGalleryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Gallery.Data.Models;

    /// <summary>
    /// Gallery logic interface that consists of painting and exhibit repos.
    /// </summary>
    public interface IExhibitLogic
    {
      
        Exhibit GetExhibit(int id);

        void AddExhibit(Exhibit newExhibit);

      
        void DeleteExhibit(int id);


        public IQueryable<Exhibit> ReadAll();


        bool ExhibitExists(int id);


        void UpdateExhibit(Exhibit x);
    }
}
