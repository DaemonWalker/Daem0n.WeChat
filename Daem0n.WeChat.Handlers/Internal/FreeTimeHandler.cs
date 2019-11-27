using Daem0n.WeChat.Handlers;
using Daem0n.WeChat.Handlers.Internal.Abstractions;
using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daem0n.WeChat.Handlers.Internal
{
    class FreeTimeHandler : HandlerBase
    {
        public override bool Check(string msg) => msg.ToLower().Contains("#freetime");

        public override IResponseMessageBase Handle(string msg, BaseMessageHandler baseMessageHandler)
        {
            var articles = baseMessageHandler.CreateArticleResult();
            var article = new Article
            {
                Title = "摸鱼时光",
                Description = "整理了一些热门消息，用于消磨时间",
                Url = ""
            };
            articles.Articles.Add(article);
            return articles;
        }
    }
}
