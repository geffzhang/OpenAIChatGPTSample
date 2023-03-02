using Spectre.Console.Cli;

namespace OpenAIChatGPTSample
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandApp<OpenAICommand>();
            return app.Run(args);
        }
    }
}