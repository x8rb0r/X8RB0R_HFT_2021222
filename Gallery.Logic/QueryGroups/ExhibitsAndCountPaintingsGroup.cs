// <copyright file="ExhibitsAndCountPaintingsGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.QueryGroups
{
    /// <summary>
    /// Grouping class for determining the result of the related NONCRUD method.
    /// </summary>
    public class ExhibitsAndCountPaintingsGroup
    {
        /// <summary>
        /// Gets or sets title of the exhibit.
        /// </summary>
        public string EXHIBIT { get; set; }

        /// <summary>
        /// Gets or sets number of paintings the Exhibit has.
        /// </summary>
        public int NUMBER_OF_PAINTINGS { get; set; }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <returns>Hash code of (EXHIBIT + NUMBER_OF_PAINTINGS).</returns>
        public override int GetHashCode()
        {
            System.StringComparison s = System.StringComparison.CurrentCulture;
            return this.EXHIBIT.GetHashCode(s) + this.NUMBER_OF_PAINTINGS.GetHashCode();
        }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <param name="obj">obj of type ExhibitsAndCountPaintingsGroup.</param>
        /// <returns>True if is equal to obj, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ExhibitsAndCountPaintingsGroup && (obj as ExhibitsAndCountPaintingsGroup).EXHIBIT == this.EXHIBIT && (obj as ExhibitsAndCountPaintingsGroup).NUMBER_OF_PAINTINGS == this.NUMBER_OF_PAINTINGS)
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
