using System.Text;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;
using Havbruksloggen_Coding_Challenge.Shared.Services;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Services
{
    public interface IBoatService
    {
        public BoatResponse Create(CreateBoatSchema model);
        public List<BoatResponse> GetAll();
        public List<BoatResponse> List(int page, int itemsPerPage);
    }
    public class BoatService : IBoatService
    {
        private IBoatRepository _boatRepository;

        private PathMaker _pathMaker;
        public BoatService(IBoatRepository boatRepository, PathMaker pathMaker)
        {
            _boatRepository = boatRepository;
            _pathMaker = pathMaker;
            _pathMaker.Service = "Boats";
        }

        private string SaveImage(string base64, string extension)
        {
            string[] parts = base64.Split("base64,");
            byte[] bytes = Convert.FromBase64String(parts[1]);
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var path = _pathMaker.MakePath($"{timeStamp}.{extension}");
            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                fs.Write(bytes);
            }

            return path;
        }

        public BoatResponse Create(CreateBoatSchema model)
        {
            BoatResponse response = new BoatResponse();
            try
            {
                var path = SaveImage(model.Picture, model.PictureName.Split(".").Last());
                BoatEntity entity = new BoatEntity()
                {
                    Name = model.Name,
                    Producer = model.Producer,
                    BuildNumber = model.BuildNumber,
                    MaximumLength = model.MaximumLength,
                    MaximumWidth = model.MaximumWidth,
                    // todo in future store relative not absolute path
                    PicturesPath = path
                };

                _boatRepository.Create(entity);
                response = new BoatResponse()
                {
                    Id = entity.Id.ToString(),
                    Name = entity.Name,
                    Producer = entity.Producer,
                    BuildNumber = entity.BuildNumber,
                    MaximumLength = entity.MaximumLength,
                    MaximumWidth = entity.MaximumWidth,
                };
            }
            catch (Exception e)
            {
                // todo log exception in the database
                Console.WriteLine(e);
                throw;
            }

            return response;
        }

        public BoatResponse Update(CreateBoatSchema model, string id)
        {
            throw new Exception();
        }

        public List<BoatResponse> GetAll()
        {
            var list = _boatRepository.GetAll();
            List<BoatResponse> response = new List<BoatResponse>();
            foreach (var boat in list)
            {
                response.Add(new BoatResponse()
                {
                    Id = boat.Id.ToString(),
                    Name = boat.Name,
                    Producer = boat.Producer,
                    BuildNumber = boat.BuildNumber,
                    MaximumLength = boat.MaximumLength,
                    MaximumWidth = boat.MaximumWidth,
                    PictureUrl = ""
                });
            }

            return response; throw new NotImplementedException();
        }

        public List<BoatResponse> List(int page, int itemsPerPage)
        {
            var list = _boatRepository.List(page, itemsPerPage);
            List<BoatResponse> response = new List<BoatResponse>();
            foreach (var boat in list)
            {
                response.Add(new BoatResponse()
                {
                    Id = boat.Id.ToString(),
                    Name = boat.Name,
                    Producer = boat.Producer,
                    BuildNumber = boat.BuildNumber,
                    MaximumLength = boat.MaximumLength,
                    MaximumWidth = boat.MaximumWidth,
                    PictureUrl = ""
                });
            }

            return response;
        }
    }
}
