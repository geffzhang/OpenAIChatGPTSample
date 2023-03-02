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
    /// 一句话生成OpenAi的代码
    /// </summary>
    public class OpenAPICode : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciCode;
        private readonly string _prompt = "\\\"\\\"\\\"\nUtil exposes the following:\nutil.openai() -> authenticates & returns the openai module, which has the following functions:\nopenai.Completion.create(\n    prompt=\\\"<my prompt>\\\", # The prompt to start completing from\n    max_tokens=123, # The max number of tokens to generate\n    temperature=1.0 # A measure of randomness\\n    echo=True, # Whether to return the prompt in addition to the generated completion\\\\n)\\\\n\\\\\\\"\\\\\\\"\\\\\\\"\\\\nimport util\\\\n\\\\\\\"\\\\\\\"\\\\\\\"\\\\n创建一个OpenAI completion，提示是“你好”，最大令牌时5\\\\n\\\\\\\"\\\\\\\"\\\\\\\"\\\\n\\\\n\r\n";
        private readonly string _endToken = "\"\"\"";

        public OpenAPICode(OpenAISetting openAISetting)
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
                frequencyPenalty: 0,
                stopSequences: new string[] { _endToken }
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
