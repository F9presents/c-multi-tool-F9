using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics; // Required for Process.Start

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("C# Ethical Hacking Multi-Tool By F9");
            Console.WriteLine("{1} Port Scanner");
            Console.WriteLine("{2} IP Info Lookup");
            Console.WriteLine("{3} F9's GitHub");
            Console.WriteLine("{4} Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PortScanner();
                    break;
                case "2":
                    IPInfoLookup();
                    break;
                case "3":
                    OpenGitHub();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    static void PortScanner()
    {
        Console.Write("Enter IP address: ");
        string ipAddress = Console.ReadLine();

        Console.Write("Enter start port: ");
        int startPort = int.Parse(Console.ReadLine());

        Console.Write("Enter end port: ");
        int endPort = int.Parse(Console.ReadLine());

        for (int port = startPort; port <= endPort; port++)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ipAddress, port);
                    Console.WriteLine($"Port {port} is OPEN");
                }
                catch
                {
                    // Port closed or filtered
                }
            }
        }
    }

    static void IPInfoLookup()
    {
        Console.Write("Enter hostname or IP: ");
        string host = Console.ReadLine();

        try
        {
            IPHostEntry entry = Dns.GetHostEntry(host);
            Console.WriteLine($"Host: {entry.HostName}");
            foreach (var ip in entry.AddressList)
            {
                Console.WriteLine($"IP Address: {ip}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void OpenGitHub()
    {
        string url = "https://github.com/F9presents"; // Replace with your actual repo
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
            Console.WriteLine("Opened GitHub link in browser.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to open link: {ex.Message}");
        }
    }
}
