using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IClass
    {
        public int SaveUpdate(ClassModel classModel);
        public int Delete(int Id, string SID);
        public List<ClassModel> GetAll();
        public ClassModel GetById(int Id, string SID);
    }
}
