using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TEGram.DAL;
//using TEGram.Models;
using Microsoft.AspNetCore.Authorization;

namespace TEGramApi.Controllers
{
    abstract public class TEGramController : Controller
    {
        protected IUserDAO userDao;
        private TEGram.Models.User currentUser = null;
        public TEGram.Models.User CurrentUser {
            get
            {
                if (currentUser == null)
                {
                    if (base.User != null)
                    {
                        currentUser = userDao.GetUser(base.User.Identity.Name);
                    }
                }
                return currentUser;
            }
        }



        public TEGramController(IUserDAO userDao)
        {
            this.userDao = userDao;
        }

    }
}