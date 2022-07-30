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
    public class user_apirepositoty : Iuser_apirepository
    {
        private readonly IDBcontext dbContext;
        public user_apirepositoty(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }
        public bool createtuser(user_api user)
        {
            var parameter = new DynamicParameters();

            parameter.Add("firstname", user.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("lastname", user.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("adr", user.address, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("user_package_api.createtuser", parameter, commandType: CommandType.StoredProcedure);
            var par = new DynamicParameters();
            par.Add("firstname", user.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("lastname", user.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("mail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("adr", user.address, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<user_iddto> result = dbContext.dbConnection.Query<user_iddto>("user_package_api.getidbyinfo", par,commandType: CommandType.StoredProcedure).ToList();


            string x = result.Select(x => x.id).FirstOrDefault().ToString();
            int uid = Int32.Parse(x);
            var parameter2 = new DynamicParameters();
            /* must get id user from procedure*/
            var username = user.fname + user.lname;
            parameter2.Add("uname", username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter2.Add("pass", "12345678", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter2.Add("uid", uid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("loginuser_package_api.createlogin", parameter2, commandType: CommandType.StoredProcedure);

            return true;

        }

        public List<getaddress_dto> getadress(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("id1", id, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<getaddress_dto> result2 = dbContext.dbConnection.Query<getaddress_dto>("user_package_api.getaddress", parameter, commandType: CommandType.StoredProcedure);
            return result2.ToList();
        }

        public List<user_api> getalluser()
        {
            var parameter = new DynamicParameters();
            IEnumerable<user_api> result2 = dbContext.dbConnection.Query<user_api>("user_package_api.getalluser", commandType: CommandType.StoredProcedure);
            return result2.ToList();
        }

        public List<countcity_dto> getcountcity()
        {
            var parameter = new DynamicParameters();
            IEnumerable<countcity_dto> result2 = dbContext.dbConnection.Query<countcity_dto>("user_package_api.getcountcity", commandType: CommandType.StoredProcedure);
            return result2.ToList();
        }
    }
}
