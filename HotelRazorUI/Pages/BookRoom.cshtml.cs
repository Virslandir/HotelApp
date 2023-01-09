using System;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoomTypeTitle  { get; set; }

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
            if (ModelState.IsValid)
            {
                _db.BookARoom(FirstName, LastName, ArrivalDate, DepartureDate, RoomTypeId);
                return RedirectToPage("BookingConfirmation");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
