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
        private MailServices mailservices;

        public BookingModelsController()
        {

            this.bookingServices = new BookingServices();
            mailservices = new MailServices();
        }

        public BookingModelsController(IBookingServices bookingServices)
        {
            this.bookingServices = bookingServices;
        }

        // GET: api/BookingModels
        [ResponseType(typeof(List<SingleBookingDTO>))]
        public async Task<IHttpActionResult> GetBookings()
        {

            return Ok(await bookingServices.GetListOfBookings());

        }



        // GET: api/BookingModels/5
        [ResponseType(typeof(SingleBookingDTO))]
        public async Task<IHttpActionResult> GetSingleBookingById(int id)
        {
            var singleBooking = await bookingServices.GetSingleBooking(id);
            if (singleBooking == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "There is no booking associated with that BookingId"));
            }
            return Ok(await bookingServices.GetSingleBooking(id));

        }
        // GET: api/BookingModels/UsersBookings/5
        [Route("api/BookingModels/UsersBookings/{Id}")]
        [ResponseType(typeof(List<SingleBookingDTO>))]
        public async Task<IHttpActionResult> GetBookingByUserId(string id)
        {
            var listOfBookings = await bookingServices.GetListOfBookingByApplicationUserId(id);
            if (listOfBookings == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "There is no booking associated with that application user ID."));
            }
            return Ok(listOfBookings);
        }

        // GET: api/BookingModels/UsersBookings/5
        [Route("api/BookingModels/UnapprovedBookings/{Id}")]
        [ResponseType(typeof(List<SingleBookingDTO>))]
        public async Task<IHttpActionResult> GetUnapprovedBookingByUserId(string id)
        {
            var listOfBookings = await bookingServices.GetListOfUnapprovedBookingsByUserId(id);
            if (listOfBookings == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "There is no booking associated with that application user ID."));
            }
            return Ok(listOfBookings);
        }

        // PUT: api/BookingModels/ApproveBooking/5 // 
        [Route("api/BookingModels/ApproveBooking/{Id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApproveBooking(int id)
        {
            var approvedBooking = await bookingServices.PutApproveBooking(id);
            if(approvedBooking == null)
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "There is no booking with that ID."));

            return Ok(approvedBooking);
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
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "The Booking Request is invalid or otherwise incomplete."));
            }
            var bookingValidator = new BookingValidation();
            var errorList = bookingValidator.ValidateBookingRequestDTO(bookingRequest);
            if (!errorList.All(x => x == true))
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "The Booking Request is invalid or otherwise incomplete."));
            }
            // kalla på service layer valideringsmetod(bookingRequest);
            
            bookingRequest = await bookingServices.AddBookingRequest(bookingRequest);
            // TO DO returnera fel om en sådan booking redan finns

            await mailservices.NotifyBookingByMail(bookingRequest);
            return CreatedAtRoute("DefaultApi", new { id = bookingRequest.Id }, bookingRequest);
        }

        // DELETE: api/BookingModels/5/234234hdfj23eh23rb2u3rwehrb
        [ResponseType(typeof(SingleBookingDTO))]
        public async Task<IHttpActionResult> DeleteBookingModels(int bookingId, string userId)
        {


            SingleBookingDTO singleBookingDTO = await bookingServices.DeleteSingleBooking(bookingId, userId);
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