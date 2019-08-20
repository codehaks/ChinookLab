using ChinookLab.Protos;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace AlbumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting GRPC Client...");
            Console.WriteLine();

            var channel = new Grpc.Core.Channel("localhost:5001", SslCredentials.Insecure);

            var client = new AlbumsService.AlbumsServiceClient (channel);

            try
            {
                var response =  client.GetAlbum(new AlbumRequest { AlbumId = 1 });

                Console.WriteLine("Id: " + response.AlbumId);
                Console.WriteLine("Title: " + response.Title);
                Console.WriteLine("ArtistId: " + response.ArtistId);
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode == StatusCode.NotFound)
                {
                    Console.WriteLine(ex.Status.Detail);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Shutting down");
            channel.ShutdownAsync().Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
