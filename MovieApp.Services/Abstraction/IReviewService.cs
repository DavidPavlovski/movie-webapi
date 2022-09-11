﻿using MovieApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IReviewService
    {
        void Create(SubmitReviewModel model);
    }
}
