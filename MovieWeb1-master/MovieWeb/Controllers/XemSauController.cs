using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWeb.Models;

namespace WebXemPhim.Controllers
{
    public class XemSauController : Controller
    {
        //
        // GET: /XemSau/
        dbDoAnWebEntities data = new dbDoAnWebEntities();
        public ActionResult Index(string tendn)
        {
            var DSPhimBo = data.DSPhimBoes.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            var quocgia = data.QuocGias.ToList();
            ViewData["QuocGia"] = quocgia;
            var hopphim = data.HopPhims.Where(m => m.TenDN.Equals(tendn)).ToList();
            return View(hopphim);
        }

        public ActionResult ThemVaoXemSau(string tendn, int idphim)
        {
            var quocgia = data.QuocGias.ToList();
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            ViewData["QuocGia"] = quocgia;

            HopPhim phim = new HopPhim();
            var dsphim = data.HopPhims.Where(m => m.TenDN == tendn).ToList();
            foreach (var item in dsphim)
            {
                if (item.IDPhim == idphim)
                    return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = item.IDPhim });
            }
            phim.TenDN = tendn;
            phim.IDPhim = idphim;
            data.HopPhims.Add(phim);
            data.SaveChanges();
            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = idphim });
        }
        public ActionResult XoaXemSau(string tendn, int idphim)
        {
            HopPhim tl = data.HopPhims.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
            if (tl == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
            data.HopPhims.Remove(tl);
            data.SaveChanges();
            return RedirectToAction("Index", new { tendn = tl.TenDN });
        }
    }
}
