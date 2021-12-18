using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Disney.Core.Entities;
using System;
using System.Linq;

namespace Disney.Infrastructure.Data.Seeds
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DisneyContext>();

                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new Genre()
                    {
                        Name = "Fantasy",
                        Image = "https://i0.wp.com/danielle-adams.com/wp-content/uploads/2018/03/fantasy_world.jpg?fit=1140%2C500&ssl=1"
                    },
                    new Genre()
                    {
                        Name = "Short film",
                        Image = "https://yumagic.com/wp-content/uploads/2019/01/cortometraje-disney.jpg"
                    });

                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new Movie()
                    {
                        Title = "Steamboat Willie",
                        Image = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS_xr_HyUuiEyhCwq_OsM_igVE7TqehBdz8RefNHcIrsG4QRQnd",
                        ReleaseDate = new DateTime(1928, 11, 18),
                        Score = Core.Enumerations.Score.Masterpiece,
                        GenreId = 2,
                        Characters = { 
                            new Character 
                            {
                                Name = "Mickey Mouse",
                                Image = "https://static.wikia.nocookie.net/doblaje/images/3/3a/Mickey_mouse-1097.jpg/revision/latest/top-crop/width/360/height/450?cb=20130925015641&path-prefix=es",
                                Age = 20,
                                Weight = 20,
                                History = "Mickey Mouse is a cartoon character created in 1928 by Walt Disney, and is the mascot of The Walt Disney Company. An anthropomorphic mouse who typically wears red shorts, large yellow shoes, and white gloves, Mickey is one of the world's most recognizable fictional characters."
                            }
                        }
                        
                    },
                    new Movie()
                    {
                        Title = "Dumbo",
                        Image = "https://es.web.img2.acsta.net/pictures/14/03/20/09/28/045404.jpg",
                        ReleaseDate = new DateTime(1941, 10, 23),
                        Score = Core.Enumerations.Score.VeryGood,
                        GenreId = 1,
                        Characters = { 
                            new Character 
                            {
                                Name = "Dumbo",
                                Image = "https://i0.wp.com/lanoticia.com/wp-content/uploads/2020/09/dumbo.png?fit=1200%2C675&ssl=1",
                                Age = 2,
                                Weight = 120,
                                History = "Dumbo is the titular protagonist of Disney's 1941 animated feature film of the same name. He is a young elephant and the son of Mrs. Jumbo. Dumbo is most famous for his giant floppy ears, which give him the ability to glide in the air. As an infant, he was harassed for his abnormal ears. While defending Dumbo from such bullies, Mrs. Jumbo was thrown into solitary confinement. To rescue his mother, Dumbo devotes himself to becoming a star, with Timothy Q. Mouse as his mentor and protector and then a flock of crows to help him and teach him to fly."
                            }
                        }
                    });

                    context.SaveChanges();
                }

            }
        }
    }
}
