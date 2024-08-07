using Microsoft.AspNetCore.Mvc;
using PinewoodsCrm.API.Exceptions;

namespace PinewoodsCrm.API.Models;

public class CustomerNotFoundResult(CustomerNotFoundException exception) : NotFoundObjectResult(new { exception.Message }) { }
