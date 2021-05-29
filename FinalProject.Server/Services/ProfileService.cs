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
  internal string GetVaultsById(string id)
  {
    return _repo.GetById(id)

  }
  internal string GetKeepsById(string keeps)
  {
    return _repo.GetByKeeps(keeps);
  }
  //   internal Profile GetOrCreateProfile(Profile userInfo)
  //   {
  //     Profile profile = _repo.GetById(userInfo);
  //     if (profile == null)
  //     {
  //       return _repo.Create(userInfo);
  //     }
  //     return profile;
  //   }
  //   //   internal Profile Edit(Profile editData, string userEmail)
  //   //   {
  //   //     Profile original = GetProfileByEmail(userEmail);
  //   //     original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
  //   //     original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
  //   //     return _repo.Edit(original);
  //   //   }
}


