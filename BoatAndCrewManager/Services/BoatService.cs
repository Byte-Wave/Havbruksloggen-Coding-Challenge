using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
        BoatResponse Update(CreateBoatSchema model, string id);
        public void Delete(string id);
    }
    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _boatRepository;

        private readonly PathMaker _pathMaker;
        public BoatService(IBoatRepository boatRepository, PathMaker pathMaker)
        {
            _boatRepository = boatRepository;
            _pathMaker = pathMaker;
            // here we set which service is gonna use this pathmaker instance and in the whole service we have access to a folder for this service
            // the paths will go /RootPath/Boats/filename
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


        private string GetBase64Image(string path)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
            }

            return Convert.ToBase64String(buffer);
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
                var pictureName = Path.GetRelativePath(_pathMaker.GetDirectoryPath(), entity.PicturesPath);
                response = new BoatResponse()
                {
                    Id = entity.Id.ToString(),
                    Name = entity.Name,
                    Producer = entity.Producer,
                    BuildNumber = entity.BuildNumber,
                    MaximumLength = entity.MaximumLength,
                    MaximumWidth = entity.MaximumWidth,
                    Picture = GetBase64Image(entity.PicturesPath),
                    PictureName = pictureName,
                    PictureType = MimeTypes.GetMimeType(pictureName)
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
            BoatResponse response = null;
            if (Guid.TryParse(id, out Guid result))
            {
                try
                {

                    BoatEntity entity = _boatRepository.Get(result);
                    entity.Name = model.Name;
                    entity.Producer = model.Producer;
                    entity.BuildNumber = model.BuildNumber;
                    entity.MaximumLength = model.MaximumLength;
                    entity.MaximumWidth = model.MaximumWidth;

                    if (!string.IsNullOrEmpty(model.Picture))
                    {
                        string path = SaveImage(model.Picture, model.PictureName.Split(".").Last());
                        entity.PicturesPath = path;
                    }

                    _boatRepository.Update(entity);
                    var pictureName = Path.GetRelativePath(_pathMaker.GetDirectoryPath(), entity.PicturesPath);
                    response = new BoatResponse()
                    {
                        Id = entity.Id.ToString(),
                        Name = entity.Name,
                        Producer = entity.Producer,
                        BuildNumber = entity.BuildNumber,
                        MaximumLength = entity.MaximumLength,
                        MaximumWidth = entity.MaximumWidth,
                        Picture = GetBase64Image(entity.PicturesPath),
                        PictureName = pictureName,
                        PictureType = MimeTypes.GetMimeType(pictureName)
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }


            }

            return response;
        }
        public BoatResponse Get(string id)
        {
            BoatResponse response = null;
            try
            {
                if (Guid.TryParse(id, out Guid result))
                {
                    var entity = _boatRepository.Get(result);
                    var pictureName = Path.GetRelativePath(_pathMaker.GetDirectoryPath(), entity.PicturesPath);
                    var mimeType = MimeTypes.GetMimeType(pictureName);
                    response = new BoatResponse()
                    {
                        Id = entity.Id.ToString(),
                        Name = entity.Name,
                        Producer = entity.Producer,
                        BuildNumber = entity.BuildNumber,
                        MaximumLength = entity.MaximumLength,
                        MaximumWidth = entity.MaximumWidth,
                        Picture = $"data: {mimeType};base64, {GetBase64Image(entity.PicturesPath)}",
                        PictureName = pictureName,
                        PictureType = mimeType

                    };
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return response;
        }
        public List<BoatResponse> GetAll()
        {
            var list = _boatRepository.GetAll();
            List<BoatResponse> response = new List<BoatResponse>();
            foreach (var entity in list)
            {
                var pictureName = Path.GetRelativePath(_pathMaker.GetDirectoryPath(), entity.PicturesPath);
                var mimeType = MimeTypes.GetMimeType(pictureName);
                var item = new BoatResponse()
                {
                    Id = entity.Id.ToString(),
                    Name = entity.Name,
                    Producer = entity.Producer,
                    BuildNumber = entity.BuildNumber,
                    MaximumLength = entity.MaximumLength,
                    MaximumWidth = entity.MaximumWidth,
                    Picture = $"data: {mimeType};base64, {GetBase64Image(entity.PicturesPath)}",
                    PictureName = pictureName,
                    PictureType = mimeType

                };
                response.Add(item);
            }

            return response;
        }

        public List<BoatResponse> List(int page, int itemsPerPage)
        {
            var list = _boatRepository.List(page, itemsPerPage);
            List<BoatResponse> response = new List<BoatResponse>();
            foreach (var entity in list)
            {
                var pictureName = Path.GetRelativePath(_pathMaker.GetDirectoryPath(), entity.PicturesPath);
                var mimeType = MimeTypes.GetMimeType(pictureName);
                var item = new BoatResponse()
                {
                    Id = entity.Id.ToString(),
                    Name = entity.Name,
                    Producer = entity.Producer,
                    BuildNumber = entity.BuildNumber,
                    MaximumLength = entity.MaximumLength,
                    MaximumWidth = entity.MaximumWidth,
                    Picture = $"data: {mimeType};base64, {GetBase64Image(entity.PicturesPath)}",
                    PictureName = pictureName,
                    PictureType = mimeType

                };
                response.Add(item);
            }

            return response;
        }

        public void Delete(string id)
        {
            if (Guid.TryParse(id, out Guid result))
            {
                _boatRepository.Delete(result);
            }


        }
    }
}
