// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Movie.cs" company="">
//   
// </copyright>
// <summary>
//   The movie.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;

namespace prep.collections
{
    /// <summary>
    /// The movie.
    /// </summary>
    public class Movie : IEquatable<Movie>
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the production_studio.
        /// </summary>
        public ProductionStudio production_studio { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        public Genre genre { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int rating { get; set; }

        /// <summary>
        /// Gets or sets the date_published.
        /// </summary>
        public DateTime date_published { get; set; }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(Movie other)
        {
            return other != null
                   && (ReferenceEquals(this, other)
                       || other.title.Equals(title));
        }
    }
}