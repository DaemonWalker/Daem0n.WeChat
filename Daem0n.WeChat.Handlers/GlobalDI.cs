using Daem0n.WeChat.Handlers.Internal;
using Daem0n.WeChat.Handlers.Internal.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daem0n.WeChat.Handlers
{
    public static class GlobalDI
    {
        public static void AddHandlers(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<HandlerManager, HandlerManager>();
            serviceDescriptors.AddSingleton<HandlerBase, FreeTimeHandler>();
        }
    }
}
