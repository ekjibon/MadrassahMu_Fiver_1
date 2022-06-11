using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;
using Subscription.Data.EntityFramework.Identity;

namespace Subscription.Data
{
    public partial class UnitOfWork : IDisposable
    {
        private SubscriptionEntities db;
        private ApplicationDbContext identityDb;

        public bool IsDealingWithIdentity;
        public SubscriptionEntities Db { get { return db; } }
        public ApplicationDbContext IdentityDb { get { return identityDb; } }

        public UnitOfWork(bool isDealingWithIdentity = false)
        {
            db = new SubscriptionEntities();
            this.IsDealingWithIdentity = isDealingWithIdentity;

            if (this.IsDealingWithIdentity)
            {
                identityDb = ApplicationDbContext.Create();
            }

        }
        public void Begin()
        {
            db.Database.BeginTransaction();
            if (IsDealingWithIdentity)
            {
                identityDb.Database.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (db.Database.CurrentTransaction != null)
            {
                db.Database.CurrentTransaction.Commit();
            }

            if (this.IsDealingWithIdentity && identityDb.Database.CurrentTransaction != null)
            {
                identityDb.Database.CurrentTransaction.Commit();
            }

            Dispose();
        }

        public void RollbackTransaction(bool shouldDispose = true)
        {
            if (db.Database.CurrentTransaction != null)
            {
                db.Database.CurrentTransaction.Rollback();
            }

            if (this.IsDealingWithIdentity && identityDb.Database.CurrentTransaction != null)
            {
                identityDb.Database.CurrentTransaction.Rollback();
            }
            if (shouldDispose)
                Dispose();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }

            if (this.IsDealingWithIdentity && identityDb != null)
            {
                identityDb.Dispose();
            }
        }

        public void SaveChanges(DbContext dbContext)
        {
            if(dbContext != null)
            {
                dbContext.SaveChanges();
            }
        }
    }
}