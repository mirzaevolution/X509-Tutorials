using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace X509InstallAndUninstall
{
    class Program
    {
        static void InstallCert(string pfxLocation)
        {
            if(!File.Exists(pfxLocation))
            {
                Console.WriteLine("File not found!");
                return;
            }
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Certificate2 pfx = new X509Certificate2(pfxLocation);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(pfx);
                Console.WriteLine($"{pfxLocation} has been installed!");
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
        static void UninstallCert(X509FindType x509FindType, string value)
        {
            X509Store x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            try
            {
                x509Store.Open(OpenFlags.ReadWrite);
                X509Certificate2Collection collection =  x509Store.Certificates.Find(x509FindType, value, false);
                if (collection.Count > 0)
                {
                    foreach(X509Certificate2 certificate in collection)
                    {

                        Console.WriteLine($"{certificate.Subject} is being removed");
                        x509Store.Remove(certificate);
                        Console.WriteLine("Removed");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                x509Store.Close();
            }
        }
        static void Main(string[] args)
        {
            //string pfxLocation = @"D:\Cert\Training\skyline.dev.pfx";
            //InstallCert(pfxLocation);
            UninstallCert(X509FindType.FindBySubjectName, "skyline.dev");
            Console.ReadLine();
        }
    }
}
