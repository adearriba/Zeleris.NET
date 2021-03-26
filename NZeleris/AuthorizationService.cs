using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NZeleris.Library.Models.Components;

namespace NZeleris.Library
{
    public class AuthorizationService
    {
        private readonly string _apiUser;
        private readonly string _apiSecret;

        public AuthorizationService(string apiUser, string apiSecret)
        {
            _apiUser = apiUser;
            _apiSecret = apiSecret;
        }

        public AccountInfo GenerateSecurityInformation(string date)
        {
            var password = GeneratePassword(date);
            AccountInfo accountInfo = new AccountInfo(_apiUser, password, date);
            return accountInfo;
        }

        public AccountInfo GenerateSecurityInformation()
        {
            TimeZoneInfo cestZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            string now = TimeZoneInfo.ConvertTime(DateTime.Now, cestZone).ToString("yyyyMMddHHmmss");

            var password = GeneratePassword(now);
            AccountInfo accountInfo = new AccountInfo(_apiUser, password, now);
            return accountInfo;
        }

        private string GeneratePassword(string datetime)
        {
            //Obtenemos X según documentación de Zeleris
            var salt = Encrypt(_apiUser, _apiSecret, datetime);

            //Sustituimos APISecret por X y hacemos el mismo proceso
            var password = Encrypt(_apiUser, salt, datetime);

            return password;
        }

        private string Encrypt(string user, string text, string datetime)
        {
            var reverseDatetime = new string(datetime.ToCharArray().Reverse().ToArray());
            var textToEncrypt = string.Format("{0}{1}{2}", user, text, reverseDatetime);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textToEncrypt));
                var base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
        }
    }
}
