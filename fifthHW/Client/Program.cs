﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class TcpClientSample
{
    private const int BufferSize = 1024;

    public static void Main()
    {
        int port;
        string filePath;

        Console.WriteLine("Please enter the port number of the server:");
        port = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the path of the file to send:");
        filePath = Console.ReadLine();

        try
        {
            using (TcpClient client = new TcpClient("127.0.0.1", port))
            {
                Console.WriteLine("Connected to the server...");

                using (NetworkStream networkStream = client.GetStream())
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        networkStream.Write(buffer, 0, bytesRead);
                    }

                    Console.WriteLine("File sent successfully.");
                }
            }
        }
        catch (SocketException)
        {
            Console.WriteLine("Unable to connect to the server.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}