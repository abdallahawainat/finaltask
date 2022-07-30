using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Iloginuser_apiservice
    {
        public string Authentication_jwt(loginuser_api login);
    }
}
