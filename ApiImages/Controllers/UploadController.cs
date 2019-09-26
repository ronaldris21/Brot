﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiImages.Controllers
{
    public class UploadController : ApiController
    {
        [Route("api/Files/Upload")]
        public async Task<string> Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);
                        postedFile.SaveAs(filePath);
                        return fileName;
                    }
                }

            }
            catch (Exception e)
            {
                return "Algo ha fallado: " + e.Message;
            }
            return "";
        }
    }
}