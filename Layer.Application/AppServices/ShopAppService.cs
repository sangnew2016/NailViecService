using Layer.Domain.Entity;
using Layer.Domain.Model;
using Layer.Domain.Repositories;
using System.Collections.Generic;

namespace Layer.Application.AppServices
{
    public class ShopAppService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IShopRepository _shopRepository;

        public ShopAppService(IUnitOfWorkFactory unitOfWorkFactory, IShopRepository shopRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _shopRepository = shopRepository;
        }

        public List<Shop> GetAll()
        {
            //For Update....
            //using (var unitOfWork = _unitOfWorkFactory.Create())
            //{
            //    var survey = _importService.Import(content, surveyName, userId, unitOfWork);
            //    unitOfWork.Commit();
            //    return survey;
            //}

            return _shopRepository.GetAll();
        }

    }
}
