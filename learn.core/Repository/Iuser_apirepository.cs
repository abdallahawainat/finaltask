using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface Iuser_apirepository
    {
        public bool createtuser(user_api user);
        public List<getaddress_dto> getadress(int id);

        public List<user_api> getalluser();

        public List<countcity_dto> getcountcity();

    }
}
