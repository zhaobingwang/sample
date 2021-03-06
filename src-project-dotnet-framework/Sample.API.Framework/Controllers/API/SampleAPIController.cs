﻿using Sample.Utilities.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sample.API.Framework.Controllers.API
{
    /// <summary>
    /// Sample ASP.NET WEB API2
    /// </summary>
    [RoutePrefix("api/samples")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SampleController : BaseController
    {
        List<SampleProduct> products = null;
        IDbConnection conn = null;
        /// <summary>
        /// ctor
        /// </summary>
        public SampleController()
        {
            products = new List<SampleProduct>();
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new SampleProduct()
                {
                    Id = i,
                    Name = $"产品{i}"
                });
            }
            conn = new MySqlConnection(Constants.CONN_MYSQL_SAMPLE);
        }

        /// <summary>
        /// 接受多个http方法（GET,POST）
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        //[Route("")]
        [Route("get-date-time")]
        public string GetDateTime()
        {
            return DateTimeOffset.Now.ToString();
        }

        /// <summary>
        /// Use a tilde (~) on the method attribute to override the route prefix
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/get-string")]
        public string GetString()
        {
            return "hello,world";
        }

        [HttpGet]
        [Route("get-all-products")]
        public IEnumerable<SampleProduct> GetProducts()
        {
            return products;
        }

        /// <summary>
        /// 获取某个产品
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>产品的json信息</returns>
        [HttpGet]
        [Route("get-product/{id:nonzero}", Name = "GetProductById")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        //[HttpPost]
        //[Route("post-file")]
        //public IHttpActionResult PostFile([FromBody] FileUpload sampleUpload)
        //{
        //    TypeConvertOperator typeConvertOperator = new TypeConvertOperator();
        //    var img = typeConvertOperator.ConvertBase64StringToImage(sampleUpload.fileBase64String);
        //    Bitmap bitmap = new Bitmap(img);
        //    string dir = "c:\\Temp\\SampleAPI\\";
        //    if (!Directory.Exists(dir))
        //    {
        //        Directory.CreateDirectory(dir);
        //    }
        //    bitmap.Save($"{dir}{sampleUpload.name}.png", ImageFormat.Png);
        //    return Ok(AppDomain.CurrentDomain.BaseDirectory);
        //}

        /// <summary>
        /// 测试WebAPI2的操作结果
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-action-result")]
        public IEnumerable<SampleProduct> GetActionResult()
        {
            #region HttpResponseMessage
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
            ////response.Content = new StringContent("hello,world", Encoding.Unicode);
            ////response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            ////{
            ////    MaxAge = TimeSpan.FromMinutes(20)
            ////};
            //return response;
            #endregion

            #region IHttpActionResult
            //return NotFound();
            //return Ok(products);
            #endregion

            #region Other Return Types
            return products;
            #endregion
        }

        /// <summary>
        /// 添加一个商品，并使用路由名称生成链接
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("post-product")]
        public HttpResponseMessage PostProduct(SampleProduct product)
        {
            // Validate and add product to database (not shown)

            var response = Request.CreateResponse(HttpStatusCode.Created);

            // Generate a link to the new product and set the Location header in the response.
            string uri = Url.Link("GetProductById", new { id = product.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }


    public class FileUpload
    {
        public string name { get; set; }
        public string fileBase64String { get; set; }
    }

    public class SampleProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
