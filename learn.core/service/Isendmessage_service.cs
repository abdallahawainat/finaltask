using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Isendmessage_service
    {
        public string sendmessage(sendmessage_dto s);
        public List<totalmessages_dto> totalmessages();

        public List<totalmessagesforeachuser_dto> totalrecivedmessages();

        public List<filtermessage> filtermessages(getdate getd);

        public List<message_api> searchmessage(string message);
    }
}
