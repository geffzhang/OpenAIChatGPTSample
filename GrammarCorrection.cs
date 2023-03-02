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
    /// 语法纠正,将句子转换成标准的英语，输出结果始终是英文
    /// </summary>
    public class GrammarCorrection : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "下半夜,突然雷声隆隆,接着电光闪闪。";
   

        public GrammarCorrection(OpenAISetting openAISetting)
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
                frequencyPenalty: 0
                ));
            AnsiConsole.Markup(result.ToString());
            return 1;
        }
    }
}
