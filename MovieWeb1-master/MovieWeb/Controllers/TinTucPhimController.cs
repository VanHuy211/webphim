using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWeb.Models;
using PagedList;
using PagedList.Mvc;

namespace WebXemPhim.Controllers
{
    public class TinTucPhimController : Controller
    {
        //
        // GET: /TinTucPhim/
        dbDoAnWebEntities data = new dbDoAnWebEntities();

       
        public ActionResult TinTuc()
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;
            var tt = data.tintucphims.ToList();
            return View(tt);
        }
        public ActionResult ChiTietTinTuc(int id)
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;
            var tt = data.tintucphims.SingleOrDefault(n => n.idtintuc == id);
            return View(tt);
        }

    }
}
