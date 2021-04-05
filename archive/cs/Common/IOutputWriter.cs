namespace Common
{
    public interface IOutputWriter
    {
        void WriteLine(string message);
        void Write(string message);
    }
}