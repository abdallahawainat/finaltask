using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class post_apiservice : Ipost_apiservice
    {
        private readonly Ipost_apirepository repo;
        public post_apiservice(Ipost_apirepository repo)
        {
            this.repo = repo;
        }
        public bool createpost(post_api post)
        {
            return repo.createpost(post);
        }

        public List<getpost_dto> getpost()
        {
            return repo.getpost();
        }
    }
}
