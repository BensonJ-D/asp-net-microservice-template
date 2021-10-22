using System.Collections.Generic;
using asp_net_microservice_template.DAO;
using asp_net_microservice_template.Models;
using MongoDB.Driver;

namespace asp_net_microservice_template.Services
{
    public class PortfolioContentService
    {
        private readonly IAboutContentDao _aboutContentDao;

        public PortfolioContentService(IAboutContentDao aboutContentDao)
        {
            _aboutContentDao = aboutContentDao;
        }

        public PortfolioContentDTO GetAbout() => _aboutContentDao.Get();

        public PortfolioContentDTO UpdateAbout(string newAboutContent) => _aboutContentDao.Update(newAboutContent);
    }
}