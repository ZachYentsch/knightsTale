using System;
using System.Collections.Generic;
using knightsTale.Models;
using knightsTale.Repositories;

namespace knightsTale.Services
{
    public class ManorsService
    {
        private readonly ManorsRepository _repo;
        private readonly AccountsRepository _accountsRepo;
        private readonly CastlesRepository _castlesRepo;

        public ManorsService(ManorsRepository repo, AccountsRepository accountsRepo, CastlesRepository castlesRepo)
        {
            _repo = repo;
            _accountsRepo = accountsRepo;
            _castlesRepo = castlesRepo;
        }

        internal Manor Create(Manor manor)
        {
            return _repo.Create(manor);
        }

        internal void Delete(int id)
        {
            Manor manorToDelete = _repo.GetById(id);
            if (manorToDelete == null)
            {
                throw new Exception("Member not found");
            }
            //   Manor manor = _castlesRepo.GetById(manorToDelete.CastleId);
            _repo.Delete(id);
        }

        internal List<CastleKnightsViewModel> GetMembers(int manorId)
        {
            //   return _accountsRepo.getManorById(manorId);
        }

        internal List<CastleKnightsViewModel> GetByAccountId(string id)
        {
            //   return _castlesRepo.GetCastlesByAccountId(id);
        }
    }
}