using System;
using System.Data;
using Dapper;
using FinalProject.Server.Models;

namespace FinalProject.Server.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;
    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id =@id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }
  }
}