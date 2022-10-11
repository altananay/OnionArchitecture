using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class Messages
    {
        public static string UserRegistered = "Kayıt işlemi başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre yalnış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string LoginSuccessful = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı daha önce kayıt olmuş.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductAdded = "Product added.";
    }
}