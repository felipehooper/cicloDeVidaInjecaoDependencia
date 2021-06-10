using System;

namespace POC_DI.Services
{
    public class UserService
    {
        public UserService(
            IUserTransient transient,
            IUserScoped scoped,
            IUserSingleton singleton)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
        }

        public IUserTransient Transient { get; }
        public IUserScoped Scoped { get; }
        public IUserSingleton Singleton { get; }
    }

    public class User : IUserTransient,
        IUserScoped,
        IUserSingleton
    {
        public User() : this(Guid.NewGuid())
        {
        }

        public User(Guid id)
        {
            UserId = id;
        }

        public Guid UserId { get; private set; }
    }

    public interface IUser
    {
        Guid UserId { get; }
    }

    public interface IUserTransient : IUser
    {
    }

    public interface IUserScoped : IUser
    {
    }

    public interface IUserSingleton : IUser
    {
    }
}