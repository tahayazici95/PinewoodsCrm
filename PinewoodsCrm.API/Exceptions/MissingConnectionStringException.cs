namespace PinewoodsCrm.API.Exceptions;

public class MissingConnectionStringException(string name) : Exception($"Connection string '{name}' not found.") { }
