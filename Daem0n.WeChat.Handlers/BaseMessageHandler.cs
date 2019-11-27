using Senparc.NeuChar.App.AppStore;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageContexts;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Daem0n.WeChat.Handlers
{
    public abstract class BaseMessageHandler : MessageHandler<DefaultMpMessageContext>
    {
        public BaseMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0,
            bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(inputStream, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
        }

        public BaseMessageHandler(XDocument requestDocument, PostModel postModel, int maxRecordCount = 0,
            bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(requestDocument, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
        }

        public BaseMessageHandler(RequestMessageBase requestMessageBase, PostModel postModel, int maxRecordCount = 0,
            bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(requestMessageBase, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
        }
    }
}
