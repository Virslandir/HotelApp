using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelRazorUI.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseCrud _db;

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]

        // TODO: Tim inicijalizuje ovde ArrivalDate = DateTime.Now i DepartureDate = DateTime.Now.AddDays(1). Zasto?
        // meni radi a nisam inicijalizovao datume, nego sam podesio u html stranici parametar "value". Da li je to pogresno?
        public DateTime ArrivalDate { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        public List<RoomTypeModel> AvailableRoomTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsSearched { get; set; } = false;

        public RoomSearchModel(IDatabaseCrud db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if (IsSearched)
            {
                AvailableRoomTypes = _db.GetAvailableRoomTypes(ArrivalDate, DepartureDate);
            }

        }

        // SOLVED: Saznaj zasto radi sa redirect na GET
        // umesto da odmah u odgovoru na POST vrati listu soba?
        // Odgovor: da bi izbegao probleme sa Refresh i Back/Forward u Browserima
        public IActionResult OnPost()
        {
            IsSearched = true;
            return RedirectToPage(new { IsSearched, ArrivalDate, DepartureDate});
        }


    }
}
