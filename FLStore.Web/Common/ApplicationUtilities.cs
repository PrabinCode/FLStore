using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FLStore.Web.Common
{
    public static class ApplicationUtilities
    {
        
        public static object GetSessionValue(this System.Web.SessionState.HttpSessionState Session, string SessionKey)
        {
            if (Session != null)
            {
                if (Session[SessionKey] != null)
                {
                    return Session[SessionKey];
                }
            }
            return "";
        }
        public static T GetSessionValue<T>(this System.Web.SessionState.HttpSessionState Session, string SessionKey)
        {
            T t = default(T);
            if (Session != null)
            {
                if (Session[SessionKey] != null)
                {
                    t = (T)Session[SessionKey];
                }
            }
            return t;
        }
        public static object GetSessionValue(string SessionKey)
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                var Session = context.Session;
                if (Session != null)
                {
                    if (Session[SessionKey] != null)
                    {
                        return Session[SessionKey];
                    }
                }
            }
            return "";
        }
        public static T GetSessionValue<T>(string SessionKey)
        {
            HttpContext context = HttpContext.Current;
            T t = default(T);
            if (context != null)
            {
                var Session = context.Session;
                if (Session != null)
                {
                    if (Session[SessionKey] != null)
                    {
                        t = (T)Session[SessionKey];
                    }
                }
            }
            return t;
        }
        #region Parameter Encryption
        public static string ParameterKey = "P@r@meter";
        public static string EncryptParameter(this string textToEncrypt)
        {
            StringCipher cipher = new StringCipher(GetSessionValue<string>("SessionGuid"));//ParameterKey
            try
            {
                if (String.IsNullOrEmpty(textToEncrypt))
                    return "";
                var encoded = cipher.Encrypt(textToEncrypt);
                var replacedString = encoded.Replace("/", "41235asf421").Replace("+", "947421asf42514af").Replace("=", "77tt4yh788qqw");
                return replacedString;
            }
            catch
            {
                return "";
            }
        }
        public static string DecryptParameter(this string textToDecrypt)
        {
            StringCipher cipher = new StringCipher(GetSessionValue<string>("SessionGuid"));//ParameterKey
            try
            {
                if (String.IsNullOrEmpty(textToDecrypt))
                    return "";
                var replacedString = textToDecrypt.Replace("41235asf421", "/").Replace("947421asf42514af", "+").Replace("77tt4yh788qqw", "=");
                return cipher.Decrypt(replacedString);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region  Password Encryption
        public static string PasswordKey = "P@$$w0rd";
        public static string EncryptPassword(this string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += PasswordKey;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
            StringCipher cipher = new StringCipher(PasswordKey);//( GetSessionValue<string>("SessionGuid"));
            try
            {
                if (String.IsNullOrEmpty(password))
                    return "";
                var encoded = cipher.Encrypt(password);
                var replacedString = encoded.Replace("/", "2345dfasdf").Replace("+", "we56465asrfsdf").Replace("=", "e8951dgas");
                return replacedString;
            }
            catch
            {
                return "";
            }
        }
        public static string DecryptPassword(this string decPassword)
        {
            if (string.IsNullOrEmpty(decPassword))
                return "";
            var base64EncodeBytes = Convert.FromBase64String(decPassword);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - PasswordKey.Length);
            return result;

            StringCipher cipher = new StringCipher("");//( GetSessionValue<string>("SessionGuid"));
            try
            {
                if (String.IsNullOrEmpty(decPassword))
                    return "";
                var replacedString = decPassword.Replace("2345dfasdf", "/").Replace("we56465asrfsdf", "+").Replace("e8951dgas", "=");
                return cipher.Decrypt(replacedString);
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region FilterString

        public static String FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str.TrimEnd().TrimStart();
        }
        private static String FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                //str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = str.Replace(" select ", "");
                str = str.Replace(" insert ", "");
                str = str.Replace(" update ", "");
                str = str.Replace(" delete ", "");

                str = str.Replace(" drop ", "");
                str = str.Replace(" truncate ", "");
                str = str.Replace(" create ", "");

                str = str.Replace(" begin ", "");
                str = str.Replace(" end ", "");
                str = str.Replace(" char(", "");

                str = str.Replace(" exec ", "");
                str = str.Replace(" xp_cmd ", "");


                str = str.Replace("<script", "");

            }
            else
            {
                str = "null";
            }
            return str;
        }

        #endregion

        #region map objects
        public static T MapObject<T>(this object item)
        {
            T sr = default(T);
            if (item != null)
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                sr = JsonConvert.DeserializeObject<T>(obj);
            }
            return sr;
        }
        public static List<T> MapObjects<T>(this object item)
        {
            List<T> sr = default(List<T>);
            if (item != null)
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                sr = JsonConvert.DeserializeObject<List<T>>(obj);
            }
            return sr;
        }

        #endregion

        #region Set Data In Drop Down List
        public static List<SelectListItem> SetDDLValue(Dictionary<string, string> dictionary, string selectedVal, string defLabel = "", bool isTextAsValue = false)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrWhiteSpace(defLabel))
            {
                items.Add(new SelectListItem { Text = defLabel, Value = "", Disabled = true });
            }
            if (dictionary.Count > 0)
            {

                foreach (var item in dictionary)
                {
                    string Value = item.Key;
                    string Name = item.Value;
                    if (isTextAsValue)
                        Value = Name;

                    if (Value == selectedVal)
                    {
                        items.Add(new SelectListItem { Text = Name, Value = Value, Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = Name, Value = Value });
                    }
                }
            }
            return items;
        }
        #endregion
    }

    public class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        public string Signature { get; set; }
        private string _encryptionKey = "";
        public StringCipher(string encryption_key)
        {
            _encryptionKey = encryption_key;
        }
        public String Encrypt(String plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, getRijndaelManaged(_encryptionKey)));
        }

        public String Decrypt(String encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, getRijndaelManaged(_encryptionKey)));
        }

        private RijndaelManaged getRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        private byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }
        public bool VerifySign(string data)
        {
            var encryptedData = Encrypt(data);
            if (encryptedData == Signature)
            {
                return true;
            }
            return false;
        }
    }
}