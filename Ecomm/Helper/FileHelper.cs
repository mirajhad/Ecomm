using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ecomm.Helper
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string filename =  Guid.NewGuid().ToString();
            string connectionString = @"";
            string containerName = "bookphotos";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename+file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            return  blobClient.Uri.AbsoluteUri;
           
        }
        public static async Task<string> UploadUrl(IFormFile file)
        {
            string filename = Guid.NewGuid().ToString();
            string connectionString = @"";
            string containerName = "bookurl";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename+file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            return blobClient.Uri.AbsoluteUri;

        }
    }
}
