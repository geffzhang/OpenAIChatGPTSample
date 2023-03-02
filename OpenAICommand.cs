using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAIChatGPTSample
{
    /// <summary>
    /// https://blog.csdn.net/luoxueyong/article/details/128360680
    /// openapi的49种模式中，支持论文创作、代码生成、SQL生成、代码解释、程序代码翻译等多种有趣的玩法，各位小伙伴一起玩起来
    /// </summary>
    internal class OpenAICommand : Command<OpenAICommand.Settings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            IGPTRuner runer = null;
            OpenAISetting openAISetting = new OpenAISetting() { ApiKey = settings.ApiKey, Organization = settings.Organization };
            switch (settings.Mode.ToLowerInvariant())
            {
                case "qna":
                    runer= new QnA(openAISetting);
                    break;
                case "grammarcorrection":
                    runer = new GrammarCorrection(openAISetting);
                    break;
                case "summarize":
                    runer = new Summarize(openAISetting);
                    break;
                case "openapicode":
                    runer = new OpenAPICode(openAISetting);
                    break;
                case "text2command":
                    runer = new TextToCommand(openAISetting);
                    break;
                case "translate2other":
                    runer = new Translate2Other(openAISetting);
                    break;
                case "stripecharge":
                    runer = new StripeCharge(openAISetting);
                    break;
                case "sqltranslate":
                    runer = new SQLTranslate(openAISetting);
                    break;
                case "tablesummarizing":
                    runer = new TableSummarizing(openAISetting);
                    break;
                case "classification":
                    runer = new Classification(openAISetting);
                    break;
                case "movietoemoji":
                    runer = new MovieToEmoji(openAISetting);
                    break;

            }
            return runer.Run().Result;

        }

        public sealed class Settings : CommandSettings
        {
            [Description("模式")]
            [CommandArgument(0, "[mode]")]
            public string? Mode { get; init; }

            [CommandOption("-k|--apikey")]
            public string? ApiKey { get; init; }

            [CommandOption("-o|--organization")]
            public string? Organization { get; init; }
            
        }
    }
}