using System;
using System.Collections.Generic;
using prep.utility;
using prep.utility.comparisons;
using prep.utility.matching;

namespace prep.collections
{
  /// <summary>
  /// The movie library.
  /// </summary>
  public class MovieLibrary
  {
    /// <summary>
    /// The movies.
    /// </summary>
    readonly IList<Movie> movies;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieLibrary"/> class.
    /// </summary>
    /// <param name="list_of_movies">
    /// The list_of_movies.
    /// </param>
    public MovieLibrary(IList<Movie> list_of_movies)
    {
      movies = list_of_movies;
    }

    /// <summary>
    /// The all_movies.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    /// <summary>
    /// The add.
    /// </summary>
    /// <param name="movie">
    /// The movie.
    /// </param>
    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    /// <summary>
    /// The all_movies_published_by_pixar.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    /// <summary>
    /// The sort_all_movies_by_title_descending.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
      string minTitle = null;
      bool nextFound;

      do
      {
        nextFound = false;
        Movie min = null;

        foreach (var movie in movies)
        {
          if (minTitle == null || minTitle.CompareTo(movie.title) < 1)
          {
            min = movie;
            minTitle = movie.title;
            nextFound = true;
          }
        }

        if (nextFound)
          yield return min;
      } while (nextFound);
    }

    /// <summary>
    /// The sort_all_movies_by_title_ascending.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      var comparer = Compare<Movie>.by(x => x.title);
      return all_movies().sort_using(comparer);
    }

    /// <summary>
    /// The sort_all_movies_by_movie_studio_and_year_published.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The sort_all_movies_by_date_published_descending.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      var comparer = Compare<Movie>.by_descending(x => x.date_published);
      return all_movies().sort_using(comparer);
    }

    /// <summary>
    /// The sort_all_movies_by_date_published_ascending.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      var comparer = Compare<Movie>.by(x => x.date_published);
      return all_movies().sort_using(comparer);
    }
  }
}
