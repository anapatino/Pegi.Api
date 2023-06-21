namespace Entities.Exceptions;

public class AcademicProgramExeption : Exception
{
    public AcademicProgramExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
