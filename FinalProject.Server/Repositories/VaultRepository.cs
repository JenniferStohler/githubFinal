using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FinalProject.Server.Models;

namespace FinalProject.Server.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Vault Create(Vault v)
    {
      string sql = @"
        INSERT INTO
        vaults(name, description, CreatorId)
        VALUES
        name: @Name,
        description: @Description,
        creatorId: @CreatorId,
        SELECT LAST_INSERT_ID();";

      v.Id = _db.ExecuteScalar<int>(sql, v);
      return v;
    }

    internal Vault Create()
    {
      throw new NotImplementedException();
    }

    internal Vault GetById(int id)
    {
      throw new NotImplementedException();
    }

    // internal Vault Update(Vault vault, Vault v1, string v2, string id)
    // {
    //   throw new NotImplementedException();
    // }

    internal Vault Update(Vault v)
    {
      throw new NotImplementedException();
    }

    internal object GetById()
    {
      throw new NotImplementedException();
    }

    internal List<Vault> GetAll()
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}