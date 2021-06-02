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

  internal Profile GetOrCreateProfile(string id, Profile userInfo)
  {
    Profile profile = _repo.GetById(id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

}


