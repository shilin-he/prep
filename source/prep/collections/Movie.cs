// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Movie.cs" company="">
//   
// </copyright>
// <summary>
//   The movie.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using prep.utility;
using prep.utility.matching;

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

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public static IMatchA<Movie> is_published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }

    public static IMatchA<Movie> is_in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchA<Movie> is_published_by_pixar_or_disney()
    {
      return is_published_by(ProductionStudio.Pixar)
        .or(is_published_by(ProductionStudio.Disney));
    }
  }
}