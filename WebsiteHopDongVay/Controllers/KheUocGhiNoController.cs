using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHopDongVay.Models;

namespace WebsiteHopDongVay.Controllers
{
    public class KheUocGhiNoController : Controller
    {
        private static bool isEdit = false;

        // GET: GiayBaoNhanLaiVay
        [HttpGet]
        public ActionResult Index()
        {
            List<HDV_KUGN1> list = new dbQuanLyHopDongVayEntities().HDV_KUGN1.ToList<HDV_KUGN1>();
            ViewData["ds_kugn"] = list;
            return View();
        }

        // thêm dữ liệu
        [HttpPost]
        public ActionResult Index(HDV_KUGN1 X)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            if (!isEdit)
                db.HDV_KUGN1.Add(X);
            else
            {
                HDV_KUGN1 y = db.HDV_KUGN1.Find(X.KUGN_SO);
                y.KUGN_NGAY = X.KUGN_NGAY;
                y.HD_SO = X.HD_SO;
                y.MSLNT = X.MSLNT;
                y.TIENVAY = X.TIENVAY;
                y.TIENVAYVND = X.TIENVAYVND;
                y.TIENMAT = X.TIENMAT;
                y.CKHOAN = X.CKHOAN;
                y.MDSD = X.MDSD;
                y.CTKT = X.CTKT;
                y.SOTHANGVAY = X.SOTHANGVAY;
                y.TLVCN = X.TLVCN;
                y.TLVCN_TQN = X.TLVCN_TQN;
                y.NTNGOC = X.NTNGOC;
                y.TL_LS = X.TL_LS;
                y.TL_LS_TQN = X.TL_LS_TQN;
                y.TL_LSGH = X.TL_LSGH;
                isEdit = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["ds_kugn"] = db.HDV_KUGN1.ToList<HDV_KUGN1>();
            return View();
        }

        // xóa dữ liệu
        [HttpPost]
        public ActionResult Delete(string giaybao_xoa)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_KUGN1 x = db.HDV_KUGN1.Find(giaybao_xoa);
            db.HDV_KUGN1.Remove(x);
            db.SaveChanges();
            ViewData["ds_kugn"] = db.HDV_KUGN1.ToList<HDV_KUGN1>();
            return View("Index");
        }

        // sửa dữ liệu
        [HttpPost]
        public ActionResult Edit(string giaybao_sua)
        {
            dbQuanLyHopDongVayEntities db = new dbQuanLyHopDongVayEntities();
            HDV_KUGN1 x = db.HDV_KUGN1.Find(giaybao_sua);
            isEdit = true;
            ViewData["ds_kugn"] = db.HDV_KUGN1.ToList<HDV_KUGN1>();
            return View("Index", x);
        }
    }
}