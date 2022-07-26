using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToDocs.Configurations
{
    internal static class GlobalSettings
    {
        public static CoreSettings Configuration { get; set; }
    }
    public class CoreSettings
    {
        public const string Core = "Core";
        public const string AuthService = "Auth";
        private static string GetFileName()
        {
#if RELEASE
			return "Core.Configuration.Prod.json";
#endif
#if DEBUG
            return "Core.Configuration.Dev.json";
#endif
        }

        CoreSettings()
        {
            Services = new List<Service>();
        }

        public List<Service> Services { get; set; }
        public JwtConfig Jwt { set; get; }
        public FileDataSettings FileDataSettings { get; set; }
        public SmtpData SmtpData { get; set; }

        public static JwtConfig GetJwtConfig()
        {
            return LoadJson()?.Jwt;
        }

        public static FileDataSettings GetFileDataSettings()
        {
            return LoadJson()?.FileDataSettings;
        }

        public static SmtpData GetSmtpData()
        {
            return LoadJson()?.SmtpData;
        }

        public static CoreSettings GetSettings()
        {
            return LoadJson();
        }
        public static Service GetService(string serviceName)
        {
            var settings = LoadJson();
            return settings.Services.FirstOrDefault(x => x.ServiceName == serviceName);
        }
        private static CoreSettings LoadJson()
        {
            try
            {
                CoreSettings config = null;
                if (GlobalSettings.Configuration != null) return GlobalSettings.Configuration;
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var file = GetFileName();
                string name = Assembly.GetExecutingAssembly().Location;
                string folders = Directory.GetCurrentDirectory();
                configPath = Path.Combine(folders +@"\Configuration\", file);
                //foreach (var f in folders)
                //{
                //}
                // var configPath = Path.Combine(path, file);

                //if (!File.Exists(configPath))
                //    configPath = file;

                var reader =
                    new JsonTextReader(new StringReader(File.ReadAllText(configPath)));
                var serializer = new JsonSerializer();
                config = serializer.Deserialize<CoreSettings>(reader);
                if (config == null)
                    throw new Exception("No configuration was found");
                if (config.Services == null || config.Services.Count == 0)
                    throw new Exception("Nexo settings was not parametrized");

                GlobalSettings.Configuration = config;

                return GlobalSettings.Configuration;
            }
            catch (Exception ex)
            {
                throw new Exception("A problem occured when loading BPCoreSettings.json. Error: " + ex.Message);
            }
        }
    }

    public enum EFileDataStorage : byte
    {
        Local = 0,
        AWS = 1,
        Azure = 2,
        CGP = 3
    }

    public class JwtConfig
    {
        public string Key { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
    }

    public class FileDataSettings
    {
        public string Comment { get; set; }
        public string StorageBucket { get; set; }
        public EFileDataStorage FileDataStorage { get; set; }
        public string AwsProfileName { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretKey { get; set; }
        public string AzureAccessKey { get; set; }
        public string GoogleCredentialFile { get; set; }
    }

    public class SmtpData
    {
        public string ServiceName { get; set; }
        public string ServiceHost { get; set; }
        public int ServicePort { get; set; }
        public string ServiceProtocol { get; set; }
        public string ServiceUser { get; set; }
        public string ServicePassword { get; set; }
        public string ServiceDefaultSender { get; set; }
    }
    public class Service
    {
        public string ServiceName { get; set; }
        public string ServiceUri { get; set; }
        public Repository Repository { get; set; }
    }
    public class Repository
    {
        public string Provider { get; set; }
        public string ConnectionString { get; set; }
    }

}
