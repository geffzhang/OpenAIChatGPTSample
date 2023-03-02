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
    /// 将一段话，概况中心
    /// </summary>
    public class Summarize : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "Summarize this for a second-grade student:\\n虽然我国国土辽阔，但我们要确保十三亿的人的衣食住行。我们的生活富裕了，但能源能不能持续跟上呢?希望大家能够利用废物，节约地球能源，善待地球环境，从身边的小事做起，从我做起，保护环境。还要呼吁大家共同保护赖以生存的家园!";
        private readonly string _endToken = "\n";

        public Summarize(OpenAISetting openAISetting)
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
                temperature: 0.7,
                top_p: 1,
                presencePenalty: 0,
                frequencyPenalty: 0
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
