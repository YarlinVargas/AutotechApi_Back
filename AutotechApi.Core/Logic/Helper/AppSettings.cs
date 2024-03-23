namespace AutotechApi.Core.Logic.Helper
{
    public class AppSettings
    {
        public string ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public double ExpiracionJWT { get; set; }
        public string IssuerJWT { get; set; }
        public string AudienceJWT { get; set; }
    }
}
