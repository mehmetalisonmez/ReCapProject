using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class CarMessages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameOrDailyPriceInvalid = "Araç ismi veya araç günlük fiyatı geçersiz";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarsByBrandId = "Uygun marka id'sine göre araçlar listelendi";
        public static string CarsByColorId = "Uygun renk id'sine göre araçlar listelendi";
        public static string SomeCarsDetails = "Araçların bazı detayları getirildi";
        public static string CarCountOfBrandError = "Bir markaya ait en fazla 5 araç olabilir";
        public static string CarNameExistsError = "Aynı isimde maksimum 2 araç eklenebilir";
        public static string ColorLimitExceded = "Renk limiti aşıldığı için araba eklenemiyor" +
            "";
    }
}
