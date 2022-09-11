﻿using MovieApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IUserService
    {
        UserModel Login(LoginModel model);
        void Register(RegisterModel model);
    }
}
