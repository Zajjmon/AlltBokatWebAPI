using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AlltBokatWebAPI.Models;
using static AlltBokatWebAPI.Services.DTOs.BookingDTOs;
using AlltBokatWebAPI.Services;

namespace AlltBokatWebAPI.Controllers
{
    public class BookingModelsController : ApiController
    {

        private IBookingServices bookingServices;

        public BookingModelsController()
        {

            this.bookingServices = new BookingServices();
        }

        public BookingModelsController(IBookingServices bookingServices)
        {
            this.bookingServices = bookingServices;
        }

        // GET: api/BookingModels
        [ResponseType(typeof(List<SingleBookingDTO>))]
        public async Task<IHttpActionResult> GetBookings()
        {
            var bookingList = await bookingServices.GetListOfBookings();
            return Ok(bookingList);

        }



        // GET: api/BookingModels/5
        [ResponseType(typeof(SingleBookingDTO))]
        public async Task<IHttpActionResult> GetSingleBookingById(int id)
        {
            var singleBooking = await bookingServices.GetSingleBooking(id);
            return Ok(singleBooking);

        }

        // PUT: api/BookingModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingModels(int id, BookingRequestDTO bookingRequest)
        {


            var bookingValidator = new BookingValidation();
            var errorList = bookingValidator.ValidateBookingRequestDTO(bookingRequest);
            if (!errorList.All(x => x == true))
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "The Booking Request is invalid or otherwise incomplete."));
            }

            bookingRequest = await bookingServices.UpdateSingleBooking(id, bookingRequest);

            return Ok(bookingRequest);
        }

        // POST: api/BookingModels
        [ResponseType(typeof(BookingRequestDTO))]
        public async Task<IHttpActionResult> PostBookingModels(BookingRequestDTO bookingRequest)
        {
            if (bookingRequest == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "You sent nothing."));
            }
            var bookingValidator = new BookingValidation();
            var errorList = bookingValidator.ValidateBookingRequestDTO(bookingRequest);
            if (!errorList.All(x => x == true))
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "The Booking Request is invalid or otherwise incomplete."));
            }
            // kalla på service layer valideringsmetod(bookingRequest);
            // gammal call BookingModels booking = await bookingRepository.PostBookingModels(bookingRequest);
            bookingRequest = await bookingServices.AddBookingRequest(bookingRequest);

            return CreatedAtRoute("DefaultApi", new { id = bookingRequest.Id }, bookingRequest);
        }

        // DELETE: api/BookingModels/5
        [ResponseType(typeof(SingleBookingDTO))]
        public async Task<IHttpActionResult> DeleteBookingModels(int id)
        {


            SingleBookingDTO singleBookingDTO = await bookingServices.DeleteSingleBooking(id);
            if (singleBookingDTO == null)
            {
                return NotFound();
            }

            return Ok(singleBookingDTO);
        }

        protected override void Dispose(bool disposing)
        {
            bookingServices.Dispose();
            base.Dispose(disposing);
        }



    }
}