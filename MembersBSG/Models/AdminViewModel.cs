using BSG.Domain;
using BSG.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSG.WebUI.Models
{
    public class AdminViewModel
    {
        public List<Coach> Coaches { get; set; }
        public List<IdentityUser> Students { get; set; }
    }
}