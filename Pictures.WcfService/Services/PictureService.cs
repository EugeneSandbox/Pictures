using System;
using System.Collections.Generic;
using System.Linq;



namespace Pictures.WcfService.Services
{
    using DAL.Models;
    using DAL.Services;
    using Models;
    using Tools;


    public class PictureService : IPictureService
    {
        private static readonly Lazy<IPictureService> Lazy = new Lazy<IPictureService>(() => new PictureService());
        public static IPictureService Instance => Lazy.Value;


        
        /// <summary>
        /// Add picture to database
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public Picture Add(Picture picture)
        {
            using (IPictureDboService pictureService = new PictureDboService())
            {
                var pictureDbo = MapToPictureDbo(picture);
                var newPictureDbo = pictureService.Add(pictureDbo);
                return MapToPicture(newPictureDbo);
            }
        }


        public Picture GetById(string pictureId) =>
            GetById(int.Parse(pictureId));
        
        /// <summary>
        /// Get picture from database by id
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public Picture GetById(int pictureId)
        {
            using (IPictureDboService pictureService = new PictureDboService())
            {
                var pictureDbo = pictureService.GetById(pictureId);
                return MapToPicture(pictureDbo);
            }
        }

        /// <summary>
        /// Get all pictures from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Picture> GetAll()
        {
            using (IPictureDboService pictureService = new PictureDboService())
            {
                var pictureDboCollection = pictureService.GetAll();
                return MapToPictureCollection(pictureDboCollection, false);
            }
        }



        /// <summary>
        /// Map PictureDbo collection to Picture collection
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        private IEnumerable<Picture> MapToPictureCollection(IEnumerable<PictureDbo> pictures, bool loadImageData) =>
            pictures.Select(picture => MapToPicture(picture, loadImageData));
        /// <summary>
        /// Map PictureDbo to Picture model
        /// </summary>
        /// <param name="pictureDbo"></param>
        /// <returns></returns>
        private Picture MapToPicture(PictureDbo pictureDbo, bool loadImageData = true) =>
            new Picture()
            {
                Id = pictureDbo.Id,
                Title = pictureDbo.Title,
                Image = loadImageData ? Helper.Compress(pictureDbo.Image) : string.Empty
            };


        /// <summary>
        /// Map Picture to PictureDbo model
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private PictureDbo MapToPictureDbo(Picture picture) =>
            new PictureDbo()
            {
                Id = picture.Id,
                Title = picture.Title,
                Image = picture.Image
            };
    }
}