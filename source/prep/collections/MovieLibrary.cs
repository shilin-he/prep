using System;
using System.Collections.Generic;
using System.Linq;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      foreach (var movie in movies)
      {
        yield return movie;
      }
    }

    public void add(Movie movie)
    {
      if (movies.Contains(movie) || movies.Any(m => m.title == movie.title)) return;
      movies.Add(movie);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return find_movies_meet(m => m.production_studio == ProductionStudio.Pixar);
    }

    IEnumerable<Movie> find_movies_meet(Predicate<Movie> condition)
    {
      foreach (var movie in movies)
      {
        if (condition(movie)) yield return movie;
      }
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return find_movies_meet(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return find_movies_meet(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return find_movies_meet(m => m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return find_movies_meet(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return find_movies_meet(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
      return find_movies_meet(m => m.genre == Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
