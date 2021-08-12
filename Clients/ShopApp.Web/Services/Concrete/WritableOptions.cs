using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ShopApp.Web.Services.Concrete
{
    public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
    {
        private readonly IHostingEnvironment _environment;
        private readonly IOptionsMonitor<T> _options;
        private readonly IConfigurationRoot _configuration;
        private readonly string _section;
        private readonly string _file;

        public WritableOptions(
            IHostingEnvironment environment, IOptionsMonitor<T> options, IConfigurationRoot configuration, string section, string file)
        {
            _environment = environment;
            _options = options;
            _configuration = configuration;
            _section = section;
            _file = file;
        }

        public T Value => _options.CurrentValue;
        public T Get(string name) => _options.Get(name);

        public void RemoveProductStock(Action<T> applyChanges)
        {
            var configJson = File.ReadAllText("product.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(configJson);
            config["Stock"] = 9;
            var updatedConfigJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("product.json", updatedConfigJson);
        }
    }
}
