using System;
using System.IO;
using Tweetinvi;
using Tweetinvi.Models;
using System.Threading.Tasks;
using Tweetinvi.Parameters;

namespace LIS2RT
{
     class Program
    {
        static async Task Main(string[] args)
        {
            string APIKey = "Sv3w0P3EFRbWRuUTwZlXOTKQv";
            string APISecret = "iy1BZFCeXYeXPYJHk3qhLmRjC3WAGN21r5psIu15dXqUWy44ay";
            string AccessToken = "1503505828946579456-1L2jzXXVdaqAYYFJaVktwbeLlLEVGp";
            string AccessSecret = "zeotY3l0USvueTmzjevuhLspdGJo1GVB0OauZUC3iVf6l";
            var files = new DirectoryInfo(@"C:\Users\bohnt\Desktop\LIS2RT\LIS2RT\LIS2RT\bin\Debug\netcoreapp3.1\LifeIsStrange2").GetFiles();
            int index = new Random().Next(0, files.Length);
            Console.WriteLine(files[index].Name);
            byte[] ImageBytes = File.ReadAllBytes(files[index].Name);
            TwitterClient UserClient = new TwitterClient(APIKey, APISecret, AccessToken, AccessSecret);
            IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);
            ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters("#LifeIsStrange2, #LIS2") { Medias = { ImageIMedia } });
        }
    }
}
