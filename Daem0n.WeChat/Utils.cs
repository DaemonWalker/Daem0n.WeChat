using Daem0n.WeChat.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daem0n.WeChat
{
    public static class Utils
    {
        public static ResponseMessageText CreateTextResult(this BaseMessageHandler messageHandler)
        {
            return messageHandler.CreateResponseMessage<ResponseMessageText>();
        }
        public static ResponseMessageNews CreateArticleResult(this BaseMessageHandler messageHandler)
        {
            return messageHandler.CreateResponseMessage<ResponseMessageNews>();
        }
        public static ResponseMessageMusic CreateMusicResult(this BaseMessageHandler messageHandler)
        {
            return messageHandler.CreateResponseMessage<ResponseMessageMusic>();
        }
        public static void AddNoobHandler(this IServiceCollection serviceDescriptors)
        {
           // serviceDescriptors.AddScoped<CustomMessageHandler, CustomMessageHandler>();
        }
        internal static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(typeof(T)).As<T>();
        }
        internal static T As<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
