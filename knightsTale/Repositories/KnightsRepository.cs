using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knightsTale.Models;

namespace knightsTale.Repositories
{
    public class KnightsRepository
    {
        private readonly IDbConnection _db;
        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Knight> getAll()
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM knights k
            JOIN accounts a ON a.id = k.creatorId";
            return _db.Query<Knight, Profile, Knight>(sql, (k, p) =>
            {
                k.Creator = p;
                return k;
            }).ToList();
        }

        public Knight getById(int id)
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM knights k
            JOIN accounts ON a.id = k.creatorId
            WHERE k.id = @id";
            return _db.Query<Knight, Profile, Knight>(sql, (k, p) =>
            {
                k.Creator = p;
                return k;
            }, new { id }).FirstOrDefault();
        }

        public Knight create(Knight knight)
        {
            string sql = @"
            INSERT INTO knights
            (name, weaponType, imgUrl, creatorId)
            VALUES
            (@Name, @WeaponType, @ImgUrl, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, knight);
            knight.Id = id;
            return knight;
        }

        public void remove(int id)
        {
            string sql = @"
            DELETE FROM knights
            WHERE id = @id
            LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}