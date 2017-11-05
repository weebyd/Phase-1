using GaragesManagement.Models;
using GaragesManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GaragesManagement.Database
{
    public class DB
    {
        private static Lazy<DB> _instance = new Lazy<DB>(() => new DB());

        public static DB Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private string connectionString = ConnectionString.GaragesConnectionString;

        public ResponseModel Login(string username, string password)
        {
            DBHelper helper = null;
            try
            {
                helper = new DBHelper(connectionString);
                List<SqlParameter> parsList = new List<SqlParameter>();
                parsList.Add(new SqlParameter("@_Username", username));
                parsList.Add(new SqlParameter("@_Password", password));
                parsList.Add(new SqlParameter("@_ResponseCode", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output });
                parsList.Add(new SqlParameter("@_Message", System.Data.SqlDbType.VarChar, 200) { Direction = System.Data.ParameterDirection.Output });
            
                helper.GetInstanceSP<ResponseModel>("Login", parsList.ToArray());

                return new ResponseModel
                {
                    ResponseCode = Convert.ToInt32(parsList[2].Value),
                    Message = Convert.ToString(parsList[3].Value)
                };
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (helper != null)
                {
                    helper.Close();
                }
            }
            return null;
        }
    }
}