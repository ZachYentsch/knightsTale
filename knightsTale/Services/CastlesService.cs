using System;
using System.Collections.Generic;
using knightsTale.Models;
using knightsTale.Repositories;

namespace knightsTale.Services
{
    public class CastlesService
    {
        private readonly CastlesRepository _repo;
        public CastlesService(CastlesRepository repo)
        {
            _repo = repo;
        }

        internal List<Castle> getAll()
        {
            return _repo.getAll();
        }

        internal Castle getById(int id)
        {
            Castle castle = _repo.getById(id);
            if (castle == null)
            {
                throw new Exception("Invalid Id");
            }
            return castle;
        }

        internal Castle create(Castle castle)
        {
            return _repo.create(castle);
        }

        internal void remove(int id, string userId)
        {
            Castle castle = getById(id);
            if (castle.CreatorId != userId)
            {
                throw new Exception("UnAuthorized");
            }
            _repo.remove(id);
        }
    }
}