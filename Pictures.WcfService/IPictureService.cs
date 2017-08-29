using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Pictures.WcfService.Models;



namespace Pictures.WcfService
{
    [ServiceContract]
    public interface IPictureService
    {
        [OperationContract]
        Picture Add(Picture picture);


        [OperationContract]
        IEnumerable<Picture> GetAll();


        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/pictures/{pictureId}",
            ResponseFormat = WebMessageFormat.Json
        )]
        Picture GetById(string pictureId);
    }
}
