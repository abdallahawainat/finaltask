using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface Igetfriends_repository
    {
        public List<getfriends_dto> getfriens(int id);
    }
}
