using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.ApiClient
{
    public class RequestContext
    {
        private readonly object _lock = new object();
        private string _cookie;

        public string Cookie
        {
            get
            {
                lock (_lock)
                {
                    return _cookie;
                }
            }
            set
            {
                lock (_lock)
                {
                    _cookie = value;
                }
            }
        }
    }

}
