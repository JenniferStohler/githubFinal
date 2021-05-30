using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FinalProject.Server.Models;

namespace FinalProject.Server.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    // internal List<Keep> GetKeeps(int vaultId)
    // {
    //   throw new NotImplementedException();
    // }

    internal Keep Create(Keep k)
    {
      string sql = @"
      INSERT INTO
      keeps(name, description, picture, views, shares, keeps, creatorId, vaultId)
      VALUES
      name = @Name,
      description = @Description,
      picture = @Picture,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps,
      creatorId = @CreatorId,
      vaultId = @VaultId;
      SELECT LAST_INSERT_ID();
      ";
      k.Id = _db.ExecuteScalar<int>(sql, k);
      return k;
    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT FROM keeps WHERE id = @Id";
      return _dbQuery.FirstOrDefault<Keep>(sql, new { Id = id });
    }

    internal Keep Update(Keep k)
    {
      throw new NotImplementedException();
    }

    internal void Remove(int id)
    {
      throw new NotImplementedException();
    }

    internal List<Keep> GetAll()
    {
      throw new NotImplementedException();
    }
    //Create Vault Keeps
  }
}