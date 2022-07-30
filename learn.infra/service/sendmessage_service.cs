using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class sendmessage_service : Isendmessage_service
    {
        private readonly Isendmessage_repository repo;
        public sendmessage_service(Isendmessage_repository repo)
        {
            this.repo = repo;
        }

        public List<filtermessage> filtermessages(getdate getd)
        {
            return repo.filtermessages(getd);
        }

        public List<message_api> searchmessage(string message)
        {
            return repo.searchmessage(message);
        }

        public string sendmessage(sendmessage_dto s)
        {
            return repo.sendmessage(s);
        }

        public List<totalmessages_dto> totalmessages()
        {
            return repo.totalmessages();
        }

        public List<totalmessagesforeachuser_dto> totalrecivedmessages()
        {
            return repo.totalrecivedmessages();
        }
    }
}
