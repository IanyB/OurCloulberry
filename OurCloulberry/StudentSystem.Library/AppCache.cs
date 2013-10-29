namespace StudentSystem.Library
{
    public class AppCache
    {
        public static Configuration Config { get; private set; }

        static AppCache()
        {
            Config = new Configuration();
        }
    }
}
