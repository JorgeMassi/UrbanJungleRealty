//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Remedy.Application.CommandQuery.Apartments.Command.CreateApartment;

//namespace Remedy.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ApartmentMediatrController : ControllerBase
//    {
//        private readonly ISender _sender;

//        public ApartmentMediatrController(ISender sender)
//        {
//            _sender = sender;
//        }

//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        [HttpPost]
//        public async Task<CreateApartmentResponse> Post(CreateApartmentCommand r, CancellationToken ct)
//        {
//            return await _sender.Send(r, ct);
//        }

//        // PUT api/<ApartmentMediatrController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ApartmentMediatrController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
