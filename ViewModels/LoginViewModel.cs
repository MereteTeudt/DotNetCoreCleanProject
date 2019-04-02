using System;

namespace CoreAPI.ViewModels
{
    public class LoginViewModel: IBaseViewModel
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}
