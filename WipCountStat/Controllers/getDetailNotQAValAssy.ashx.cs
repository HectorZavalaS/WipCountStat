using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WipCountStat.Models;

namespace WipCountStat.Controllers
{
    /// <summary>
    /// Summary description for getDetailNotQAValAssy
    /// </summary>
    public class getDetailNotQAValAssy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            siixsem_stocktake_dbEntities m_db = new siixsem_stocktake_dbEntities();
            //DataTable models = new DataTable();
            String html = "", htmlHead = "", htmlBody = "";
            int idarea = Convert.ToInt32(context.Request.Form["idarea"]);
            try
            {
                List<WIP_NOT_QA_VALIDATE_Result> areasDetail = m_db.WIP_NOT_QA_VALIDATE(idarea).ToList();


                html += "<div id='tableDetAssy'><table id='tableDetQANonVal' class='table display nowrap' style='font-size:11px;width:93%;'>";
                //html += "<div class='table-responsive-sm'><table id='tableSerialsDet' class='table' style='font-size:11px;'>";
                htmlHead = "<thead class='tablehead' style='background:lightgray;'>";
                htmlHead += "<tr>";
                htmlHead += "<th>ZONE</th>";
                htmlHead += "<th>MAGAZINE</th>";
                htmlHead += "<th>SERIAL SCANED</th>";
                htmlHead += "<th>MODEL</th>";
                htmlHead += "<th>SEMIFINISH</th>";
                htmlHead += "<th>TYPE</th>";
                htmlHead += "<th>DJ GROUP</th>";
                htmlHead += "<th>QUARANTINE</th>";
                htmlHead += "<th>DELETED</th>";
                htmlHead += "</tr>";
                htmlHead += "</thead>";
                htmlBody += "<tbody>";
                foreach (WIP_NOT_QA_VALIDATE_Result area in areasDetail)
                {
                    htmlBody += "<tr>";
                    htmlBody += "<td style='text-align:center;'>" + area.LOCATOR.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.MAGAZINE.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.SCANNED_SERIAL.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.MODEL.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.SEMIFINISH.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.TYPE.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.DJ_GROUP.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.QUARANTINE.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.DELETED.Replace("\t", "").Replace("\n", "").Replace("\r", "") + "</td>";
                    htmlBody += "</tr>";
                }
                htmlBody += "</tbody>";

                html += htmlHead + htmlBody + "</table></div>";


                json += "\"result\":\"true\",";
                json += "\"html\":\"" + html + "\"";


            }
            catch (Exception ex)
            {
                json += "\"result\":\"false\",";
                json += "\"MessageError\":\"" + ex.Message + "\"";
            }
            json += "}";
            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}