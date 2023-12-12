using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public PaymentDetailsController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
        {
          if (_context.PaymentDetails == null)
          {
              return NotFound();
          }
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int id)
        {
          if (_context.PaymentDetails == null)
          {
              return NotFound();
          }
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetails(int id, PaymentDetails paymentDetails)
        {
            var details = await _context.PaymentDetails.FindAsync(id);

            if (details != null)
            {
                details.CardNumber = paymentDetails.CardNumber;
                details.CardOwnerName = paymentDetails.CardOwnerName;
                details.SecurityCode = paymentDetails.SecurityCode;
                details.ExpirationDate = paymentDetails.ExpirationDate;
            }

           // _context.Entry(paymentDetails).State = EntityState.Modified;



            try
            {
               // _context.PaymentDetails.Update(details);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
          if (_context.PaymentDetails == null)
          {
              return Problem("Entity set 'PaymentDbContext.PaymentDetails'  is null.");
          }
            var newPayment = new PaymentDetails()
            {
                CardNumber = paymentDetails.CardNumber,
                CardOwnerName = paymentDetails.CardOwnerName,
                SecurityCode = paymentDetails.SecurityCode,
                ExpirationDate = paymentDetails.ExpirationDate,
            };
            _context.PaymentDetails.Add(newPayment);
            await _context.SaveChangesAsync();
            return Ok(await _context.PaymentDetails.ToListAsync());

        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        private bool PaymentDetailsExists(int id)
        {
            return (_context.PaymentDetails?.Any(e => e.PaymentDetailsId == id)).GetValueOrDefault();
        }
    }
}
