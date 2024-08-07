namespace PinewoodsCrm.API.Exceptions;

public class NullContextException(string name) : Exception($"Null {name}.") { }
