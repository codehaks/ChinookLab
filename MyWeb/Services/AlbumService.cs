using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookLab.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<AlbumListResponse> GetAll(Empty request, ServerCallContext context)
        {
            var model =  _db.Albums.Select(m => new AlbumReply { AlbumId = m.AlbumId, ArtistId = m.ArtistId, Title = m.Title });
            var data =await model.ToListAsync();

            AlbumListResponse response = new AlbumListResponse();

            foreach (var item in data)
            {
                response.Results.Add(item);
            }


            return response;
        }
    }
}
