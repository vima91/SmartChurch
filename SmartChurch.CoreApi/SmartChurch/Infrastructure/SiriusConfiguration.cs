namespace SmartChurch.Infrastructure
{
    public static class SiriusConfiguration
    {
        public static string ConnectionString => Startup.Configuration["ConnectionStrings:SiriusDbContextConnection"];
        public static string AppSecret => Startup.Configuration["SiriusSettings:AppSecret"];
        public static string Salt => Startup.Configuration["SiriusSettings:PasswordSalt"];
        public static string AppName => Startup.Configuration["SiriusSettings:AppName"];
    }
}