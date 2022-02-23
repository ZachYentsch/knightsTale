using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using knightsTale.Models;

namespace knightsTale.Repositories
{
    public class ManorsRepository
    {
        private readonly IDbConnection _db;

        public ManorsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Manor Create(Manor manor)
        {
            string sql = @"
        INSERT INTO manors 
        (castleId, knightId)
        VALUES
        (@CastleId, @KnightId);
        SELECT LAST_INSERT_ID();";
            var id = _db.ExecuteScalar<int>(sql, manor);
            manor.Id = id;
            return manor;

        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM manors WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        public Manor GetById(int id)
        {
            string sql = "SELECT * FROM manors WHERE id = @id";
            return _db.QueryFirstOrDefault<Manor>(sql, new { id });
        }
    }
}