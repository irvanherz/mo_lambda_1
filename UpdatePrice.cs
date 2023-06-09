using System;
using System.Collections.Generic;
using System.Text;
using Lazop.Api;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Net.Http;
using Amazon.Lambda.APIGatewayEvents;
using System.Net;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

namespace MO_Lambda
{
    public class UpdatePrice
    {
        static string eraAppKey = "101775";
        static string eraAppSecret = "QwUJjjtZ3eCy2qaz6Rv1PEXPyPaPkDSu";
        static string eraCallbackUrl = "https://masteronline.co.id/lzd/code?user=";
        static string urlLazada = "https://api.lazada.co.id/rest";

        static string shopeeV2Url = "https://partner.shopeemobile.com";
        static int MOPartnerIDV2 = 2000894;
        static string MOPartnerKeyV2 = "7375892abcfe85bdfb391fe0dc5ba611330e5e080c49eef0b9b55f469918b0ee";

        static string Version2 = "2.0";
        static string Format = "json";
        static string SignMethod = "md5";
        static string ServerUrlV2 = "https://open-api.jd.id/routerjson";

        static string eraAppKey_Tiktok = "3cqbhg";
        static string eraAppSecret_Tiktok = "57fb173019d59898be333ac5af995585437ed8bf";
        static string api_version = "2023-01";
        //private static readonly HttpClient client = new HttpClient();
        public UpdatePrice()
        {

        }

