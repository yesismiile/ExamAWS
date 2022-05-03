using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAWS.Services
{
    public class s3
    {
        private string bucket;
        private IAmazonS3 awsClient;
        public s3(IAmazonS3 client, IConfiguration configuration)
        {

            this.awsClient = client;
            this.bucket = configuration.GetValue<string>("AWS:bucketexam");
        }
        public async Task<bool> UploadFileAsync(Stream stream, string fileName)
        {

            PutObjectRequest request = new PutObjectRequest
            {
                InputStream = stream,
                Key = fileName,
                BucketName = this.bucket
            };

            PutObjectResponse response = await this.awsClient.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteFileAsync(string fileName)
        {
            DeleteObjectResponse response = await this.awsClient.DeleteObjectAsync(this.bucket, fileName);


            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Stream> GetFileAsync(string fileName)
        {
            GetObjectResponse response = await this.awsClient.GetObjectAsync(this.bucket, fileName);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.ResponseStream;
            }
            else
            {
                return null;
            }
        }


    }
}
