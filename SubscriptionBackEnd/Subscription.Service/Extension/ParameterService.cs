using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.HostedDomain;
using Subscription.Data;

namespace Subscription.Service
{
    public partial class ParameterService : BaseService
    {
      

        internal string GetRaterizerApplicationPath()
        {
            List<long> idParameters = new List<long>() { };
            Expression<Func<Parameter, bool>> expression = property => property.IsDeactivated != true
                && property.IdParameter == (long)ParameterEnum.RASTERIZER_APPLICATION_PATH;

            return daoFactory.ParameterDao.GetParameterCustom(expression).ParamaterValue;
        }
    }
}
