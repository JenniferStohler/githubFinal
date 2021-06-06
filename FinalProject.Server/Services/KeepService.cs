using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

namespace FinalProject.Server.Services
{
  public class KeepService
  {
    private readonly KeepRepository _kp;
    public KeepService(KeepRepository kp)
    {
      _kp = kp;
    }

    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _kp.Create(newKeep);
      return newKeep;
    }

    internal Keep Update(Keep k, string id)
    {

      Keep keep = _kp.GetById(k.Id);

      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (keep.CreatorId != id)
      {
        throw new Exception("You do not have permission to edit this");
      }

      return _kp.Update(k);
    }

    public IEnumerable<Keep> GetAll()
    {
      IEnumerable<Keep> keeps = _kp.GetAll();
      return keeps.ToList();
    }

    public Keep Get(int id)
    {
      Keep original = _kp.GetById(id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      return original;
    }

    internal void Remove(int id, string userId)
    {
      Keep keep = Get(id);
      if (keep.CreatorId != userId)
      {
        throw new Exception("You do not have permission to delete this");
      }
      _kp.Remove(id);
    }

    internal IEnumerable<Keep> getKeepsByAccountId(string id)
    {
      return _kp.GetByCreatorId(id);
    }

    internal Keep GetById(int id)
    {

      return _kp.GetById(id);
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _kp.GetKeepsByVaultId(id).ToList().FindAll(k => k.Published);
    }
    internal IEnumerable<Keep> GetKeepsByProfileId(string id)
    {
      return _kp.GetByCreatorId(id).ToList().FindAll(k => k.Published);
    }

    // internal IEnumerable<Keep> GetByProfileId(string id)
    // {
    //   return _kp.GetByCreatorId(id).ToList().FindAll(k => k.Published);
    // }



    // internal Keep GetUserKeeps(string userId)
    // {
    //   return _kp.GetUserKeeps(userId);
    // }


    //Get Profiles Keeps
  }
}