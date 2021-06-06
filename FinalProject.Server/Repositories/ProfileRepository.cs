using System;
using System.Collections.Generic;
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
    internal Profile Create(Profile newProfile)
    {
      string sql = @"
      INSERT INTO accounts
        (name, img, id, email)
        VALUES
        (@Name, @Img, @Id, @Email)";
      _db.Execute(sql, newProfile);
      return newProfile;
    }
    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

  }
}