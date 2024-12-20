using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WipCountStat.Models;

namespace WipCountStat.Controllers
{
    /// <summary>
    /// Summary description for getDetailCountAKBattery
    /// </summary>
    public class getDetailCountAKBattery : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            siixsem_wip_control_dbEntities m_db = new siixsem_wip_control_dbEntities();
            //DataTable models = new DataTable();
            String html = "", htmlHead = "", htmlBody = "";
            String serial = context.Request.Form["serial"];
            try
            {
                List<getDetailCountAk_Result> areasDetail = m_db.getDetailCountAk().ToList();


                html += "<div id='tableInfoDet'><table id='tableSerialsDetAk' class='table display nowrap' style='font-size:11px;width:93%;'>";
                //html += "<div class='table-responsive-sm'><table id='tableSerialsDet' class='table' style='font-size:11px;'>";
                htmlHead = "<thead class='tablehead' style='background:lightgray;'>";
                htmlHead += "<tr style='background:black; color:white;'>";
                htmlHead += "<td style='font-weight:bold;background:white;'></td>";
                htmlHead += "<td style='text-align:center;font-weight:bold;' colspan='3'>TYPE LABEL COUNT</td>";
                htmlHead += "<td style='text-align:center;font-weight:bold;' colspan='3'>DELETE LABEL COUNT</td>";
                htmlHead += "<td style='text-align:center;font-weight:bold;' colspan='4'>QA VALIDATE</td>";
                htmlHead += "<td style='text-align:center;font-weight:bold;' colspan='4'>FINANCE VALIDATE</td>";
                htmlHead += "<td style='font-weight:bold;background:white;'></td>";
                htmlHead += "</tr>";

                htmlHead += "<tr>";
                htmlHead += "<th>ZONE</th>";

                htmlHead += "<th style='background:gray; color:white;'>Box</th>";
                htmlHead += "<th style='background:gray; color:white;'>Mag</th>";
                htmlHead += "<th style='background:gray; color:white;border-right:double;border-right-color:black;border-right-width:1px;'>FG Box</th>";

                htmlHead += "<th>Mag </th>";
                htmlHead += "<th>Box </th>";
                htmlHead += "<th style='border-right:double;border-right-color:black;border-right-width:1px;'>FG Box </th>";

                htmlHead += "<th style='background:gray; color:white;'>Mag</th>";
                htmlHead += "<th style='background:gray; color:white;'>Box</th>";
                htmlHead += "<th style='background:gray; color:white;'>FG Box</th>";
                htmlHead += "<th style='background:gray; color:white;border-right:double;border-right-color:black;border-right-width:1px;'>TOTAL %</th>";

                htmlHead += "<th>Mag</th>";
                htmlHead += "<th>Box</th>";
                htmlHead += "<th>FG Box</th>";
                htmlHead += "<th style='border-right:double;border-right-color:black;border-right-width:1px;'>TOTAL %</th>";

                htmlHead += "<th>TOTAL PRINTED LABELS</th>";
                htmlHead += "</tr>";
                htmlHead += "</thead>";

                htmlBody += "<tbody>";
                int i = 1;
                foreach (getDetailCountAk_Result area in areasDetail)
                {
                    //htmlBody += "<tr class='tablerows'>";

                    htmlBody += "<tr>";

                    htmlBody += "<td style='font-weight:bold;background:lightgray;'>" +
                        "<button type='button' class='btn butTable' data-toggle='modal' data-target='.bs-example-modal-xl' onclick = 'getDetailAreaSMT(" + area.IDAREA.ToString() + ")'>" + area.ZONE + "</button></td>";
                    htmlBody += "<td style='text-align:center;'>" + area.BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.MAG_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;border-right:double;border-right-color:black;border-right-width:1px;'>" + area.FINAL_BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.DELETE_LABEL + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.DEL_BOX_LABEL + "</td>";
                    htmlBody += "<td style='text-align:center;border-right:double;border-right-color:black;border-right-width:1px;'>" + area.DEL_FG_BOX_LABEL + "</td>";

                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_QA_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_QA_BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_QA_FG_BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;border-right:double;border-right-color:black;border-right-width:1px;'>" +
                                    "<div class='progress'>" +
                                      "<div class='progress-bar' role='progressbar' style='font-weight:bold;text-align:center;color:orange;width:" + area.QA_VALIDATE__ + "%;' aria-valuenow='" + area.QA_VALIDATE__ + "' aria-valuemin='0' aria-valuemax='100'>" + area.QA_VALIDATE__ + "%</div>" +
                                    "</div>" +
                                //      area.QA_VALIDATE__ + 

                                "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_FIN_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_FIN__BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;'>" + area.VALIDATE_QA_FG_BOX_QTY + "</td>";
                    htmlBody += "<td style='text-align:center;border-right:double;border-right-color:black;border-right-width:1px;'>" +
                                    "<div class='progress'>" +
                                      "<div class='progress-bar' role='progressbar' style='font-weight:bold;text-align:center;color:orange;width:" + area.FIN_VALIDATE__ + "%;' aria-valuenow='" + area.FIN_VALIDATE__ + "' aria-valuemin='0' aria-valuemax='100'>" + area.FIN_VALIDATE__ + "%</div>" +
                                    "</div>" +
                                 "</td>";
                    htmlBody += "<td style='font-weight:bold;text-align:center;background:lightgray;'>" + area.TOTAL_LABEL_PRINT + "</td>";
                    htmlBody += "</tr>";
                    i++;
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