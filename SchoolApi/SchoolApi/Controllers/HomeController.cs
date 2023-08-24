using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interface;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IClass iclass;
        private readonly ISection iSection;
        public HomeController(IClass iclass, ISection iSection)
        {
            this.iclass = iclass;
            this.iSection = iSection;
        }

        #region ClassMaster
        [HttpGet]
        [Route("GetAllClasses")]
        public IActionResult GetAllClasses() 
        {
            List<ClassModel> model = iclass.GetAll();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAllClassById")]
        public IActionResult GetAllClassByid(int id, string SID)
        {
            ClassModel model = iclass.GetById(id, SID);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpDelete]
        [Route("DeleteClass")]
        public IActionResult DeleteClass(int id, string SID)
        {
            int retVal = iclass.Delete(id, SID);
            if (retVal != 0)
            {
                return Ok("Delete Successfully");
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("SaveUpdateClass")]
        public IActionResult SaveUpdateClass(ClassModel model)
        {
            int retVal = iclass.SaveUpdate(model);
            if(retVal != 0) 
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

        #region Section Master
        [HttpGet]
        [Route("GetAllSection")]
        public IActionResult GetAllSection()
        {
            List<SectionModel> model = iSection.GetAll();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAllSectionById")]
        public IActionResult GetAllSectionByid(int id, string SID)
        {
            SectionModel model = iSection.GetById(id, SID);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("DeleteSection")]
        public IActionResult DeleteSection(int id, string SID)
        {
            int retVal = iSection.Delete(id, SID);
            if (retVal != 0)
            {
                return Ok("Delete Successfully");
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("SaveUpdateSection")]
        public IActionResult SaveUpdateSection(SectionModel model)
        {
            int retVal = iSection.SaveUpdate(model);
            if (retVal != 0)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
