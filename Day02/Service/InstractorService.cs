using Day02.Models;
using System.Collections.Generic;
using System.Linq;  

namespace Day02.Service
{


    public class InstractorService : IEntityService<Instractor>
    {
        private readonly MVCDBContext db;

        public InstractorService(MVCDBContext db)
        {
            this.db = db;
        }

        public List<Instractor> GetAll()
        {
            return db.Instractors.ToList();
        }
        public Instractor GetById(int id)
        {
            return db.Instractors.FirstOrDefault(i => i.Id == id);
        }
        public int Add(Instractor newInstractor)
        {
            db.Instractors.Add(newInstractor);
            return db.SaveChanges();
        }
        public int Update(int id, Instractor newInstractor)
        {
            Instractor oldInstractor = GetById(id);
            oldInstractor.Name = newInstractor.Name;
            oldInstractor.Address = newInstractor.Address;
            oldInstractor.Salary = newInstractor.Salary;
            oldInstractor.CId = newInstractor.CId;
            oldInstractor.DId = newInstractor.DId;
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            db.Instractors.Remove(GetById(id));
            return db.SaveChanges();
        }
    }
}
