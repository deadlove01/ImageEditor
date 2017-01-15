using AutoArtist.Model;
using log4net;
using MongoRepository;
using SunfrogUploader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Controller
{
    public class MongoController: Singleton<MongoController>
    {

        private static readonly ILog logger =
              LogManager.GetLogger(typeof(MongoController));
        private MongoRepository<ArtModel> artModelRep;
        public MongoController()
        {
            artModelRep = new MongoRepository<ArtModel>();
        }

        public ArtModel FindModel(string name, string logoName)
        {
            try
            {
                var queryInstance = from p in _instance.artModelRep.AsQueryable<ArtModel>()
                                    where p.LogoName == logoName && p.Name == name
                                    select p;
                return (queryInstance.Count() > 0) ? queryInstance.Single() : null;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public bool InsertArtModel(ArtModel artModel)
        {
            try
            {
                _instance.artModelRep.Add(artModel);
               
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return false;
            }
            return true;
        }
    }
}
