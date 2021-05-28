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

}


