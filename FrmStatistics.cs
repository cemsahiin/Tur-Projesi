using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon Sayısı
            lblLocationCount.Text = db.Location.Count().ToString();
            #endregion

            #region Toplam Kapasite
            lblSumCapacity.Text= db.Location.Sum(x => x.Capacity).ToString();
            #endregion

            #region Rehber Sayısı
            lblGuideCount.Text = db.Guide.Count().ToString();
            #endregion

            #region Ortalama Kapasite
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
            #endregion

            #region Ortalama Tur Fiyatı
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).ToString() + "TL";
            #endregion

            #region Eklenen Son Ülke
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(Y => Y.Country).FirstOrDefault();
            #endregion

            #region Kapadokya Tur Kapasitesi
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City=="Kapadokya").Select(y =>y.Capacity).FirstOrDefault().ToString();
            #endregion

           # region Türkiye Turları Ortalama Kapasite
            lblTurkeyCapacityAvg.Text = db.Location.Where(x => x.Country =="Türkiye").Average(y => y.Capacity).ToString();
            #endregion

            #region Roma Gezi Rehberi
            var romeGuideId = db.Location.Where(x =>x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            #endregion

            #region En Yüksek Kapasiteli Tur
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text= db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            #endregion

            #region En Pahalı Tur
            var maxPrice = db.Location.Max(x =>x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x =>x.Price == maxPrice).Select(y =>y.City).FirstOrDefault().ToString();
            #endregion

            #region Nermin Özel Tur Sayısı
            var guideIdByNerminOzel = db.Guide.Where(x => x.GuideName == "Nermin" && x.GuideSurname == "Özel").Select(y => y.GuideId).FirstOrDefault();
            lblNerminOzelLocationCount.Text = db.Location.Where(x => x.GuideId ==guideIdByNerminOzel).Count().ToString();
            #endregion
        }
    }
}
