
using System;
using System.IO;

namespace NZeleris.Tests
{
    public class ZelerisTestSettings
    {
        private static ZelerisTestSettings _instance = null;

        public string XMLTestDirectory { get; set; }
        public string ClientId { get; set; }
        public string APIUser { get; set; }
        public string APIPassword { get; set; }

        private ZelerisTestSettings()
        {
            XMLTestDirectory = $"{Directory.GetCurrentDirectory()}/XmlExamples";
            ClientId = GetEnvironmentVariable("ZelerisClientId");
            APIUser = GetEnvironmentVariable("ZelerisAPIUser");
            APIPassword = GetEnvironmentVariable("ZelerisAPIPassword");
        }

        public static ZelerisTestSettings GetInstance()
        {
            if(_instance == null)
            {
                _instance = new ZelerisTestSettings();
            }

            return _instance;
        }

        private string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name) ?? name;
        }

    }
}
