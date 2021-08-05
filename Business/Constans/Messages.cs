using Core.Entities.Concrete;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public  static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün  ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductListed="ürünler listelendi";
        public static string ProductCountOfCategoryError = "kategory count hatası";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var ";
        public static string CategoryLimmitExceded = "kategori limiti aşıldı yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz Yok!";
        public static string UserRegistered = "kullanıcı eklendi";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
