using System;
using System.Collections.Generic;
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

    internal Keep Create(Keep k)
    {
      return _kp.Create(k);
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

    public List<Keep> GetAll()
    {
      return _kp.GetAll();
    }

    internal Keep Get(int id)
    {
      var k = _kp.GetById(id);
      if (k == null)
      {
        throw new Exception("Invalid Id");
      }
      return k;
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

    internal Keep GetById(int id)
    {
      return _kp.GetById(id);
    }

    // internal Keep GetUserKeeps(string userId)
    // {
    //   return _kp.GetUserKeeps(userId);
    // }


    //Get Profiles Keeps
  }
}