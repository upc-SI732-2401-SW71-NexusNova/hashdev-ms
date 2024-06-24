using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PaymentManagerService.Data.Repositories;
using PaymentManagerService.Dtos;
using PaymentManagerService.Models;

namespace PaymentManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _repository;

        public PaymentController(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _repository = paymentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentReadDto>> GetAllPayments()
        {
            Console.WriteLine("--> Getting all Payments");
            var payments = _repository.GetAllPayments();
            return Ok(_mapper.Map<IEnumerable<PaymentReadDto>>(payments));
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public ActionResult<PaymentReadDto> GetPaymentById(int id)
        {
            Console.WriteLine($"--> Getting Payment with id: {id}");
            var payment = _repository.GetPaymentById(id);
            if (payment != null)
            {
                return Ok(_mapper.Map<PaymentReadDto>(payment));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PaymentReadDto> CreatePayment(PaymentCreateDto paymentCreateDto)
        {
            Console.WriteLine("--> Creating Payment");
            var paymentModel = _mapper.Map<Payment>(paymentCreateDto);
            _repository.CreatePayment(paymentModel);
            _repository.SaveChanges();

            var paymentReadDto = _mapper.Map<PaymentReadDto>(paymentModel);

            return CreatedAtRoute(nameof(GetPaymentById), new { Id = paymentReadDto.Id }, paymentReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            Console.WriteLine($"--> Deleting Payment with id: {id}");
            var paymentModelFromRepo = _repository.GetPaymentById(id);
            if (paymentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePayment(paymentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
