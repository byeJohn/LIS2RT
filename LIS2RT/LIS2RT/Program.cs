using System;
using System.IO;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace LIS2RT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string APIKey = "";
            string APISecret = "";
            string AccessToken = "";
            string AccessSecret = "";

            var files = new DirectoryInfo(@"C:\Users\userhere\Desktop\LIS2RT\LIS2RT\LIS2RT\bin\Debug\netcoreapp3.1\LifeIsStrange2").GetFiles();
            int index = new Random().Next(0, files.Length);
            Console.WriteLine(files[index].Name);

            byte[] ImageBytes = File.ReadAllBytes(files[index].FullName);

            TwitterClient UserClient = new TwitterClient(APIKey, APISecret, AccessToken, AccessSecret);

            try
            {
                IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);
                string tweetText = "#LifeIsStrange2, #LIS2";
                ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters(tweetText) { Medias = { ImageIMedia } });
                Console.WriteLine("Tweet sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image and sending tweet: {ex.Message}");
            }
        }
    }
}
