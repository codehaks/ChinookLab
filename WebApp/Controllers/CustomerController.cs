using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookLab.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController : ControllerBase
    {
        [Route("api/customer")]
        public IActionResult Index()
        {
            var channel = new Grpc.Core.Channel("localhost:5001", SslCredentials.Insecure);

            var client = new AlbumsService.AlbumsServiceClient(channel);

            try
            {
                var response = client.GetAll(new Empty());

                return Ok(response);
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode == Grpc.Core.StatusCode.NotFound)
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        [Route("api/customer/{customerId}")]
        public IActionResult Get(int customerId)
        {
            var channel = new Grpc.Core.Channel("localhost:5001", SslCredentials.Insecure);

            var client = new AlbumsService.AlbumsServiceClient(channel);

            try
            {
                var response = client.GetAlbum(new AlbumRequest { AlbumId = customerId });

                return Ok(response);
            }
            catch (RpcException ex)
            {
                if (ex.StatusCode == Grpc.Core.StatusCode.NotFound)
                {
                    return NotFound();
                }
            }

            return NotFound();
            
        }
    }
}