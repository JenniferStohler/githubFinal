using System;
using System.Collections.Generic;
using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

public class VaultService
{

  private readonly VaultRepository _vp;
  private readonly KeepRepository _kp;
  public VaultService(VaultRepository vp, KeepRepository kp)
  {
    _vp = vp;
    _kp = kp;
  }
  internal List<Vault> GetAll()
  {
    return _vp.GetAll();
  }

  internal Vault Get(int id)
  {
    var v = _vp.GetById(id);
    if (v == null)
    {
      throw new Exception("Invalid Id");
    }
    return v;
  }

  internal Vault Create(Vault v)
  {
    return _vp.Create(v);
  }

  internal Vault Update(Vault v, string id)
  {
    Vault vault = _vp.GetById(v.Id);
    {
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.CreatorId != id)
      {
        throw new Exception("You do not have permission to edit this");
      }
      return _vp.Update(v);
    }
  }

  internal void Remove(int id, string userId)
  {
    Vault vault = Get(id);
    if (vault.CreatorId != userId)
    {
      throw new Exception("You do not have permission to delete this");
    }
    _vp.Remove(id);
  }
  internal List<Keep> GetKeepsByVaultId(int vaultId)
  {
    return _kp.GetKeepsByVaultId(vaultId);
  }
}
//Get ProfilesVaults
