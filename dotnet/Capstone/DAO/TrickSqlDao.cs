using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class TrickSqlDao : ITrickDao
    {
        private readonly string connectionString;

        public TrickSqlDao(string dbConnectionString)
        {
            this.connectionString = dbConnectionString;
        }

       public IList<Trick>GetTricks()
        {
            List<Trick> tricks = new List<Trick>();

            string sql = "SELECT * FROM tricks";

             try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Trick trick = MapRowToTrick(reader);
                        tricks.Add(trick);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return tricks;
        }
        
        private Trick MapRowToTrick(SqlDataReader reader)
        {
            Trick trick = new Trick();

            trick.Id = Convert.ToInt32(reader["trick_id"]);
            trick.Name = Convert.ToString(reader["name"]);
            trick.Stance = Convert.ToString(reader["stance"]);
            trick.Bagged = Convert.ToBoolean(reader["bagged"]);
            trick.Link = Convert.ToString(reader["link"]);

            return trick;
        }
    }
}
