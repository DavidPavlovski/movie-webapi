using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Configurations
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
        public string DefaultErrorMessage { get; set; }
        public string AllowedOrigins { get; set; }
    }
}
