using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class user_apiservice : Iuser_apiservice
    {
        private readonly Iuser_apirepository repo;
        public user_apiservice(Iuser_apirepository repo)
        {
            this.repo = repo;
        }
        public bool createtuser(user_api user)
        {
            return repo.createtuser(user);
        }

        public List<getaddress_dto> getadress(int id)
        {
            return repo.getadress(id);
        }

        public List<user_api> getalluser()
        {
            return repo.getalluser();
        }

        public List<countcity_dto> getcountcity()
        {
            return repo.getcountcity();
        }
    }
}
