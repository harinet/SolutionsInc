using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceApi.Models;

namespace ServiceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StatsController : Controller
    {
        private static List<User> _sampleUserList = null;
        private static List<Hit> _sampleHitList = null;

        public StatsController()
        {
            LoadSampleData();
        }

        /// <summary>
        /// computes the last visited page yesterday for each user from the sample data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("visits")]
        public JsonResult LastVisitedUserPage()
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            var data = from user in (from hits in _sampleHitList
                                     where hits.Date.Date == yesterday.Date
                                     group hits by hits.UserId into grp
                                     select new
                                     {
                                         grp.Key,
                                         url = (from item in grp
                                                orderby item.Date descending
                                                select item.Url).FirstOrDefault()
                                     })
                       join usr in _sampleUserList on user.Key equals usr.Id
                       select new { Name = usr.FirstName + ' ' + usr.LastName, LastVisited = user.url };
            return Json(data);
        }

        /// <summary>
        /// computes the top 10 most active users anytime from the sample data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("activeusers")]
        public JsonResult ActiveUsers()
        {
            var data = from user in (from hit in _sampleHitList
                                     group hit by hit.UserId into grp
                                     select new { id = grp.Key, count = grp.Count() })
                       join usr in _sampleUserList on user.id equals usr.Id
                       orderby user.count descending
                       select new { Name = usr.FirstName + ' ' + usr.LastName, HitCount = user.count };
            return Json(data.Take(10));
        }

        /// <summary>
        /// Load sample data to lists
        /// </summary>
        [NonAction]
        private void LoadSampleData()
        {
            _sampleUserList = new List<User>{
                new User{Id = Guid.NewGuid(),FirstName = "Allan",LastName = "Jones"},
                new User{Id = Guid.NewGuid(),FirstName = "Carson",LastName = "Smith"},
                new User{Id = Guid.NewGuid(),FirstName = "Caron",LastName = "Brown"},
                new User{Id = Guid.NewGuid(),FirstName = "John",LastName = "Miller"}
            };

            _sampleHitList = new List<Hit> {
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Allan").Id, Url = "www.google.com", Date = DateTime.Now},
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Carson").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-1) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-2) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.google.com", Date = DateTime.Now },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Caron").Id, Url = "www.ggle.com", Date = DateTime.Now.Date.AddDays(-1) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-3) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Allan").Id, Url = "www.gole.com", Date = DateTime.Now.Date.AddDays(-1) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Caron").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-2) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.google.com", Date = DateTime.Now },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.le.com", Date = DateTime.Now.Date.AddDays(-1) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Allan").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-2) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Caron").Id, Url = "www.e.com", Date = DateTime.Now.Date.AddDays(-1).AddMinutes(30) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Carson").Id, Url = "www.google.com", Date = DateTime.Now },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "Allan").Id, Url = "www.gle.com", Date = DateTime.Now.Date.AddDays(-1).AddHours(4) },
                new Hit { Id = Guid.NewGuid(), UserId = _sampleUserList.Single(u => u.FirstName == "John").Id, Url = "www.google.com", Date = DateTime.Now.Date.AddDays(-3) }
            };
        }
    }
}
