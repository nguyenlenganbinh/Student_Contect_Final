using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Student_Contact_Final.Models;
using Student_Contact_Final.Data;
using DTOCls;

namespace Student_Contact_Final.Controllers.api
{
    public class InformationController : ApiController
    {
        private readonly MyDBContext _context = new MyDBContext();

        /// <summary>
        /// Get All Information when user click function "Information" on NAVBAR
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllInformations()
        {
            IEnumerable<Infomation> listItem = from n in _context.infomations
                                               orderby n.CreateDate descending
                                               select n;
            List<DTOInformation> listInfo = new List<DTOInformation>();
            if (listItem != null)
            {
                GetListCustom(listItem, listInfo);
                return Ok(listInfo);
            }
            return NotFound();
        }

        /// <summary>
        /// Get List Information by search
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="createDate"></param>
        /// <returns></returns>
        public IHttpActionResult GetInformations(string adminname, DateTime createdate)
        {
            IEnumerable<Infomation> listItem = null;
            List<DTOInformation> listInfo = new List<DTOInformation>();
            if (adminname != null && createdate != null)        //Have All
            {
               listItem = from n in _context.infomations
                          where n.Admin.Name.Equals(adminname) && n.CreateDate.Equals(createdate)
                          orderby n.CreateDate descending
                          select n;
                if (listItem != null)
                {
                    GetListCustom(listItem, listInfo);
                    return Ok(listInfo);
                }
                return NotFound();
            }
            else if (adminname == null && createdate != null)  //Not Name But Have Date
            {
                listItem = from n in _context.infomations
                           where n.CreateDate.Equals(createdate)
                           orderby n.CreateDate descending
                           select n;
                if (listItem != null)
                {
                    GetListCustom(listItem, listInfo);
                    return Ok(listInfo);
                }
                return NotFound();
            }
            else if (adminname != null && createdate == null)  //Have Name But Not Date
            {
                listItem = from n in _context.infomations
                           where n.Admin.Name.Equals(adminname)
                           orderby n.CreateDate descending
                           select n;
                if (listItem != null)
                {
                    GetListCustom(listItem, listInfo);
                    return Ok(listInfo);
                }
                return NotFound();
            }
            else                                               //Not All
            {
                listItem = from n in _context.infomations
                           orderby n.CreateDate descending
                           select n;
                if (listItem != null)
                {
                    GetListCustom(listItem, listInfo);
                    return Ok(listInfo);
                }
                return NotFound();
            }
        }

        /// <summary>
        /// Post Information
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public IHttpActionResult PostInformation(DTOInformation information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                Infomation item = new Infomation();
                item.Title = information.Title;
                item.Content = information.Content;
                item.CreateDate = information.CreateDate;
                item.AdminId = information.AdminId;
                _context.infomations.Add(item);
                _context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Put Information
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public IHttpActionResult PutInformation(DTOInformation information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                Infomation item = (from n in _context.infomations
                                   where n.InfomationId.Equals(information.InfomationId)
                                   select n).FirstOrDefault();
                if (item != null)
                {
                    item.Title = information.Title;
                    item.Content = information.Content;
                    item.CreateDate = information.CreateDate;
                    item.AdminId = information.AdminId;
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest("Invalid data.");
            }
        }

        /// <summary>
        /// Delete information
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public IHttpActionResult DeleteInformation(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                Infomation item = (from n in _context.infomations
                                   where n.InfomationId.Equals(id)
                                   select n).FirstOrDefault();
                _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Custom List Information to List DTO Information
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="listInfo"></param>
        protected void GetListCustom(IEnumerable<Infomation> listItem, List<DTOInformation> listInfo)
        {
            foreach (Infomation item in listItem)
            {
                DTOInformation information = new DTOInformation();
                information.InfomationId = item.InfomationId;
                information.Title = item.Title;
                information.Content = item.Content;
                information.CreateDate = item.CreateDate;
                information.AdminId = item.AdminId;
                information.AdminName = item.Admin.Name;
                listInfo.Add(information);
            }
        }
    }
}
