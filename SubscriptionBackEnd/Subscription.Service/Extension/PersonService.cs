using CoreWeb.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.Utils;
using Subscription.Data;

namespace Subscription.Service
{
    public partial class PersonService : BaseService
    {
        internal Person RemapPerson(Person person)
        {
            Person remappedPerson = Mapper.MapPersonSingle(person, true);
            remappedPerson.Person_ContactType = new List<Person_ContactType>();

            if (person.Person_ContactType != null)
            {
                person.Person_ContactType.Where(pi => pi.IsDeactivated != true).ToList().ForEach(pc =>
                {
                    Person_ContactType person_ContactType = Mapper.MapPerson_ContactTypeSingle(pc, true);
                    if (pc.ContactType != null)
                    {
                        person_ContactType.ContactType = Mapper.MapContactTypeSingle(pc.ContactType, true);
                    }
                    remappedPerson.Person_ContactType.Add(person_ContactType);
                });
            }

            if (person.Title != null)
            {
                remappedPerson.Title = Mapper.MapTitleSingle(person.Title, true);
            }

            if (person.Person_Address != null)
            {
                person.Person_Address.Where(pi => pi.IsDeactivated != true).ToList().ForEach(pa =>
                {
                    Person_Address person_Address = Mapper.MapPerson_AddressSingle(pa, true);
                    if (pa.Address != null)
                    {
                        person_Address.Address = Mapper.MapAddressSingle(pa.Address, true);
                        if (pa.Address.Country != null)
                        {
                            person_Address.Address.Country = Mapper.MapCountrySingle(pa.Address.Country, true);
                        }
                        if (pa.Address.City1 != null)
                        {
                            person_Address.Address.City1 = Mapper.MapCitySingle(pa.Address.City1, true);
                        }
                    }
                    remappedPerson.Person_Address.Add(person_Address);
                });
            }

            if (person.Users != null)
            {
                remappedPerson.Users = new List<User>();
                person.Users.ToList().ForEach(u =>
                {
                    User user = Mapper.MapUserSingle(u, true);
                    remappedPerson.Users.Add(user);
                });
            }

            return remappedPerson;
        }

        internal SaveProfileAdminPersonReturnType SaveProfileAdminPersonRaw(SaveProfileAdminPersonDto saveProfileAdminPersonDto, UnitOfWork unitOfWork)
        {
            SaveProfileAdminPersonReturnType saveProfileAdminPersonReturnType = new SaveProfileAdminPersonReturnType();

            daoFactory.PersonDao.SaveOnlyPerson(saveProfileAdminPersonDto.Person);
            if (saveProfileAdminPersonDto.Person.Person_ContactType != null)
            {
                daoFactory.PersonDao.UpdatePerson_ContactTypeForPerson(saveProfileAdminPersonDto.Person.Person_ContactType.ToList(), saveProfileAdminPersonDto.Person.IdPerson.Value, unitOfWork.Db);
            } else
            {
                saveProfileAdminPersonDto.Person.Person_ContactType.ToList().ForEach((contact) => {
                    Person_ContactType person_ContactType = new Person_ContactType();
                    person_ContactType.ContactType = contact.ContactType;
                    person_ContactType.Description = contact.Description;
                    person_ContactType.IdPerson = saveProfileAdminPersonDto.Person.IdPerson;
                    daoFactory.Person_ContactTypeDao.SaveOnlyPerson_ContactType(person_ContactType);
                });               
            }

            if (saveProfileAdminPersonDto.Person.Person_Address != null)
            {
                daoFactory.PersonDao.UpdatePerson_AddressForPerson(saveProfileAdminPersonDto.Person.Person_Address.ToList(), saveProfileAdminPersonDto.Person.IdPerson.Value, unitOfWork.Db);
                saveProfileAdminPersonDto.Person.Person_Address.Where(pa => pa.IsDeactivated != true && pa.Address != null).ToList().ForEach(pa =>
                {
                    daoFactory.AddressDao.SaveOnlyAddress(pa.Address, unitOfWork.Db);
                    pa.IdAddress = pa.Address.IdAddress;
                    daoFactory.Person_AddressDao.SaveOnlyPerson_Address(pa, unitOfWork.Db);
                });
            }

            saveProfileAdminPersonReturnType.Person = saveProfileAdminPersonDto.Person;

            return saveProfileAdminPersonReturnType;
        }
    }
}
