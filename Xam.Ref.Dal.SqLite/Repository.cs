using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Models;

namespace Xam.Ref.Dal.SqLite
{
    public class Repository<T> : BaseDal, IRepository<T> where T : BaseModel, new()
    {
        public Repository()
        {
               
        }

        public virtual string Save(T entity)
        {
            return Database.Insert(entity).ToString();
        }

        public virtual bool Update(T entity)
        {
            return Database.Update(entity) > 0 ? true : false;
        }

        public virtual bool Delete(T entity)
        {
            return Database.Delete<T>(entity.Id) > 0 ? true : false;
        }

        public virtual T GetById(int id)
        {
            return Database.Get<T>(i => i.Id == id);
        }

        public virtual bool SaveAll(IEnumerable<T> entities)
        {
            return Database.InsertAll(entities) > 0 ? true : false;
        }

        public virtual bool UpdateAll(IEnumerable<T> entities)
        {
            return Database.UpdateAll(entities) > 0 ? true : false;
        }

        public virtual bool DeleteAll()
        {

            var isSuccess = Database.DeleteAll<T>() > 0 ? true : false;

            //Database.Query( BenefitLocation,"DELETE FROM SQLITE_SEQUENCE WHERE NAME = {0}","BenefitLocation")

            return isSuccess;
        }

        public virtual bool DropTable()
        {
            return Database.DropTable<T>() > 0 ? true : false;
        }

        public virtual bool CreateTable()
        {
            return Database.CreateTable<T>() > 0 ? true : false;
        }


        public virtual IEnumerable<T> GetAll()
        {
            lock (_locker)
            {
                return (from i in Database.Table<T>() select i);
            }
        }

        public virtual bool IfExists(T entity)
        {
            throw new NotImplementedException();
        }


        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Database.Commit();
        }
    }
}
