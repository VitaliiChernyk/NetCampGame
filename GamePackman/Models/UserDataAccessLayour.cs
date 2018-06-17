using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamePackman.Models
{
    public class UserDataAccessLayour
    {
        public static IConfiguration Configuration { get; set; }
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }
        string connectionString = GetConnectionString();
        public string RegisterUser(UserData userData)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", userData.FirstName);
                cmd.Parameters.AddWithValue("@LastName", userData.LastName);
                cmd.Parameters.AddWithValue("@Login", userData.UserLogin);
                cmd.Parameters.AddWithValue("@Password", userData.Password);
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();
                return result;
            }
        }
        public string ValidateLogin(UserData userData)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUserLogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", userData.UserLogin);
                cmd.Parameters.AddWithValue("@Password", userData.Password);
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();
                return result;
            }
        }
    }
}
