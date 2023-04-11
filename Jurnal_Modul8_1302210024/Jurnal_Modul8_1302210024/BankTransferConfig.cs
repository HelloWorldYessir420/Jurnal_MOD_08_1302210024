using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Jurnal_Modul8_1302210024
{
    class BankTransferConfig
    {
        private JObject _config;

        public BankTransferConfig()
        {
            string filePath = "bank_transfer_config.json";

            if (!File.Exists(filePath))
            {
                // Set default values
                _config = JObject.Parse(@"{
                    'lang': 'en',
                    'transfer': {
                        'threshold': 25000000,
                        'low_fee': 6500,
                        'high_fee': 15000
                    },
                    'methods': [
                        'RTO (real-time)',
                        'SKN',
                        'RTGS',
                        'BI FAST'
                    ],
                    'confirmation': {
                        'en': 'yes',
                        'id': 'ya'
                    }
                }");
            }
            else
            {
                _config = JObject.Parse(File.ReadAllText(filePath));
            }
        }

        public string GetLanguage()
        {
            return _config.Value<string>("lang");
        }

        public double GetTransferThreshold()
        {
            return _config.SelectToken("transfer.threshold").Value<double>();
        }

        public double GetLowFee()
        {
            return _config.SelectToken("transfer.LowFee").Value<double>(7500);
        }

        public double GetHighFee()
        {
            return _config.SelectToken("transfer.HighFee").Value<double>(20000);
        }

        public string[] GetMethods()
        {
            return _config.SelectToken("Methods").ToObject<string[]>();
        }

        public string GetConfirmation()
        {
            return _config.SelectToken($"Confirmation.{GetLanguage()}").Value<string>();
        }
    }
}
