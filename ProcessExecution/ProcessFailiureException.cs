namespace Common.ProcessExecution
{
    using System;
    using Model;

    public class ProcessFailiureException : Exception
    {

        public ProcessFailiureException(ProcessInstructions instructions) 
            : this(instructions, string.Empty)
        {
        }

        public ProcessFailiureException(ProcessInstructions instructions, string output)
            :base(FormatMessage(instructions,output))
        {
            
        }

        private static string FormatMessage(ProcessInstructions instructions, string output)
        {
            return $"{instructions.Program} with arguments: {instructions.Arguments} failed." +
                   $"{Environment.NewLine} " + $"{output}";
        }
    }
}