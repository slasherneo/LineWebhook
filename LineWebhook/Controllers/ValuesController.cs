using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineWebhook.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "reggie", "webhook" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            string MyLineChannelAccessToken = "QVS7shFmoEt6QiEbel7KFPSgRceEfqTatiFiNAQOqQ+FcColF0xyA+WqZEKs0G50jpJPjh2GaUgtpjeaT0Xr7AXtRxCVo0WpdA9FgLdFl8Uh7FvapYa1GSmMW/7iNq61xjHuGySyGaSNi0MsZLRVxwdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = string.Format("現在時間:{0}  您說了:{1}", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), ReceivedMessage.events[0].message.text);
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, MyLineChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
