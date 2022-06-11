using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IDocumentDao
    {
        void SaveOnlyDocumentWithDocumentDetail(Document document);
        void SaveOnlyDocumentWithDocumentDetail(Document document, SubscriptionEntities db);
        Parameter GetPhysicalDocumentRepositoryPath();
        Parameter GetPhysicalDocumentRepositoryPath(SubscriptionEntities db);
        Parameter GetDocumentServerUrl();
        Parameter GetDocumentServerUrl(SubscriptionEntities db);
        Parameter GetReportDllPath();
        Parameter GetReportDllPath(SubscriptionEntities db);
        Parameter GetMefDllPath();
        Parameter GetMefDllPath(SubscriptionEntities db);
        void DeleteMultipleDocumentWithoutSaving(List<long> idDocuments, SubscriptionEntities db);
    }
}
