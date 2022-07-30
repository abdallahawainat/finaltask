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
    public class sendmessage_repository : Isendmessage_repository
    {
        private readonly IDBcontext dbContext;
        public sendmessage_repository(IDBcontext dbContext)
        {

            this.dbContext = dbContext;
        }

        public List<filtermessage> filtermessages(getdate getd)
        {
            var parameter = new DynamicParameters();
        
            parameter.Add("startdate", getd.startdate, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("enddate", getd.enddate, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<filtermessage> result = dbContext.dbConnection.Query<filtermessage>("message_package_api.getmessagebetweeandate", parameter , commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<message_api> searchmessage(string message)
        {
            var parameter = new DynamicParameters();

            parameter.Add("text", message, dbType: DbType.String, direction: ParameterDirection.Input);
           

            IEnumerable<message_api> result = dbContext.dbConnection.Query<message_api>("message_package_api.filtermessage", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string sendmessage(sendmessage_dto s)
        {
            var par1 = new DynamicParameters();
            par1.Add("n", s.fromuser, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<getidbyname> result1 = dbContext.dbConnection.Query<getidbyname>("message_package_api.getidbyusername", par1, commandType: CommandType.StoredProcedure).ToList();
            string fu = result1.Select(x => x.userid).FirstOrDefault().ToString();
            int fid = Int32.Parse(fu);


            var par2 = new DynamicParameters();
            par2.Add("n", s.touser, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<getidbyname> result2 = dbContext.dbConnection.Query<getidbyname>("message_package_api.getidbyusername", par2, commandType: CommandType.StoredProcedure).ToList();
            string tu = result2.Select(x => x.userid).FirstOrDefault().ToString();
            int tid = Int32.Parse(tu);

            var parameter1 = new DynamicParameters();
            var datenow = DateTime.Now;
            parameter1.Add("fromuser", fid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter1.Add("touser", tid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter1.Add("mes", s.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter1.Add("sdate", datenow, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("message_package_api.sendmessage", parameter1, commandType: CommandType.StoredProcedure);

        
            dbContext.dbConnection.ExecuteAsync("message_package_api.recivedmessage", parameter1, commandType: CommandType.StoredProcedure);
            return "true";
        }

        public List<totalmessages_dto> totalmessages()
        {
            IEnumerable<totalmessages_dto> result = dbContext.dbConnection.Query<totalmessages_dto>("message_package_api.gettotalmessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<totalmessagesforeachuser_dto> totalrecivedmessages()
        {
            IEnumerable<totalmessagesforeachuser_dto> result = dbContext.dbConnection.Query<totalmessagesforeachuser_dto>("message_package_api.gettotalmessagesforeachuser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
