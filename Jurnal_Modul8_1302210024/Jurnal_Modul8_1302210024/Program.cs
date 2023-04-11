using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Jurnal_Modul8_1302210024
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig config = new BankTransferConfig();
            Console.WriteLine(config.GetLanguage() == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:");

            double amount = double.Parse(Console.ReadLine());
            double transferFee = amount <= config.GetTransferThreshold() ? config.GetLowFee() : config.GetHighFee();
            double totalAmount = amount + transferFee;

            Console.WriteLine(config.GetLanguage() == "en" ? $"Transfer fee = {transferFee}" : $"Biaya transfer = {transferFee}");
            Console.WriteLine(config.GetLanguage() == "en" ? $"Total amount = {totalAmount}" : $"Total biaya = {totalAmount}");

            Console.WriteLine(config.GetLanguage() == "en" ? "Select transfer method:" : "Pilih metode transfer:");
            int i = 1;
            foreach (string method in config.GetMethods())
            {
                Console.WriteLine($"{i++}. {method}");
            }

            Console.WriteLine(config.GetLanguage() == "en" ? $"Please type \"{config.GetConfirmation()}\" to confirm the transaction:" : $"Ketik \"{config.GetConfirmation()}\" untuk mengkonfirmasi transaksi:");
            string confirmation = Console.ReadLine();

            if (confirmation == config.GetConfirmation())
            {
                Console.WriteLine(config.GetLanguage() == "en" ? "The transfer is completed" : "Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine(config.GetLanguage() == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
            }

            Console.ReadKey();
        }
    }
}