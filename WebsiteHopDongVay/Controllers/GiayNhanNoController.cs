using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHopDongVay.Models;

namespace WebsiteHopDongVay.Controllers
{
    public class GiayNhanNoController : Controller
    {
        private static bool isEdit = false;

        // GET: GiayBaoNhanLaiVay
        [HttpGet]
        public ActionResult Index()
        {
            List<HDV_GNN> list = new dbQuanLyHopDongVayEntities().HDV_GNN.ToList<HDV_GNN>();
            ViewData["ds_gnn"] = list;
            return View();
        }

        // thêm dữ liệu
        [HttpPost]
        public ActionResult Index(HDV_GNN X)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            if (!isEdit)
                db.HDV_GNN.Add(X);
            else
            {
                HDV_GNN y = db.HDV_GNN.Find(X.GNN_SO);
                y.GNN_NGAY = X.GNN_NGAY;
                y.KUGN_SO = X.KUGN_SO;
                y.MSLNT = X.MSLNT;
                y.TYGIA = X.TYGIA;
                y.TIENVAY = X.TIENVAY;
                y.TIENVAYVND = X.TIENVAYVND;
                y.TIENMAT = X.TIENMAT;
                isEdit = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["ds_gnn"] = db.HDV_GNN.ToList<HDV_GNN>();
            return View();
        }

        // xóa dữ liệu
        [HttpPost]
        public ActionResult Delete(string giaybao_xoa)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GNN x = db.HDV_GNN.Find(giaybao_xoa);
            db.HDV_GNN.Remove(x);
            db.SaveChanges();
            ViewData["ds_gnn"] = db.HDV_GNN.ToList<HDV_GNN>();
            return View("Index");
        }

        // sửa dữ liệu
        [HttpPost]
        public ActionResult Edit(string giaybao_sua)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_GNN x = db.HDV_GNN.Find(giaybao_sua);
            isEdit = true;
            ViewData["ds_gnn"] = db.HDV_GNN.ToList<HDV_GNN>();
            return View("Index", x);
        }
    }
}