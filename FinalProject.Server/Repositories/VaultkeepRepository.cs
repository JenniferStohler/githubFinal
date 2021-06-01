using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FinalProject.Server.Models;

namespace FinalProject.Server.Repositories
{
  public class VaultkeepRepository
  {

    private readonly IDbConnection _db;
    public VaultkeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //Create, Get Profiles Keeps, GetAll, GetKeepById, Update, Remove
    internal Vaultkeep Create(Vaultkeep vk)
    {
      string sql = @"
      INSERT INTO
      vaultkeeps(id, CreatorId, VaultId, KeepId)
      VALUES
      id: @Id,
      creatorId: @CreatorId,
      vaultId: @VaultId,
      keepId: KeepId,
      SELECT LAST_INSERT_ID();";

      vk.Id = _db.ExecuteScalar<int>(sql, vk);
      return vk;
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal List<Vaultkeep> GetAll(int id)
    {
      string sql = @"
      SELECT
      vk.*,
      a.*
      FROM vaultkeeps vk
      JOIN accounts a ON vk.creatorId = a.id;";
      return _db.Query<Vaultkeep, Profile, Vaultkeep>(sql,
      (vk, a) =>
      {
        vk.Creator = a;
        return vk;
      }, splitOn: "id").ToList();
    }

    internal Vaultkeep GetById(int id)
    {
      string sql = @"
      SELECT
      vk.*,
      a.*
      FROM vaultkeeps vk
      JOIN accounts a ON a.id = vk.creatorId
      WHERE vk.id = @id";
      return _db.Query<Vaultkeep, Account, Vaultkeep>(sql, (vk, a) =>
      {
        vk.Creator = a;
        return vk;
      }, new { id }).FirstOrDefault();
    }
  }
}