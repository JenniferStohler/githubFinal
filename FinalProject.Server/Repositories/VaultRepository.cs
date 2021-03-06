using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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



    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { id }).FirstOrDefault();
    }

    // internal Vault Update(Vault vault, Vault v1, string v2, string id)
    // {
    //   throw new NotImplementedException();
    // }

    internal Vault Update(Vault v)
    {
      string sql = @"
            UPDATE vaults 
            SET 
                name = @Name,
                description = @Description
            WHERE id = @id;
            ";
      _db.Execute(sql, v);
      return v;
    }

    internal Vault Create(Vault v)
    {
      string sql = @"
        INSERT INTO vaults
        (name, description, isPrivate, creatorId)
        VALUES
        (@Name, @Description, @IsPrivate, @CreatorId);
        SELECT LAST_INSERT_ID();";
      try
      {
        v.Id = _db.ExecuteScalar<int>(sql, v);
        return v;
      }
      catch (System.Exception e)
      {

        System.Console.WriteLine(e.Message);
        throw e;
      }
    }

    internal List<Vault> GetVaultsByProfileId(string id)
    {
      string sql = @"
      SELECT 
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON v.creatorId = a.id
      WHERE v.creatorId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { id }, splitOn: "id").ToList();
    }



    internal List<Vault> GetAll()
    {
      string sql = @"
            SELECT 
            v.*,
            a.* 
            FROM vaults v
            JOIN accounts a ON v.creatorId = a.id;";
      return _db.Query<Vault, Profile, Vault>(sql,
      (v, a) =>
      {
        v.Creator = a;
        return v;
      }, splitOn: "id").ToList();
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
  //Get Profiles Vaults
}