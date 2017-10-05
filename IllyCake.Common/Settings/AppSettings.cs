namespace IllyCake.Common.Settings
{
    public class AppSettings
    {
        public string[] UserRoles { get; set; }

        public CommonSettings Common { get; set; }
    }

    public class CommonSettings
    {
        public string WebAddressDomain { get; set; }
    }
}
