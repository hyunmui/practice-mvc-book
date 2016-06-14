using System.Net.Http;
using System.Threading.Tasks;

namespace CsharpExample.Models
{
    public class MyAsyncMehtods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }

        public async static Task<long?> GetPageLengthByAsync()
        {
            HttpClient client = new HttpClient();
            var httpMesage = await client.GetAsync("http://apress.com");

            return httpMesage.Content.Headers.ContentLength;
        }
    }
}