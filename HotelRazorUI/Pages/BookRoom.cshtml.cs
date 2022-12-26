using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelRazorUI.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseCrud _db;

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [BindProperty]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        public BookRoomModel(IDatabaseCrud db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            // TODO: Dodati ucitavanje RoomType (i odgovoarajuci public property) prema unetom RoomTypeId.

            return Page();
        }

        public IActionResult OnPost()
        {
            _db.BookARoom(FirstName, LastName, ArrivalDate, DepartureDate, RoomTypeId);
            return RedirectToPage("Index");
        }
    }
}
