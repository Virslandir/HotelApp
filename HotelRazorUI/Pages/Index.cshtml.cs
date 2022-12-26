using DataAccessLibrary.Data;
using DataAccessLibrary.Databases;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRazorUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDatabaseCrud _db;
        
        public List<FullBookingModel> Bookings { get; set; }

        public IndexModel(IDatabaseCrud db)
        {
            _db = db;
        }

        
        public void OnGet()
        {
            Bookings = _db.GetBookings("Spiric");
            
        }
    }
}
