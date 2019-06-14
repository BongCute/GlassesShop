using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassesShop
{
    [Serializable]
    public class UserLogincs
    {
        public long  UserID { set; get; }
        public string UserName { set; get; }
    }
}