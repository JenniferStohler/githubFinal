using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    internal int Create(Keep KeepData)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, picture, creatorId)
      VALUES
      (@Name, @Description, @Picture, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, KeepData);

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

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
     SELECT
     k.*,
     a.*
     FROM keeps keep
     JOIN accounts account ON k.creatorId = a.id
     WHERE k.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) => { k.Creator = a; return k; }, splitOn: "id");
    }
    internal List<Keep> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT
      k.*,
      v.*
      FROM keeps k
      JOIN vaults v ON k.creatorId = v.id ";
      return _db.Query<Keep, Profile, Keep>(sql,
      (k, v) =>
      {
        k.Creator = v;
        return k;
      }, splitOn: "id").ToList();

    }
    internal IEnumerable<Keep> GetByCreatorId(string id)
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps keep
      JOIN account a ON k.creatorId = a.id
      WHERE k.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) => { k.Creator = a; return k; }, new { id }, splitOn: "id");
    }
    internal Keep Get(int id)
    {
      string sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON k.creatorId = account.id
    WHERE k.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) => { k.Creator = a; return k; }, new { id }, splitOn: "id").FirstOrDefault();
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

    internal bool Remove(int Id)
    {
      string sql = @"
     DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int remove = _db.Execute(sql, new { Id });
      return remove == 1;
    }


    // internal Keep GetById(int id)
    // {
    //   string sql = "SELECT * FROM keeps WHERE creatorId = @UserId";
    //   return _db.Query<Keep>(sql, new { id });
    // }


    //Create Vault Keeps
  }
}