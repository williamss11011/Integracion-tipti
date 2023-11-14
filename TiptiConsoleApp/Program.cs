using TiptiConsoleApp.ApiRest;
using System;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace TiptiConsoleApp
{
    class Program
    {
        static DBApi dBApi = new DBApi();
        static dynamic respuestaB;
        static string jsonB;
        static string jsonN;
        static string json;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("ejecutando.... InsertarProduct");
                InsertarProductos();
            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            finally
            {
                Console.WriteLine("Fin de programa");

            }
        }

        private static void SendMail(string error)
        {
            //error = "";
            //  Console.WriteLine(error);
            // Console.WriteLine("Mail enviado co56565656565te");
            /***********/
            string notificacion = error.ToString();
            string destinatario = "william.marcillo@bebemundo.ec";
            string destinatario2 = "jaime.barrionuevo@bebemundo.ec";

            SmtpClient client = new SmtpClient()
            {

                Host = "mx2.crmbebemundo.ec",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "administrador/mx2",
                    Password = "Vpayp8vb2UmIdfD7z99sLtIn"
                }

            };

            MailAddress FromEmail = new MailAddress("notificacion.rappi@mundobebemundo.ec", "Notificacion");
            MailAddress ToEmail = new MailAddress(destinatario);
            MailAddress ToEmail2 = new MailAddress(destinatario2);


            //string gpsc = System.IO.File.ReadAllText(@"C:\HTML\GPSC.txt");
            string dd = notificacion;
            string html = dd;
            string htmlBody = html;

            MailMessage Message = new MailMessage();

            Message.From = FromEmail;
            Message.Subject = "Notificacion de Error";
            Message.Body = htmlBody;
            Message.IsBodyHtml = true;
            Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
            Message.To.Add(ToEmail);
            Message.CC.Add(ToEmail2);

            // Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
            try
            {
                client.Send(Message);
                Console.WriteLine("Mail enviado correctamente");
            }
            catch (Exception exc)
            {
                Console.WriteLine("" + exc.Message, "");
            }

        }

        private static void InsertarProductos()
        {
            

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=facturacion.bebelandia.com.ec;Initial Catalog=InventarioSQL;User ID=inventario;Password=inventa3iobm11$;"))


                {




                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.spInsertProductosTipti", con);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    string key = dt.Rows[1]["kkey"].ToString();
                    string partner_key = dt.Rows[1]["partner_key"].ToString();
                    string part = dt.Rows[1]["part"].ToString();
                    string total = dt.Rows[1]["total"].ToString();




                    string jsonA = @"{
                   ""partner_key"": ""partner_key2"",
                 ""part"": part2,
                ""total"": total2,
                ""products"": [";



                    jsonA = jsonA.Replace("partner_key2", partner_key);
                    jsonA = jsonA.Replace("part2", part);
                    jsonA = jsonA.Replace("total2", total);


                    //dynamic respuestaA = dBApi.jsonpartA(jsonA);

                    string jsonC = @"]}";





                    StringBuilder jsonf = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)

                    //foreach (DataRow row in dt.Rows)
                    {

                        //string key = row["kkey"].ToString();
                        //string partner_key = row["partner_key"].ToString();
                        //string part = row["part"].ToString();
                        //string total = row["total"].ToString();
                        string barcode = dt.Rows[i]["barcode"].ToString();
                        string name = dt.Rows[i]["name"].ToString();
                        string in_stock = dt.Rows[i]["in_stock"].ToString();
                        string presentation_units = dt.Rows[i]["presentation_units"].ToString();
                        string presentation_measure = dt.Rows[i]["presentation_measure"].ToString();
                        string bulk_sale = dt.Rows[i]["bulk_sale"].ToString();
                        string brand = dt.Rows[i]["brand"].ToString();
                        string manufacturer = dt.Rows[i]["manufacturer"].ToString();
                        string description = dt.Rows[i]["description"].ToString();
                        string affiliate_price_with_tax = dt.Rows[i]["affiliate_price_with_tax"].ToString();
                        string affiliate_price_without_tax = dt.Rows[i]["affiliate_price_without_tax"].ToString();
                        string non_affiliate_price_with_tax = dt.Rows[i]["non_affiliate_price_with_tax"].ToString();
                        string non_affiliate_price_without_tax = dt.Rows[i]["non_affiliate_price_without_tax"].ToString();
                        string value_added_tax = dt.Rows[i]["value_added_tax"].ToString();
                        string url = dt.Rows[i]["url"].ToString();
                        string retailer_internal_code = dt.Rows[i]["retailer_internal_code"].ToString();
                        string name3 = dt.Rows[i]["name3"].ToString();
                        string name4 = dt.Rows[i]["name4"].ToString();
                        string reg = dt.Rows[i]["reg"].ToString();






                        string jsonB = @"
                   {
                ""product"": {
                ""barcode"": ""barcode2"",
                ""name"": ""name2"",
                ""in_stock"": in_stock2,
                ""presentation_units"": ""presentation_units2"",
                ""presentation_measure"": presentation_measure2,
                ""bulk_sale"": bulk_sale2,
                ""brand"": ""brand2"",
                ""manufacturer"": ""manufacturer2"",
                ""description"": ""description2"",
                ""affiliate_price_with_tax"": affiliate_price_with_tax2,
                ""affiliate_price_without_tax"": affiliate_price_without_tax2,
                ""non_affiliate_price_with_tax"": non_afiliate_price_with_tax2,
                ""non_affiliate_price_without_tax"": non_afiliate_price_without_tax2,
                ""value_added_tax"": value_added_tax2,
                ""pictures"": [
                    {
                        ""url"": ""url2""
                    }
                ],
                ""category"": {
                    ""retailer_internal_code"": ""retailer_internal_code2"",
                    ""name"": ""name33""
                },
                ""subcategory"": {
                    ""retailer_internal_code"": ""retailer_internal_code2"",
                    ""name"": ""name44""
                },
                ""classification"": {
                    ""education"": false,
                    ""health"": false,
                    ""feeding"": false,
                    ""clothing"": false
                },
                ""traffic_light_labelling"": {
                    ""sugar"": """",
                    ""fat"": """",
                    ""salt"": """"
                }}},";




                       /* jsonA = jsonA.Replace("partner_key2", partner_key);
                        jsonA = jsonA.Replace("part2", part);
                        jsonA = jsonA.Replace("total2", total);*/
                        jsonB = jsonB.Replace("barcode2", barcode);
                        jsonB = jsonB.Replace("name2", name);
                        jsonB = jsonB.Replace("in_stock2", in_stock);
                        jsonB = jsonB.Replace("presentation_units2", presentation_units);
                        jsonB = jsonB.Replace("presentation_measure2", presentation_measure);
                        jsonB = jsonB.Replace("bulk_sale2", bulk_sale);
                        jsonB = jsonB.Replace("brand2", brand);
                        jsonB = jsonB.Replace("manufacturer2", manufacturer);
                        jsonB = jsonB.Replace("description2", description);
                        jsonB = jsonB.Replace("affiliate_price_with_tax2", affiliate_price_with_tax);
                        jsonB = jsonB.Replace("affiliate_price_without_tax2", affiliate_price_without_tax);
                        jsonB = jsonB.Replace("non_afiliate_price_with_tax2", non_affiliate_price_with_tax);
                        jsonB = jsonB.Replace("non_afiliate_price_without_tax2", non_affiliate_price_without_tax);
                        jsonB = jsonB.Replace("value_added_tax2", value_added_tax);
                        jsonB = jsonB.Replace("url2", url);
                        jsonB = jsonB.Replace("retailer_internal_code2", retailer_internal_code);
                        jsonB = jsonB.Replace("name33", name3);
                        jsonB = jsonB.Replace("name44", name4);
                                                                      
                        
                       
                        jsonf.Append(jsonB);
                        string jsonN = jsonf.ToString();


                        // Console.WriteLine(jsonf.ToString());
                        //dynamic respuestaB = dBApi.jsonpartB(jsonB);
                        // dynamic respuesta = dBApi.PostProduct("https://api.tipti.market/api/v3/retailer/upload/products", json, key);

                        // string res = respuesta.ToString();
                        //Console.WriteLine("Respuesta WS:" +res);
                        //Console.WriteLine("Nombre Item:" +name);   
                        //Console.WriteLine("Num reg:" +reg);

                    }

                    string json = jsonA+jsonf+jsonC;
                    json = json.Replace("}}},]}", "}}}]}");
                    dynamic respuesta = dBApi.PostProduct("https://api.tipti.market/api/v3/retailer/upload/products", json, key);
                    string res = respuesta.ToString();
                    Console.WriteLine("Respuesta WS:" +res);


                }
            }
            catch (SqlException ex)
            {

                string error = ex.ToString();
                SendMail(error);
                Console.WriteLine(ex);

            }
            
        }
    }
}
