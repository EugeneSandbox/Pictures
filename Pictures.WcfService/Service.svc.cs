using System.Collections.Generic;



namespace Pictures.WcfService
{
    using Models;
    using Services;


    public class Service : IPictureService
    {
        private static IPictureService Pictures => PictureService.Instance;


        public Picture Add(Picture picture) => Pictures.Add(picture);
        public Picture GetById(string pictureId) => Pictures.GetById(pictureId);
        public IEnumerable<Picture> GetAll() => Pictures.GetAll();
    }
}
