using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Configuration
{
    /// <summary>
    /// Database setting.
    /// </summary>
    public class MongoSetting
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        public string Database { get; set; }
    }
}
