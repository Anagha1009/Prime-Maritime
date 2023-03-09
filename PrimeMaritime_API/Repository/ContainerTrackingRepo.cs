using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class ContainerTrackingRepo
    {
        public void InsertContainerTracking(string connstring, CONTAINER_TRACKING request)
        {
            if (request.CONTAINER_NO != "")
            {
                SqlParameter[] paramS =
                    {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_CONTAINER_TRACKING" },
                      new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = request.BOOKING_NO },
                      new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = request.CRO_NO },
                      new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = request.CONTAINER_NO },
                      new SqlParameter("@ACTIVITY", SqlDbType.VarChar, 50) { Value = request.ACTIVITY },
                      new SqlParameter("@PREV_ACTIVITY", SqlDbType.VarChar, 50) { Value = request.PREV_ACTIVITY },
                      new SqlParameter("@ACTIVITY_DATE", SqlDbType.DateTime) { Value = request.ACTIVITY_DATE },
                      new SqlParameter("@LOCATION", SqlDbType.VarChar, 100) { Value = request.LOCATION },
                      new SqlParameter("@STATUS", SqlDbType.VarChar,50) { Value = request.STATUS },
                      new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 20) { Value = request.AGENT_CODE },
                      new SqlParameter("@DEPO_CODE", SqlDbType.VarChar, 20) { Value = request.DEPO_CODE },
                      new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY }
                    };

                var newCTID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_TRACKING", paramS);

            }
            else
            {

                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CRO_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("ACTIVITY", typeof(string)));
                tbl.Columns.Add(new DataColumn("PREV_ACTIVITY", typeof(string)));
                tbl.Columns.Add(new DataColumn("ACTIVITY_DATE", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("LOCATION", typeof(string)));
                tbl.Columns.Add(new DataColumn("STATUS", typeof(string)));
                tbl.Columns.Add(new DataColumn("AGENT_CODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("DEPO_CODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.CONTAINER_MOVEMENT_LIST)
                {
                    DataRow dr = tbl.NewRow();

                    dr["BOOKING_NO"] = i.BOOKING_NO;
                    dr["CRO_NO"] = i.CRO_NO;
                    dr["CONTAINER_NO"] = i.CONTAINER_NO;
                    dr["ACTIVITY"] = i.ACTIVITY;
                    dr["PREV_ACTIVITY"] = i.PREV_ACTIVITY;
                    dr["ACTIVITY_DATE"] = i.ACTIVITY_DATE;
                    dr["LOCATION"] = i.LOCATION;
                    dr["STATUS"] = i.STATUS;
                    dr["AGENT_CODE"] = i.AGENT_CODE;
                    dr["DEPO_CODE"] = i.DEPO_CODE;
                    dr["CREATED_BY"] = i.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[11];
                columns[0] = "BOOKING_NO";
                columns[1] = "CRO_NO";
                columns[2] = "CONTAINER_NO";
                columns[3] = "ACTIVITY";
                columns[4] = "PREV_ACTIVITY";
                columns[5] = "ACTIVITY_DATE";
                columns[6] = "LOCATION";
                columns[7] = "STATUS";
                columns[8] = "AGENT_CODE";
                columns[9] = "DEPO_CODE";
                columns[10] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_CONTAINER_TRACKING", columns);
                
            }
        }

        public List<CT> GetContainerTrackingList(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CONTAINER_TRACKING" },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = CONTAINER_NO }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_TRACKING", parameters);
                List<CT> containerList = SqlHelper.CreateListFromTable<CT>(dataTable);
                return containerList;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CT> GetContainerTrackingAsPerBooking(string connstring,string BOOKING_NO,string CRO_NO,string CONTAINER_NO)
        {
            try
            {
                string prevRowCurrentActivity = "";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CONTAINER_TRACKING" },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = CRO_NO },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = CONTAINER_NO }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_TRACKING", parameters);
                List<CT> containerList = SqlHelper.CreateListFromTable<CT>(dataTable);
                containerList.Reverse();
                List<CT> containerTrackingList = new List<CT>();
                foreach (var i in containerList)
                {
                    CT ct = new CT();
                    if (prevRowCurrentActivity != i.PREV_ACTIVITY)
                    {
                        ct.BOOKING_NO = i.BOOKING_NO;
                        ct.CRO_NO = i.CRO_NO;
                        ct.CONTAINER_NO = i.CONTAINER_NO;
                        ct.ACTIVITY = i.PREV_ACTIVITY;
                        ct.ACTIVITY_DATE = i.ACTIVITY_DATE;
                        ct.LOCATION = i.LOCATION;
                        ct.STATUS = i.STATUS;

                        containerTrackingList.Add(ct);

                    }
                    prevRowCurrentActivity = i.ACTIVITY;
                    ct.BOOKING_NO = i.BOOKING_NO;
                    ct.CRO_NO = i.CRO_NO;
                    ct.CONTAINER_NO = i.CONTAINER_NO;
                    ct.ACTIVITY = i.ACTIVITY;
                    ct.ACTIVITY_DATE = i.ACTIVITY_DATE;
                    ct.LOCATION = i.LOCATION;
                    ct.STATUS = i.STATUS;

                    containerTrackingList.Add(ct);
                }
                return containerTrackingList;

            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}
