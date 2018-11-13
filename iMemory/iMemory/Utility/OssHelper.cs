using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aliyun.OSS;

namespace Utility
{
    public class OssHelper
    {
        public static List<string> GetFileUrls(string endpoint, string bucketName, string accessKeyId, string accessKeySecret, string folder = null)
        {
            List<string> urls = new List<string>();
            try
            {
                ObjectListing result = null;
                string nextMarker = string.IsNullOrEmpty(folder) ? "" : folder;

                var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                do
                {
                    var listObjectsRequest = new ListObjectsRequest(bucketName)
                    {
                        MaxKeys = 1000,
                        Marker = nextMarker,
                    };
                    result = client.ListObjects(listObjectsRequest);
                    foreach (var summary in result.ObjectSummaries)
                    {
                        if (!string.IsNullOrEmpty(folder) && summary.Key.StartsWith(folder))
                        {
                            urls.Add(summary.Key);
                        }
                    }
                    nextMarker = result.NextMarker;
                } while (result.IsTruncated);
            }
            catch (Exception e)
            {

            }
            return urls;
        }
    }
}