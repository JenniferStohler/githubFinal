using System;
using System.Data;
using Dapper;
using FinalProject.Server.Models;
using FinalProject.Server.Services;

namespace FinalProject.Server.Repositories
{
  public class AccountRepository
  {
    // internal AccountService GetByEmail(string email)
    // {
    //   throw new NotImplementedException();
    // }

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

    internal Account Create(Account newAccount)
    {
      string sql = @"
      INSERT INTO accounts
        (name, picture, email, id)
        VALUES
        (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, newAccount);
      return newAccount;
    }

    internal Account Edit(Account update)
    {
      string sql = @"
        UPDATE accounts
        SET
        name = @Name,
        img= @Img,
        WHERE id = @Id;";
      _db.Execute(sql, update);
      return update;
    }
  }
}