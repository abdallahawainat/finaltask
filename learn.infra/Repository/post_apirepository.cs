using Dapper;
using learn.core.Data;
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
    public class post_apirepository : Ipost_apirepository
    {
        private readonly IDBcontext dbContext;
        public post_apirepository(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }
        public bool createpost(post_api post)
        {
            var parameter = new DynamicParameters();

            DateTime dnow = DateTime.Now;

            parameter.Add("fromu", post.fromuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sub", post.subject, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("pdate", dnow, dbType: DbType.String, direction: ParameterDirection.Input);
           
            dbContext.dbConnection.ExecuteAsync("post_package_api.createpost", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<getpost_dto> getpost()
        {
            IEnumerable<getpost_dto> result = dbContext.dbConnection.Query<getpost_dto>("post_package_api.getallpost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
