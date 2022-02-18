using GameFinder.Data;
using GameFinder.Models;
using GameFinder.Models.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class RatingService
    {
        private readonly Guid _userId;
        private readonly string _userName;

        public RatingService(Guid userId, string userName)
        {
            _userId = userId;
            _userName = userName;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity = new Rating()
            {
                GameId = model.GameId,
                Author = _userId,
                Review = model.Review,
                VisualsScore = model.VisualScore,
                GameplayScore = model.GameplayScore,
                SoundScore = model.SoundScore
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Ratings.Select(r => new RatingListItem()
                {
                    RatingId = r.RatingId,
                    GameName = r.Game.Title,
                    OverallRating = r.OverallScore
                });

                return list.ToArray();
            }
        }

        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Find(id);

                return new RatingDetail()
                {
                    RatingId = entity.RatingId,
                    AuthorId = entity.Author,
                    Author = entity.AuthorName,
                    GameId = entity.GameId,
                    GameName = entity.Game.Title,
                    Review = entity.Review,
                    VisualScore = entity.VisualsScore,
                    GameplayScore = entity.GameplayScore,
                    SoundScore = entity.SoundScore,
                    OverallScore = entity.OverallScore
                };
            }
        }

        public bool UpdateRating(int id, RatingUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Find(id);

                entity.GameId = model.GameId;
                entity.Review = model.Review;
                entity.VisualsScore = model.VisualScore;
                entity.GameplayScore = model.GameplayScore;
                entity.SoundScore = model.SoundScore;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Find(id);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
