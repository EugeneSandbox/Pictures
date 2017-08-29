using System;
using System.Collections.Generic;
using System.Linq;
using Pictures.DAL.Models;


namespace Pictures.DAL.Services
{
    public interface IPictureDboService : IDisposable
    {
        PictureDbo Add(PictureDbo picture);
        PictureDbo GetById(int pictureId);
        IEnumerable<PictureDbo> GetAll();
    }


    public class PictureDboService : IPictureDboService
    {
        private readonly DatabaseContext _context;


        public PictureDboService()
        {
            _context = new DatabaseContext();
        }


        public void Dispose() =>
            _context.Dispose();


        /// <summary>
        /// Add new picture
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public PictureDbo Add(PictureDbo picture)
        {
            var newPicture = _context.Pictures.Add(picture);
            _context.SaveChanges();
            return newPicture;
        }


        /// <summary>
        /// Get picture by Id
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public PictureDbo GetById(int pictureId) =>
            _context.Pictures.Find(pictureId);


        /// <summary>
        /// Get all pictures
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PictureDbo> GetAll() =>
            _context.Pictures.ToArray();
    }
}
