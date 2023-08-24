using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ClassRepository : IClass
    {
        private readonly ApplicationDBContext dbContext;
        public ClassRepository(ApplicationDBContext applicationDBContext) 
        {
            dbContext = applicationDBContext;
        }
        public int Delete(int Id, string SID)
        {
            int retVal = 0;
            ClassModel model = dbContext.Class.Where(x => x.srno == Id && x.SID == SID).FirstOrDefault();
            if (model != null)
            {
                dbContext.Class.Remove(model);
                retVal = dbContext.SaveChanges();
                return retVal;
            }
            else
            {
                return 0;
            }
        }

        public List<ClassModel> GetAll()
        {
           return dbContext.Class.ToList();
        }

        public ClassModel GetById(int Id, string SID)
        {
            return dbContext.Class.Where(x => x.srno == Id && x.SID == SID).FirstOrDefault();
        }

        public int SaveUpdate(ClassModel classModel)
        {
            if(classModel!=null)
            {
                int retVal = 0;
                ClassModel model = dbContext.Class.Where(x => x.srno == classModel.srno && x.SID == classModel.SID).FirstOrDefault();
                if (model != null)
                {
                    model.classname = classModel.classname;
                    dbContext.Class.Update(model);
                    retVal = dbContext.SaveChanges();
                }
                else
                {
                    int maxValue = Convert.ToInt32(dbContext.Class.ToList().OrderByDescending(x=>x.srno).Select(x=>x.classid).FirstOrDefault().Substring(2,4));
                    string classId = string.Format("{0:CL000}", maxValue + 1);
                    classModel.classid = classId;
                    dbContext.Class.Add(classModel);
                    retVal =  dbContext.SaveChanges();
                }
                return retVal;
            }
            else
            {
                return 0;
            }
        }
    }
}
