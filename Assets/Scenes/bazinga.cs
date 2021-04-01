using Console;

public class bazinga : Commands
{
    [ConsoleCommand("bazinga", "ba de la zinga")]
    class BazingaCommand : Command
    {
        [CommandParameter("shelden")] public int i;
        [CommandParameter("cuper")] public int j;
        
        public override ConsoleOutput Logic()
        {
            if (j == 0)
            {
                return new ConsoleOutput("AOOOOOOOOOOOOOOOOOOOOOO", ConsoleOutput.OutputType.Error);
            }
            
            int result = i / j;
            return new ConsoleOutput(result.ToString(), ConsoleOutput.OutputType.Log);
        }
    }
}