        public async Task<string> Call_UpdatePrice_Lazada_http(UpdatePrice_Lazada_Request request)
        {

            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            string xmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Request><Product>";
            xmlString += "<Skus><Sku><SellerSku>" + XmlEscape(request.kdBrg) + "</SellerSku>";
            if (!string.IsNullOrEmpty(request.harga))
                xmlString += "<Price>" + XmlEscape(request.harga) + "</Price>";
            xmlString += "</Sku></Skus></Product></Request>";

            string errorMessage = "";
            string path = "/product/price_quantity/update";
            var millis = CurrentTimeMiliSecond();
            var signString = path + "access_token" + request.token + "app_key" + eraAppKey + "payload" + xmlString + "sign_methodsha256timestamp" + millis;
            var sign = CreateSignAuthenLazada(signString, eraAppSecret);
            var reqBody = new RequestBodyUpdatePriceLazada
            {
                access_token = request.token,
                app_key = eraAppKey,
                payload= xmlString,
                sign = sign,
                sign_method= "sha256",
                timestamp = millis
            };
            //ILazopClient client = new LazopClient(urlLazada, eraAppKey, eraAppSecret);
            //LazopRequest requestLzd = new LazopRequest();
            //requestLzd.SetApiName("/product/price_quantity/update");
            //requestLzd.AddApiParameter("payload", xmlString);
            var myData = JsonConvert.SerializeObject(reqBody);
            try
            {
                //LazopResponse response = client.Execute(requestLzd, request.token);
                //var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //var response = await client.PostAsync(urlLazada + path, content);

                //var content = new StringContent(myData, Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
                //var taskAPI = Task.Run(() => client.PostAsync(urlLazada + path, content));
                //HttpResponseMessage clientResponse = taskAPI.Result;
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urlLazada + path);
                myReq.Method = "POST";
                myReq.Accept = "application/json";
                myReq.ContentType = "application/json";
                string responseFromServer = "";
                //using (HttpContent responseContent = clientResponse.Content)
                //{
                //    using (var reader = new StreamReader(await responseContent.ReadAsStringAsync()))
                //    {
                //        responseFromServer = reader.ReadToEnd();
                //    }
                //};
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
                
                var res = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(LazadaResponseObj)) as LazadaResponseObj;
                if (res.code.Equals("0"))
                {
                    if (res.detail != null)
                    {
                        errorMessage = res.detail[0].message;
                    }
                }
                else
                {
                    if (res.detail != null)
                    {
                        errorMessage = res.detail[0].message;
                    }
                    //else
                    //{
                    //    errorMessage = res.message;
                    //}
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + ";" + ex.Source + ";" + ex.StackTrace;
                //errorMessage = ex.ToString();
            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    //responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
            //return responseRet;
        }
        public string Call_UpdatePrice_Lazada(UpdatePrice_Lazada_Request request)
        {

            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            string xmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Request><Product>";
            xmlString += "<Skus><Sku><SellerSku>" + XmlEscape(request.kdBrg) + "</SellerSku>";
            //if (!string.IsNullOrEmpty(qty))
            //    xmlString += "<Quantity>" + qty + "</Quantity>";
            if (!string.IsNullOrEmpty(request.harga))
                xmlString += "<Price>" + XmlEscape(request.harga) + "</Price>";
            xmlString += "</Sku></Skus></Product></Request>";

            string errorMessage = "";

            ILazopClient client = new LazopClient(urlLazada, eraAppKey, eraAppSecret);
            LazopRequest requestLzd = new LazopRequest();
            requestLzd.SetApiName("/product/price_quantity/update");
            requestLzd.AddApiParameter("payload", xmlString);
            try
            {
                LazopResponse response = client.Execute(requestLzd, request.token);
                var res = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Body, typeof(LazadaResponseObj)) as LazadaResponseObj;
                if (res.code.Equals("0"))
                {

                }
                else
                {
                    if (res.detail != null)
                    {
                        errorMessage = res.detail[0].message;
                    }
                    else
                    {
                        errorMessage = res.message;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + ";" + ex.Source + ";" + ex.StackTrace;
                //errorMessage = ex.ToString();
            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    //responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
            //return responseRet;
        }
        public static void UpdatePrice_Lazada(UpdatePrice_Lazada_Request request)
        {

            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            string xmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Request><Product>";
            xmlString += "<Skus><Sku><SellerSku>" + XmlEscape(request.kdBrg) + "</SellerSku>";
            //if (!string.IsNullOrEmpty(qty))
            //    xmlString += "<Quantity>" + qty + "</Quantity>";
            if (!string.IsNullOrEmpty(request.harga))
                xmlString += "<Price>" + XmlEscape(request.harga) + "</Price>";
            xmlString += "</Sku></Skus></Product></Request>";

            string errorMessage = "";

            ILazopClient client = new LazopClient(urlLazada, eraAppKey, eraAppSecret);
            LazopRequest requestLzd = new LazopRequest();
            requestLzd.SetApiName("/product/price_quantity/update");
            requestLzd.AddApiParameter("payload", xmlString);
            try
            {
                LazopResponse response = client.Execute(requestLzd, request.token);
                var res = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Body, typeof(LazadaResponseObj)) as LazadaResponseObj;
                if (res.code.Equals("0"))
                {

                }
                else
                {
                    if (res.detail != null)
                    {
                        errorMessage = res.detail[0].message;
                    }
                    else
                    {
                        errorMessage = res.message;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return errorMessage;
            //return responseRet;
        }

        public string Call_UpdatePrice_Bukalapak(UpdatePrice_Bukalapak_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);

            var splitKode = request.brgmp.Split(';');

            string urll = "https://api.bukalapak.com/products/" + splitKode[0] + "/skus/" + splitKode[1];

            string myData = "{\"price\":" + request.price + "}";

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
            myReq.Method = "PATCH";
            myReq.Headers.Add("Authorization", "Bearer " + request.token);
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            string responseFromServer = "";
            //try
            //{
            myReq.ContentLength = myData.Length;
            using (var dataStream = myReq.GetRequestStream())
            {
                dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
            }
            try
            {
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                string err = "";
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        err = sr.ReadToEnd();
                    }
                }
                errorMessage = (err == "" ? e.Message : err);

            }
            if (responseFromServer != "")
            {
                try
                {
                    var resp = JsonConvert.DeserializeObject(responseFromServer, typeof(BukalapakResponseAPI)) as BukalapakResponseAPI;
                    if (resp != null)
                    {
                        if (resp.meta != null)
                        {
                            //if (resp.meta.http_status != 200)
                            if (resp.meta.http_status >= 200 && resp.meta.http_status < 300)
                            {
                                if (resp.errors != null)
                                {
                                    if (resp.errors.Length > 0)
                                    {
                                        string errMsg = "";
                                        foreach (var error in resp.errors)
                                        {
                                            errMsg += error.code + ":" + error.message + "\n";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex2)
                {
                    errorMessage = ex2.Message;
                }
            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);

            //}
            return errorMessage;
        }
        public static void UpdatePrice_Bukalapak(UpdatePrice_Bukalapak_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);

            var splitKode = request.brgmp.Split(';');

            string urll = "https://api.bukalapak.com/products/" + splitKode[0] + "/skus/" + splitKode[1];

            string myData = "{\"price\":" + request.price + "}";

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
            myReq.Method = "PATCH";
            myReq.Headers.Add("Authorization", "Bearer " + request.token);
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            string responseFromServer = "";
            //try
            //{
            myReq.ContentLength = myData.Length;
            using (var dataStream = myReq.GetRequestStream())
            {
                dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
            }
            try
            {
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                string err = "";
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        err = sr.ReadToEnd();
                    }
                }
                errorMessage = (err == "" ? e.Message : err);

            }
            if (responseFromServer != "")
            {
                try
                {
                    var resp = JsonConvert.DeserializeObject(responseFromServer, typeof(BukalapakResponseAPI)) as BukalapakResponseAPI;
                    if (resp != null)
                    {
                        if (resp.meta != null)
                        {
                            //if (resp.meta.http_status != 200)
                            if (resp.meta.http_status >= 200 && resp.meta.http_status < 300)
                            {
                                if (resp.errors != null)
                                {
                                    if (resp.errors.Length > 0)
                                    {
                                        string errMsg = "";
                                        foreach (var error in resp.errors)
                                        {
                                            errMsg += error.code + ":" + error.message + "\n";
                                        }
                                    }
                                }
                            }
                            //if (request.log_ActionName.Contains("UPDATE_MASSAL"))
                            //{
                            //    var dataLog = request.log_ActionName.Split('_');
                            //    if (dataLog.Length >= 4)
                            //    {
                            //        var nobuk = dataLog[2];
                            //        var indexData = Convert.ToInt32(dataLog[3]);
                            //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                            //        if (log_b != null)
                            //        {
                            //            var currentProgress = log_b.KET.Split('/');
                            //            if (currentProgress.Length == 2)
                            //            {
                            //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                            //                ErasoftDbContext.SaveChanges();
                            //                //currentLog.CUST_ATTRIBUTE_2 = (Convert.ToInt32(currentProgress[0]) + 1).ToString();
                            //                //currentLog.CUST_ATTRIBUTE_3 = currentProgress[1];
                            //            }
                            //        }
                            //    }
                            //}
                        }
                    }
                }
                catch (Exception ex2)
                {
                    errorMessage = ex2.Message;
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                throw new Exception(errorMessage);

            }
            //return responseRet;
        }

        public string Call_UpdatePrice_Tokopedia(UpdatePrice_Tokped_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";

            long milis = CurrentTimeMillis();
            DateTime milisBack = DateTimeOffset.FromUnixTimeMilliseconds(milis).UtcDateTime.AddHours(7);
            string urll = "https://fs.tokopedia.net/inventory/v1/fs/" + Uri.EscapeDataString(request.merchant_code) + "/price/update?shop_id="
                + Uri.EscapeDataString(request.API_secret_key);

            var myData = "[{ \"product_id\":" + request.product_id + ", \"new_price\": " + request.price + "}]";
            string responseFromServer = "";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
            myReq.Method = "POST";
            myReq.Headers.Add("Authorization", ("Bearer " + request.token));
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            //string myData = JsonConvert.SerializeObject(HttpBodies);
            try
            {
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                try
                {
                    using (WebResponse response = myReq.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    string err = "";
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse resp = e.Response;
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                        {
                            err = sr.ReadToEnd();
                        }

                    }
                    errorMessage = (string.IsNullOrEmpty(err) ? e.Message : err);
                }
                if (responseFromServer != "")
                {
                    var result = JsonConvert.DeserializeObject(responseFromServer, typeof(UpdatePriceResponse_Tokped)) as UpdatePriceResponse_Tokped;
                    if (result != null)
                    {
                        if (result.data != null)
                        {
                            if (result.data.failed_rows > 0)
                            {
                                if (result.data.failed_rows_data.Length > 0)
                                {
                                    var rowFailedMessage = "";
                                    foreach (var itemRow in result.data.failed_rows_data)
                                    {
                                        if (!string.IsNullOrEmpty(itemRow.message) && itemRow.product_id != 0)
                                        {
                                            rowFailedMessage = rowFailedMessage + Convert.ToString(itemRow.message) + " product id:"
                                                + Convert.ToString(itemRow.product_id) + ";";
                                        }
                                    }
                                    errorMessage = "failed_rows_data:" + rowFailedMessage;
                                }
                                else
                                {
                                    errorMessage = responseFromServer;
                                }

                            }
                            else
                            {
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    //responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);

            //}
            return errorMessage;
        }
        public static void UpdatePrice_Tokopedia(UpdatePrice_Tokped_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";

            //string ConnectionString = "Data Source=" + request.dbsource.Replace("\\\\SQLEXPRESS", "") + ";Initial Catalog=" + request.dbpath 
            //    + ";Persist Security Info=True;User ID=sa;Password=admin123^;Encrypt=False";

            //using (var Conn = new SqlConnection(ConnectionString))
            //{
            //    using (var Cmd = new SqlCommand("SELECT TOKEN FROM ARF01 where RecNum = " + request.idmarket, Conn))
            //    {
            //        Conn.Open();

            //        SqlDataReader rdr = Cmd.ExecuteReader();
            //        while (rdr.Read())
            //        {
            //            request.token = rdr[0].ToString();
            //        }

            //        Conn.Close();
            //    }
            //}

            long milis = CurrentTimeMillis();
            DateTime milisBack = DateTimeOffset.FromUnixTimeMilliseconds(milis).UtcDateTime.AddHours(7);
            string urll = "https://fs.tokopedia.net/inventory/v1/fs/" + Uri.EscapeDataString(request.merchant_code) + "/price/update?shop_id="
                + Uri.EscapeDataString(request.API_secret_key);

            var myData = "[{ \"product_id\":" + request.product_id + ", \"new_price\": " + request.price + "}]";
            string responseFromServer = "";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
            myReq.Method = "POST";
            myReq.Headers.Add("Authorization", ("Bearer " + request.token));
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            //string myData = JsonConvert.SerializeObject(HttpBodies);
            try
            {
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                try
                {
                    using (WebResponse response = myReq.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    string err = "";
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse resp = e.Response;
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                        {
                            err = sr.ReadToEnd();
                        }

                    }
                    errorMessage = (string.IsNullOrEmpty(err) ? e.Message : err);
                }
                if (responseFromServer != "")
                {
                    var result = JsonConvert.DeserializeObject(responseFromServer, typeof(UpdatePriceResponse_Tokped)) as UpdatePriceResponse_Tokped;
                    if (result != null)
                    {
                        if (result.data != null)
                        {
                            if (result.data.failed_rows > 0)
                            {
                                if (result.data.failed_rows_data.Length > 0)
                                {
                                    var rowFailedMessage = "";
                                    foreach (var itemRow in result.data.failed_rows_data)
                                    {
                                        if (!string.IsNullOrEmpty(itemRow.message) && itemRow.product_id != 0)
                                        {
                                            rowFailedMessage = rowFailedMessage + Convert.ToString(itemRow.message) + " product id:"
                                                + Convert.ToString(itemRow.product_id) + ";";
                                        }
                                    }
                                    errorMessage = "failed_rows_data:" + rowFailedMessage;
                                }
                                else
                                {
                                    errorMessage = responseFromServer;
                                }

                            }
                            else
                            {
                                //if (request.log_ActionName.Contains("UPDATE_MASSAL"))
                                //{
                                //    var dataLog = request.log_ActionName.Split('_');
                                //    if (dataLog.Length >= 4)
                                //    {
                                //        var nobuk = dataLog[2];
                                //        var indexData = Convert.ToInt32(dataLog[3]);
                                //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                                //        if (log_b != null)
                                //        {
                                //            var currentProgress = log_b.KET.Split('/');
                                //            if (currentProgress.Length == 2)
                                //            {
                                //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                                //                ErasoftDbContext.SaveChanges();
                                //            }
                                //        }
                                //    }
                                //}
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                throw new Exception(errorMessage);

            }
            //return responseRet;
        }

        public string Call_UpdatePrice_Blibli(UpdatePrice_Blibli_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);

            long milis = CurrentTimeMillis();
            DateTime milisBack = DateTimeOffset.FromUnixTimeMilliseconds(milis).UtcDateTime.AddHours(7);

            string apiId = request.API_client_username + ":" + request.API_client_password;//<-- diambil dari profil API
            string userMTA = request.mta_username_email_merchant;//<-- email user merchant
            string passMTA = request.mta_password_password_merchant;//<-- pass merchant


            string signature_1 = CreateToken("GET\n\n\n" + milisBack.ToString("ddd MMM dd HH:mm:ss WIB yyyy")
                + "\n/mtaapi/api/businesspartner/v1/product/detailProduct", request.API_secret_key);
            string[] brg_mp = request.kode_mp.Split(';');

            if (brg_mp.Length >= 1)
            {
                string myData = "{";
                myData += "\"merchantCode\": \"" + request.merchant_code + "\", ";
                myData += "\"productRequests\": ";
                myData += "[ ";  //MERCHANT ID ADA DI https://merchant.blibli.com/MTA/store-info/store-info
                {
                    {
                        myData += "{";
                        myData += "\"gdnSku\": \"" + brg_mp[0] + "\",  ";
                        myData += "\"stock\": null, ";
                        myData += "\"minimumStock\": null, ";
                        myData += "\"price\": " + request.Price + ", ";
                        myData += "\"salePrice\": " + request.MarketPrice + " ";
                        myData += "},";
                    }
                }
                myData = myData.Remove(myData.Length - 1);
                myData += "]";
                myData += "}";

                //add by nurul 13/7/2020
                string urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
                //end add by nurul 13/7/2020

                //change by nurul 13/7/2020
                if (request.versiToken != "2")
                {
                    string signature = CreateToken("POST\n" + CalculateMD5Hash(myData) + "\napplication/json\n" + milisBack.ToString("ddd MMM dd HH:mm:ss WIB yyyy")
                        + "\n/mtaapi/api/businesspartner/v1/product/updateProduct", request.API_secret_key);

                    urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";

                    myReq = (HttpWebRequest)WebRequest.Create(urll);
                    myReq.Method = "POST";
                    myReq.Headers.Add("Authorization", ("bearer " + request.token));
                    myReq.Headers.Add("x-blibli-mta-authorization", ("BMA " + userMTA + ":" + signature));
                    myReq.Headers.Add("x-blibli-mta-date-milis", (milis.ToString()));
                    myReq.Accept = "application/json";
                    myReq.ContentType = "application/json";
                    myReq.Headers.Add("requestId", "MasterOnline-" + milis.ToString());
                    myReq.Headers.Add("sessionId", milis.ToString());
                    myReq.Headers.Add("username", userMTA);
                }
                else
                {
                    string usernameMO = request.API_client_username;
                    string passMO = request.API_client_password;
                    urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";

                    myReq = (HttpWebRequest)WebRequest.Create(urll);
                    myReq.Method = "POST";
                    myReq.Headers.Add("Authorization", ("Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameMO + ":" + passMO))));
                    myReq.Accept = "application/json";
                    myReq.ContentType = "application/json";
                    myReq.Headers.Add("Api-Seller-Key", request.API_secret_key);
                    myReq.Headers.Add("Signature-Time", milis.ToString());
                }
                //end change by nurul 13/7/2020

                string responseFromServer = "";
                try
                {
                    myReq.ContentLength = myData.Length;
                    using (var dataStream = myReq.GetRequestStream())
                    {
                        dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                    }
                    using (WebResponse response = myReq.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    string err = "";
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse resp = e.Response;
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                        {
                            err = sr.ReadToEnd();
                        }
                        var response = e.Response as HttpWebResponse;
                        var status = (int)response.StatusCode;
                        if (status == 429)
                        {
                            if (string.IsNullOrEmpty(request.berat))
                            {
                                request.berat = "0";
                            }
                            var loop = Convert.ToInt32(request.berat);
                            
                            {
                                errorMessage = err;
                            }
                        }
                        else
                        {
                            errorMessage = err;
                        }
                    }
                    else
                    {
                        errorMessage = e.Message;
                    }
                }
                if (responseFromServer != "")
                {
                    dynamic result2 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer);
                    if (string.IsNullOrEmpty(result2.errorCode.Value))
                    {
                    }
                    else
                    {
                        errorMessage = responseFromServer;
                    }
                }

            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    //responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
        }
        public static void UpdatePrice_Blibli(UpdatePrice_Blibli_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);

            long milis = CurrentTimeMillis();
            DateTime milisBack = DateTimeOffset.FromUnixTimeMilliseconds(milis).UtcDateTime.AddHours(7);

            string apiId = request.API_client_username + ":" + request.API_client_password;//<-- diambil dari profil API
            string userMTA = request.mta_username_email_merchant;//<-- email user merchant
            string passMTA = request.mta_password_password_merchant;//<-- pass merchant


            string signature_1 = CreateToken("GET\n\n\n" + milisBack.ToString("ddd MMM dd HH:mm:ss WIB yyyy")
                + "\n/mtaapi/api/businesspartner/v1/product/detailProduct", request.API_secret_key);
            string[] brg_mp = request.kode_mp.Split(';');

            if (brg_mp.Length >= 1)
            {
                string myData = "{";
                myData += "\"merchantCode\": \"" + request.merchant_code + "\", ";
                myData += "\"productRequests\": ";
                myData += "[ ";  //MERCHANT ID ADA DI https://merchant.blibli.com/MTA/store-info/store-info
                {
                    {
                        myData += "{";
                        myData += "\"gdnSku\": \"" + brg_mp[0] + "\",  ";
                        myData += "\"stock\": null, ";
                        myData += "\"minimumStock\": null, ";
                        myData += "\"price\": " + request.Price + ", ";
                        myData += "\"salePrice\": " + request.MarketPrice + " ";
                        myData += "},";
                    }
                }
                myData = myData.Remove(myData.Length - 1);
                myData += "]";
                myData += "}";

                //add by nurul 13/7/2020
                string urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
                //end add by nurul 13/7/2020

                //change by nurul 13/7/2020
                if (request.versiToken != "2")
                {
                    string signature = CreateToken("POST\n" + CalculateMD5Hash(myData) + "\napplication/json\n" + milisBack.ToString("ddd MMM dd HH:mm:ss WIB yyyy")
                        + "\n/mtaapi/api/businesspartner/v1/product/updateProduct", request.API_secret_key);

                    urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";

                    myReq = (HttpWebRequest)WebRequest.Create(urll);
                    myReq.Method = "POST";
                    myReq.Headers.Add("Authorization", ("bearer " + request.token));
                    myReq.Headers.Add("x-blibli-mta-authorization", ("BMA " + userMTA + ":" + signature));
                    myReq.Headers.Add("x-blibli-mta-date-milis", (milis.ToString()));
                    myReq.Accept = "application/json";
                    myReq.ContentType = "application/json";
                    myReq.Headers.Add("requestId", "MasterOnline-" + milis.ToString());
                    myReq.Headers.Add("sessionId", milis.ToString());
                    myReq.Headers.Add("username", userMTA);
                }
                else
                {
                    string usernameMO = request.API_client_username;
                    string passMO = request.API_client_password;
                    urll = "https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/product/updateProduct?channelId=MasterOnline";

                    myReq = (HttpWebRequest)WebRequest.Create(urll);
                    myReq.Method = "POST";
                    myReq.Headers.Add("Authorization", ("Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameMO + ":" + passMO))));
                    myReq.Accept = "application/json";
                    myReq.ContentType = "application/json";
                    myReq.Headers.Add("Api-Seller-Key", request.API_secret_key);
                    myReq.Headers.Add("Signature-Time", milis.ToString());
                }
                //end change by nurul 13/7/2020

                string responseFromServer = "";
                try
                {
                    myReq.ContentLength = myData.Length;
                    using (var dataStream = myReq.GetRequestStream())
                    {
                        dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                    }
                    using (WebResponse response = myReq.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    string err = "";
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse resp = e.Response;
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                        {
                            err = sr.ReadToEnd();
                        }
                        var response = e.Response as HttpWebResponse;
                        var status = (int)response.StatusCode;
                        if (status == 429)
                        {
                            if (string.IsNullOrEmpty(request.berat))
                            {
                                request.berat = "0";
                            }
                            var loop = Convert.ToInt32(request.berat);
                            //if (loop < 2)
                            //{
                            //    await Task.Delay(60000);
                            //    request.berat = (loop + 1).ToString();
                            //    await UpdatePrice_Blibli(request, context);
                            //}
                            //else
                            {
                                errorMessage = err;
                            }
                        }
                        else
                        {
                            errorMessage = err;
                        }
                    }
                    else
                    {
                        errorMessage = e.Message;
                    }
                }
                if (responseFromServer != "")
                {
                    dynamic result2 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer);
                    if (string.IsNullOrEmpty(result2.errorCode.Value))
                    {
                        //add 19 sept 2020, update harga massal
                        //if (request.log_ActionName.Contains("UPDATE_MASSAL"))
                        //{
                        //    var dataLog = request.log_ActionName.Split('_');
                        //    if (dataLog.Length >= 4)
                        //    {
                        //        var nobuk = dataLog[2];
                        //        var indexData = Convert.ToInt32(dataLog[3]);
                        //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                        //        if (log_b != null)
                        //        {
                        //            var currentProgress = log_b.KET.Split('/');
                        //            if (currentProgress.Length == 2)
                        //            {
                        //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                        //                ErasoftDbContext.SaveChanges();
                        //            }
                        //            //currentLog.CUST_ATTRIBUTE_2 = (Convert.ToInt32(currentProgress[0]) + 1).ToString();
                        //            //currentLog.CUST_ATTRIBUTE_3 = currentProgress[1];
                        //        }
                        //    }
                        //}
                        //end add 19 sept 2020, update harga massal

                        //BlibliQueueFeedData queueData = new BlibliQueueFeedData
                        //{
                        //    request_id = result2.requestId.Value,
                        //    log_request_id = currentLog.REQUEST_ID
                        //};
                        //await GetQueueFeedDetail(iden, queueData);
                    }
                    else
                    {
                        errorMessage = responseFromServer;
                    }
                }

            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        public string Call_UpdatePrice_Shopee(UpdatePrice_Shopee_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);


            long seconds = CurrentTimeSecond();

            int MOPartnerID = MOPartnerIDV2;
            string MOPartnerKey = MOPartnerKeyV2;
            string urll = shopeeV2Url;
            string path = "/api/v2/product/update_price";

            var baseString = MOPartnerID + path + seconds + request.token + request.merchant_code;
            var sign = CreateSignAuthenShop_V2(baseString, MOPartnerKey);

            string param = "?partner_id=" + MOPartnerID + "&timestamp=" + seconds + "&sign=" + sign
                + "&access_token=" + request.token + "&shop_id=" + request.merchant_code;

            DateTime milisBack = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime.AddHours(7);


            string[] brg_mp_split = request.brg_mp.Split(';');

            string myData = "{ \"price_list\": [{ \"model_id\":" + brg_mp_split[1] + ", \"original_price\":" + request.price + " }], \"item_id\":" + brg_mp_split[0] + " }";

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll + path + param);
            myReq.Method = "POST";
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            string responseFromServer = "";
            try
            {
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            }

            if (responseFromServer != "")
            {
                try
                {
                    var resServer = JsonConvert.DeserializeObject(responseFromServer, typeof(ShopeeUpdatePriceResponse)) as ShopeeUpdatePriceResponse;
                    if (resServer.response.failure_list != null)
                    {
                        if (resServer.response.failure_list.Length > 0)
                        {
                            errorMessage = responseFromServer;
                        }
                    }
                    if (!string.IsNullOrEmpty(resServer.error))
                    {
                        errorMessage = responseFromServer;
                    }
                }
                catch (Exception ex2)
                {
                    errorMessage = ex2.InnerException == null ? ex2.Message : ex2.InnerException.Message;

                }
            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
        }
        public static void UpdatePrice_Shopee(UpdatePrice_Shopee_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);


            long seconds = CurrentTimeSecond();

            int MOPartnerID = MOPartnerIDV2;
            string MOPartnerKey = MOPartnerKeyV2;
            string urll = shopeeV2Url;
            string path = "/api/v2/product/update_price";

            var baseString = MOPartnerID + path + seconds + request.token + request.merchant_code;
            var sign = CreateSignAuthenShop_V2(baseString, MOPartnerKey);

            string param = "?partner_id=" + MOPartnerID + "&timestamp=" + seconds + "&sign=" + sign
                + "&access_token=" + request.token + "&shop_id=" + request.merchant_code;

            DateTime milisBack = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime.AddHours(7);


            string[] brg_mp_split = request.brg_mp.Split(';');

            string myData = "{ \"price_list\": [{ \"model_id\":" + brg_mp_split[1] + ", \"original_price\":" + request.price + " }], \"item_id\":" + brg_mp_split[0] + " }";

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll + path + param);
            myReq.Method = "POST";
            myReq.Accept = "application/json";
            myReq.ContentType = "application/json";
            string responseFromServer = "";
            try
            {
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            }

            if (responseFromServer != "")
            {
                try
                {
                    var resServer = JsonConvert.DeserializeObject(responseFromServer, typeof(ShopeeUpdatePriceResponse)) as ShopeeUpdatePriceResponse;
                    //change position, cek list error first
                    if (resServer.response.failure_list != null)
                    {
                        if (resServer.response.failure_list.Length > 0)
                        {
                            errorMessage = responseFromServer;
                        }
                    }
                    if (!string.IsNullOrEmpty(resServer.error))
                    {
                        errorMessage = responseFromServer;
                    }
                    //end change position, cek list error first
                    //add 19 sept 2020, update harga massal
                    //if (request.log_ActionName.Contains("UPDATE_MASSAL"))
                    //{
                    //    var dataLog = request.log_ActionName.Split('_');
                    //    if (dataLog.Length >= 4)
                    //    {
                    //        var nobuk = dataLog[2];
                    //        var indexData = Convert.ToInt32(dataLog[3]);
                    //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                    //        if (log_b != null)
                    //        {
                    //            var currentProgress = log_b.KET.Split('/');
                    //            if (currentProgress.Length == 2)
                    //            {
                    //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                    //                ErasoftDbContext.SaveChanges();
                    //                //currentLog.CUST_ATTRIBUTE_2 = (Convert.ToInt32(currentProgress[0]) + 1).ToString();
                    //                //currentLog.CUST_ATTRIBUTE_3 = currentProgress[1];
                    //            }
                    //        }
                    //    }
                    //}
                    //end add 19 sept 2020, update harga massal
                }
                catch (Exception ex2)
                {
                    errorMessage = ex2.InnerException == null ? ex2.Message : ex2.InnerException.Message;

                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        public string Call_UpdatePrice_82Cart(UpdatePrice_82Cart_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);
            string[] brg_mp_split = request.brg_mp.Split(';');

            string urll = string.Format("{0}/api/v1/editProductdetail", request.API_url);

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);

            //Required parameters, other parameters can be add
            var postData = "apiKey=" + Uri.EscapeDataString(request.API_key);
            postData += "&apiCredential=" + Uri.EscapeDataString(request.API_credential);
            if (brg_mp_split[1] == "0")
            {
                postData += "&id_product=" + Uri.EscapeDataString(brg_mp_split[0]);
                postData += "&price=" + Uri.EscapeDataString(request.priceInduk.ToString());
                postData += "&wholesale_price=" + Uri.EscapeDataString("0");
            }
            else
            {
                postData += "&id_product=" + Uri.EscapeDataString(brg_mp_split[0]);
                postData += "&id_product_attribute=" + Uri.EscapeDataString(brg_mp_split[1]);
                postData += "&price_attribute=" + Uri.EscapeDataString(request.priceImpact.ToString());
                postData += "&wholesale_price=" + Uri.EscapeDataString("0");

            }

            var data = Encoding.ASCII.GetBytes(postData);

            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = data.Length;

            string responseFromServer = "";
            try
            {
                using (var stream = myReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream2 = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream2);
                        responseFromServer = reader.ReadToEnd();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            if (!string.IsNullOrEmpty(responseFromServer))
            {
                try
                {
                    var resultAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(ResultUpdatePrice)) as ResultUpdatePrice;
                    if (resultAPI.error == "none" && resultAPI.data.Length > 0)
                    {
                    }
                    else
                    {
                        throw new Exception(responseFromServer);
                    }
                }
                catch (Exception ex2)
                {
                    throw new Exception(ex2.InnerException == null ? ex2.Message : ex2.InnerException.Message);
                }

            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
        }
        public static void UpdatePrice_82Cart(UpdatePrice_82Cart_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);
            string[] brg_mp_split = request.brg_mp.Split(';');

            string urll = string.Format("{0}/api/v1/editProductdetail", request.API_url);

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);

            //Required parameters, other parameters can be add
            var postData = "apiKey=" + Uri.EscapeDataString(request.API_key);
            postData += "&apiCredential=" + Uri.EscapeDataString(request.API_credential);
            if (brg_mp_split[1] == "0")
            {
                postData += "&id_product=" + Uri.EscapeDataString(brg_mp_split[0]);
                postData += "&price=" + Uri.EscapeDataString(request.priceInduk.ToString());
                postData += "&wholesale_price=" + Uri.EscapeDataString("0");
            }
            else
            {
                postData += "&id_product=" + Uri.EscapeDataString(brg_mp_split[0]);
                postData += "&id_product_attribute=" + Uri.EscapeDataString(brg_mp_split[1]);
                postData += "&price_attribute=" + Uri.EscapeDataString(request.priceImpact.ToString());
                postData += "&wholesale_price=" + Uri.EscapeDataString("0");

            }

            var data = Encoding.ASCII.GetBytes(postData);

            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = data.Length;

            string responseFromServer = "";
            try
            {
                using (var stream = myReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream2 = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream2);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
                //manageAPI_LOG_MARKETPLACE(api_status.Pending, ErasoftDbContext, iden, currentLog);

            }
            catch (Exception ex)
            {
                //currentLog.REQUEST_EXCEPTION = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                //manageAPI_LOG_MARKETPLACE(api_status.Pending, ErasoftDbContext, iden, currentLog);
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            if (!string.IsNullOrEmpty(responseFromServer))
            {
                try
                {
                    var resultAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(ResultUpdatePrice)) as ResultUpdatePrice;
                    if (resultAPI.error == "none" && resultAPI.data.Length > 0)
                    {
                        //add 19 sept 2020, update harga massal
                        //if (log_ActionName.Contains("UPDATE_MASSAL"))
                        //{
                        //    var dataLog = log_ActionName.Split('_');
                        //    if (dataLog.Length >= 4)
                        //    {
                        //        var nobuk = dataLog[2];
                        //        var indexData = Convert.ToInt32(dataLog[3]);
                        //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                        //        if (log_b != null)
                        //        {
                        //            var currentProgress = log_b.KET.Split('/');
                        //            if (currentProgress.Length == 2)
                        //            {
                        //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                        //                ErasoftDbContext.SaveChanges();
                        //            }
                        //        }
                        //    }
                        //}
                        ////end add 19 sept 2020, update harga massal
                        //manageAPI_LOG_MARKETPLACE(api_status.Success, ErasoftDbContext, iden, currentLog);
                    }
                    else
                    {
                        //currentLog.REQUEST_EXCEPTION = resultAPI.error.ToString();
                        //manageAPI_LOG_MARKETPLACE(api_status.Exception, ErasoftDbContext, iden, currentLog);
                        throw new Exception(responseFromServer);
                    }
                }
                catch (Exception ex2)
                {
                    //currentLog.REQUEST_EXCEPTION = ex2.InnerException == null ? ex2.Message : ex2.InnerException.Message;
                    //manageAPI_LOG_MARKETPLACE(api_status.Exception, ErasoftDbContext, iden, currentLog);
                    throw new Exception(ex2.InnerException == null ? ex2.Message : ex2.InnerException.Message);
                }

            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }
        public async Task<string> Call_UpdatePrice_Shopify(UpdatePrice_Shopify_Request request)
        {
            string ret = "";
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";

            string[] brg_mp_split = request.brg_mp.Split(';');

            string urll = "https://{0}.myshopify.com/admin/api/" + api_version + "/variants/{1}.json";
            var kodeBarang = "";
            if (brg_mp_split[1] != "0")
            {
                kodeBarang = brg_mp_split[1];
            }
            else
            {
                kodeBarang = brg_mp_split[0];
            }

            //var vformatUrl = String.Format(urll, request.API_key, request.API_password, request.account_store, Convert.ToInt64(kodeBarang));
            var vformatUrl = String.Format(urll, request.account_store, Convert.ToInt64(kodeBarang));

            ShopifyUpdateHargaProduct putProdData = new ShopifyUpdateHargaProduct
            {
                //id = Convert.ToInt64(brg_mp_split[0]),
                variant = new ShopifyUpdateHargaProductVariant()
            };

            putProdData.variant.id = Convert.ToInt64(kodeBarang);
            putProdData.variant.price = Convert.ToString(request.price);


            string myData = JsonConvert.SerializeObject(putProdData);
            try
            {
                string responseFromServer = "";
                //var client = new HttpClient();
                //client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", (request.API_password));
                //var content = new StringContent(myData, Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
                //var taskAPI = Task.Run(() => client.PutAsync(vformatUrl, content));
                //HttpResponseMessage clientResponse = taskAPI.Result;

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(vformatUrl);
                myReq.Headers.Add("X-Shopify-Access-Token", (request.API_password));
                myReq.Method = "PUT";
                myReq.Accept = "application/json";
                myReq.ContentType = "application/json";

                //using (HttpContent responseContent = clientResponse.Content)
                //{
                //    using (var reader = new StreamReader(await responseContent.ReadAsStringAsync()))
                //    {
                //        responseFromServer = reader.ReadToEnd();
                //    }
                //};
                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }

                if (responseFromServer != "")
                {
                    //try
                    //{
                    var result = JsonConvert.DeserializeObject(responseFromServer, typeof(ResultUpdatePriceVariant)) as ResultUpdatePriceVariant;
                    if (!string.IsNullOrWhiteSpace(result.ToString()))
                    {
                        if (result != null)
                        {
                            if (result.variant != null)
                            {
                            }
                            else
                            {
                                var msgError = "";
                                if (result.errors != null)
                                {
                                    msgError = result.errors;
                                }
                                throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". " + msgError);
                            }
                        }
                        else
                        {
                            throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". API no response");
                            
                        }
                    }
                    else
                    {
                        throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". API no response");
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                //throw new Exception(msg);
                errorMessage = msg;
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                //responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                //responseRet.Body = errorMessage;
                //throw new Exception(errorMessage);
                return errorMessage;
            }
            return ret;
        }
        public static async void UpdatePrice_Shopify(UpdatePrice_Shopify_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";

            string[] brg_mp_split = request.brg_mp.Split(';');

            //string urll = "https://{0}:{1}@{2}.myshopify.com/admin/variants/{3}.json";
            string urll = "https://{0}.myshopify.com/admin/api/" + api_version + "/variants/{1}.json";
            var kodeBarang = "";
            if (brg_mp_split[1] != "0")
            {
                kodeBarang = brg_mp_split[1];
            }
            else
            {
                kodeBarang = brg_mp_split[0];
            }

            //var vformatUrl = String.Format(urll, request.API_key, request.API_password, request.account_store, Convert.ToInt64(kodeBarang));
            var vformatUrl = String.Format(urll, request.account_store, Convert.ToInt64(kodeBarang));

            ShopifyUpdateHargaProduct putProdData = new ShopifyUpdateHargaProduct
            {
                //id = Convert.ToInt64(brg_mp_split[0]),
                variant = new ShopifyUpdateHargaProductVariant()
            };

            putProdData.variant.id = Convert.ToInt64(kodeBarang);
            putProdData.variant.price = Convert.ToString(request.price);


            string myData = JsonConvert.SerializeObject(putProdData);
            try { 
                string responseFromServer = "";
                //var client = new HttpClient();
                //client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", (request.API_password));
                //var content = new StringContent(myData, Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
                //var taskAPI = Task.Run(() => client.PutAsync(vformatUrl, content));
                //HttpResponseMessage clientResponse = taskAPI.Result;

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(vformatUrl);
                myReq.Headers.Add("X-Shopify-Access-Token", (request.API_password));
                myReq.Method = "PUT";
                myReq.Accept = "application/json";
                myReq.ContentType = "application/json";

                //    using (HttpContent responseContent = clientResponse.Content)
                //{
                //    using (var reader = new StreamReader(await responseContent.ReadAsStringAsync()))
                //    {
                //        responseFromServer = reader.ReadToEnd();
                //    }
                //};

                myReq.ContentLength = myData.Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, myData.Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }

                if (responseFromServer != "")
            {
                //try
                //{
                    var result = JsonConvert.DeserializeObject(responseFromServer, typeof(ResultUpdatePriceVariant)) as ResultUpdatePriceVariant;
                    if (!string.IsNullOrWhiteSpace(result.ToString()))
                    {
                        if (result != null)
                        {
                            if (result.variant != null)
                            {
                                ////add 19 sept 2020, update harga massal
                                //if (log_ActionName.Contains("UPDATE_MASSAL"))
                                //{
                                //    var dataLog = log_ActionName.Split('_');
                                //    if (dataLog.Length >= 4)
                                //    {
                                //        var nobuk = dataLog[2];
                                //        var indexData = Convert.ToInt32(dataLog[3]);
                                //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                                //        if (log_b != null)
                                //        {
                                //            var currentProgress = log_b.KET.Split('/');
                                //            if (currentProgress.Length == 2)
                                //            {
                                //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                                //                ErasoftDbContext.SaveChanges();
                                //            }
                                //        }
                                //    }
                                //}
                            }
                            else
                            {
                                var msgError = "";
                                if (result.errors != null)
                                {
                                    msgError = result.errors;
                                }
                                throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". " + msgError);
                            }
                        }
                        else
                        {
                            //if (result.errors.Length > 0)
                            //{
                            throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". API no response");
                            //}
                        }
                    }
                    else
                    {
                        throw new Exception("Failed update harga " + Convert.ToString(brg_mp_split[0]) + ": price " + Convert.ToString(request.price) + ". API no response");
                    }
                //}
                //catch (Exception ex)
                //{
                //    string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                //    throw new Exception(msg);
                //}
            }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception(msg);
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        public static void UpdatePrice_JDID(UpdatePrice_JDID_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);
            var brgMp = "";
            if (request.id.Contains(";"))
            {
                string[] brgSplit = request.id.Split(';');
                if (brgSplit[1] != "0")
                {
                    brgMp = brgSplit[1].ToString();
                }
            }
            else
            {
                brgMp = request.id;
            }

            string responseFromServer = "";
            bool responseApi = false;
            int retry = 0;
            while (!responseApi && retry <= 2)
            {
                //data = RefreshToken(data);
                var sysParams = new Dictionary<string, string>();
                var gettimestamp = getCurrentTimeFormatted();

                //change by Tri, ubah api untuk update harga, ikutin saran jdid
                //this.ParamJson = "{\"salePrice\":\"" + price + "\",\"skuId\":\"" + brgMp + "\"}";
                var ParamJson = "{\"jdPrice\":\"" + request.price + "\",\"skuId\":\"" + brgMp + "\",\"spuId\":\"" + request.id.Split(';')[0] + "\"}";
                //end change by Tri, ubah api untuk update harga, ikutin saran jdid
                sysParams.Add("360buy_param_json", ParamJson);

                sysParams.Add("access_token", request.accessToken);
                sysParams.Add("app_key", request.appKey);
                //change by Tri, ubah api untuk update harga, ikutin saran jdid
                //this.Method = "jingdong.seller.price.updatePriceBySkuIds"; //update skus prices
                var Method = "jingdong.seller.product.sku.write.updateSkuList"; //update skus prices
                                                                                //end change by Tri, ubah api untuk update harga, ikutin saran jdid
                sysParams.Add("method", Method);
                //var gettimestamp = getCurrentTimeFormatted();
                sysParams.Add("timestamp", gettimestamp);
                sysParams.Add("v", Version2);
                sysParams.Add("format", Format);
                sysParams.Add("sign_method", SignMethod);


                var signature = generateSign(sysParams, request.appSecret);

                string urll = ServerUrlV2 + "?v=" + Uri.EscapeDataString(Version2) + "&method=" + Method + "&app_key=" + Uri.EscapeDataString(request.appKey)
                    + "&access_token=" + Uri.EscapeDataString(request.accessToken) + "&360buy_param_json=" + Uri.EscapeDataString(ParamJson)
                    + "&timestamp=" + Uri.EscapeDataString(gettimestamp) + "&sign=" + Uri.EscapeDataString(signature);
                urll += "&format=json&sign_method=md5";
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urll);
                myReq.Method = "GET";
                try
                {
                    using (WebResponse response = myReq.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            responseFromServer = reader.ReadToEnd();
                            responseApi = true; break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The remote name could not be resolved: 'open-api.jd.id'"))
                    {
                        retry = retry + 1;
                        string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        if (retry == 3)
                        {
                            throw new Exception(msg);
                        }
                    }
                    else
                    {
                        retry = 3;
                        string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        throw new Exception(msg);
                    }
                }
            }

            if (!string.IsNullOrEmpty(responseFromServer))
            {
                try
                {
                    var retPrice = JsonConvert.DeserializeObject(responseFromServer, typeof(JDIDUpdatePriceV2)) as JDIDUpdatePriceV2;
                    if(retPrice.error_response != null)
                    {
                        throw new Exception(responseFromServer);
                    }
                    if (retPrice.jingdong_seller_product_sku_write_updateSkuList_response.returnType != null)
                    {
                        if (retPrice.jingdong_seller_product_sku_write_updateSkuList_response.returnType.success)
                        {
                            //if (log_ActionName.Contains("UPDATE_MASSAL"))
                            //{
                            //    var dataLog = log_ActionName.Split('_');
                            //    if (dataLog.Length >= 4)
                            //    {
                            //        var nobuk = dataLog[2];
                            //        var indexData = Convert.ToInt32(dataLog[3]);
                            //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                            //        if (log_b != null)
                            //        {
                            //            var currentProgress = log_b.KET.Split('/');
                            //            if (currentProgress.Length == 2)
                            //            {
                            //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                            //                ErasoftDbContext.SaveChanges();
                            //            }
                            //        }
                            //    }
                            //}
                        }
                        else
                        {
                            throw new Exception(retPrice.jingdong_seller_product_sku_write_updateSkuList_response.returnType.message.ToString());
                        }
                    }
                    else
                    {
                        throw new Exception(responseFromServer);
                    }

                }
                catch (Exception ex2)
                {
                    throw new Exception(ex2.InnerException == null ? ex2.Message.ToString() : ex2.InnerException.Message.ToString());
                }
            }
            else
            {
                throw new Exception("Tidak ada respon dari API.");
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        public string Call_UpdatePrice_Tiktok(UpdatePrice_Tiktok_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);
            var brgmp = request.product_id.Split(';');
            if (brgmp.Length != 2)
            {
                throw new Exception("Update harga gagal, Link barang salah.");
            }
            var ret = "";
            string urll = "https://open-api.tiktokglobalshop.com/api/products/prices?access_token={0}&timestamp={1}&sign={2}&app_key={3}&shop_id={4}";
            int timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            string sign = eraAppSecret_Tiktok + "/api/products/pricesapp_key" + eraAppKey_Tiktok + "shop_id" + request.shop_id + "timestamp" + timestamp + eraAppSecret_Tiktok;
            string signencry = GetHash(sign, eraAppSecret_Tiktok);
            var vformatUrl = String.Format(urll, request.access_token, timestamp, signencry, eraAppKey_Tiktok, request.shop_id);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(vformatUrl);
            myReq.Method = "PUT";
            myReq.ContentType = "application/json";


            string myData = "{\"product_id\":\"" + brgmp[0] + "\", \"skus\" : [{ \"original_price\":\"" + request.price + "\",\"id\" : \"" + brgmp[1] + "\" }] }";


            string responseFromServer = "";
            try
            {
                myReq.ContentLength = System.Text.Encoding.UTF8.GetBytes(myData).Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, System.Text.Encoding.UTF8.GetBytes(myData).Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                string err = e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        err = sr.ReadToEnd();
                    }
                }
                //return "error : " + err;
                //currentLog.REQUEST_EXCEPTION = err;
                //manageAPI_LOG_MARKETPLACE(api_status.Exception, ErasoftDbContext, log_CUST, currentLog);
                //throw new Exception(err);
                errorMessage = err;
            }

            if (responseFromServer != "")
            {
                var result = JsonConvert.DeserializeObject(responseFromServer, typeof(TiktokCommonResponse)) as TiktokCommonResponse;
                if (result.code != 0)
                {
                    //currentLog.REQUEST_EXCEPTION = responseFromServer;
                    //manageAPI_LOG_MARKETPLACE(api_status.Failed, ErasoftDbContext, log_CUST, currentLog);
                    //throw new Exception(responseFromServer);
                    errorMessage = responseFromServer;
                    //return "error : " + responseFromServer;
                }

            }

            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
            //    responseRet.Body = errorMessage;
            //    throw new Exception(errorMessage);
            //}
            return errorMessage;
        }
        public static void UpdatePrice_Tiktok(UpdatePrice_Tiktok_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            //var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);
            var brgmp = request.product_id.Split(';');
            if (brgmp.Length != 2)
            {
                throw new Exception("Update harga gagal, Link barang salah.");
            }
            var ret = "";
            string urll = "https://open-api.tiktokglobalshop.com/api/products/prices?access_token={0}&timestamp={1}&sign={2}&app_key={3}&shop_id={4}";
            int timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            string sign = eraAppSecret_Tiktok + "/api/products/pricesapp_key" + eraAppKey_Tiktok + "shop_id" + request.shop_id + "timestamp" + timestamp + eraAppSecret_Tiktok;
            string signencry = GetHash(sign, eraAppSecret_Tiktok);
            var vformatUrl = String.Format(urll, request.access_token, timestamp, signencry, eraAppKey_Tiktok, request.shop_id);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(vformatUrl);
            myReq.Method = "PUT";
            myReq.ContentType = "application/json";


            string myData = "{\"product_id\":\"" + brgmp[0] + "\", \"skus\" : [{ \"original_price\":\"" + request.price + "\",\"id\" : \"" + brgmp[1] + "\" }] }";

            //MasterOnline.API_LOG_MARKETPLACE currentLog = new API_LOG_MARKETPLACE
            //{
            //    //REQUEST_ID = seconds.ToString(),
            //    REQUEST_ID = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            //    REQUEST_ACTION = "Update Price", //ganti
            //    REQUEST_DATETIME = DateTime.UtcNow.AddHours(7),
            //    REQUEST_ATTRIBUTE_1 = log_CUST,
            //    REQUEST_ATTRIBUTE_2 = kdbrgMO,
            //    REQUEST_STATUS = "Pending",
            //};

            string responseFromServer = "";
            try
            {
                myReq.ContentLength = System.Text.Encoding.UTF8.GetBytes(myData).Length;
                using (var dataStream = myReq.GetRequestStream())
                {
                    dataStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, System.Text.Encoding.UTF8.GetBytes(myData).Length);
                }
                using (WebResponse response = myReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                string err = e.Message;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        err = sr.ReadToEnd();
                    }
                }
                //return "error : " + err;
                //currentLog.REQUEST_EXCEPTION = err;
                //manageAPI_LOG_MARKETPLACE(api_status.Exception, ErasoftDbContext, log_CUST, currentLog);
                throw new Exception(err);
            }

            if (responseFromServer != "")
            {
                var result = JsonConvert.DeserializeObject(responseFromServer, typeof(TiktokCommonResponse)) as TiktokCommonResponse;
                if (result.code != 0)
                {
                    //currentLog.REQUEST_EXCEPTION = responseFromServer;
                    //manageAPI_LOG_MARKETPLACE(api_status.Failed, ErasoftDbContext, log_CUST, currentLog);
                    throw new Exception(responseFromServer);
                    //return "error : " + responseFromServer;
                }
                //if (log_ActionName.Contains("UPDATE_MASSAL"))
                //{
                //    var dataLog = log_ActionName.Split('_');
                //    if (dataLog.Length >= 4)
                //    {
                //        var nobuk = dataLog[2];
                //        var indexData = Convert.ToInt32(dataLog[3]);
                //        var log_b = ErasoftDbContext.LOG_HARGAJUAL_B.Where(m => m.NO_BUKTI == nobuk && m.NO_FILE == indexData).FirstOrDefault();
                //        if (log_b != null)
                //        {
                //            var currentProgress = log_b.KET.Split('/');
                //            if (currentProgress.Length == 2)
                //            {
                //                log_b.KET = (Convert.ToInt32(currentProgress[0]) + 1) + "/" + currentProgress[1];
                //                ErasoftDbContext.SaveChanges();
                //                currentLog.CUST_ATTRIBUTE_2 = (Convert.ToInt32(currentProgress[0]) + 1).ToString();
                //                currentLog.CUST_ATTRIBUTE_3 = currentProgress[1];
                //            }
                //        }
                //    }
                //}
                //manageAPI_LOG_MARKETPLACE(api_status.Success, ErasoftDbContext, log_CUST, currentLog);

            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        public static void template(UpdatePrice_Bukalapak_Request request)
        {
            var responseRet = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "OK",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
            string errorMessage = "";
            var ErasoftDbContext = new ErasoftContext(request.dbsource, request.dbpath);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                responseRet.StatusCode = (int)HttpStatusCode.BadRequest;
                responseRet.Body = errorMessage;
                throw new Exception(errorMessage);
            }
            //return responseRet;
        }

        #region function
        public static string CreateSignAuthenLazada(string data, string secretKey)
        {
            secretKey = secretKey ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashmessage).Replace("-", "").ToUpper();
                //return BitConverter.ToString(hashmessage).ToLower();
            }
        }
        public static long CurrentTimeMiliSecond()
        {
            //        return (long)DateTime.Now.ToUniversalTime().Subtract(
            //new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            //).TotalMilliseconds;
            return (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
        public static string XmlEscape(string unescaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerText = unescaped;
            return node.InnerXml;
        }

        public static string XmlUnescape(string escaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerXml = escaped;
            return node.InnerText;
        }

        public static long CurrentTimeMillis()
        {
            return (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static string CreateToken(string urlBlili, string secretMTA)
        {
            secretMTA = secretMTA ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretMTA);
            byte[] messageBytes = encoding.GetBytes(urlBlili);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
                //return BitConverter.ToString(hashmessage).Replace("-", "").ToLower();

            }
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            //byte[] encodedBytes = Encoding.UTF8.GetBytes(input);
            //Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            //byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static long CurrentTimeSecond()
        {
            //        return (long)DateTime.Now.ToUniversalTime().Subtract(
            //new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            //).TotalMilliseconds;
            return (long)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static string CreateSignAuthenShop_V2(string data, string secretKey)
        {
            secretKey = secretKey ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
                //return BitConverter.ToString(hashmessage).ToLower();
            }
        }

        public static string getCurrentTimeFormatted()
        {
            var dt = System.DateTime.Now.ToLocalTime();
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + dt.ToString("zzzz").Replace(":", "");
        }

        private static string generateSign(Dictionary<string, string> sysDataDictionary, string sappSecret)
        {
            var dic = sysDataDictionary.OrderBy(key => key.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
            var sb = new System.Text.StringBuilder();
            foreach (var item in dic)
            {
                if (!"".Equals(item.Key) && !"".Equals(item.Value))
                {
                    sb.Append(item.Key).Append(item.Value);
                }

            }
            //prepend and append appsecret   
            //sb.Insert(0, this.AppSecret);
            //sb.Append(this.AppSecret);
            sb.Insert(0, sappSecret);
            sb.Append(sappSecret);
            var signValue = calculateMD5Hash(sb.ToString());
            //Console.WriteLine("raw string=" + sb.ToString());
            //Console.WriteLine("signValue=" + signValue);
            return signValue;
        }

        private static string calculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();

        }

        public static String GetHash(String text, String key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public static string EncryptString(string input, Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string DecryptString(string hexInput, Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
        #endregion

        #region class
        //public class ARF01_DATA
        //{
        //    public string TOKEN { get; set; }

        //}

        public class User_Identity
        {
            public string dbpath { get; set; }
            public string dbsource { get; set; }
            public string log_ActionName { get; set; }
            public int idmarket { get; set; }
        }
        #region lazada
        public class UpdatePrice_Lazada_Request : User_Identity
        {
            public string kdBrg { get; set; }
            public string token { get; set; }
            public string harga { get; set; }
        }
        public class LazadaCommonRes
        {
            public string code { get; set; }
            public string request_id { get; set; }
            public string type { get; set; }
            public string message { get; set; }
        }
        public class LazadaResponseObj : LazadaCommonRes
        {
            public detailUpdateBrg[] detail { get; set; }
            public dataUploadBrg data { get; set; }
        }
        public class detailUpdateBrg
        {
            public string seller_sku { get; set; }
            public string message { get; set; }
            public string field { get; set; }
        }
        public class dataUploadBrg
        {
            public imgLazada image { get; set; }
        }
        public class imgLazada
        {
            public string hash_code { get; set; }
            public string url { get; set; }
        }

        public class RequestBodyUpdatePriceLazada
        {
            public string access_token { get; set; }
            public string sign_method { get; set; }
            public string sign { get; set; }
            public string app_key { get; set; }
            public string payload { get; set; }
            public long timestamp { get; set; }
        }
        #endregion
        #region bukalapak
        public class UpdatePrice_Bukalapak_Request : User_Identity
        {
            public string token { get; set; }
            public string brgmp { get; set; }
            public string price { get; set; }
        }
        public class BukalapakResponseAPI : BLErrorResponse
        {
            public BukalapakResponseMeta meta { get; set; }
        }
        public class BukalapakResponseMeta
        {
            public int http_status { get; set; }
        }
        public class BLErrorResponse
        {
            public ErrorDetail[] errors { get; set; }
        }
        public class ErrorDetail
        {
            public string message { get; set; }
            public long code { get; set; }
        }
        #endregion
        #region tokped

        public class UpdatePrice_Tokped_Request : User_Identity
        {
            public string token { get; set; }
            public string merchant_code { get; set; }
            public string API_secret_key { get; set; }
            public string product_id { get; set; }
            public string price { get; set; }
        }

        public class UpdatePriceResponse_Tokped
        {
            public UpdatePriceResponseHeader_Tokped header { get; set; }
            public UpdatePriceResponseData_Tokped data { get; set; }
        }

        public class UpdatePriceResponseHeader_Tokped
        {
            public string messages { get; set; }
            public string reason { get; set; }
        }

        public class UpdatePriceResponseData_Tokped
        {
            public int succeed_rows { get; set; }
            public int failed_rows { get; set; }
            public UpdatePriceResponseFailed_Rows_Data_Tokped[] failed_rows_data { get; set; }
        }

        public class UpdatePriceResponseFailed_Rows_Data_Tokped
        {
            public long product_id { get; set; }
            public string message { get; set; }
        }
        #endregion
        #region blibli

        public class UpdatePrice_Blibli_Request : User_Identity
        {
            public string API_client_username { get; set; }
            public string API_client_password { get; set; }
            public string mta_username_email_merchant { get; set; }
            public string mta_password_password_merchant { get; set; }
            public string kode_mp { get; set; }
            public string API_secret_key { get; set; }

            public string versiToken { get; set; }
            public string merchant_code { get; set; }
            public string Price { get; set; }
            public string MarketPrice { get; set; }
            public string token { get; set; }
            public string berat { get; set; }
        }
        #endregion
        #region shopee
        public class UpdatePrice_Shopee_Request : User_Identity
        {
            public string brg_mp { get; set; }

            public string merchant_code { get; set; }
            public string price { get; set; }
            public string token { get; set; }
        }

        public class ShopeeUpdatePriceResponse
        {
            public string error { get; set; }
            public string message { get; set; }
            public string warning { get; set; }
            public string request_id { get; set; }
            public ShopeeUpdatePrice response { get; set; }
        }

        public class ShopeeUpdatePrice
        {
            public ShopeeUpdatePriceFailure_List[] failure_list { get; set; }
            public ShopeeUpdatePriceSuccess_List[] success_list { get; set; }
        }

        public class ShopeeUpdatePriceFailure_List
        {
            public long model_id { get; set; }
            public string failed_reason { get; set; }
        }

        public class ShopeeUpdatePriceSuccess_List
        {
            public long model_id { get; set; }
            public float original_price { get; set; }
        }
        #endregion
        #region 82cart

        public class UpdatePrice_82Cart_Request : User_Identity
        {
            public string brg_mp { get; set; }
            public string API_url { get; set; }
            public string API_credential { get; set; }
            public string API_key { get; set; }
            public string priceInduk { get; set; }
            public string priceImpact { get; set; }
        }

        public class ResultUpdatePrice
        {
            public string requestid { get; set; }
            public string error { get; set; }
            public DetailUpdatePrice[] data { get; set; }
        }

        public class DetailUpdatePrice
        {
            public string id_product { get; set; }
            public string active { get; set; }
            public string name { get; set; }
            public string visibility { get; set; }
            public string available_for_order { get; set; }
            public string show_price { get; set; }
            public string online_only { get; set; }
            public string wholesale_price { get; set; }
            public string price { get; set; }
            public string on_sale { get; set; }
            public string id_category_default { get; set; }
            public string id_manufacturer { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public string depth { get; set; }
            public string weight { get; set; }
            public string additional_shipping_cost { get; set; }
            public string minimal_quantity { get; set; }
            public string out_of_stock { get; set; }
            public string indexed { get; set; }
            public string quantity { get; set; }
            public string date_add { get; set; }
            public string date_upd { get; set; }
        }
        #endregion
        #region shopify

        public class UpdatePrice_Shopify_Request : User_Identity
        {
            public string kodeBarang { get; set; }
            public string API_password { get; set; }
            public string account_store { get; set; }
            public string API_key { get; set; }
            public string price { get; set; }
            public string brg_mp { get; set; }
        }

        public class ResultUpdatePriceVariant
        {
            public object variant { get; set; }
            public string errors { get; set; }
        }

        public class ShopifyUpdateHargaProduct
        {
            //public long id { get; set; }
            public ShopifyUpdateHargaProductVariant variant { get; set; }
        }

        public class ShopifyUpdateHargaProductVariant
        {
            public long id { get; set; }
            //public long product_id { get; set; }
            public string price { get; set; }
        }
        #endregion
        #region jdid

        public class UpdatePrice_JDID_Request : User_Identity
        {
            public string accessToken { get; set; }
            public string appKey { get; set; }
            public string id { get; set; }
            public string price { get; set; }
            public string appSecret { get; set; }
        }

        public class JDIDUpdatePriceV2 : JDIDUpdatePriceV2_Error
        {
            public Jingdong_Seller_Price_Updatepricebyskuids_Response jingdong_seller_product_sku_write_updateSkuList_response { get; set; }
        }

        public class JDIDUpdatePriceV2_Error
        {
            public Error_Response error_response { get; set; }
        }

        public class Error_Response
        {
            public string code { get; set; }
            public string zh_desc { get; set; }
            public string en_desc { get; set; }
        }

        public class Jingdong_Seller_Price_Updatepricebyskuids_Response
        {
            public string code { get; set; }
            public ReturntypeUpdatePriceV2 returnType { get; set; }
        }

        public class ReturntypeUpdatePriceV2
        {
            public string message { get; set; }
            public int[] model { get; set; }
            public int code { get; set; }
            public bool success { get; set; }
        }
        #endregion
        #region tiktok
        public class UpdatePrice_Tiktok_Request : User_Identity
        {
            public string shop_id { get; set; }
            public string access_token { get; set; }
            public string product_id { get; set; }
            public string price { get; set; }

        }

        public class TiktokCommonResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public string request_id { get; set; }
        }
        #endregion

        #endregion
    }

    public static class Retry
    {
        //public static void Do(
        //    Action action,
        //    TimeSpan retryInterval,
        //    int maxAttemptCount = 3)
        //{
        //    Do<object>(() =>
        //    {
        //        action();
        //        return null;
        //    }, retryInterval, maxAttemptCount);
        //}

        //public static T Do<T>(
        //    Func<T> action,
        //    TimeSpan retryInterval,
        //    int maxAttemptCount = 3)
        //{
        //    var exceptions = new List<Exception>();

        //    for (int attempted = 0; attempted < maxAttemptCount; attempted++)
        //    {
        //        try
        //        {
        //            if (attempted > 0)
        //            {
        //                Thread.Sleep(retryInterval);
        //            }
        //            return action();
        //        }
        //        catch (Exception ex)
        //        {
        //            exceptions.Add(ex);
        //        }
        //    }
        //    throw new AggregateException(exceptions);
        //}
        public static void DoWithRetry(Action action, TimeSpan sleepPeriod, int tryCount = 3)
        {
            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            while (true)
            {
                try
                {
                    action();
                    break; // success!
                }
                catch (Exception ex)
                {
                    if (--tryCount == 0)
                        throw ex;
                    //System.Threading.Thread.Sleep(sleepPeriod);
                }
            }
        }
    }
}
