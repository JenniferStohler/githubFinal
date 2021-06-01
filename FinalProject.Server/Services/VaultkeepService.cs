using System;
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

    internal Vaultkeep Create(VaultkeepService vk)
    {
      return _vkp.Create();
    }

    internal object GetAll()
    {
      throw new NotImplementedException();
    }
    // internal Vaultkeep Remove(VaultkeepService vks)
    // {
    //   return _vkp.Remove();
    // }

    internal void Remove(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}