using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFit.Infrastructure.Data.Models
{
    public class Trainer:ApplicationUser
    {
        public IList<double> Ratings { get; set; }=new List<double>();  

    }
}
