using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daem0n.WeChat.Handlers.Internal.Abstractions
{
    public abstract class HandlerBase
    {
        public abstract IResponseMessageBase Handle(string msg, BaseMessageHandler messageHandler);
        public abstract bool Check(string msg);
    }
}
