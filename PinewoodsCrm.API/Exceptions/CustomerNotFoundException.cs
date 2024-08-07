namespace PinewoodsCrm.API.Exceptions;

public class CustomerNotFoundException(Guid id) : Exception($"Customer with ID '{id}' was not found.") { }
