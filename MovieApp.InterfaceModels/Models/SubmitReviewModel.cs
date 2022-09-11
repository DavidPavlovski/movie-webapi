using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.InterfaceModels.Models
{
    public class SubmitReviewModel
    {
        public int Rating { get; set; }
        public string? Review { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
