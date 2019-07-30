using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartChurch.DataAccess;
using SmartChurch.Infrastructure;
using SmartChurch.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace SmartChurch.Services
{
    public interface IUserService
    {
        IdentityUser Authenticate(string username, string password);
        IEnumerable<IdentityUser> GetAll();
        IdentityUser GetById(int id);
        IdentityUser Create(IdentityUser user, string password);
        void Update(IdentityUser user, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly SiriusDbContext _context;

        public UserService(SiriusDbContext context)
        {
            _context = context;
        }

        public IdentityUser Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _context.Users.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
            {
                return null;
            }

            // check if password is correct
            var hasher = new PasswordHasher<IdentityUser>();
            var passHashResult = hasher.VerifyHashedPassword(user, user.PasswordHash, password + SiriusConfiguration.Salt);

            if (passHashResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // authentication successful
            return user;
        }

        public IEnumerable<IdentityUser> GetAll()
        {
            return _context.Users;
        }

        public IdentityUser GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IdentityUser Create(IdentityUser user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            if (_context.Users.Any(x => x.UserName == user.UserName))
            {
                throw new AppException("Username \"" + user.UserName + "\" is already taken");
            }

            CreatePasswordHash(password + SiriusConfiguration.Salt, out var passwordHash);
            user.PasswordHash = Encoding.UTF8.GetString(passwordHash, 0, passwordHash.Length);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(IdentityUser userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            if (userParam.UserName != user.UserName)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.UserName == userParam.UserName))
                {
                    throw new AppException("Username " + userParam.UserName + " is already taken");
                }
            }

            // update user properties
            user.UserName = userParam.UserName;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out var passwordHash);

                user.PasswordHash = Encoding.UTF8.GetString(passwordHash, 0, passwordHash.Length);
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}