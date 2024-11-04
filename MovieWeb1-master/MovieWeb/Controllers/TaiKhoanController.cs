using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWeb.Models;

namespace MovieWeb.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        //
        // GET: /Admin/TaiKhoan/

        dbDoAnWebEntities data = new dbDoAnWebEntities();
        public ActionResult DSTaiKhoan()
        {
            var tk = data.TaiKhoans.ToList();
            return View(tk);
        }
        private bool ContainsSpecialCharacter(string str)
        {
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";

            foreach (var character in specialCharacters)
            {
                if (str.Contains(character))
                {
                    return true;
                }
            }

            return false;
        }
        //Xóa TK
        public ActionResult XoaTK(string tendn)
        {
            TaiKhoan tk = data.TaiKhoans.SingleOrDefault(n => n.TenDN == tendn);
            if (tk == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
            data.TaiKhoans.Remove(tk);
            data.SaveChanges();
            return RedirectToAction("DSTaiKhoan");
        }
        //Thêm tài khoản
        [HttpGet]
        public ActionResult ThemTK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTK(TaiKhoan tk, FormCollection coll)
        {
            var tendn = coll["TenDN"];
            var mk = coll["MatKhau"];
            //var taikhoan = from t in data.TaiKhoans where t.TenDN.Equals(tendn) select t.TenDN;
            var taikhoan = data.TaiKhoans.ToList();
            int kt = 0;
            foreach (var item in taikhoan)
            {
                if (item.TenDN == tendn)
                    kt = 1;
            }
            if (String.IsNullOrEmpty(tendn))
                ViewData["Loi"] = "Tên đăng nhập không được để trống";
            if(mk.Length<8)
            {
                ViewData["Loi11"] = "Mật khẩu phải lớn hơn 8 kí tự";
            }
            else if (String.IsNullOrEmpty(mk))
                ViewData["Loi1"] = "Mật khẩu không được để trống";
            else if (kt == 1)
            {
                ViewData["Loi2"] = "Đã có tài khoản này";
            }
             else if (!ContainsSpecialCharacter(mk))
            {
                ViewData["Loi12"] = "Mật khẩu phải chứa ít nhất một kí tự đặt biệt";
            }
            else
            {
                tk.TenDN = tendn;
                tk.MatKhau = mk;
                data.TaiKhoans.Add(tk);
                data.SaveChanges();
                return RedirectToAction("DSTaiKhoan");
            }
            return View();
        }
        //Sửa
        public ActionResult SuaTK(string tendn)
        {
            var tk = data.TaiKhoans.First(n => n.TenDN == tendn);
            if (tk == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
           
            return View(tk);
        }

        [HttpPost]
        public ActionResult SuaTK(string tendn, FormCollection collection)
        {
            var tk = data.TaiKhoans.First(n => n.TenDN == tendn);
            var quyen = collection["Quyen"];
            var matkhau = collection["MatKhau"];
            /*  var img = collection["Img"];*/
           
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi"] = "Không được để trống";
            }
            if (String.IsNullOrEmpty(quyen))
            {
                ViewData["Loi"] = "Không được để trống";
            }
            if (matkhau.Length < 8)
            {
                ViewData["Loi11"] = "Mật khẩu phải lớn hơn 7 kí tự";
            }
            if (quyen != "True" && quyen != "False")
            {
                ViewData["Loi13"] = "Quyền True(Admin) hoặc False(User)";
            }
            else if (!ContainsSpecialCharacter(matkhau))
            {
                ViewData["Loi12"] = "Mật khẩu phải chứa ít nhất một kí tự đặt biệt";
            }
            else
            {
                tk.Quyen = Convert.ToBoolean(quyen);
                tk.MatKhau = matkhau;
                UpdateModel(quyen);
                UpdateModel(tk);
                data.SaveChanges();
                
               
                return RedirectToAction("DSTaiKhoan");
            }
            return this.SuaTK(tendn);
        }

    }
}
