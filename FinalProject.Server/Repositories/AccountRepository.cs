using System;
using System.Data;
using Dapper;
using FinalProject.Server.Models;
using FinalProject.Server.Services;

namespace FinalProject.Server.Repositories
{
  public class AccountRepository
  {
    internal AccountService GetByEmail(string email)
    {
      throw new NotImplementedException();
    }

    private readonly IDbConnection _db;
    public AccountRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Account GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id =@id";
      return _db.QueryFirstOrDefault<Account>(sql, new { id });
    }

    internal Account Create(Account userInfo)
    {
      throw new NotImplementedException();
    }

    internal Account Edit(Account original)
    {
      throw new NotImplementedException();
    }

    // internal string GetByEmail(string email)
    // {

    // }

    // internal Account Create(Account userInfo)
    // {

    // }

    // internal Account Edit(Account original)
    // {

    // }
  }
}