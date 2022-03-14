// <copyright file="MostExpensivePaintingAndItsExhibitGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.QueryGroups
{
    /// <summary>
    /// Grouping class for determining the result of the related NONCRUD method.
    /// </summary>
    public class MostExpensivePaintingAndItsExhibitGroup
    {
        /// <summary>
        /// Gets or sets name of the exhibit that the most expensive painting is displayed in.
        /// </summary>
        public string EXHIBIT { get; set; }

        /// <summary>
        /// Gets or sets title of the most expensive painting.
        /// </summary>
        public string PAINTING { get; set; }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <returns>Hash code of (EXHIBIT + PAINTING).</returns>
        public override int GetHashCode()
        {
            System.StringComparison s = System.StringComparison.CurrentCulture;
            return this.EXHIBIT.GetHashCode(s) + this.PAINTING.GetHashCode(s);
        }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <param name="obj">obj of type MostExpensivePaintingAndItsExhibitGroup.</param>
        /// <returns>True if is equal to obj, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MostExpensivePaintingAndItsExhibitGroup && (obj as MostExpensivePaintingAndItsExhibitGroup).EXHIBIT == this.EXHIBIT && (obj as MostExpensivePaintingAndItsExhibitGroup).PAINTING == this.PAINTING)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
