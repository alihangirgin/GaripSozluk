using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class EntryRatingService : IEntryRatingService
    {
        private readonly IEntryRatingRepository _entryRatingRepository;
        public EntryRatingService(IEntryRatingRepository entryRatingRepository)
        {
            _entryRatingRepository = entryRatingRepository;
        }


        public void AddLike(EntryRatingViewModel model)
        {
            var likeRecord = _entryRatingRepository.Get(x => x.UserId == model.UserId && x.EntryId == model.EntryId);

            if (likeRecord != null)
            {
                if(likeRecord.IsLiked==true)
                {
                    _entryRatingRepository.Remove(likeRecord);
                }
                else
                {
                    likeRecord.IsLiked = true;
                    likeRecord.UpdateDate = DateTime.Now;
                    _entryRatingRepository.SaveChanges();
                }
               
            }
            else
            {
                var entry = new EntryRating()
                {
                    EntryId = model.EntryId,
                    UserId = model.UserId,
                    IsLiked = true,
                    CreateDate = DateTime.Now,
                };


                var entity = _entryRatingRepository.Add(entry);

                try
                {
                    _entryRatingRepository.SaveChanges();
                    //return new EntryRatingViewModel() { EntryId = entity.EntryId, UserId=entry.UserId, IsLiked=entity.IsLiked };
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }


        public void AddDislike(EntryRatingViewModel model)
        {
            var likeRecord = _entryRatingRepository.Get(x => x.UserId == model.UserId && x.EntryId == model.EntryId);

            if (likeRecord != null)
            {
                if (likeRecord.IsLiked == false)
                {
                    _entryRatingRepository.Remove(likeRecord);
                }
                else
                {
                    likeRecord.IsLiked = false;
                    likeRecord.UpdateDate = DateTime.Now;
                    _entryRatingRepository.SaveChanges();
                }
            }
            else
            {
                var entry = new EntryRating()
                {
                    EntryId = model.EntryId,
                    UserId = model.UserId,
                    IsLiked = false,
                    CreateDate = DateTime.Now,
                };


                var entity = _entryRatingRepository.Add(entry);

                try
                {
                    _entryRatingRepository.SaveChanges();
                    //return new EntryRatingViewModel() { EntryId = entity.EntryId, UserId=entry.UserId, IsLiked=entity.IsLiked };
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }



        public int GetLikeCount(int id)
        {
            var count = _entryRatingRepository.GetAll(x => x.EntryId == id && x.IsLiked == true).Count();
            //item.Ratings.Where(x => x.IsLiked == true).Count();
            return count;
        }

        public int GetDislikeCount(int id)
        {
            var count = _entryRatingRepository.GetAll(x => x.EntryId == id && x.IsLiked == false).Count();
            //item.Ratings.Where(x => x.IsLiked == true).Count();
            return count;
        }


    }
}
