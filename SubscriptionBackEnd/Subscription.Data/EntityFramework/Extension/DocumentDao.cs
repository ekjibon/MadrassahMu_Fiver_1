using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Enums;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial class DocumentDao : IDocumentDao
    {
        public void SaveOnlyDocumentWithDocumentDetail(Document document)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                SaveOnlyDocumentWithDocumentDetail(document, db);
            }
        }

        public void SaveOnlyDocumentWithDocumentDetail(Document document, SubscriptionEntities db)
        {
            Parameter parameterPhysicalDocumentRepositoryPath = GetPhysicalDocumentRepositoryPath(db);
            Parameter parameterBaseServerUrl = GetDocumentServerUrl(db);

            if (document.IdParameterBasePhysicalFilePath == null)
            {
                document.IdParameterBasePhysicalFilePath = parameterPhysicalDocumentRepositoryPath?.IdParameter;
                document.Parameter = parameterPhysicalDocumentRepositoryPath;
            };

            if (document.IdParameterBaseServerUrl == null)
            {
                document.IdParameterBaseServerUrl = parameterBaseServerUrl?.IdParameter;
                document.Parameter1 = parameterBaseServerUrl;
            };

            SaveOnlyDocument(document, db);
        }

        public Parameter GetPhysicalDocumentRepositoryPath()
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetPhysicalDocumentRepositoryPath(db);
            }
        }
        public Parameter GetPhysicalDocumentRepositoryPath(SubscriptionEntities db)
        {
            return db.Parameters.Where(p => p.IdParameter == (long)ParameterEnum.DOCUMENT_PHYSICAL_PATH).FirstOrDefault();
        }

        public Parameter GetDocumentServerUrl()
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetDocumentServerUrl(db);
            }
        }
        public Parameter GetDocumentServerUrl(SubscriptionEntities db)
        {
            return db.Parameters.Where(p => p.IdParameter == (long)ParameterEnum.DOCUMENT_SERVER_URL).FirstOrDefault();
        }

        public Parameter GetReportDllPath()
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetReportDllPath(db);
            }
        }
        public Parameter GetReportDllPath(SubscriptionEntities db)
        {
            return db.Parameters.Where(p => p.IdParameter == (long)ParameterEnum.REPORT_DLL_PATH).FirstOrDefault();
        }

        public Parameter GetMefDllPath()
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetMefDllPath(db);
            }
        }
        public Parameter GetMefDllPath(SubscriptionEntities db)
        {
            return db.Parameters.Where(p => p.IdParameter == (long)ParameterEnum.MEF_DLL_PATH).FirstOrDefault();
        }

        public void DeleteMultipleDocumentWithoutSaving(List<long> idDocuments, SubscriptionEntities db)
        {
            db.Documents.RemoveRange(db.Documents.Where(d => idDocuments.Contains(d.IdDocument.Value)));
        }
    }
}