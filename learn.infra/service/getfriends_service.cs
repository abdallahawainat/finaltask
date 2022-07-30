using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class getfriends_service : Igetfriends_service
    {
        private readonly Igetfriends_repository repo;
        public getfriends_service(Igetfriends_repository repo)
        {
            this.repo = repo;
        }
        public List<getfriends_dto> getfriens(int id)
        {
            return repo.getfriens(id);
        }
    }
}
