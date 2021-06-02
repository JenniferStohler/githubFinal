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
    internal Profile Create(Profile newProfile)
    {
      string sql = @"
      INSERT INTO accounts
        (name, picture, id, email)
        VALUES
        (@Name, @Picture, @Id, @Email)";
      _db.Execute(sql, newProfile);
      return newProfile;
    }
    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }
    internal Profile GetVaultsById(string id)
    {
      throw new NotImplementedException();
    }

    // internal string Get(string keeps)
    // {
    //   throw new NotImplementedException();
    // }

    // internal string GetByKeepsId(string keeps)
    // {

    // }


    // internal Profile GetByProfileId(string id)
    // {
    //   throw new NotImplementedException();
    // }
  }
}