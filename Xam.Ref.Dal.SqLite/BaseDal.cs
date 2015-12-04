using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;

namespace Xam.Ref.Dal.SqLite
{
    public abstract class BaseDal : IDisposable
    {
        protected BaseDal()
        {
            _database = IocContainer.Resolve<IDataConnection>().GetConnection() as SQLiteConnection;
            //// Create the tables here  
            //Database.CreateTable<User>();
            //Database.CreateTable<BenefitLocation>();
            //Database.CreateTable<BenefitDetails>();
            //Database.CreateTable<ProductDetails>();
            //Database.CreateTable<ProductBenefitType>();
            //Database.CreateTable<UserProductBenefitType>();
            //Database.CreateTable<MembershipData>();
            //Database.CreateTable<AppSettings>();
            //Database.CreateTable<BenefitSyncStatus>();
            //Database.CreateTable<ContentMaster>();
        }

        #region Private Variables

        /// <summary>
        /// The locker
        /// </summary>
        public static object _locker = new object();

        // The below code will return the platform specific connection using the dependency service provided by Xamarin
        // Each platform has implemented teh ISQLiteConnection interface to return the platform specific local connection string
        /// <summary>
        /// The _database
        /// </summary>
        //static SQLiteAsyncConnection database = DependencyService.Get<ISQLiteConnection>().GetAsyncConnection();
        private static SQLiteConnection _database = null;

        #endregion


        #region Properties

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>The database.</value>
        public static SQLiteConnection Database
        {
            get
            {
                lock (_locker)
                {
                    return _database;
                }
            }
        }

        #endregion

        #region IDisposable Members

        //Implement IDisposable Correctly
        //http://msdn.microsoft.com/en-us/library/ms244737(VS.80).aspx
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            // free native resources if there are any.

        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        /// <summary>
        /// Finalizes an instance of the <see cref="BaseView"/> class.
        /// </summary>
        ~BaseDal()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        #endregion
    }
}
