using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace X509Certificate2Samples
{
    class Program
    {
        static void ShowCertDetail(string location)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2(location);
            string issuer = x509Certificate2.Issuer;
            string subject = x509Certificate2.Subject;
            string expirationDate = x509Certificate2.GetExpirationDateString();
            string effectiveDate = x509Certificate2.GetEffectiveDateString();
            string nameInfo = x509Certificate2.GetNameInfo(X509NameType.SimpleName, true);
            bool hasPrivateKey = x509Certificate2.HasPrivateKey;
            string serialNumber = x509Certificate2.SerialNumber;
            Console.WriteLine($"Issuer: {issuer}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Expiration date: {expirationDate}");
            Console.WriteLine($"Effective date: {effectiveDate}");
            Console.WriteLine($"NameInfo: {nameInfo}");
            Console.WriteLine($"Has private key: {hasPrivateKey}");
            Console.WriteLine($"Serial number: {serialNumber}");
        }
        static void ReadCerFile(string location)
        {
            Console.WriteLine("** CER FILE **");
            ShowCertDetail(location);
            Console.WriteLine();
        }
        static void ReadPfxFile(string location)
        {
            Console.WriteLine("** PFX FILE **");
            ShowCertDetail(location);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ReadCerFile(@"D:\Cert\Training\RootCertificate.cer");
            ReadPfxFile(@"D:\Cert\Training\RootCertificate.pfx");
            Console.ReadLine();
        }
    }
}
