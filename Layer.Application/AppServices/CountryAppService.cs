using Layer.Domain.Entity;
using Layer.Domain.Model;
using Layer.Domain.Repositories;
using Layer.Domain.Services;
using System.Collections.Generic;

namespace Layer.Application.AppServices
{
    public class CountryAppService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICountryRepository _countryRepository;

        public CountryAppService(IUnitOfWorkFactory unitOfWorkFactory, ICountryRepository countryRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _countryRepository = countryRepository;
        }

        public IEnumerable<Country> GetAll()
        {
            //For Update....
            //using (var unitOfWork = _unitOfWorkFactory.Create())
            //{
            //    var survey = _importService.Import(content, surveyName, userId, unitOfWork);
            //    unitOfWork.Commit();
            //    return survey;
            //}
            
            return _countryRepository.GetAll();
        }

    }
}
