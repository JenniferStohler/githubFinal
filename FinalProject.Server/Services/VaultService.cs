using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Server.Models;
using FinalProject.Server.Repositories;

public class VaultService
{

  private readonly VaultRepository _vp;
  private readonly VaultkeepRepository _vkp;
  private readonly KeepRepository _kp;

  public VaultService(VaultRepository vp, VaultkeepRepository vkp, KeepRepository kp)
  {
    _vp = vp;
    _vkp = vkp;
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

  public List<Vault> GetVaultsByProfileId(string id)
  {
    List<Vault> vaults = _vp.GetVaultsByProfileId(id);
    return vaults.ToList().FindAll(vaults => vaults.IsPrivate == false);
  }


  public List<VaultKeepViewModel> GetKeepsByVaultId(int vaultId)
  {
    return _vkp.GetKeepsByVaultId(vaultId);
  }
}
//Get ProfilesVaults
