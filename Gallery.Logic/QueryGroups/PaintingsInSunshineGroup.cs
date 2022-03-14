// <copyright file="PaintingsInSunshineGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Gallery.Logic.QueryGroups
{
    /// <summary>
    /// Grouping class for determining the result of the related NONCRUD method.
    /// </summary>
    public class PaintingsInSunshineGroup
    {
        /// <summary>
        /// Gets or sets name of the painting.
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <returns>Hash code of NAME.</returns>
        public override int GetHashCode()
        {
            System.StringComparison s = System.StringComparison.CurrentCulture;
            return this.NAME.GetHashCode(s);
        }

        /// <summary>
        /// Override required for the equality to be asserted.
        /// </summary>
        /// <param name="obj">obj of type PaintingsInSunshineGroup.</param>
        /// <returns>True if is equal to obj, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is PaintingsInSunshineGroup && (obj as PaintingsInSunshineGroup).NAME == this.NAME)
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
