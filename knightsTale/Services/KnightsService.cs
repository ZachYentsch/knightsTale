using System;
using System.Collections.Generic;
using knightsTale.Models;
using knightsTale.Repositories;

namespace knightsTale.Services
{
    public class KnightsService
    {
        private readonly KnightsRepository _repo;
        public KnightsService(KnightsRepository repo)
        {
            _repo = repo;
        }

        internal List<Knight> getAll()
        {
            return _repo.getAll();
        }

        internal Knight getById(int id)
        {
            Knight knight = _repo.getById(id);
            if (knight == null)
            {
                throw new Exception("Invalid");
            }
            return knight;
        }

        internal Knight create(Knight knight)
        {
            return _repo.create(knight);
        }

        internal void remove(int id, string userId)
        {
            Knight knight = getById(id);
            if (knight.CreatorId != userId)
            {
                throw new Exception("Unauthorized");
            }
            _repo.remove(id);
        }
    }
}