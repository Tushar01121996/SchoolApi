using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ISection
    {
        public int SaveUpdate(SectionModel classModel);
        public int Delete(int Id, string SID);
        public List<SectionModel> GetAll();
        public SectionModel GetById(int Id, string SID);
    }
}
