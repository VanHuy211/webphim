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
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        dbDoAnWebEntities data = new dbDoAnWebEntities();

        public ActionResult TimKiemTheLoai(int id)
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["QuocGia"] = quocgia;
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            var Phim = data.DSPhimBoes.Where(m => m.IDTheLoai == id);
            return View(Phim);
        }
        public ActionResult TimKiemNam(int id)
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;
            var Phim = data.DSPhimBoes.Where(m => m.NamPhatHanh == id);
            return View(Phim);
        }
        public ActionResult TimKiemQuocGia(int id)
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;
            var Phim = data.DSPhimBoes.Where(m => m.MaQG == id);
            return View(Phim);
        }
    }
}
