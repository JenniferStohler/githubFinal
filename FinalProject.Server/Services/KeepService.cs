using System;
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
      throw new NotImplementedException();
    }

    internal Vault Update(Vault k, string id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id, Account userInfo)
    {
      throw new NotImplementedException();
    }
  }
}