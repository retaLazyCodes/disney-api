using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repositories
{
    public static class Extensions 
    {
        public static void TryAdd(this List<int> l, int value, List<int> existingIds)
        {
            foreach (var id in existingIds) 
            {
                var exist = existingIds.Find(x => x == value);
                if (exist == 0) {
                    l.Add(value);
                }
            }
        }
    }


    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        private static List<int> newMovieIds = new List<int>(); 

        public CharacterRepository(DisneyContext context) : base(context)
        {
        }

        public Character InsertCharacter(Character character, List<int> moviesIds)
        {
            _context.Characters.Add(character);
            // _context.SaveChanges();

            if (moviesIds != null) 
            {
                foreach (var id in moviesIds)
                {
                    var characterMovie = new CharacterMovie()
                    {
                        CharacterId = character.Id,
                        MovieId = id
                    };

                    _context.CharacterMovie.Add(characterMovie);
                }
            }

            _context.SaveChanges();
            return character;
        }

        

        public async Task<bool> UpdateCharacter(Character character, List<int> moviesIds)
        {
            _context.Characters.Update(character);

            if (moviesIds != null) 
            {
                var existingCharacter = await _context.Characters
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(x => x.Id == character.Id);

                
                var movieIdsOfExistingCharacter = new List<int>();
                foreach (var movie in existingCharacter.Movies) 
                {
                    movieIdsOfExistingCharacter.Add(movie.Id);
                }

                foreach (var id in moviesIds)
                {
                    newMovieIds.TryAdd(id, movieIdsOfExistingCharacter);
                }


                foreach (var id in newMovieIds)
                {
                    var characterMovie = new CharacterMovie()
                    {
                        CharacterId = character.Id,
                        MovieId = id
                    };

                    _context.CharacterMovie.Add(characterMovie);
                }
            }

            _context.SaveChanges();
            return true;
        }

        public async Task<CharacterWithMovies> GetCharacterDetailById(int characterId)
        {
            var character = await _context.Characters
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(x => x.Id == characterId);

            if (character == null)
            {
                return null;
            }

            var movieList = new List<MovieDto>();

            foreach (var movie in character.Movies)
            {
                var movieDto = new MovieDto()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Image = movie.Image,
                    ReleaseDate = movie.ReleaseDate,
                    Score = movie.Score,
                    GenreId = movie.GenreId
                };

                movieList.Add(movieDto);
            }

            var characterWithMovies = new CharacterWithMovies()
            {
                Id = character.Id,
                Name = character.Name,
                Image = character.Image,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History,
                Movies = movieList
            };

            return characterWithMovies;
        }

        public IEnumerable<Character> GetCharactersByMovie(int movieId)
        {
            var allCharacters = _context.Characters
                .Where(c => c.Movies.Any(m => m.Id == movieId));
            return allCharacters.AsEnumerable();
        }

    }
}