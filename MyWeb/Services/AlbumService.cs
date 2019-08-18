using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookLab.Protos;
using Grpc.Core;
using MyWeb.Models;

namespace ServerApp.Services
{
    public class AlbumService : ChinookLab.Protos.AlbumsService.AlbumsServiceBase
    {
        private readonly ChinbookContext _db;
        public AlbumService(ChinbookContext db)
        {
            _db = db;
        }

        public override async Task<AlbumReply> GetAlbum(AlbumRequest request, ServerCallContext context)
        {
            var model = await _db.Albums.FindAsync(request.AlbumId);
            var resposne = new AlbumReply { AlbumId = model.AlbumId,ArtistId=model.ArtistId,Title=model.Title };

            return resposne;
        }
    }
}
