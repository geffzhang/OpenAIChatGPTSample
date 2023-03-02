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
    /// 对于非结构化的数据抽取其中的特征生成结构化的表格
    /// </summary>
    public class TableSummarizing : IGPTRuner
    {
        private readonly OpenAISetting _openAISetting;
        private readonly Model CHATGPT_MODEL = Model.DavinciText;
        private readonly string _prompt = "A table summarizing, use Chinese:\\n我是一个活泼可爱的小女孩，我有着一双水灵灵的大眼睛；弯弯的眉毛像月亮一样；高高的鼻子下面有一张粉红色的樱桃小嘴。\\n";

        public TableSummarizing(OpenAISetting openAISetting)
        {
            _openAISetting = openAISetting;
        }

        public async Task<int> Run()
        {
            var api = new OpenAI_API.OpenAIAPI(_openAISetting.ApiKey);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(_prompt,
                model: CHATGPT_MODEL,
                max_tokens: 100,
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
