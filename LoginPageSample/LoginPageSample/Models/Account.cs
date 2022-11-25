using System;
using SQLite;

namespace LoginPageSample.Models
{
	public class Account
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Account()
		{            
        }
	}
}

