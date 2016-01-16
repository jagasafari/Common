namespace Common.ProcessExecution.Model
{
    using Common.Core;
    public class ProcessInstructions
    {
        private string _program;
        public string Program {get{ return _program;} set { _program=Check.NotNull(value, nameof(value));}}
        private string _arguments;
        public string Arguments {get{ return _arguments;} set { _arguments=Check.NotNull(value, nameof(value));}}
    }
}