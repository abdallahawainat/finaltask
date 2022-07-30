using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface Ipost_apirepository
    {
        public bool createpost(post_api post);

        public List<getpost_dto> getpost();
    }
}
