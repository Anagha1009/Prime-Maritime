using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class ContainerMovementRepo
    {
        public void InsertContainerMovement(string connstring, CONTAINER_MOVEMENT request, bool fromXL)
        {
            if (request.CONTAINER_NO != "")
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_SINGLE_CONTAINER_MOVEMENT" },
                  new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = request.CONTAINER_NO }
                };

                var cmID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                if (cmID != "")
                {
                    SqlParameter[] parameters1 =
                    {
                        new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_SINGLE_CONTAINER_MOVEMENT" },
                        new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = request.CONTAINER_NO }
                    };
                    DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters1);
                    List<CM> containerMovementList = SqlHelper.CreateListFromTable<CM>(dataTable);

                    foreach (var i in containerMovementList)
                    {
                        i.BOOKING_NO = request.BOOKING_NO;
                        i.CRO_NO = request.CRO_NO;
                        i.CONTAINER_NO = request.CONTAINER_NO;
                        if (i.ACTIVITY != request.ACTIVITY)
                        {
                            i.PREV_ACTIVITY = i.ACTIVITY;
                            i.ACTIVITY = request.ACTIVITY;
                        }
                        else if (i.ACTIVITY == request.ACTIVITY)
                        {
                            i.PREV_ACTIVITY = i.PREV_ACTIVITY;
                            i.ACTIVITY = i.ACTIVITY;
                        }
                        i.ACTIVITY_DATE = request.ACTIVITY_DATE;
                        i.LOCATION = request.LOCATION;
                        i.CURRENT_LOCATION = request.CURRENT_LOCATION;
                        i.STATUS = request.STATUS;
                        if (request.AGENT_CODE != "")
                        {
                            i.AGENT_CODE = request.AGENT_CODE;
                        }
                        if (request.DEPO_CODE != "")
                        {
                            i.DEPO_CODE = request.DEPO_CODE;
                        }
                        //Commented created by in update and allow only in insert
                        //i.CREATED_BY = request.CREATED_BY;
                    }

                    string[] columns = new string[12];
                    columns[0] = "BOOKING_NO";
                    columns[1] = "CRO_NO";
                    columns[2] = "CONTAINER_NO";
                    columns[3] = "ACTIVITY";
                    columns[4] = "PREV_ACTIVITY";
                    columns[5] = "ACTIVITY_DATE";
                    columns[6] = "LOCATION";
                    columns[7] = "CURRENT_LOCATION";
                    columns[8] = "STATUS";
                    columns[9] = "AGENT_CODE";
                    columns[10] = "DEPO_CODE";
                    columns[11] = "CREATED_BY";

                    SqlHelper.UpdateCMData<CM>(containerMovementList, "TB_CONTAINER_MOVEMENT", connstring, columns);
                }
                else
                {
                    SqlParameter[] paramS =
                    {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_CONTAINER_MOVEMENT" },
                      new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = request.BOOKING_NO },
                      new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = request.CRO_NO },
                      new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = request.CONTAINER_NO },
                      new SqlParameter("@ACTIVITY", SqlDbType.VarChar, 50) { Value = request.ACTIVITY },
                      new SqlParameter("@PREV_ACTIVITY", SqlDbType.VarChar, 50) { Value = request.PREV_ACTIVITY },
                      new SqlParameter("@ACTIVITY_DATE", SqlDbType.DateTime) { Value = request.ACTIVITY_DATE },
                      new SqlParameter("@LOCATION", SqlDbType.VarChar, 100) { Value = request.LOCATION },
                      new SqlParameter("@CURRENT_LOCATION", SqlDbType.VarChar, 100) { Value = request.CURRENT_LOCATION },
                      new SqlParameter("@STATUS", SqlDbType.VarChar,50) { Value = request.STATUS },
                      new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 20) { Value = request.AGENT_CODE },
                      new SqlParameter("@DEPO_CODE", SqlDbType.VarChar, 20) { Value = request.DEPO_CODE },
                      new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY }
                    };

                    var newCmID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", paramS);

                }

            }
            else
            {
                if (fromXL == true)
                {
                    DataTable tbl = new DataTable();
                    tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
                    tbl.Columns.Add(new DataColumn("CRO_NO", typeof(string)));
                    tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                    tbl.Columns.Add(new DataColumn("ACTIVITY", typeof(string)));
                    tbl.Columns.Add(new DataColumn("PREV_ACTIVITY", typeof(string)));
                    tbl.Columns.Add(new DataColumn("ACTIVITY_DATE", typeof(DateTime)));
                    tbl.Columns.Add(new DataColumn("LOCATION", typeof(string)));
                    tbl.Columns.Add(new DataColumn("CURRENT_LOCATION", typeof(string)));
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
                        dr["CURRENT_LOCATION"] = i.CURRENT_LOCATION;
                        dr["STATUS"] = i.STATUS;
                        dr["AGENT_CODE"] = i.AGENT_CODE;
                        dr["DEPO_CODE"] = i.DEPO_CODE;
                        dr["CREATED_BY"] = i.CREATED_BY;

                        tbl.Rows.Add(dr);
                    }

                    string[] columns = new string[12];
                    columns[0] = "BOOKING_NO";
                    columns[1] = "CRO_NO";
                    columns[2] = "CONTAINER_NO";
                    columns[3] = "ACTIVITY";
                    columns[4] = "PREV_ACTIVITY";
                    columns[5] = "ACTIVITY_DATE";
                    columns[6] = "LOCATION";
                    columns[7] = "CURRENT_LOCATION";
                    columns[8] = "STATUS";
                    columns[9] = "AGENT_CODE";
                    columns[10] = "DEPO_CODE";
                    columns[11] = "CREATED_BY";

                    SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_CONTAINER_MOVEMENT", columns);

                }
                else
                {
                    //No need to bind other list properties at backend
                    foreach (var i in request.CONTAINER_MOVEMENT_LIST)
                    {
                        if (request.DEPO_CODE != "")
                        {
                            i.DEPO_CODE = request.DEPO_CODE;
                        }
                        i.CURRENT_LOCATION = request.CURRENT_LOCATION;
                        //Commented created by in update and allow only in insert
                        //i.CREATED_BY = request.CREATED_BY;
                    }

                    string[] columns = new string[12];
                    columns[0] = "BOOKING_NO";
                    columns[1] = "CRO_NO";
                    columns[2] = "CONTAINER_NO";
                    columns[3] = "ACTIVITY";
                    columns[4] = "PREV_ACTIVITY";
                    columns[5] = "ACTIVITY_DATE";
                    columns[6] = "LOCATION";
                    columns[7] = "CURRENT_LOCATION";
                    columns[8] = "STATUS";
                    columns[9] = "AGENT_CODE";
                    columns[10] = "DEPO_CODE";
                    columns[11] = "CREATED_BY";

                    SqlHelper.UpdateCMData<CM>(request.CONTAINER_MOVEMENT_LIST, "TB_CONTAINER_MOVEMENT", connstring, columns);
                }


            }
        }
        //public List<CMList> GetContainerMovementList(string connstring, string AGENT_CODE, string DEPO_CODE,string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        //{
        //    SqlParameter[] parameters =
        //    {
        //        new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CONTAINER_MOVEMENT" },
        //        new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,20) { Value = AGENT_CODE },
        //        new SqlParameter("@DEPO_CODE", SqlDbType.VarChar,20) { Value = DEPO_CODE },
        //        new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
        //        new SqlParameter("@CRO_NO", SqlDbType.VarChar,100) { Value = CRO_NO },
        //        new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,100) { Value = CONTAINER_NO }

        //     };
        //    DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
        //    List<CMList> containerList = SqlHelper.CreateListFromTable<CMList>(dataTable);

        //    var uniqueCMList = containerList.GroupBy(x => x.CONTAINER_NO);

        //    List<CMList> cmList = new List<CMList>();
        //    foreach(var cont in uniqueCMList)
        //    {
        //        CMList cm = new CMList();
        //        cm = cont.FirstOrDefault();

        //        var nextActList = cont
        //        .Where(x => x.CONTAINER_NO == cm.CONTAINER_NO)
        //        .Select(n => n.Column1).ToList();

        //        cm.NEXT_ACTIVITY_LIST = nextActList;
        //        cmList.Add(cm);
        //    }

        //    return cmList;
        //}

        public List<CMList> GetContainerMovementList(string connstring, string BOOKING_NO, string CRO_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CONTAINERMOVEMENT_LIST" },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar,100) { Value = CRO_NO },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CMList> containerList = SqlHelper.CreateListFromTable<CMList>(dataTable);

                return containerList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CM> GetAvailableContainerListForDepo(string connstring, string DEPO_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_AVAILABLE_CONTAINERS_FORDEPO" },
                    new SqlParameter("@DEPO_CODE", SqlDbType.VarChar,20) { Value = DEPO_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CM> containerList = SqlHelper.CreateListFromTable<CM>(dataTable);

                return containerList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CM> GetAllContainerListForDepo(string connstring, string DEPO_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_ALL_CONTAINERS_FORDEPO" },
                    new SqlParameter("@DEPO_CODE", SqlDbType.VarChar,20) { Value = DEPO_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CM> containerList = SqlHelper.CreateListFromTable<CM>(dataTable);

                return containerList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CM> GetAllContainerListForAdmin(string connstring, string LOCATION)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_ALL_CONTAINERS_FORADMIN" },
                    new SqlParameter("@LOCATION", SqlDbType.VarChar,100) { Value = LOCATION },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CM> containerList = SqlHelper.CreateListFromTable<CM>(dataTable);

                return containerList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetContainerMovement(string connstring, string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CONTAINERMOVEMENT" },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar,100) { Value = CRO_NO },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = CONTAINER_NO },
                };

               return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CM> GetContainerMovementBooking(string connstring, string BOOKING_NO, string CRO_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CONTAINER_MOVEMENT_BOOKING" },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = CRO_NO }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CM> containerList = SqlHelper.CreateListFromTable<CM>(dataTable);
                return containerList;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CM> GetCMAvailable(string connstring, string STATUS, string CURRENT_LOCATION)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CM_AVAILABLE" },
                    new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = STATUS },
                    new SqlParameter("@CURRENT_LOCATION", SqlDbType.VarChar, 100) { Value = CURRENT_LOCATION }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<CM> containerList = SqlHelper.CreateListFromTable<CM>(dataTable);
                return containerList;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ValidContainer(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "VALID_CONTAINERNO" },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 50) { Value = CONTAINER_NO },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ValidCROForContainer(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "VALIDATE_CRONO" },
                   new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = CONTAINER_NO },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string UpdateContainerMovement(string connstring, CONTAINERMOVEMENT cm)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "UPDATE_CONTAINERMOVEMENT" },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = cm.BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = cm.CRO_NO },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 50) { Value = cm.CONTAINER_NO },
                    new SqlParameter("@CURR_ACT_CODE", SqlDbType.VarChar, 50) { Value = cm.CURR_ACT_CODE },
                    new SqlParameter("@PREV_ACTIVITY", SqlDbType.VarChar, 50) { Value = cm.PREV_ACTIVITY },
                    new SqlParameter("@ACTIVITY_DATE", SqlDbType.DateTime) { Value = cm.ACTIVITY_DATE },
                    new SqlParameter("@LOCATION", SqlDbType.VarChar,100) { Value = cm.LOCATION },
                    new SqlParameter("@STATUS", SqlDbType.VarChar,100) { Value = cm.STATUS }
                };
               
                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT",parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UploadContainerMovement(string connstring, List<CONTAINERMOVEMENT> cm)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CRO_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("ACTIVITY", typeof(string)));
                tbl.Columns.Add(new DataColumn("PREV_ACTIVITY", typeof(string)));
                tbl.Columns.Add(new DataColumn("ACTIVITY_DATE", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("LOCATION", typeof(string)));
                tbl.Columns.Add(new DataColumn("CURRENT_LOCATION", typeof(string)));
                tbl.Columns.Add(new DataColumn("STATUS", typeof(string)));
                tbl.Columns.Add(new DataColumn("AGENT_CODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("DEPO_CODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in cm)
                {
                    var CRONO = "NULL";
                    var ACTIVITY = "NULL";

                    if (i.CRO_NO == "" || i.CRO_NO == null)
                    {
                        SqlParameter[] parameters =
                        {
                            new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "VALIDATE_CRONO" },
                            new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = i.CONTAINER_NO },
                        };

                        CRONO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                    }

                    SqlParameter[] parameters1 =
                    {
                       new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CURRENT_ACTIVITY" },
                       new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = i.CONTAINER_NO },
                    };

                    ACTIVITY = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters1);

                    DataRow dr = tbl.NewRow();

                    dr["BOOKING_NO"] = i.BOOKING_NO;
                    dr["CRO_NO"] = CRONO != "NULL" ? CRONO : i.CRO_NO;
                    dr["CONTAINER_NO"] = i.CONTAINER_NO;
                    dr["ACTIVITY"] = i.CURR_ACT_CODE;
                    dr["PREV_ACTIVITY"] = ACTIVITY;
                    dr["ACTIVITY_DATE"] = i.ACTIVITY_DATE;
                    dr["LOCATION"] = i.LOCATION;
                    dr["CURRENT_LOCATION"] = i.CURRENT_LOCATION;
                    dr["STATUS"] = i.STATUS;
                    dr["AGENT_CODE"] = i.AGENT_CODE;
                    dr["DEPO_CODE"] = i.DEPO_CODE;
                    dr["CREATED_BY"] = i.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[12];
                columns[0] = "BOOKING_NO";
                columns[1] = "CRO_NO";
                columns[2] = "CONTAINER_NO";
                columns[3] = "ACTIVITY";
                columns[4] = "PREV_ACTIVITY";
                columns[5] = "ACTIVITY_DATE";
                columns[6] = "LOCATION";
                columns[7] = "CURRENT_LOCATION";
                columns[8] = "STATUS";
                columns[9] = "AGENT_CODE";
                columns[10] = "DEPO_CODE";
                columns[11] = "CREATED_BY";

                foreach (var items in cm)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "DELETE_CONTAINER" },
                        new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = items.CONTAINER_NO },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                }

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_CONTAINER_MOVEMENT", columns);
                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_CONTAINER_TRACKING", columns);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public CM GetSingleContainerMovement(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_SINGLE_CONTAINER_MOVEMENT" },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = CONTAINER_NO }
                };

                return SqlHelper.ExtecuteProcedureReturnData<CM>(connstring, "SP_CRUD_CONTAINER_MOVEMENT", r => r.TranslateCM(), parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<NEXT_ACTIVITY> GetNextActivityList(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_NEXTACT_LIST" },
                    new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = CONTAINER_NO }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CONTAINER_MOVEMENT", parameters);
                List<NEXT_ACTIVITY> List = SqlHelper.CreateListFromTable<NEXT_ACTIVITY>(dataTable);
                return List;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }
    }
}
