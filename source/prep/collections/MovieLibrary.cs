// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieLibrary.cs" company="">
//   
// </copyright>
// <summary>
//   The movie library.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;

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
        private readonly IList<Movie> movies;

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
            foreach (Movie movie in movies)
                yield return movie;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="movie">
        /// The movie.
        /// </param>
        public void add(Movie movie)
        {
            bool found = false;

            foreach (Movie existingMovie in movies)
            {
                if (existingMovie.Equals(movie))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                movies.Add(movie);
        }

        /// <summary>
        /// The all_movies_published_by_pixar.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
                if (movie.production_studio == ProductionStudio.Pixar)
                    yield return movie;
        }

        /// <summary>
        /// The all_movies_published_by_pixar_or_disney.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
        }

        /// <summary>
        /// The all_movies_not_published_by_pixar.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
                if (movie.production_studio != ProductionStudio.Pixar)
                    yield return movie;
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
            foreach (var movie in movies)
                if (movie.date_published.Year > year)
                    yield return movie;
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
            foreach (var movie in movies)
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
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
            foreach (var movie in movies)
                if (movie.genre == Genre.kids )
                    yield return movie;
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
            foreach (var movie in movies)
                if (movie.genre == Genre.action)
                    yield return movie;
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