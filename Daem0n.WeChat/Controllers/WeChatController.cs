using Daem0n.WeChat.Handlers;
using Daem0n.WeChat.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Daem0n.WeChat.Controllers
{
    public class WeChatController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private string token;
        private string encodingAESKey;
        private string appID;
        public WeChatController(IConfiguration config, IServiceProvider serviceProvider)
        {
            this._config = config;
            this._serviceProvider = serviceProvider;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index(PostModel postModel, string echostr)
        {
            if (Check(postModel) == false)
            {
                return Json(new
                {
                    msg = $"failed:{postModel.Signature},{CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, token)}。" +
                            $"如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。"
                });
            }
            else
            {
                return Content(echostr);
            }
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(PostModel postModel)
        {
            if (Check(postModel) == false)
            {
                return Json(new
                {
                    msg = "error"
                });
            }
            postModel.Token = this.token;
            postModel.EncodingAESKey = this.encodingAESKey;
            postModel.AppId = appID;

            var handler = new CustomMessageHandler(this._serviceProvider.GetService<HandlerManager>(), Request.Body, postModel);
            handler.ExecuteAsync(new CancellationTokenSource().Token).Wait();
            return new FixWeixinBugWeixinResult(handler);

        }
        private bool Check(PostModel model) => CheckSignature.Check(model.Signature, model.Timestamp, model.Nonce, token);
    }
}
