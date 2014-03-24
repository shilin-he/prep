using System;
using System.Collections.Generic;
using prep.utility;

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
    public delegate bool MovieMatcher(Movie movie);
      
    public bool is_published_by_pixar(Movie movie)
    {
      return movie.production_studio == ProductionStudio.Pixar;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      foreach (var movie in movies)
        if (is_published_by_pixar(movie))
          yield return movie;
    }

    public IEnumerable<Movie> all_movies_matching(MovieMatcher condition)
    {
//      return movies.all_items_matching(movie => condition(movie));
      return movies.all_items_matching(condition.Invoke);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return all_movies_matching(x => x.production_studio == ProductionStudio.Pixar || x.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return all_movies_matching(x => x.production_studio != ProductionStudio.Pixar);
    }

    /// <summary>
    /// The all_movies_published_after.
    /// </summary>
    /// <param name="year">
    /// The year.
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return all_movies_matching(x => x.date_published.Year > year);
    }

    /// <summary>
    /// The all_movies_published_between_years.
    /// </summary>
    /// <param name="startingYear">
    /// The starting year.
    /// </param>
    /// <param name="endingYear">
    /// The ending year.
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return all_movies_matching(x => x.date_published.Year >= startingYear && x.date_published.Year <= endingYear);
    }

    /// <summary>
    /// The all_kid_movies.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> all_kid_movies()
    {
      return all_movies_matching(x => x.genre == Genre.kids);
    }

    /// <summary>
    /// The all_action_movies.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public IEnumerable<Movie> all_action_movies()
    {
      return all_movies_matching(x => x.genre == Genre.action);
    }

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
      throw new NotImplementedException();
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
      throw new NotImplementedException();
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
      throw new NotImplementedException();
    }
  }
}