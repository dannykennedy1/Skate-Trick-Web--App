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

        public Trick GetTrickById(int id)
        {
            Trick trick = null;

            string sql = "SELECT * FROM tricks WHERE trick_id = @trick_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trick_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                         trick = MapRowToTrick(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return trick;
        }

        public Trick AddNewTrick(Trick trick)
        {
            Trick newTrick = null;

            string sql = @"INSERT INTO tricks (name, stance, bagged, link)
                OUTPUT INSERTED.trick_id
                VALUES (@name,@stance,@bagged,@link)";

            int newTrickId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", trick.Name);
                    cmd.Parameters.AddWithValue("@stance", trick.Stance);
                    cmd.Parameters.AddWithValue("@bagged", trick.Bagged);
                    cmd.Parameters.AddWithValue("@link", trick.Link);

                    newTrickId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newTrick = GetTrickById(newTrickId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            
            return newTrick; 


        }

        public Trick UpdateTrick(Trick updatedTrick)
        {
            string sql = @"UPDATE tricks SET
                        name = @name,
                        stance = @stance,
                        bagged = @bagged,
                        link = @link
                        WHERE trick_id = @trick_id";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", updatedTrick.Name);
                    cmd.Parameters.AddWithValue("@stance", updatedTrick.Stance);
                    cmd.Parameters.AddWithValue("@bagged", updatedTrick.Bagged);
                    cmd.Parameters.AddWithValue("@link", updatedTrick.Link);
                    cmd.Parameters.AddWithValue("@trick_id", updatedTrick.Id);

                    int count = cmd.ExecuteNonQuery();

                    if(count == 1)
                    {
                        return updatedTrick;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }



        private Trick MapRowToTrick(SqlDataReader reader)
        {
            Trick trick = new Trick();

            trick.Id = Convert.ToInt32(reader["trick_id"]);
            trick.Name = Convert.ToString(reader["name"]);
            trick.Stance = Convert.ToString(reader["stance"]);
            trick.Bagged = Convert.ToString(reader["bagged"]);
            trick.Link = Convert.ToString(reader["link"]);

            return trick;
        }
    }
}
