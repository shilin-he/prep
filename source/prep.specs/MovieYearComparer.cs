using System;
using System.Collections.Generic;
using prep.collections;

namespace prep.specs
{
  public delegate int Comparer<in ItemToCompare>(ItemToCompare x, ItemToCompare y);

  public class MovieYearComparer : IComparer<Movie>
  {
    public int Compare(Movie x, Movie y)
    {
      // >0 == x > y
      // <0 == x < y
      // ==0 == x == y

      return x.date_published.Year - y.date_published.Year;
    }
  }

  public class Client
  {
    void run()
    {
      Comparison<Movie> year_comparison = (x, y) => x.date_published.Year - y.date_published.Year;
      var movies = new List<Movie>();
      movies.Sort(new MovieYearComparer().Compare);
    }
  }

}