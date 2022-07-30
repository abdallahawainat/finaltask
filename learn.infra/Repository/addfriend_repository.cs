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
    public class addfriend_repository : Iaddfriend_repository
    {
        private readonly IDBcontext dbContext;
        public addfriend_repository(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }
        public bool addfriend(addfriend_dto addFriend)
        {
            var par1 = new DynamicParameters();
            par1.Add("n", addFriend.fromuser, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<getidbyname> result1 = dbContext.dbConnection.Query<getidbyname>("friends_package_api.getidbyname", par1, commandType: CommandType.StoredProcedure).ToList();
            string fu = result1.Select(x => x.userid).FirstOrDefault().ToString();
            int fid = Int32.Parse(fu);


            var par2 = new DynamicParameters();
            par2.Add("n", addFriend.touser, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<getidbyname> result2 = dbContext.dbConnection.Query<getidbyname>("friends_package_api.getidbyname", par2, commandType: CommandType.StoredProcedure).ToList();
            string tu = result2.Select(x => x.userid).FirstOrDefault().ToString();
            int tid = Int32.Parse(tu);


            var parameter1 = new DynamicParameters();
            parameter1.Add("fromuser", fid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter1.Add("touser", tid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("friends_package_api.addfriends", parameter1, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
