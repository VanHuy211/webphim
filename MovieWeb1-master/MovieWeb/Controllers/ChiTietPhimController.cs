using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class ChiTietPhimController : Controller
    {
        //
        // GET: /ChiTietPhim/
        dbDoAnWebEntities data = new dbDoAnWebEntities();
        public ActionResult ChiTietPhim(int id, string tendn)
        {

            var Phim = data.DSPhimBoes.Where(m => m.ID == id).First();
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["QuocGia"] = quocgia;
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;


            return View(Phim);
        }
        public ActionResult ChiTietPhimLe(int id)
        {
            var DSPhimLe = data.DSPhimLes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimLe;
            var Phim = data.DSPhimLes.Where(m => m.ID == id).First();
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["QuocGia"] = quocgia;
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            return View(Phim);
        }



    }
}
