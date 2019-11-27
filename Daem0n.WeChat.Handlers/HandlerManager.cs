using Daem0n.WeChat.Handlers.Internal.Abstractions;
using Senparc.NeuChar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daem0n.WeChat.Handlers
{
    public class HandlerManager
    {
        private readonly IEnumerable<HandlerBase> _handlers;
        private readonly IServiceProvider _serviceProvider;
        public HandlerManager(IEnumerable<HandlerBase> handlers, IServiceProvider serviceProvider)
        {
            this._handlers = handlers;
            this._serviceProvider = serviceProvider;
        }
        public IResponseMessageBase Handle(BaseMessageHandler baseMessageHandler, string msg)
        {
            foreach (var handle in this._handlers)
            {
                if (handle.Check(msg))
                {
                    return handle.Handle(msg, baseMessageHandler);
                }
            }
            return null;
        }
    }
}
