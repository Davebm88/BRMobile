using SQLite;

namespace BRMobile
{
    public static class Constants
    {
        #region WebService
        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "https"; // or http
        public static string Port = "7217";//"5001";
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/cap/{{0}}";
        #endregion WebService

        #region SQLite
        private const string dbFileName = "SQLite.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
                                             SQLiteOpenFlags.Create |
                                             SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, dbFileName);
        #endregion SQLite
    }
}