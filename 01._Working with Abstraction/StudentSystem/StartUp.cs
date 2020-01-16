namespace StudentSystem
{
    public class StartUp
    {
        static void Main()
        {
            var studentSystem = new StudentSystem();
            while (true)
            {
                studentSystem.ReadCommand();
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
