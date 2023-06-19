using Newtonsoft.Json.Linq;
using PowerConvert.Utils;
using System;
using System.Drawing;
using System.Net;
using System.Web;
using Console = Colorful.Console;
using HttpRequest = Leaf.xNet.HttpRequest;

namespace PowerConvert.Models.YouTube
{
    internal class Convert
    {
        public class YouTubeVideo
        {
            public static string VideoId { get; set; }
            public static string VideoTitle { get; set; }
            public static string Key { get; set; }
            public static string Status { get; set; }

            public YouTubeVideo(string videoId, string videoTitle, string key, string status)
            {
                VideoId = videoId;
                VideoTitle = videoTitle;
                Key = key;
                Status = status;
            }

            public override string ToString()
            {
                return $"Title: {VideoTitle}\nVideo Id: {VideoId}\nDownload Key: {Key}\nStatus: {Status}";
            }
        }

        public static void ConvertYoutube(string VideoUrl, string Extension)
        {
            Console.Clear();
            Console.Title = $"{Globals.ToolName} by {Globals.Author} ~ Version {Globals.Version} | Converting ";
            Interface.PrintArt();
            try
            {
                HttpRequest hr = new HttpRequest();
                hr.UserAgentRandomize();

                var getTokens = hr.Post($"https://9convert.com/api/ajaxSearch/index",
                    $"query={HttpUtility.UrlDecode(VideoUrl)}&vt=home", "application/x-www-form-urlencoded; charset=UTF-8");

                JObject jobj = JObject.Parse(getTokens.ToString());
                var videoId = (string)jobj.SelectToken("vid");
                var videoTitle = (string)jobj.SelectToken("title");
                var key = string.Empty;

                switch (Extension)
                {
                    case "mp4":
                        key = (string)jobj.SelectToken($"links.{Extension}.auto.k");
                        break;

                    case "mp3":
                        key = (string)jobj.SelectToken($"links.{Extension}.mp3128.k");
                        break;
                }

                var status = (string)jobj.SelectToken("status");

                YouTubeVideo youTubeVideo = new YouTubeVideo(videoId, videoTitle, key, status);

                if (status.Equals("ok") && !key.Equals(string.Empty))
                {
                    var getDownload = hr.Post("https://9convert.com/api/ajaxConvert/convert",
                        $"vid={videoId}&k={HttpUtility.UrlEncode(key)}", "application/x-www-form-urlencoded; charset=UTF-8");

                    jobj = JObject.Parse(getDownload.ToString());
                    var downloadLink = (string)jobj.SelectToken("dlink");
                    var downloadStatus = (string)jobj.SelectToken("c_status");

                    if (downloadStatus.Equals("CONVERTED"))
                    {
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                client.DownloadFile(downloadLink, $"Downloads\\YouTube\\{ModelsHelper.ToValidName(videoTitle)}.{Extension}");
                                Interface.Prefix("+", $"Downloaded: {videoTitle}", Color.Green);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}