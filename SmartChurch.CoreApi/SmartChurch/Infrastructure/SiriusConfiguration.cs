namespace SmartChurch.Infrastructure
{
    public static class SiriusConfiguration
    {
        public static string ConnectionString => Startup.Configuration["ConnectionStrings:SiriusDbContextConnection"];
        public static string AppSecret => Startup.Configuration["SiriusSettings:AppSecret"];
        public static string Salt => Startup.Configuration["SiriusSettings:PasswordSalt"];
        public static string AppName => Startup.Configuration["SiriusSettings:AppName"];

        #region Email settings

        public static string EmailUserName => Startup.Configuration["EmailSettings:EmailUserName"];
        public static string EmailPassword => Startup.Configuration["EmailSettings:Password"];
        public static string EmailHost => Startup.Configuration["EmailSettings:Host"];
        public static string EmailPort => Startup.Configuration["EmailSettings:Port"];

        #endregion
    }
}