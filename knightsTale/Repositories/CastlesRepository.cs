using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knightsTale.Models;

namespace knightsTale.Repositories
{
    public class CastlesRepository
    {
        private readonly IDbConnection _db;
        public CastlesRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Castle> getAll()
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM castles c
            JOIN accounts a ON a.id = c.creatorId";
            return _db.Query<Castle, Profile, Castle>(sql, (c, p) =>
            {
                c.Creator = p;
                return c;
            }).ToList();
        }

        public Castle getById(int id)
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM castles c
            JOIN accounts a ON a.id = c.creatorId
            WHERE c.id = @id";
            return _db.Query<Castle, Profile, Castle>(sql, (c, p) =>
            {
                c.Creator = p;
                return c;
            }, new { id }).FirstOrDefault();
        }

        public Castle create(Castle castle)
        {
            string sql = @"
            INSERT INTO castles
            (name, locataion, imgUrl, creatorId)
            VALUES
            (@Name, @Locataion, @ImgUrl, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, castle);
            castle.Id = id;
            return castle;
        }

        public void remove(int id)
        {
            string sql = @"
            DELETE FROM castles
            WHERE id = @id
            LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}