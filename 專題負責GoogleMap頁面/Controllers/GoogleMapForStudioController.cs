using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 專題負責GoogleMap頁面.Controllers
{
    public class GoogleMapForStudioController : Controller
    {
        public ActionResult displayPage() => View();

        public string defaultPage()
        {
            //Models.期末專題_Test資料庫Entities temp = new Models.期末專題_Test資料庫Entities();
            Models.Azure雲端上的期末資料庫Entities temp = new Models.Azure雲端上的期末資料庫Entities();
            var x = from i in temp.tStudio
                    select new { i.fCorpName, i.fCounty, i.fDistrict, i.cfImage, i.fLatitude, i.fLongitude, i.fAddress };

            string json = JsonConvert.SerializeObject(x);
            return json;
        }
    }
}




/*
 ˇtStudio: fId(int)*p, fCorpName(nvarchar(20)), fTaxId(char(8)), fOwner(nvarchar(20)), 
fRepresentative(nvarchar(20)), fPhone(varchar(20)), fEmail(varchar(40))*u, 
fStudioNumber(char(13))[e.g., 010-0503-2012], fPasswords(char(20)), fRegisterTime(date), 
fActivated(bit), fNotification(nvarchar(100)),fCounty(nvarchar(20)), fDistrict(nvarchar(20)), 
fAddress(nvarchar(50)), cfImage(varchar(100))

{縣市、區域、地址、開放時間} --開放時間由tSchedule決定

--以下都還未check過--

ˇtAppointment: fId(int)*p, fOrderNumber(char(14))[e.g., ORDR-0039-4123]*u, fOrderTime(smalldatetime), 
fCompleted(byte), {客戶ID、工作室ID、健身教練ID（其中某些可null）}, 客戶點數（堂數）

ˇtTransaction: fId(int)*p, fOrderNumber(char(14))[e.g., TRAS-0039-4123]*u, fOrderTime(smalldatetime), 
fCompleted(byte), {訂單ID、總金額、三方金流交易序號ID（其中某些可null）}，客戶點數（堂數）

看要不要再新增個小費功能，就像uber eat一樣
 
順便問一下青原，她的tSchedule做了沒（裡頭會FK教練編號＆健身房編號）
tSchedule跟tAppointment會隨時相互連動到，很重要（預約成功後，其他人看Schedule上面即顯示紅色）

 */