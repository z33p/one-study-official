namespace OneStudy.Lib.Providers
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }

        public class ConnectionString
        {
            public string Develop { get; set; }
        }
    }
}