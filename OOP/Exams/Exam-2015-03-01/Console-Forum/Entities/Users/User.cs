namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class User : IUser
    {
        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IList<IQuestion> Questions { get; private set; }
    }
}
