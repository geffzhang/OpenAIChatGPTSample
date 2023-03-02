using OpenAI_API.Completions;
using OpenAI_API.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAIChatGPTSample
{
    /// <summary>
    /// 依据现有知识库问&答
    /// </summary>
    public class QnA : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "Q: 今天深圳的天气咋样?\nA:";
        private readonly string _endToken = "\n";

        public QnA(OpenAISetting openAISetting)
        {
            _openAISetting = openAISetting;
        }

        public async Task<int> Run()
        {
            var api = new OpenAI_API.OpenAIAPI(_openAISetting.ApiKey);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(_prompt,
                model: CHATGPT_MODEL, 
                max_tokens: 1000, 
                temperature: 0,
                top_p: 1, 
                presencePenalty: 0, 
                frequencyPenalty: 0,
                stopSequences: new string[] { _endToken }
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
