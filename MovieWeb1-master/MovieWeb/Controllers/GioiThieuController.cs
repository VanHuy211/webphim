using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWeb.Models;
using PagedList;
using PagedList.Mvc;

namespace MovieWeb.Controllers
{
    public class GioiThieuController : Controller
    {
        //
        // GET: /GioiThieu/
        dbDoAnWebEntities data = new dbDoAnWebEntities();
        public ActionResult GioiThieuWebXemPhim()
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;
            var tt = data.gioithieux.ToList();
            return View(tt);
        }

    }
}
