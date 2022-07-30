using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class loginuser_apirepository : Iloginuser_apirepository
    {
        private readonly IDBcontext dbContext;
        public loginuser_apirepository(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }
        public loginuser_api auth(loginuser_api login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("username1",login.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<loginuser_api> result = dbContext.dbConnection.Query<loginuser_api>("loginuser_package_api.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
