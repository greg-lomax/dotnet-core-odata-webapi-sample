using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace odata_error.Models
{
    public static class TestDataHelper
    {

        public static void LoadTestData(this TestDbContext context)
        {
            var loadedData = context.ConfigNodes.FirstOrDefault(cn => cn.Id > 0) != null;

            if (!loadedData)
            {

                var configNodes = context.LoadTestData<ConfigNode>("odata_error.TestData.ControllerTests.Data.ConfigNode.json");
                context.AddRange(configNodes);
                context.SaveChanges();
            }

            loadedData = context.AzureClassUsers.FirstOrDefault(u => u.Id > 0) != null;

            if (!loadedData)
            { 
                var users = context.LoadTestData<AzureClassUser>("odata_error.TestData.ControllerTests.Data.AzureClassUser.json");
                context.AddRange(users);
                context.SaveChanges();
            }

        }


        private static TEntityType[] LoadTestData<TEntityType>(this TestDbContext context, string resourceName)
        {
            using (var stream = context.GetType().Assembly.GetManifestResourceStream(resourceName)!)
            {
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    var settings = new JsonSerializerSettings()
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                        Formatting = Formatting.Indented,
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                    return JsonConvert.DeserializeObject<TEntityType[]>(json, settings)!;
                }
            }
        }

    }
}
