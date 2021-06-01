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
      throw new NotImplementedException();
    }

    // internal List<Keep> GetKeeps(int vaultId)
    // {
    //   throw new NotImplementedException();
    // }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id = id });
    }

    internal Keep Update(Keep k)
    {
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        picture = @Picture
        WHERE id = @id
        ";
      _db.Execute(sql, k);
      return k;
    }

    internal List<Keep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
    SELECT
    k.*,
    vk.Id AS vaultKeepId
    FROM vaultkeeps vk
    INNER JOIN keeps k ON k.id = vk.keepId
    WHERE vaultId = @VaultId AND isPrivate = 0";
      return _db.Query<Vaultkeep>(sql, new { VaultId });

    }

    // internal Keep GetById(int id)
    // {
    //   string sql = "SELECT * FROM keeps WHERE creatorId = @UserId";
    //   return _db.Query<Keep>(sql, new { id });
    // }

    internal bool Remove(int Id)
    {
      string sql = @"
     DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int remove = _db.Execute(sql, new { Id });
      return remove == 1;
    }

    internal List<Keep> GetAll()
    {
      throw new NotImplementedException();
    }
    //Create Vault Keeps
  }
}