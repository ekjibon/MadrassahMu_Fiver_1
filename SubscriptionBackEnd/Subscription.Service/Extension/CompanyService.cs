using Subscription.Business;
using Subscription.Business.Dto;
using Subscription.Business.ReturnType;
using Subscription.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Service
{
    public partial class CompanyService : BaseService
    {
        internal SaveCompanyAdminDetailCompanyReturnType SaveCompanyAdminDetailCompanyRaw(SaveCompanyAdminDetailCompanyDto saveCompanyAdminDetailCompanyDto, UnitOfWork unitOfWork)
        {
            SaveCompanyAdminDetailCompanyReturnType saveCompanyAdminDetailCompanyReturnType = new SaveCompanyAdminDetailCompanyReturnType();

            daoFactory.CompanyDao.SaveOnlyCompany(saveCompanyAdminDetailCompanyDto.Company, unitOfWork.Db);

            if (saveCompanyAdminDetailCompanyDto.Company.Company_ContactType != null)
            {
                daoFactory.CompanyDao.UpdateCompany_ContactTypeForCompany(saveCompanyAdminDetailCompanyDto.Company.Company_ContactType.ToList(), saveCompanyAdminDetailCompanyDto.Company.IdCompany.Value, unitOfWork.Db);
            }

            if (saveCompanyAdminDetailCompanyDto.Company.CompanyLocations != null)
            {
                saveCompanyAdminDetailCompanyDto.Company.CompanyLocations.Where(l => l.IsDeactivated != true).ToList().ForEach(l =>
                {
                    if (l.Address != null)
                    {
                        daoFactory.AddressDao.SaveOnlyAddress(l.Address, unitOfWork.Db);
                        l.IdAddress = l.Address.IdAddress;
                    }
                });
                daoFactory.CompanyDao.UpdateCompanyLocationsForCompany(saveCompanyAdminDetailCompanyDto.Company.CompanyLocations.ToList(), saveCompanyAdminDetailCompanyDto.Company.IdCompany.Value, unitOfWork.Db);
            }

            saveCompanyAdminDetailCompanyReturnType.Company = saveCompanyAdminDetailCompanyDto.Company;

            return saveCompanyAdminDetailCompanyReturnType;
        }

        public Company RemapCompany(Company company)
        {
            Company remappedCompany = Mapper.MapCompanySingle(company, true);
            remappedCompany.CompanyLocations = new List<CompanyLocation>();
            remappedCompany.Company_ContactType = new List<Company_ContactType>();

            if (company.Company_ContactType != null)
            {
                company.Company_ContactType.Where(pi => pi.IsDeactivated != true).ToList().ForEach(pc =>
                {
                    Company_ContactType company_ContactType = Mapper.MapCompany_ContactTypeSingle(pc, true);
                    if (pc.ContactType != null)
                    {
                        company_ContactType.ContactType = Mapper.MapContactTypeSingle(pc.ContactType, true);
                    }
                    remappedCompany.Company_ContactType.Add(company_ContactType);
                });
            }

            if (company.CompanyLocations != null)
            {
                company.CompanyLocations.Where(pi => pi.IsDeactivated != true).ToList().ForEach(pa =>
                {
                    CompanyLocation companyLocation = Mapper.MapCompanyLocationSingle(pa, true);
                    if (pa.Address != null)
                    {
                        companyLocation.Address = Mapper.MapAddressSingle(pa.Address, true);
                        if (pa.Address.Country != null)
                        {
                            companyLocation.Address.Country = Mapper.MapCountrySingle(pa.Address.Country, true);
                        }
                        if (pa.Address.City != null)
                        {
                           // companyLocation.Address.City = Mapper.MapCitySingle(pa.Address.City, true);
                        }
                    }
                    remappedCompany.CompanyLocations.Add(companyLocation);
                });
            }

            return remappedCompany;
        }
    }
}
