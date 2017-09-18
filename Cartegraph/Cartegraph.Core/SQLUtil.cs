using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Core
{
    public class SQLUtil
    {
        private SQLUtil()
        {

        }

        public static int ExecuteNonQuery(string commandText, List<Tuple<string, object>> inputParams)
        {
            int numRecsAffected = 0;
            string sqlConnectionString = @"Server = .\SQLExpress; Database= CartegraphTest; User Id=sa; Password= Chicken27.";
            try
            {
                using (var sqlAccess = new SqlConnection { ConnectionString = sqlConnectionString })
                {
                    sqlAccess.Open();
                    using (var sqlCommand = sqlAccess.CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = commandText;

                        foreach (Tuple<string, object> parameter in inputParams)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter(string.Format("@{0}", parameter.Item1), parameter.Item2) { Direction = ParameterDirection.Input });
                        }

                        numRecsAffected = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
            return numRecsAffected;
        }

        public static DataTable ExecuteStoredProcedure(string commandText, List<Tuple<string, object>> parameterList, int commandTimeout = 35)
        {
            try
            {
                DataTable dataTable = new DataTable();

                string sqlConnectionString = @"Server = .\SQLExpress; Database= CartegraphTest; User Id=sa; Password= Chicken27.";

                using (var sqlAccess = new SqlConnection { ConnectionString = sqlConnectionString })
                {
                    sqlAccess.Open();
                    var sqlCommand = sqlAccess.CreateCommand();

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = commandText;
                    sqlCommand.CommandTimeout = commandTimeout;
                    if (parameterList != null)
                    {
                        foreach (Tuple<string, Object> parameter in parameterList)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter(string.Format("@{0}", parameter.Item1), parameter.Item2) { Direction = ParameterDirection.Input });
                        }
                    }

                    var dataSet = new DataSet();

                    using (var sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlCommand;
                        sqlAdapter.Fill(dataSet);
                    }

                    if (dataSet.Tables.Count > 0)
                    {
                        dataTable = dataSet.Tables[dataSet.Tables.Count - 1];
                    }
                }
                return dataTable;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
