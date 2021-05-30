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

  }
}