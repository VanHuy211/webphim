
namespace MovieWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class XemSau
    {
        dbDoAnWebEntities data = new dbDoAnWebEntities();
        public int iID { set; get; }
        public string iTenPhim { set; get; }
        public string hinh { set; get; }
        public XemSau(int id)
        {
            iID = id;
            DSPhimBo phim = data.DSPhimBoes.Single(n => n.ID == iID);
            iTenPhim = phim.TenPhim;
            hinh = phim.Img;
        }
    }
}
