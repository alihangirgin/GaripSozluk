using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class BlockedUserService : IBlockedUserService
    {

        private readonly IBlockedUserRepository _blockedUserRepository;
        public BlockedUserService(IBlockedUserRepository blockedUserRepository)
        {
            _blockedUserRepository = blockedUserRepository;
        }

        //Todo: ekleme, güncelleme,silme gibi işlemlerde önyüzdeki kullanıcıya işlem başarıyla gerçekleşti veya başarısız bilgisi vermek isteyebiliriz. böyle durumlarda alttaki metot için void dönmek yerine ya boolean true false ya da int 1,0, -1 gibi bir şeyler dönecek halde kullanmak daha iyi olur. Projenin sonraki aşamalarda nasıl gelişebileceğini düşünerek kod yazmak avantaj sağlar. 
        public void AddBlock(UserBlockVM model)
        {

            var blockRecord = _blockedUserRepository.Get(x => x.UserId == model.UserId && x.BlockedUserId == model.BlockedUserId);
            
            if ( blockRecord != null)
            {

                return;
            }
            
                var blockedUser = new BlockedUser()
            {
                BlockedUserId = model.BlockedUserId,
                UserId = model.UserId
            };
           //blockedUser.BlockedUserId = model.BlockedUserId,
           //blockedUser.UserId = model.UserId

            blockedUser.CreateDate = DateTime.Now;

            if(blockedUser.BlockedUserId != blockedUser.UserId)
            {
                var entity = _blockedUserRepository.Add(blockedUser);
                try
                {
                    _blockedUserRepository.SaveChanges();
                    //return new EntryViewModel() { Id = entity.Id, Content = entity.Content };
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }



        public BlockedUser Get(Expression<Func<BlockedUser, bool>> expression)
        {

            return _blockedUserRepository.Get(expression);
        }


        public IQueryable<BlockedUser> GetAll(int id)
        {
            return _blockedUserRepository.GetAllWithUserId(id);
        }


        public void RemoveBlock(UserBlockVM model)
        {
            var blockRecord = _blockedUserRepository.Get(x => x.UserId == model.UserId && x.BlockedUserId == model.BlockedUserId);

            if (blockRecord != null)
            {
                _blockedUserRepository.Remove(blockRecord);
                
            }
        }

    }
}
