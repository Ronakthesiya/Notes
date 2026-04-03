using APICRUDDemo.MAL.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace APICRUDDemo.BAL
{
    public class BLSTD01
    {
        private readonly string _connectionString;

        public BLSTD01()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        public List<STD01> getAllStudents()
        {
            List<STD01> STDs = new List<STD01>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SelectAllSTD",connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            STDs.Add(new STD01
                            {
                                D01F01 = reader.GetInt32("D01F01"),
                                D01F02 = reader.GetString("D01F02"),
                                D01F03 = reader.GetInt32("D01F03"),
                                D01F04 = reader.GetString("D01F04")
                            }) ;
                        }
                    }
                }
            }

            return STDs;

        }

        public STD01 getStudentById(int id)
        {
            STD01 std = new STD01();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand("STDById", conn))
                {
                    command.Parameters.AddWithValue("p_id", id);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            std.D01F01 = reader.GetInt32("D01F01");
                            std.D01F02 = reader.GetString("D01F02");
                            std.D01F03 = reader.GetInt32("D01F03");
                            std.D01F04 = reader.GetString("D01F04");
                            
                        }
                    }
                }
            }

            return std;
        }

        public int AddStudent(STD01 std)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("STDInsert" , conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_D01F02",std.D01F02);
                    cmd.Parameters.AddWithValue("p_D01F03",std.D01F03);
                    cmd.Parameters.AddWithValue("p_D01F04",std.D01F04);

                    
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public int UpdateStudent(STD01 std)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("STDUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_D01F01", std.D01F01);
                    cmd.Parameters.AddWithValue("p_D01F02", std.D01F02);
                    cmd.Parameters.AddWithValue("p_D01F03", std.D01F03);
                    cmd.Parameters.AddWithValue("p_D01F04", std.D01F04);


                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteStudent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("STDDelete",conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_D01F01",id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}