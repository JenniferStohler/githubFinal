using System;
using System.Collections.Generic;
using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

namespace FinalProject.Server.Services
{
  public class VaultkeepService
  {
    //Create, Delete
    private readonly VaultkeepRepository _vkp;
    public VaultkeepService(VaultkeepRepository vkp)
    {
      _vkp = vkp;
    }

    internal Vaultkeep Create(Vaultkeep vk)
    {
      return _vkp.Create();
    }

    // internal List<Vaultkeep> GetAll()
    // {
    //   return _vkp.GetAll();
    // }
    // internal Vaultkeep Remove(VaultkeepService vks)
    // {
    //   return _vkp.Remove();
    // }
    public Vaultkeep GetAll(int id)
    {
      return _vkp.GetAll(id);
    }

    internal void Remove(int id, string userId)
    {
      Vaultkeep vaultkeep = GetAll(id);
      if (vaultkeep.CreatorId != userId)
      {
        throw new Exception("You do not have permission to delete this");
      }
      _vkp.Remove(id);
    }

    // internal object GetAll()
    // {
    //   throw new NotImplementedException();
    // }
  }
}