using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public class Messages
    {
        public static string UserRegistered = "User kaydedildi..";
        internal static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "sifre hatalı";
        internal static string SuccessfulLogin = "login başarılı";
    }
}
