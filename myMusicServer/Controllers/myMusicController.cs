using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myMusicServer.Models;

namespace myMusicServer.Controllers
{
    [RoutePrefix("api")]
    public class myMusicController : ApiController
    {
        myMusicEntities1 objEntity = new myMusicEntities1();
        [HttpGet]
        [Route("AllItemsDetails")]

        public IQueryable<Item> GetItems()
        {
            try
            {
                return objEntity.Items;
            }

            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("GetItemDetailsById/{itemID}")]
        public IHttpActionResult GetItemDetailsById(int itemID)
        {
            Item myObj = new Item();
            try
            {
                myObj = objEntity.Items.Find(itemID);
                if (myObj == null)
                {
                    return NotFound();
                }
            }

            catch (Exception)
            {
                throw;
            }
            return Ok(myObj);
        }

        [HttpPost]
        [Route("InsertItemsDetails")]
        public IHttpActionResult PostItems(Item data)
        {
            //modelState review
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Items.Add(data);
                objEntity.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteItemsDetails")]
        public IHttpActionResult DeleteItem(int id)
        {
            Item myObj = objEntity.Items.Find(id);
            if (myObj == null)
            {
                return NotFound();
            }
            objEntity.Items.Remove(myObj);
            objEntity.SaveChanges();
            return Ok(myObj);
        }

        [HttpPost]
        [Route("InsertUserDetails")]
        public IHttpActionResult PostUser(User data)
        {
            //modelState review
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.Users.Add(data);
                objEntity.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }
    }
}
