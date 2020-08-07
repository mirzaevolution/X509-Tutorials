using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace X509CertificateStoreSamples
{
    class Program
    {
        static void ShowCertDetail(X509Certificate2 x509Certificate2)
        {
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
            Console.WriteLine($"Serial number: {serialNumber}\n\n");
        }
        static void LoadRootCALocalMachine()
        {
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection collection = 
                    store.Certificates;
                foreach(X509Certificate2 certificate in collection)
                {
                    ShowCertDetail(certificate);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                store.Close();
            }
        }

        static void SearchForCertificate(X509FindType findType, string name)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection collection = store.Certificates.Find(findType, name, false);
                if(collection.Count>0)
                {
                    foreach(X509Certificate2 certificate in collection)
                    {
                        ShowCertDetail(certificate);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                store.Close();
            }
        }
        static void Main(string[] args)
        {
            // LoadRootCALocalMachine();
            //SearchForCertificate(X509FindType.FindByIssuerName, "RootCert");
            SearchForCertificate(X509FindType.FindBySubjectName, "mirzaghulamrasyid.local");
            Console.ReadLine();
        }
    }
}
