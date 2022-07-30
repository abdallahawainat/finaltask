using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class addfriend_service : Iaddfriend_service
    {
        private readonly Iaddfriend_repository repo;
        public addfriend_service(Iaddfriend_repository repo)
        {
            this.repo = repo;
        }
        public bool addfriend(addfriend_dto addFriend)
        {
            return repo.addfriend(addFriend);
        }
    }
}
