using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ex1.scripts
{
	public class Database
	{
		public class UserInfo
		{
			public string Id;
			public string UserName;
			public string Password;
			public string Role;
			public string Email;
			public string SecretQuestion;
			public string SecretAnswer;
		}

		public static UserInfo GetUser(string name, string password)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["logindetailsConnectionString"].ConnectionString);
			conn.Open();


			string checkuser = "select * from usertable where username = '" + name + "'";
			SqlCommand com = new SqlCommand(checkuser, conn);

			UserInfo ui = null;
			SqlDataReader reader = com.ExecuteReader();
			if (reader.Read())
			{
				// 0 = id
				// 1 = username
				// 2 = password
				// 3 = role
				// 4 = email
				// 5 = secretquestion
				// 6 = secretanswer
				string pwd = PasswordHasher.GetPasswordHash(password);
				if (pwd == (string)reader[2])
				{
					ui = new UserInfo()
					{
						Id = ((string)reader[0]).Trim(),
						UserName = ((string)reader[1]).Trim(),
						Password = (string)reader[2],
						Role = ((string)reader[3]).Trim(),
						Email = ((string)reader[4]).Trim(),
						SecretQuestion = ((string)reader[5]).Trim(),
						SecretAnswer = ((string)reader[6]).Trim()
					};
				}
			}
			reader.Close();
			conn.Close();
			return ui;

		}

		public static void ChangePassword(UserInfo ui, string newPassword)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["logindetailsConnectionString"].ConnectionString);
			conn.Open();
			string str = string.Format("update usertable set password='{0}' where username='{1}';", newPassword, ui.UserName);
			SqlCommand com = new SqlCommand(str, conn);
			com.ExecuteNonQuery();
			conn.Close();
		}
	}
}