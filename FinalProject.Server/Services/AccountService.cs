using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

namespace FinalProject.Server.Services
{
  public class AccountService
  {
    private readonly AccountRepository _repo;
    public AccountService(AccountRepository repo)
    {
      _repo = repo;
    }


    internal Account GetOrCreateProfile(Account userInfo)
    {
      Account profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;

    }
    internal Profile GetProfileById(string id)
    {
      return _repo.GetById(id);
    }
    // }
    // internal Account Edit(Account editData, string userEmail)
    // {
    //   Profile original = GetProfileById);
    //   original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    //   original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    //   return _repo.Edit(original);
    // }
  }
}