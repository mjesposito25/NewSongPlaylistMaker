using System;
using System.Threading.Tasks;
using System.IO;
using SpotifyAPI.Web;

class Program
{
    public static async Task Main(string[] args)
        {
            StreamReader sr = new StreamReader("keys.txt");

            var ID = sr.ReadLine();
            var SECRET = sr.ReadLine();

            sr.Close(); 

            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(ID, SECRET);
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
            Console.WriteLine(track.Name);
        }
}