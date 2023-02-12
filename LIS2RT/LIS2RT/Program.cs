using System;
using System.IO;
using Tweetinvi;
using Tweetinvi.Models;
using System.Threading.Tasks;
using Tweetinvi.Parameters;

namespace TwitterBot
{
     class Program
    {
        static async Task Main(string[] args)
        {
            string APIKey = "";
            string APISecret = "";
            string AccessToken = "";
            string AccessSecret = "";
            var files = new DirectoryInfo(@"C:\Users\user\folder").GetFiles(); 
            int index = new Random().Next(0, files.Length);
            Console.WriteLine(files[index].Name);
            byte[] ImageBytes = File.ReadAllBytes(files[index].Name);
            TwitterClient UserClient = new TwitterClient(APIKey, APISecret, AccessToken, AccessSecret);
            IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);
            ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters("Enter Text Here") { Medias = { ImageIMedia } });
        }
    }
}
