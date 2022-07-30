using Dapper;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class getfriends_repository : Igetfriends_repository
    {
        private readonly IDBcontext dbContext;
        public getfriends_repository(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }
        public List<getfriends_dto> getfriens(int id)
        {
            var parameter1 = new DynamicParameters();
            parameter1.Add("id1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<getfriends_dto> result2 = dbContext.dbConnection.Query<getfriends_dto>("friends_package_api.getfriendnamebyid", parameter1, commandType: CommandType.StoredProcedure);
            return result2.ToList();
        }
    }
}
