using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daem0n.WeChat.Handlers
{
    public static class Utils
    {
        public static ResponseMessageText CreateTextResult<TMC>(this MessageHandler<TMC> messageHandler) where TMC : class, IMessageContext<IRequestMessageBase, IResponseMessageBase>, new()
        {
            return messageHandler.CreateResponseMessage<ResponseMessageText>();
        }
        public static ResponseMessageNews CreateArticleResult<TMC>(this MessageHandler<TMC> messageHandler) where TMC : class, IMessageContext<IRequestMessageBase, IResponseMessageBase>, new()
        {
            return messageHandler.CreateResponseMessage<ResponseMessageNews>();
        }
        public static ResponseMessageMusic CreateMusicResult<TMC>(this MessageHandler<TMC> messageHandler) where TMC : class, IMessageContext<IRequestMessageBase, IResponseMessageBase>, new()
        {
            return messageHandler.CreateResponseMessage<ResponseMessageMusic>();
        }
        internal static T As<T>(this object obj)
        {
            return (T)obj;
        }
        internal static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(typeof(T)).As<T>();
        }
        
    }
}
