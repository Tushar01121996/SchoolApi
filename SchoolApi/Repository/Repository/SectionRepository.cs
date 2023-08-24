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
    public class SectionRepository : ISection
    {
        private readonly ApplicationDBContext dbContext;
        public SectionRepository(ApplicationDBContext applicationDBContext) 
        {
            dbContext = applicationDBContext;
        }
        public int Delete(int Id, string SID)
        {
            int retVal = 0;
            SectionModel model = dbContext.Section.Where(x => x.srno == Id && x.SID == SID).FirstOrDefault();
            if (model != null)
            {
                dbContext.Section.Remove(model);
                retVal = dbContext.SaveChanges();
                return retVal;
            }
            else
            {
                return 0;
            }
        }

        public List<SectionModel> GetAll()
        {
           return dbContext.Section.ToList();
        }

        public SectionModel GetById(int Id, string SID)
        {
            return dbContext.Section.Where(x => x.srno == Id && x.SID == SID).FirstOrDefault();
        }

        public int SaveUpdate(SectionModel sectionModel)
        {
            if(sectionModel !=null)
            {
                int retVal = 0;
                SectionModel model = dbContext.Section.Where(x => x.srno == sectionModel.srno && x.SID == sectionModel.SID).FirstOrDefault();
                if (model != null)
                {
                    model.sectionname = sectionModel.sectionname;
                    dbContext.Section.Update(model);
                    retVal = dbContext.SaveChanges();
                }
                else
                {
                    var data = dbContext.Section.ToList().OrderByDescending(x => x.srno).Select(x => x.sectionid).FirstOrDefault();
                    int maxValue = data != null ? Convert.ToInt32(dbContext.Section.ToList().OrderByDescending(x=>x.srno).Select(x=>x.sectionid).FirstOrDefault().Substring(2,4)) : 0;
                    string sectionId = string.Format("{0:SL000}", maxValue + 1);
                    sectionModel.sectionid = sectionId;
                    dbContext.Section.Add(sectionModel);
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
