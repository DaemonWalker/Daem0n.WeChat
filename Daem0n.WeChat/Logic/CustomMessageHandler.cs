using Daem0n.WeChat.Handlers;
using Senparc.NeuChar.App.AppStore;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Daem0n.WeChat.Logic
{
    public class CustomMessageHandler : BaseMessageHandler
    {
        private readonly HandlerManager _handlerManager;
        public CustomMessageHandler(HandlerManager handlerManager, Stream inputStream, PostModel postModel,
            int maxRecordCount = 0, bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(inputStream, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
            this._handlerManager = handlerManager;
        }

        public CustomMessageHandler(HandlerManager handlerManager, XDocument requestDocument, PostModel postModel,
            int maxRecordCount = 0, bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(requestDocument, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
            this._handlerManager = handlerManager;
        }

        public CustomMessageHandler(HandlerManager handlerManager, RequestMessageBase requestMessageBase, PostModel postModel,
            int maxRecordCount = 0, bool onlyAllowEcryptMessage = false, DeveloperInfo developerInfo = null)
            : base(requestMessageBase, postModel, maxRecordCount, onlyAllowEcryptMessage, developerInfo)
        {
            this._handlerManager = handlerManager;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            throw new NotImplementedException("Fixed it soon");
        }
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            return _handlerManager.Handle(this, requestMessage.Content);
        }
    }
}
