using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

using System.Data.SqlClient;
using Azure;
using static MO_Lambda.UpdatePrice;
using MO_Lambda.Models;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Drawing;
using System.Threading;
using Lazop.Api;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MO_Lambda
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse Get(string request, ILambdaContext context)
        {
            var param = request.Split('_');
            //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(testJson)) as testJson;
            context.Logger.LogLine("Get Request\n");
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello AWS Serverless " + param[0] + " : ",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            try
            {
                if (param[1] == "1")
                {
                    var MoDbContext = new MoDbContext("", param[0]);
                    var acc = MoDbContext.Account.Where(m => m.Email.Contains("baimsky")).FirstOrDefault();
                    ////var EDB = new DatabaseSQL(acc.DatabasePathErasoft);
                    ////var dsArf01 = EDB.GetDataSet("CString", "ARF01", "SELECT TOP 1 * FROM ARF01");
                    ////var test = dsArf01.Tables[0].Rows[0]["PERSO"].ToString();
                    //var ErasoftDbContext = new ErasoftContext(acc.DataSourcePathDebug, acc.DatabasePathErasoft);
                    //var test = ErasoftDbContext.ARF01.FirstOrDefault().PERSO;
                    if (acc != null)
                    {
                        var test = acc.Username;
                        //#if (AWS)
                        // var test = "aws";
                        //#elif (Debug_AWS)
                        // var test = "Debug_AWS";
                        //#elif (DEV)
                        // var test = "DEV";
                        //#elif (DEBUG)
                        //                var test = "DEBUG";
                        //#else
                        // var test = "other";
                        //#endif
                        response.Body += test;
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Body += ex.Message;
            }
            return response;
        }

        public APIGatewayProxyResponse TestAPI(UpdatePrice.UpdatePrice_Tokped_Request request_param, ILambdaContext context)
        //public APIGatewayProxyResponse TestAPI(APIGatewayProxyRequest request, ILambdaContext context)
        {
            //var param = request.Split('_');
            //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(testJson)) as testJson;
            //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Tokped_Request)) as UpdatePrice.UpdatePrice_Tokped_Request;
            context.Logger.LogLine("Get Request\n");
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello AWS Serverless updated again " + request_param.dbsource + " : ",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            try
            {
                //if (request_param.cek == "1")
                {
                    //if (request_param.type == "1")
                    {
                        //response.Body += ConnectionString + " ; ";
                        //using (var Conn = new SqlConnection(ConnectionString))
                        //{
                        //    using (var Cmd = new SqlCommand("SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket, Conn))
                        //    {
                        //        Conn.Open(); //<-- this is where the error fires.

                        //        SqlDataReader rdr = Cmd.ExecuteReader();
                        //        while (rdr.Read())
                        //        {
                        //            //myDbItems.Add(rdr[1].ToString());
                        //            response.Body += rdr[0].ToString();
                        //        }

                        //        Conn.Close();
                        //    }
                        //}
                        var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN, tgl_input, recnum, al2 FROM ARF01 where RecNum = " + request_param.idmarket, 4);
                        foreach(var data in readDB)
                        {
                            response.Body += data + "_|_";
                        }
                    }
                    //else
                    //{
                    //    //var MoDbContext = new MoDbContext("", request_param.ip);
                    //    //var acc = MoDbContext.Account.Where(m => m.Email.Contains("baimsky")).FirstOrDefault();
                    //    //var acc = MoDbContext.Database.SqlQuery<testClass>("SELECT TOP 1 Username FROM Account ").FirstOrDefault();
                    //    //response.Body += acc.Username;

                    //    var ErasoftDbContext = new ErasoftContext(request_param.ip, "ERASOFT_rahmamk");

                    //    var arf01inDB = ErasoftDbContext.Database.SqlQuery<ARF01_DATA>("SELECT TOKEN, REFRESH_TOKEN FROM ARF01 where RecNum = 1028").FirstOrDefault();
                    //    response.Body += arf01inDB.TOKEN;
                    //    //response.Body += " test";
                    //}
                }
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Body += ex.Message;

            }
            return response;
        }
        public List<string> GetToken(string dbsource, string dbpath, string qry, int paramNum)
        {
            var ret = new List<string>();
            string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dbpath + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";
            try
            {
                using (var Conn = new SqlConnection(ConnectionString))
                {
                    using (var Cmd = new SqlCommand(qry, Conn))
                    {
                        Conn.Open(); //<-- this is where the error fires.

                        SqlDataReader rdr = Cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            //myDbItems.Add(rdr[1].ToString());
                            for (int i = 0; i < paramNum; i++)
                            {
                                ret.Add(rdr[i].ToString());
                            }
                        }

                        Conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return ret;
        }
        public void updateHargaMaster(string dbsource, string dbpath, double hjual, string brg)
        {
            //var ret = new List<string>();
            string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dbpath + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

            using (var Conn = new SqlConnection(ConnectionString))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE STF02 SET hjual = @param1, Tgl_Input = @param3 WHERE BRG = @param2", Conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Float).Value = hjual;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 20).Value = brg;
                    cmd.Parameters.Add("@param3", SqlDbType.Date).Value = DateTime.UtcNow;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                Conn.Close();
            }
            //return ret;
        }
        public void updateHargaMp(string dbsource, string dbpath, double hjual, string brg, int idmarket)
        {
            //var ret = new List<string>();
            string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dbpath + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

            using (var Conn = new SqlConnection(ConnectionString))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE STF02H SET hjual = @param1 WHERE BRG = @param2 AND IDMARKET = @param3", Conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Float).Value = hjual;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 20).Value = brg;
                    cmd.Parameters.Add("@param3", SqlDbType.Int).Value = idmarket;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                Conn.Close();
            }
            //return ret;
        }
        public void updateHargaMpBlibli(string dbsource, string dbpath, double hjual, double hpromo, string brg, int idmarket)
        {
            //var ret = new List<string>();
            string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dbpath + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

            using (var Conn = new SqlConnection(ConnectionString))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE STF02H SET HARGA_NORMAL = @param1,hjual = @param4 WHERE BRG = @param2 AND IDMARKET = @param3", Conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Float).Value = hjual;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 20).Value = brg;
                    cmd.Parameters.Add("@param3", SqlDbType.Int).Value = idmarket;
                    cmd.Parameters.Add("@param4", SqlDbType.Float).Value = hpromo;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                Conn.Close();
            }
            //return ret;
        }
        public class ARF01_DATA
        {

            public string TOKEN { get; set; }

            public string REFRESH_TOKEN { get; set; }

        }
        public class testJson
        {
            public string ip { get; set; }
            public string cek { get; set; }
            public string type { get; set; }
        }
        public class testClass
        {
            public string Username { get; set; }
        }
        //public APIGatewayProxyResponse UpdatePriceTokped([FromBody] UpdatePrice.UpdatePrice_Tokped_Request request, ILambdaContext context)
        public APIGatewayProxyResponse UpdatePriceTokped(UpdatePrice.UpdatePrice_Tokped_Request request_param, ILambdaContext context)
        //public APIGatewayProxyResponse UpdatePriceTokped(APIGatewayProxyRequest request, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Tokped_Request)) as UpdatePrice.UpdatePrice_Tokped_Request;
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            //request_param.token = GetToken(ConnectionString, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket);

            Action <UpdatePrice.UpdatePrice_Tokped_Request> secondAction = UpdatePrice.UpdatePrice_Tokopedia;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket, 1);
                request_param.token = readDB[0];
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Tokped_Request)) as UpdatePrice.UpdatePrice_Tokped_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);

                //string ConnectionString = "Data Source=" + request_param.dbsource
                //    + ";Initial Catalog=" + request_param.dbpath + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

                //responseRet.Body += GetToken(ConnectionString, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceBukalapak(UpdatePrice.UpdatePrice_Bukalapak_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Bukalapak_Request> secondAction = UpdatePrice.UpdatePrice_Bukalapak;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket, 1);
                request_param.token = readDB[0];
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Bukalapak_Request)) as UpdatePrice.UpdatePrice_Bukalapak_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceBlibli(UpdatePrice.UpdatePrice_Blibli_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Blibli_Request> secondAction = UpdatePrice.UpdatePrice_Blibli;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN,API_CLIENT_P,API_CLIENT_U FROM ARF01 where RecNum = " + request_param.idmarket, 3);
                request_param.token = readDB[0];
                request_param.API_client_password = readDB[1];
                request_param.API_client_username = readDB[2];
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Blibli_Request)) as UpdatePrice.UpdatePrice_Blibli_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceShopee(UpdatePrice.UpdatePrice_Shopee_Request request_param, ILambdaContext context)
        //public APIGatewayProxyResponse UpdatePriceShopee(APIGatewayProxyRequest request, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Shopee_Request)) as UpdatePrice.UpdatePrice_Shopee_Request;
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Shopee_Request> secondAction = UpdatePrice.UpdatePrice_Shopee;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket, 1);
                request_param.token = readDB[0];
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Shopee_Request)) as UpdatePrice.UpdatePrice_Shopee_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceLazada(UpdatePrice.UpdatePrice_Lazada_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Lazada_Request> secondAction = UpdatePrice.UpdatePrice_Lazada;

            try
            {
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Lazada_Request)) as UpdatePrice.UpdatePrice_Lazada_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePrice82Cart(UpdatePrice.UpdatePrice_82Cart_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_82Cart_Request> secondAction = UpdatePrice.UpdatePrice_82Cart;

            try
            {
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_82Cart_Request)) as UpdatePrice.UpdatePrice_82Cart_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceShopify(UpdatePrice.UpdatePrice_Shopify_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Shopify_Request> secondAction = UpdatePrice.UpdatePrice_Shopify;

            try
            {
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Shopify_Request)) as UpdatePrice.UpdatePrice_Shopify_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceJDID(UpdatePrice.UpdatePrice_JDID_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_JDID_Request> secondAction = UpdatePrice.UpdatePrice_JDID;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN,API_CLIENT_U FROM ARF01 where RecNum = " + request_param.idmarket, 2);
                request_param.accessToken = readDB[0];
                request_param.appSecret = readDB[1];

                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_JDID_Request)) as UpdatePrice.UpdatePrice_JDID_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePriceTiktok(UpdatePrice.UpdatePrice_Tiktok_Request request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            Action<UpdatePrice.UpdatePrice_Tiktok_Request> secondAction = UpdatePrice.UpdatePrice_Tiktok;

            try
            {
                var readDB = GetToken(request_param.dbsource, request_param.dbpath, "SELECT TOKEN FROM ARF01 where RecNum = " + request_param.idmarket, 1);
                request_param.access_token = readDB[0];
                //var request_param = JsonConvert.DeserializeObject(request.Body, typeof(UpdatePrice.UpdatePrice_Tiktok_Request)) as UpdatePrice.UpdatePrice_Tiktok_Request;

                Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }

        public APIGatewayProxyResponse UpdatePricePerBrg(UpdatePriceV2ViewModel request_param, ILambdaContext context)
        {
            //string request_data = JsonConvert.SerializeObject(request.Body);
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(request_param),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            int workerThreads; int completionPortThreads; ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            //Action<UpdatePrice.UpdatePrice_Tiktok_Request> secondAction = UpdatePrice.UpdatePrice_Tiktok;
            var listReq_id = new List<string>();
            try
            {
                var updateInduk = false;
                var cekHargaInduk = GetToken(request_param.dbsource, request_param.dbpath, "SELECT HJUAL FROM STF02 where BRG = '" + request_param.BRG + "'", 1);
                if(request_param.HMASTER != Convert.ToDouble(cekHargaInduk[0]))
                {
                    updateInduk = true;
                    updateHargaMaster(request_param.dbsource, request_param.dbpath, request_param.HMASTER, request_param.BRG);
                }
                var task = new Task[request_param.ListUpdatePriceModel.Count];
                var idx = 0;
                var conn_id = Guid.NewGuid().ToString("N");
                foreach (var hjual in request_param.ListUpdatePriceModel)
                {
                    #region loop per mp
                    var reqID = request_param.dbpath + "_" + conn_id + ";" + idx + "_" + DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmssfff");
                    listReq_id.Add(reqID);
                    task[idx] = Task.Factory.StartNew(async () =>
                    {
                       await UpdatePrice_Thread(request_param, hjual, updateInduk, reqID);
                    });
                    //var customer = GetToken(request_param.dbsource, request_param.dbpath, "SELECT NAMA, TOKEN, KD_ANALISA,API_CLIENT_P,API_CLIENT_U,API_KEY,Sort1_Cust,EMAIL,PASSWORD,PERSO FROM ARF01 where RECNUM = '"
                    //    + hjual.IDMARKET + "'", 1);
                    //if (customer != null)
                    //{
                    //    //if (hJualInDb.DISPLAY)
                    //    if (customer[0] == "16")
                    //    {
                    //        if (hjual.HARGA < 100)
                    //        {
                    //            hjual.error_msg = "Harga Jual minimal 100.";
                    //            continue;
                    //        }
                    //        if (hjual.HARGA_PROMO < 100)
                    //        {
                    //            hjual.error_msg = "Harga Jual minimal 100.";
                    //            continue;
                    //        }
                    //        if (hjual.HARGA < hjual.HARGA_PROMO)
                    //        {
                    //            hjual.error_msg = "Harga Jual Normal tidak bisa lebih kecil dari Harga Jual Promosi";
                    //            continue;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        var retVal = ValidasiHarga(customer[0], hjual.HARGA);
                    //        if (retVal.status == 0)
                    //        {
                    //            //ret.message = retVal.message;
                    //            hjual.error_msg = retVal.message;
                    //            //return Json(ret, JsonRequestBehavior.AllowGet);
                    //            continue;
                    //        }
                    //    }
                    //}
                    //if (customer[0] == "16")
                    //{
                    //    updateHargaMpBlibli(request_param.dbsource, request_param.dbpath, hjual.HARGA, hjual.HARGA_PROMO, request_param.BRG, hjual.IDMARKET);

                    //}
                    //else
                    //{
                    //    updateHargaMp(request_param.dbsource, request_param.dbpath, hjual.HARGA, request_param.BRG, hjual.IDMARKET);

                    //}

                    //#region update data

                    //#endregion
                    //var brgmp = GetToken(request_param.dbsource, request_param.dbpath, "SELECT BRG_MP FROM STF02H where BRG = '" 
                    //    + request_param.BRG + "' AND IDMARKET = " + hjual.IDMARKET, 1);
                    //if (!string.IsNullOrEmpty(brgmp[0]))
                    //{
                        #region move to multi thread
                        //if (customer[0] == "7")//lazada
                        //{
                        //    if (!string.IsNullOrEmpty(customer[1]))//add by Tri, 24-06-2019
                        //    {
                        //        //var reqBody = "{\"kdBrg\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"harga\": \"" + hargaJualBaru
                        //        //     + "\",\"idmarket\": " + customer.RecNum
                        //        //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //        var dataLambda = new UpdatePrice.UpdatePrice_Lazada_Request()
                        //        {
                        //            kdBrg = brgmp[0],
                        //            token = customer[1],
                        //            harga = hjual.HARGA.ToString(),
                        //            idmarket = hjual.IDMARKET,
                        //            dbsource = request_param.dbsource,
                        //            dbpath = request_param.dbpath
                        //        };
                        //        try
                        //        {
                        //            Action<UpdatePrice.UpdatePrice_Lazada_Request> secondAction = UpdatePrice.UpdatePrice_Lazada;
                        //            Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //        }
                        //        catch (Exception err)
                        //        {
                        //            hjual.error_msg = err.Message;
                        //        }
                        //    }
                        //}
                        //else if (customer[0] == "8")//bukalapak
                        //{
                        //    //var reqBody = "{\"brgmp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //    //         + "\",\"idmarket\": " + customer.RecNum
                        //    //        + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //    var dataLambda = new UpdatePrice.UpdatePrice_Bukalapak_Request()
                        //    {
                        //        brgmp = brgmp[0],
                        //        token = customer[1],
                        //        price = hjual.HARGA.ToString(),
                        //        idmarket = hjual.IDMARKET,
                        //        dbsource = request_param.dbsource,
                        //        dbpath = request_param.dbpath
                        //    };
                        //    try
                        //    {
                        //        Action<UpdatePrice.UpdatePrice_Bukalapak_Request> secondAction = UpdatePrice.UpdatePrice_Bukalapak;
                        //        Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //    }
                        //    catch (Exception err)
                        //    {
                        //        hjual.error_msg = err.Message;
                        //    }
                        //}
                        //else if (customer[0] == "16")//blibli
                        //{
                        //    //var reqBody = "{\"kode_mp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"Price\": \"" + hargaJualIndukBaru
                        //    //        + "\",\"idmarket\": " + customer.RecNum + ",\"MarketPrice\": \"" + hJualInDb.HJUAL + "\",\"versiToken\": \"" + customer.KD_ANALISA
                        //    //         + "\",\"API_client_password\": \"" + customer.API_CLIENT_P + "\",\"API_client_username\": \"" + customer.API_CLIENT_U
                        //    //          + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"API_secret_key\": \"" + customer.API_KEY
                        //    //         + "\",\"mta_username_email_merchant\": \"" + customer.EMAIL + "\",\"mta_password_password_merchant\": \"" + customer.PASSWORD
                        //    //       + "\",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //    var dataLambda = new UpdatePrice.UpdatePrice_Blibli_Request()
                        //    {
                        //        kode_mp = brgmp[0],
                        //        token = customer[1],
                        //        Price = hjual.HARGA.ToString(),
                        //        MarketPrice = hjual.HARGA_PROMO.ToString(),
                        //        idmarket = hjual.IDMARKET,
                        //        API_client_password = customer[3],
                        //        API_client_username= customer[4],
                        //        API_secret_key= customer[5],
                        //        merchant_code= customer[6],
                        //        mta_password_password_merchant= customer[8],
                        //        mta_username_email_merchant= customer[7],
                        //        versiToken= customer[2],
                        //        dbsource = request_param.dbsource,
                        //        dbpath = request_param.dbpath
                        //    };
                        //    try
                        //    {
                        //        Action<UpdatePrice.UpdatePrice_Blibli_Request> secondAction = UpdatePrice.UpdatePrice_Blibli;
                        //        Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //    }
                        //    catch (Exception err)
                        //    {
                        //        hjual.error_msg = err.Message;
                        //    }
                        //}
                        //else if (customer[0] == "17")//shopee
                        //{
                        //    if (!string.IsNullOrWhiteSpace(customer[6]))
                        //    {


                        //    //        var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //    //    + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"idmarket\": " + customer.RecNum
                        //    //+ ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //        var dataLambda = new UpdatePrice.UpdatePrice_Shopee_Request()
                        //        {
                        //            brg_mp = brgmp[0],
                        //            token = customer[1],
                        //            price = hjual.HARGA.ToString(),
                        //            idmarket = hjual.IDMARKET,
                        //            merchant_code = customer[6],
                        //            dbsource = request_param.dbsource,
                        //            dbpath = request_param.dbpath
                        //        };
                        //        try
                        //        {
                        //            Action<UpdatePrice.UpdatePrice_Shopee_Request> secondAction = UpdatePrice.UpdatePrice_Shopee;
                        //            Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //        }
                        //        catch (Exception err)
                        //        {
                        //            hjual.error_msg = err.Message;
                        //        }

                        //    }
                        //}
                        //else if (customer[0] == "21")//shopify
                        //{
                        //    if (!string.IsNullOrWhiteSpace(customer[6]))
                        //    {
                        //        //var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"API_password\": \"" + customer.API_CLIENT_P + "\",\"price\": \"" + hargaJualBaru
                        //        //    + "\",\"account_store\": \"" + customer.PERSO + "\",\"API_key\": \"" + customer.API_KEY + "\",\"idmarket\": " + customer.RecNum
                        //        //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //        var dataLambda = new UpdatePrice.UpdatePrice_Shopify_Request()
                        //        {
                        //            brg_mp = brgmp[0],
                        //            price = hjual.HARGA.ToString(),
                        //            idmarket = hjual.IDMARKET,
                        //            API_password = customer[3],
                        //            account_store= customer[9],
                        //            API_key = customer[5],
                        //            dbsource = request_param.dbsource,
                        //            dbpath = request_param.dbpath
                        //        };
                        //        try
                        //        {
                        //            Action<UpdatePrice.UpdatePrice_Shopify_Request> secondAction = UpdatePrice.UpdatePrice_Shopify;
                        //            Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //        }
                        //        catch (Exception err)
                        //        {
                        //            hjual.error_msg = err.Message;
                        //        }
                        //    }
                        //}
                        //else if (customer[0] == "15")//tokopedia
                        //{
                        //    if (brgmp[0].Contains("PENDING") || brgmp[0].Contains("PEDITENDING"))
                        //    {
                        //        hjual.error_msg = "Harga barang tidak berhasil disimpan. Mohon lakukan edit barang dan simpan barang di menu master barang kemudian lakukan ubah harga lagi!";
                        //    }
                        //    else
                        //    {
                        //        //var reqBody = "{\"product_id\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //        //    + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"API_secret_key\": \"" + customer.API_KEY + "\",\"idmarket\": " + customer.RecNum
                        //        //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //        var dataLambda = new UpdatePrice.UpdatePrice_Tokped_Request()
                        //        {
                        //            product_id = brgmp[0],
                        //            price = hjual.HARGA.ToString(),
                        //            idmarket = hjual.IDMARKET,
                        //            token = customer[1],
                        //            API_secret_key= customer[5],
                        //            merchant_code= customer[6],
                        //            dbsource = request_param.dbsource,
                        //            dbpath = request_param.dbpath
                        //        };
                        //        try
                        //        {
                        //            Action<UpdatePrice.UpdatePrice_Tokped_Request> secondAction = UpdatePrice.UpdatePrice_Tokopedia;
                        //            Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //        }
                        //        catch (Exception err)
                        //        {
                        //            hjual.error_msg = err.Message;
                        //        }
                        //    }
                        //}
                        //else if (customer[0] == "2021")//tiktok
                        //{

                        //        //var reqBody = "{\"product_id\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //        //     + "\",\"shop_id\": \"" + customer.Sort1_Cust + "\",\"idmarket\": " + customer.RecNum
                        //        //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        //    var dataLambda = new UpdatePrice.UpdatePrice_Tiktok_Request()
                        //    {
                        //        product_id = brgmp[0],
                        //        price = hjual.HARGA.ToString(),
                        //        idmarket = hjual.IDMARKET,
                        //        access_token = customer[1],
                        //        shop_id = customer[6],
                        //        dbsource = request_param.dbsource,
                        //        dbpath = request_param.dbpath
                        //    };
                        //    try
                        //    {
                        //        Action<UpdatePrice.UpdatePrice_Tiktok_Request> secondAction = UpdatePrice.UpdatePrice_Tiktok;
                        //        Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //    }
                        //    catch (Exception err)
                        //    {
                        //        hjual.error_msg = err.Message;
                        //    }
                        //}
                        //else if (customer[0] == "20")//82cart
                        //{
                        //    if (!string.IsNullOrWhiteSpace(customer[6]))
                        //    {
                        //       // var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"API_url\": \"" + customer.PERSO + "\",\"priceInduk\": \"" + hargaJualIndukBaru
                        //       // + "\",\"idmarket\": " + customer.RecNum + ",\"priceImpact\": \"" + hargaJualDampakBaru
                        //       //   + "\",\"API_credential\": \"" + customer.Sort1_Cust + "\",\"API_key\": \"" + customer.API_KEY
                        //       //+ "\",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";

                        //        var dataLambda = new UpdatePrice.UpdatePrice_82Cart_Request()
                        //        {
                        //            //brg_mp = brgmp[0],
                        //            idmarket = hjual.IDMARKET,
                        //            API_url = customer[9],
                        //            API_credential= customer[6],
                        //            API_key = customer[5],
                        //            dbsource = request_param.dbsource,
                        //            dbpath = request_param.dbpath
                        //        };
                        //        if (updateInduk)
                        //        {
                        //            var brg_mp = brgmp[0].Split(';');
                        //            if (brg_mp[1] != "0")//update harga induk untuk brg varian
                        //            {
                        //                dataLambda.priceInduk = request_param.HMASTER.ToString();
                        //                dataLambda.brg_mp = brg_mp[0] + ";0";
                        //                try
                        //                {
                        //                    Action<UpdatePrice.UpdatePrice_82Cart_Request> secondActionParent = UpdatePrice.UpdatePrice_82Cart;
                        //                    Retry.DoWithRetry(() => secondActionParent(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //                }
                        //                catch (Exception err)
                        //                {
                        //                    hjual.error_msg = "harga induk : " + err.Message + "\n";
                        //                }
                        //            }
                        //        }
                        //        try
                        //        {
                        //            dataLambda.brg_mp = brgmp[0];
                        //            dataLambda.priceInduk = hjual.HARGA.ToString();
                        //            dataLambda.priceImpact = (hjual.HARGA - request_param.HMASTER).ToString();
                        //            Action<UpdatePrice.UpdatePrice_82Cart_Request> secondAction = UpdatePrice.UpdatePrice_82Cart;
                        //            Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                        //        }
                        //        catch (Exception err)
                        //        {
                        //            hjual.error_msg += err.Message;
                        //        }
                        //    }
                        //}
                        #endregion
                    //}
                    #endregion
                    idx++;
                }
                Task.WaitAll(task);
                //Retry.DoWithRetry(() => secondAction(request_param), TimeSpan.FromSeconds(1), 2);
                if(listReq_id.Count > 0)
                {
                    var adaError = false;
                    foreach (var err in listReq_id)
                    {
                        var tblCust = GetToken(request_param.dbsource, request_param.dbpath, "SELECT CUST, MARKETPLACE, REQUEST_EXCEPTION FROM API_LOG_MARKETPLACE where REQUEST_ID = 'LAMBDA_" + err + "'", 3);

                        if(tblCust.Count > 0)
                        {
                            if (!adaError)
                            {
                                adaError = true;
                                responseRet.Body = "List Error : \n";
                            }
                            var perso = GetToken(request_param.dbsource, request_param.dbpath, "SELECT PERSO FROM ARF01 where CUST = '" + tblCust[0] + "'", 1);
                            responseRet.Body += tblCust[1] + " (" + perso[0] + ") : " + tblCust[2] + "\n";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body += ex.Message;
            }

            return responseRet;
        }
        public async Task<string> UpdatePrice_Thread(UpdatePriceV2ViewModel request_param, UpdatePriceModel hjual, bool updateInduk, string log_id)
        {
            var dataLog = new LogLambdaData()
            {
                //cust = customer.CUST,
                dbpathera = request_param.dbpath,
                function_name = "Update Price",
                //marketplace = "LAZADA",
                //myData = reqBody,
                param1 = request_param.BRG,
                //path = "LambdaWebAPI-UpdatePriceLazada-NNdT3YuicSVl",
                username = request_param.username,
                function_cat = "Price",
            };
            try
            {
                var customer = GetToken(request_param.dbsource, request_param.dbpath, "SELECT NAMA, TOKEN, KD_ANALISA,API_CLIENT_P,API_CLIENT_U,API_KEY,Sort1_Cust,EMAIL,PASSWORD,PERSO, CUST FROM ARF01 where RECNUM = '"
                    + hjual.IDMARKET + "'", 11);
                dataLog.cust = customer[10];
                if (customer != null)
                {
                    //if (hJualInDb.DISPLAY)
                    if (customer[0] == "16")
                    {
                        if (hjual.HARGA < 100)
                        {
                            hjual.error_msg = "Harga Jual minimal 100.";
                            //continue;
                            throw new Exception(hjual.error_msg);
                        }
                        if (hjual.HARGA_PROMO < 100)
                        {
                            hjual.error_msg = "Harga Jual minimal 100.";
                            //continue;
                            throw new Exception(hjual.error_msg);
                        }
                        if (hjual.HARGA < hjual.HARGA_PROMO)
                        {
                            hjual.error_msg = "Harga Jual Normal tidak bisa lebih kecil dari Harga Jual Promosi";
                            //continue;
                            throw new Exception(hjual.error_msg);
                        }
                    }
                    else
                    {
                        var retVal = ValidasiHarga(customer[0], hjual.HARGA);
                        if (retVal.status == 0)
                        {
                            //ret.message = retVal.message;
                            hjual.error_msg = retVal.message;
                            //return Json(ret, JsonRequestBehavior.AllowGet);
                            //continue;
                            throw new Exception(hjual.error_msg);
                        }
                    }
                }
                #region update to db
                if (customer[0] == "16")
                {
                    updateHargaMpBlibli(request_param.dbsource, request_param.dbpath, hjual.HARGA, hjual.HARGA_PROMO, request_param.BRG, hjual.IDMARKET);

                }
                else
                {
                    updateHargaMp(request_param.dbsource, request_param.dbpath, hjual.HARGA, request_param.BRG, hjual.IDMARKET);

                }
                #endregion
                var brgmp = GetToken(request_param.dbsource, request_param.dbpath, "SELECT BRG_MP FROM STF02H where BRG = '"
                        + request_param.BRG + "' AND IDMARKET = " + hjual.IDMARKET, 1);
                if (!string.IsNullOrEmpty(brgmp[0]))
                {
                    if (customer[0] == "7")//lazada
                    {
                        if (!string.IsNullOrEmpty(customer[1]))//add by Tri, 24-06-2019
                        {
                            //var reqBody = "{\"kdBrg\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"harga\": \"" + hargaJualBaru
                            //     + "\",\"idmarket\": " + customer.RecNum
                            //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                            var dataLambda = new UpdatePrice.UpdatePrice_Lazada_Request()
                            {
                                kdBrg = brgmp[0],
                                token = customer[1],
                                harga = hjual.HARGA.ToString(),
                                idmarket = hjual.IDMARKET,
                                dbsource = request_param.dbsource,
                                dbpath = request_param.dbpath
                            };
                            dataLog.marketplace = "LAZADA";
                            dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                            dataLog.path = "LambdaWebAPI-UpdatePriceLazada-NNdT3YuicSVl";
                            try
                            {
                                //Action<UpdatePrice.UpdatePrice_Lazada_Request> secondAction = UpdatePrice.UpdatePrice_Lazada;
                                //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                                var ret = await new UpdatePrice().Call_UpdatePrice_Lazada_http(dataLambda);
                                if (!string.IsNullOrEmpty(ret))
                                {
                                    throw new Exception(ret);
                                }
                            }
                            catch (Exception err)
                            {
                                //hjual.error_msg = err.Message + ";" + err.Source + ";" + err.StackTrace;
                                hjual.error_msg = err.Message;
                                throw new Exception(hjual.error_msg);
                            }
                        }
                    }
                    else if (customer[0] == "8")//bukalapak
                    {
                        //var reqBody = "{\"brgmp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //         + "\",\"idmarket\": " + customer.RecNum
                        //        + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        var dataLambda = new UpdatePrice.UpdatePrice_Bukalapak_Request()
                        {
                            brgmp = brgmp[0],
                            token = customer[1],
                            price = hjual.HARGA.ToString(),
                            idmarket = hjual.IDMARKET,
                            dbsource = request_param.dbsource,
                            dbpath = request_param.dbpath
                        };
                        dataLog.marketplace = "BUKALAPAK";
                        dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                        dataLog.path = "LambdaWebAPI-UpdatePriceBukalapak-2Bg8mDOPQjeT";
                        try
                        {
                            //Action<UpdatePrice.UpdatePrice_Bukalapak_Request> secondAction = UpdatePrice.UpdatePrice_Bukalapak;
                            //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                            var ret = new UpdatePrice().Call_UpdatePrice_Bukalapak(dataLambda);
                            if (!string.IsNullOrEmpty(ret))
                            {
                                throw new Exception(ret);
                            }
                        }
                        catch (Exception err)
                        {
                            hjual.error_msg = err.Message;
                            throw new Exception(hjual.error_msg);
                        }
                    }
                    else if (customer[0] == "16")//blibli
                    {
                        //var reqBody = "{\"kode_mp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"Price\": \"" + hargaJualIndukBaru
                        //        + "\",\"idmarket\": " + customer.RecNum + ",\"MarketPrice\": \"" + hJualInDb.HJUAL + "\",\"versiToken\": \"" + customer.KD_ANALISA
                        //         + "\",\"API_client_password\": \"" + customer.API_CLIENT_P + "\",\"API_client_username\": \"" + customer.API_CLIENT_U
                        //          + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"API_secret_key\": \"" + customer.API_KEY
                        //         + "\",\"mta_username_email_merchant\": \"" + customer.EMAIL + "\",\"mta_password_password_merchant\": \"" + customer.PASSWORD
                        //       + "\",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        var dataLambda = new UpdatePrice.UpdatePrice_Blibli_Request()
                        {
                            kode_mp = brgmp[0],
                            token = customer[1],
                            Price = hjual.HARGA.ToString(),
                            MarketPrice = hjual.HARGA_PROMO.ToString(),
                            idmarket = hjual.IDMARKET,
                            API_client_password = customer[3],
                            API_client_username = customer[4],
                            API_secret_key = customer[5],
                            merchant_code = customer[6],
                            mta_password_password_merchant = customer[8],
                            mta_username_email_merchant = customer[7],
                            versiToken = customer[2],
                            dbsource = request_param.dbsource,
                            dbpath = request_param.dbpath
                        };
                        dataLog.marketplace = "BLIBLI";
                        dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                        dataLog.path = "LambdaWebAPI-UpdatePriceBlibli-5jyr56jy2kbw";
                        try
                        {
                            //Action<UpdatePrice.UpdatePrice_Blibli_Request> secondAction = UpdatePrice.UpdatePrice_Blibli;
                            //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                            var ret = new UpdatePrice().Call_UpdatePrice_Blibli(dataLambda);
                            if (!string.IsNullOrEmpty(ret))
                            {
                                throw new Exception(ret);
                            }
                        }
                        catch (Exception err)
                        {
                            hjual.error_msg = err.Message;
                            throw new Exception(hjual.error_msg);
                        }
                    }
                    else if (customer[0] == "17")//shopee
                    {
                        if (!string.IsNullOrWhiteSpace(customer[6]))
                        {
                            //        var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                            //    + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"idmarket\": " + customer.RecNum
                            //+ ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                            var dataLambda = new UpdatePrice.UpdatePrice_Shopee_Request()
                            {
                                brg_mp = brgmp[0],
                                token = customer[1],
                                price = hjual.HARGA.ToString(),
                                idmarket = hjual.IDMARKET,
                                merchant_code = customer[6],
                                dbsource = request_param.dbsource,
                                dbpath = request_param.dbpath
                            };
                            dataLog.marketplace = "SHOPEE";
                            dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                            dataLog.path = "LambdaWebAPI-UpdatePriceShopee-WtaW1NYZn4I8";
                            try
                            {
                                //Action<UpdatePrice.UpdatePrice_Shopee_Request> secondAction = UpdatePrice.UpdatePrice_Shopee;
                                //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                                var ret = new UpdatePrice().Call_UpdatePrice_Shopee(dataLambda);
                                if (!string.IsNullOrEmpty(ret))
                                {
                                    throw new Exception(ret);
                                }
                            }
                            catch (Exception err)
                            {
                                hjual.error_msg = err.Message;
                                throw new Exception(hjual.error_msg);
                            }

                        }
                    }
                    else if (customer[0] == "21")//shopify
                    {
                        if (!string.IsNullOrWhiteSpace(customer[6]))
                        {
                            //var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"API_password\": \"" + customer.API_CLIENT_P + "\",\"price\": \"" + hargaJualBaru
                            //    + "\",\"account_store\": \"" + customer.PERSO + "\",\"API_key\": \"" + customer.API_KEY + "\",\"idmarket\": " + customer.RecNum
                            //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                            var dataLambda = new UpdatePrice.UpdatePrice_Shopify_Request()
                            {
                                brg_mp = brgmp[0],
                                price = hjual.HARGA.ToString(),
                                idmarket = hjual.IDMARKET,
                                API_password = customer[3],
                                account_store = customer[9],
                                API_key = customer[5],
                                dbsource = request_param.dbsource,
                                dbpath = request_param.dbpath
                            };
                            dataLog.marketplace = "SHOPIFY";
                            dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                            dataLog.path = "LambdaWebAPI-UpdatePriceShopify-Ea4T3THlbMPC";
                            try
                            {
                                //Action<UpdatePrice.UpdatePrice_Shopify_Request> secondAction = UpdatePrice.UpdatePrice_Shopify;
                                //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                                //UpdatePrice.UpdatePrice_Shopify(dataLambda);
                                var ret = await new UpdatePrice().Call_UpdatePrice_Shopify(dataLambda);
                                if (!string.IsNullOrEmpty(ret))
                                {
                                    throw new Exception(ret);
                                }
                            }
                            catch (Exception err)
                            {
                                hjual.error_msg = err.Message;
                                throw new Exception(hjual.error_msg);
                            }
                        }
                    }
                    else if (customer[0] == "15")//tokopedia
                    {
                        if (brgmp[0].Contains("PENDING") || brgmp[0].Contains("PEDITENDING"))
                        {
                            hjual.error_msg = "Harga barang tidak berhasil disimpan. Mohon lakukan edit barang dan simpan barang di menu master barang kemudian lakukan ubah harga lagi!";
                            throw new Exception(hjual.error_msg);
                        }
                        else
                        {
                            //var reqBody = "{\"product_id\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                            //    + "\",\"merchant_code\": \"" + customer.Sort1_Cust + "\",\"API_secret_key\": \"" + customer.API_KEY + "\",\"idmarket\": " + customer.RecNum
                            //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                            var dataLambda = new UpdatePrice.UpdatePrice_Tokped_Request()
                            {
                                product_id = brgmp[0],
                                price = hjual.HARGA.ToString(),
                                idmarket = hjual.IDMARKET,
                                token = customer[1],
                                API_secret_key = customer[5],
                                merchant_code = customer[6],
                                dbsource = request_param.dbsource,
                                dbpath = request_param.dbpath
                            };
                            dataLog.marketplace = "TOKOPEDIA";
                            dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                            dataLog.path = "LambdaWebAPI-UpdatePriceTokped-zZFtoidzw1Ig";
                            try
                            {
                                //Action<UpdatePrice.UpdatePrice_Tokped_Request> secondAction = UpdatePrice.UpdatePrice_Tokopedia;
                                //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                                var ret = new UpdatePrice().Call_UpdatePrice_Tokopedia(dataLambda);
                                if (!string.IsNullOrEmpty(ret))
                                {
                                    throw new Exception(ret);
                                }
                            }
                            catch (Exception err)
                            {
                                hjual.error_msg = err.Message;
                                throw new Exception(hjual.error_msg);
                            }
                        }
                    }
                    else if (customer[0] == "2021")//tiktok
                    {

                        //var reqBody = "{\"product_id\": \"" + hJualInDb.BRG_MP + "\",\"token\": \"" + customer.TOKEN + "\",\"price\": \"" + hargaJualBaru
                        //     + "\",\"shop_id\": \"" + customer.Sort1_Cust + "\",\"idmarket\": " + customer.RecNum
                        //    + ",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";
                        var dataLambda = new UpdatePrice.UpdatePrice_Tiktok_Request()
                        {
                            product_id = brgmp[0],
                            price = hjual.HARGA.ToString(),
                            idmarket = hjual.IDMARKET,
                            access_token = customer[1],
                            shop_id = customer[6],
                            dbsource = request_param.dbsource,
                            dbpath = request_param.dbpath
                        };
                        dataLog.marketplace = "TIKTOK";
                        dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                        dataLog.path = "LambdaWebAPI-UpdatePriceTiktok-EekrxEW2iEoJ";
                        try
                        {
                            //Action<UpdatePrice.UpdatePrice_Tiktok_Request> secondAction = UpdatePrice.UpdatePrice_Tiktok;
                            //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                            var ret = new UpdatePrice().Call_UpdatePrice_Tiktok(dataLambda);
                            if (!string.IsNullOrEmpty(ret))
                            {
                                throw new Exception(ret);
                            }
                        }
                        catch (Exception err)
                        {
                            hjual.error_msg = err.Message;
                        }
                    }
                    else if (customer[0] == "20")//82cart
                    {
                        if (!string.IsNullOrWhiteSpace(customer[6]))
                        {
                            // var reqBody = "{\"brg_mp\": \"" + hJualInDb.BRG_MP + "\",\"API_url\": \"" + customer.PERSO + "\",\"priceInduk\": \"" + hargaJualIndukBaru
                            // + "\",\"idmarket\": " + customer.RecNum + ",\"priceImpact\": \"" + hargaJualDampakBaru
                            //   + "\",\"API_credential\": \"" + customer.Sort1_Cust + "\",\"API_key\": \"" + customer.API_KEY
                            //+ "\",\"dbsource\": \"" + HttpUtility.JavaScriptStringEncode(dbSourceEra_ND) + "\",\"dbpath\": \"" + dbPathEra + "\"}";

                            var dataLambda = new UpdatePrice.UpdatePrice_82Cart_Request()
                            {
                                //brg_mp = brgmp[0],
                                idmarket = hjual.IDMARKET,
                                API_url = customer[9],
                                API_credential = customer[6],
                                API_key = customer[5],
                                dbsource = request_param.dbsource,
                                dbpath = request_param.dbpath
                            };
                            dataLog.marketplace = "82Cart";
                            dataLog.myData = JsonConvert.SerializeObject(dataLambda);
                            dataLog.path = "LambdaWebAPI-UpdatePrice82Cart-jPQ5lgZOiGLa";
                            //if (updateInduk)
                            //{
                            //    var brg_mp = brgmp[0].Split(';');
                            //    if (brg_mp[1] != "0")//update harga induk untuk brg varian
                            //    {
                            //        dataLambda.priceInduk = request_param.HMASTER.ToString();
                            //        dataLambda.brg_mp = brg_mp[0] + ";0";
                            //        try
                            //        {
                            //            Action<UpdatePrice.UpdatePrice_82Cart_Request> secondActionParent = UpdatePrice.UpdatePrice_82Cart;
                            //            Retry.DoWithRetry(() => secondActionParent(dataLambda), TimeSpan.FromSeconds(1), 2);
                            //        }
                            //        catch (Exception err)
                            //        {
                            //            hjual.error_msg = "harga induk : " + err.Message + "\n";
                            //        }
                            //    }
                            //}
                            try
                            {
                                dataLambda.brg_mp = brgmp[0];
                                dataLambda.priceInduk = hjual.HARGA.ToString();
                                dataLambda.priceImpact = (hjual.HARGA - hjual.INDUK).ToString();
                                //Action<UpdatePrice.UpdatePrice_82Cart_Request> secondAction = UpdatePrice.UpdatePrice_82Cart;
                                //Retry.DoWithRetry(() => secondAction(dataLambda), TimeSpan.FromSeconds(1), 2);
                                var ret = new UpdatePrice().Call_UpdatePrice_82Cart(dataLambda);
                                if (!string.IsNullOrEmpty(ret))
                                {
                                    throw new Exception(ret);
                                }
                            }
                            catch (Exception err)
                            {
                                hjual.error_msg += err.Message;
                                throw new Exception(hjual.error_msg);
                            }
                        }
                    }
                }
            } catch(Exception ex)
            {
                CreateLogLambda(log_id, dataLog, "FAILED", request_param.dbsource);
                CreateLogLambdaError(log_id, dataLog, ex.Message, request_param.dbsource);
            }
            return "";
        }
        public BindingBase ValidasiHarga(string idmarket, double price)
        {
            var ret = new BindingBase
            {
                status = 1
            };
            switch (idmarket)
            {
                case "7"://Lazada
                    //if (price < 3000)
                    if (price < 1000)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 1000.";
                    }
                    break; 
                case "2021"://tiktok
                    if (price < 100)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 100.";
                    }
                    break;
                case "15"://Tokopedia
                    if (price < 100)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 100.";
                    }
                    break;
                case "16":
                    if (price < 100)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 100.";
                    }
                    break;
                case "17"://Shopee
                    if (price < 100)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 100.";
                    }
                    break;
                case "19"://JD.ID
                    if (price < 100)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 100.";
                    }
                    break;
                case "21"://SHOPIFY
                    if (price < 0)
                    {
                        ret.status = 0;
                        ret.message = "Harga Jual harus lebih dari 0.";
                    }
                    break;
            }
            return ret;
        }

        public string CreateLogLambda(string id, LogLambdaData dataLog, string status, string dbsource)
        {
            try
            {
                //SetupContext(dataLog.dbpathera, dataLog.username);
                var tgl = DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
                //EDB.ExecuteSQL("CString", CommandType.Text, "DELETE FROM API_LOG_LAMBDA WHERE TGL <= '" + DateTime.UtcNow.AddHours(7).AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss") + "'");
                //EDB.ExecuteSQL("CString", CommandType.Text, "DELETE FROM API_LOG_LAMBDA WHERE TGL <= '" + DateTime.UtcNow.AddHours(7).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' AND status = 'SUCCESS'");
                //if (string.IsNullOrEmpty(id))
                {
                    //var reqID = dataLog.path + "_" + Guid.NewGuid().ToString("N") + "_" + DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmssfff");
                    //id = reqID;
                    //var sSQL = "INSERT INTO API_LOG_LAMBDA (REQUEST_ID, TGL, path, myData, function_name, marketplace, cust, param1, param2, param3, dbpathera, username, status) ";
                    //sSQL += "values ( '" + reqID + "', '" + tgl + "', '" + dataLog.path + "', '" + dataLog.myData + "', '" + dataLog.function_name + "', '" + dataLog.marketplace + "', '";
                    //sSQL += dataLog.cust + "', '" + dataLog.param1 + "', '" + dataLog.param2 + "', '" + dataLog.param3 + "', '" + dataLog.dbpathera + "', '" + dataLog.username + "', '" + status + "')";
                    //var insertLog = EDB.ExecuteSQL("CString", CommandType.Text, sSQL);

                    string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dataLog.dbpathera + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

                    using (var Conn = new SqlConnection(ConnectionString))
                    {
                        Conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO API_LOG_LAMBDA (REQUEST_ID, TGL, path, myData, function_name, marketplace, cust, param1, param2, param3, dbpathera, username, status) VALUES (@REQUEST_ID, @TGL, @path, @myData, @function_name, @marketplace, @cust, @param1, @param2, @param3, @dbpathera, @username, @status)", Conn))
                        {
                            cmd.Parameters.Add("@REQUEST_ID", SqlDbType.NVarChar, 250).Value = id;
                            cmd.Parameters.Add("@TGL", SqlDbType.Date).Value = tgl;
                            cmd.Parameters.Add("@path", SqlDbType.VarChar, 50).Value = dataLog.path;
                            cmd.Parameters.Add("@myData", SqlDbType.NVarChar, -1).Value = dataLog.myData;
                            cmd.Parameters.Add("@function_name", SqlDbType.VarChar, 50).Value = dataLog.function_name;
                            cmd.Parameters.Add("@marketplace", SqlDbType.VarChar, 50).Value = dataLog.marketplace;
                            cmd.Parameters.Add("@cust", SqlDbType.VarChar, 50).Value = dataLog.cust;
                            cmd.Parameters.Add("@param1", SqlDbType.NVarChar, -1).Value = dataLog.param1 ?? "";
                            cmd.Parameters.Add("@param2", SqlDbType.NVarChar, -1).Value = dataLog.param2 ?? "";
                            cmd.Parameters.Add("@param3", SqlDbType.NVarChar, -1).Value = dataLog.param3 ?? "";
                            cmd.Parameters.Add("@dbpathera", SqlDbType.VarChar, 50).Value = dataLog.dbpathera;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = dataLog.username;
                            cmd.Parameters.Add("@status", SqlDbType.VarChar, 50).Value = status;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                        Conn.Close();
                    }
                }
                //else
                //{
                //    var updateLog = EDB.ExecuteSQL("CString", CommandType.Text, "UPDATE API_LOG_LAMBDA SET STATUS = '" + status + "' , TGL_UPDATE = '" + tgl + "' WHERE REQUEST_ID = '" + id + "' ");
                //}
            }
            catch (Exception ex)
            {

            }
            return id;
        }

        public void CreateLogLambdaError(string id, LogLambdaData dataLog, string error, string dbsource)
        {
            //SetupContext(dataLog.dbpathera, username);
            var reqID = id;
            if (!reqID.Contains("LAMBDA_"))
            {
                reqID = "LAMBDA_" + id;
            }
            //var sSQL = "INSERT INTO API_LOG_MARKETPLACE (REQUEST_STATUS,CUST_ATTRIBUTE_1,CUST_ATTRIBUTE_2,CUST_ATTRIBUTE_3,CUST,MARKETPLACE,REQUEST_ID,";
            //sSQL += "REQUEST_ACTION,REQUEST_DATETIME,REQUEST_ATTRIBUTE_3, REQUEST_ATTRIBUTE_4,REQUEST_ATTRIBUTE_5, ";
            //sSQL += "REQUEST_RESULT,REQUEST_EXCEPTION) ";
            //sSQL += "SELECT 'FAILED',A.CUST_ATTRIBUTE_1, A.CUST_ATTRIBUTE_2,A.CUST_ATTRIBUTE_3, A.CUST,A.MARKETPLACE,A.REQUEST_ID, A.REQUEST_ACTION,A.REQUEST_DATETIME,A.REQUEST_ATTRIBUTE_3,A.REQUEST_ATTRIBUTE_4,A.REQUEST_ATTRIBUTE_5,A.REQUEST_RESULT,A.REQUEST_EXCEPTION FROM ( SELECT ";
            //sSQL += "'FAILED' REQUEST_STATUS, '" + dataLog.param1.Replace("'", "`") + "' CUST_ATTRIBUTE_1, '1' CUST_ATTRIBUTE_2,'' CUST_ATTRIBUTE_3, '" + dataLog.cust
            //    + "' CUST, '" + dataLog.marketplace + "' MARKETPLACE, '" + reqID + "' REQUEST_ID, ";
            //sSQL += "'" + dataLog.function_name + "' REQUEST_ACTION, '" + DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss")
            //    + "' REQUEST_DATETIME, '" + dataLog.function_cat + "' REQUEST_ATTRIBUTE_3, '" + dataLog.param1 + "' REQUEST_ATTRIBUTE_4,";
            //sSQL += "'HANGFIRE' REQUEST_ATTRIBUTE_5, '" + dataLog.function_name + " " + dataLog.param1 + " ke " + dataLog.marketplace + " gagal.' REQUEST_RESULT, '" + error + "' REQUEST_EXCEPTION";
            //sSQL += ") A LEFT JOIN API_LOG_MARKETPLACE B ON B.REQUEST_ATTRIBUTE_5 = 'HANGFIRE' AND A.REQUEST_ACTION = B.REQUEST_ACTION AND A.CUST = B.CUST AND A.CUST_ATTRIBUTE_1 = B.CUST_ATTRIBUTE_1 WHERE ISNULL(B.RECNUM,0) = 0";
            //var insertLog = EDB.ExecuteSQL("CString", CommandType.Text, sSQL);
            //if (insertLog == 0)
            //{
            //    //update JOBID MENJADI JOBID BARU JIKA TIDAK SEDANG RETRY,STATUS,DATE,FAIL COUNT
            //    sSQL = "UPDATE B SET REQUEST_STATUS = 'FAILED', REQUEST_ID = '" + reqID + "', REQUEST_DATETIME = '" + DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss") + "', CUST_ATTRIBUTE_2 = CONVERT(INT,CUST_ATTRIBUTE_2) + 1 ";
            //    sSQL += ", REQUEST_RESULT = '" + dataLog.function_name + " " + dataLog.param1.Replace("'", "`") + " ke " + dataLog.marketplace + " gagal.', REQUEST_EXCEPTION = '" + error.Replace("'", "`") + "' ";
            //    sSQL += ",CUST_ATTRIBUTE_3 = '' FROM API_LOG_MARKETPLACE B INNER JOIN ";
            //    sSQL += "( SELECT '" + dataLog.param1.Replace("'", "`") + "' CUST_ATTRIBUTE_1,'" + dataLog.cust + "' CUST,'" + dataLog.marketplace + "' MARKETPLACE, '" + reqID + "' REQUEST_ID, ";
            //    sSQL += "'" + dataLog.function_name + "' REQUEST_ACTION, '" + DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss") + "' REQUEST_DATETIME, ";
            //    sSQL += "'" + dataLog.function_cat + "' REQUEST_ATTRIBUTE_3,'" + dataLog.param1 + "' REQUEST_ATTRIBUTE_4, 'HANGFIRE' REQUEST_ATTRIBUTE_5, ";
            //    sSQL += "'" + dataLog.function_name + " " + dataLog.param1.Replace("'", "`") + " ke " + dataLog.marketplace + " gagal.' REQUEST_RESULT, '" + error.Replace("'", "`") + "' REQUEST_EXCEPTION ) A ";
            //    sSQL += "ON B.REQUEST_ATTRIBUTE_5 = 'HANGFIRE' AND A.REQUEST_ACTION = B.REQUEST_ACTION AND A.CUST = B.CUST AND A.CUST_ATTRIBUTE_1 = B.CUST_ATTRIBUTE_1 AND B.REQUEST_STATUS IN ('FAILED','RETRYING')";
            //    EDB.ExecuteSQL("sConn", CommandType.Text, sSQL);
            //}
            try
            {
                var tgl = DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
                {
                    string ConnectionString = "Data Source=" + dbsource
                        + ";Initial Catalog=" + dataLog.dbpathera + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

                    using (var Conn = new SqlConnection(ConnectionString))
                    {
                        Conn.Open();
                        var sSQL = "INSERT INTO API_LOG_MARKETPLACE (REQUEST_STATUS,CUST_ATTRIBUTE_1,CUST,MARKETPLACE,REQUEST_ID,";
                        sSQL += "REQUEST_ACTION,REQUEST_DATETIME,REQUEST_ATTRIBUTE_3, REQUEST_ATTRIBUTE_4,REQUEST_ATTRIBUTE_5, ";
                        sSQL += "REQUEST_RESULT,REQUEST_EXCEPTION) VALUES (@REQUEST_STATUS,@CUST_ATTRIBUTE_1,@CUST,@MARKETPLACE,@REQUEST_ID,";
                        sSQL += "@REQUEST_ACTION,@REQUEST_DATETIME,@REQUEST_ATTRIBUTE_3, @REQUEST_ATTRIBUTE_4,@REQUEST_ATTRIBUTE_5, ";
                        sSQL += "@REQUEST_RESULT,@REQUEST_EXCEPTION)";
                        //using (SqlCommand cmd = new SqlCommand(sSQL, Conn))
                        using (SqlCommand cmd = Conn.CreateCommand())
                        {
                            cmd.CommandText = "DELETE FROM [API_LOG_MARKETPLACE] WHERE REQUEST_ID='" + reqID + "'";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = sSQL;
                            cmd.Parameters.Add("@REQUEST_STATUS", SqlDbType.NVarChar, 20).Value = "FAILED";
                            cmd.Parameters.Add("@CUST_ATTRIBUTE_1", SqlDbType.NVarChar, 100).Value = dataLog.param1.Replace("'", "`");
                            cmd.Parameters.Add("@CUST", SqlDbType.NVarChar, 10).Value = dataLog.cust;
                            cmd.Parameters.Add("@MARKETPLACE", SqlDbType.VarChar, 50).Value = dataLog.marketplace;
                            cmd.Parameters.Add("@REQUEST_ID", SqlDbType.NVarChar, -1).Value = reqID;
                            cmd.Parameters.Add("@REQUEST_ACTION", SqlDbType.NVarChar, -1).Value = dataLog.function_name;
                            cmd.Parameters.Add("@REQUEST_DATETIME", SqlDbType.DateTime).Value = tgl;
                            cmd.Parameters.Add("@REQUEST_ATTRIBUTE_3", SqlDbType.NVarChar, -1).Value = dataLog.function_cat;
                            cmd.Parameters.Add("@REQUEST_ATTRIBUTE_4", SqlDbType.NVarChar, -1).Value = dataLog.param1;
                            cmd.Parameters.Add("@REQUEST_ATTRIBUTE_5", SqlDbType.NVarChar, -1).Value = "HANGFIRE";
                            cmd.Parameters.Add("@REQUEST_RESULT", SqlDbType.NVarChar, -1).Value = dataLog.function_name + " " + dataLog.param1 + " ke " + dataLog.marketplace + " gagal";
                            cmd.Parameters.Add("@REQUEST_EXCEPTION", SqlDbType.NVarChar, -1).Value = error;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                        Conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


    }

    public class LogLambdaData
    {
        public string path { get; set; }
        public string myData { get; set; }
        public string function_cat { get; set; }
        public string function_name { get; set; }
        public string marketplace { get; set; }
        public string cust { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string dbpathera { get; set; }
        public string username { get; set; }
    }

    public class UpdatePriceV2ViewModel : User_Identity
    {
        public string username { get; set; }
        public string LOG_ID { get; set; }
        public string BRG { get; set; }
        public string NAMA { get; set; }
        public double HBELI { get; set; }
        public double HMASTER { get; set; }
        public List<UpdatePriceModel> ListUpdatePriceModel { get; set; } = new List<UpdatePriceModel>();
        public List<int> ListUpdateMP { get; set; }

    }
    public class UpdatePriceModel
    {
        public int IDMARKET { get; set; }
        public string BRG { get; set; }
        //public string NAMA { get; set; }
        public double HARGA { get; set; }
        public double HARGA_PROMO { get; set; }
        public string MP { get; set; }
        public string NAMA_MP { get; set; }
        public string UPD { get; set; }
        public string error_msg { get; set; }
        public double INDUK { get; set; }

    }
}
