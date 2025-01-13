using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class DigitalAlbumService : IDigitalAlbumService
    {
        private readonly NetEaseApiClient _client;

        public DigitalAlbumService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAlbumDetail(long albumId)
        {
            try
            {
                var options = new RequestOptions($"/api/digitalAlbum", new { id = albumId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album detail with ID '{albumId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAlbumSales(long[] albumIds)
        {
            try
            {
                var options = new RequestOptions($"/api/vipmall/albumproduct/album/query/sales", new { albumIds = albumIds });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album sales with IDs '{albumIds}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetPurchasedAlbums(PurchasedAlbumsRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/digitalAlbum/purchased", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get purchased degital album.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> OrderAlbum(DigitalAlbumOrderRequestModel requestModel)
        {
            try
            {
                DigitalResource digitalResource = new DigitalResource()
                {
                    Quantity = requestModel.Quantity,
                    ResourceID = requestModel.AlbumId
                };

                var data = new
                {
                    business = "Album",
                    paymentMethod = requestModel.PaymentMethod,
                    from = "web",
                    digitalResource = JsonConvert.SerializeObject(new DigitalResource[] { digitalResource })
                };

                var options = new RequestOptions($"/api/ordering/web/digital", data);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to purchase degital album.", ex);
            }
        }
    }
}
