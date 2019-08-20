using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookLab.Protos;
using Grpc.Core;


namespace ServerApp.Services
{
    public class AlbumService : ChinookLab.Protos.AlbumsService.AlbumsServiceBase
    {
        public override async Task<AlbumReply> GetAlbum(AlbumRequest request, ServerCallContext context)
        {
            await Task.Delay(1);
            var resposne = new AlbumReply { AlbumId =1,ArtistId=10,Title="Hello from server" };

            return resposne;
        }
    }
}
