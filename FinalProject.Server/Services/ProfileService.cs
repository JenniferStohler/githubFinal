using System;
using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

public class ProfileService
{
  private readonly ProfileRepository _repo;
  public ProfileService(ProfileRepository repo)
  {
    _repo = repo;
  }
  internal Profile GetProfileById(string id)
  {
    return _repo.GetById(id);
  }
  // internal string GetVaultById(string id)
  // {
  //   return _repo.GetById(vaultId);

  // }

  internal Profile GetOrCreateProfile(string id)
  {
    Profile profile = _repo.GetById(id);
    if (profile == null)
    {
      return _repo.Create(profile);
    }
    return profile;
  }
  //   //   internal Profile Edit(Profile editData, string userEmail)
  //   //   {
  //   //     Profile original = GetProfileByEmail(userEmail);
  //   //     original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
  //   //     original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
  //   //     return _repo.Edit(original);
  //   //   }
}


