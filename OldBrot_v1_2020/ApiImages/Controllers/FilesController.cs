//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ApiImages.Controllers
//{
//    public class FilesController
//    {
//        [System.Web.Http.AcceptVerbs("GET", "POST")]
//        public List<mdl_status> Registration2(mdl_user user)
//        {

//            List<mdl_status> statusList = new List<mdl_status>();

//            try
//            {
//                var httpRequest = HttpContext.Current.Request;
//                if (httpRequest.Files.Count > 0)
//                {
//                    foreach (string file in httpRequest.Files)
//                    {
//                        var postedFile = httpRequest.Files[file];
//                        var filePath = HttpContext.Current.Server.MapPath("~/Media/" + postedFile.FileName);
//                        postedFile.SaveAs(filePath);
//                        statusList.Add(new mdl_status
//                        {
//                            Success = true,
//                            ReturnMessage = "Documents Uploaded at " + filePath + " User Name: " + user.Name_en +
//                            " User ID: " + user.ID
//                        });

//                    }
//                }
//                else
//                {
//                    statusList.Add(new mdl_status { Success = false, ReturnMessage = "No documents found" });
//                }

//                return statusList;



//            }
//            catch (Exception ex)
//            {


//                statusList.Add(new mdl_status { Success = false, ReturnMessage = ex.Message });
//                return statusList;

//            }

//        }
//    }
//}