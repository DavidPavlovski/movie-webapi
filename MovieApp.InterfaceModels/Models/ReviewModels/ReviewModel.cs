using MovieApp.InterfaceModels.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.InterfaceModels.Models.ReviewModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int MovieId { get; set; }
        public EntityOwnerModel User { get; set; }
        public DateTime Posted { get; set; }
    }
}
