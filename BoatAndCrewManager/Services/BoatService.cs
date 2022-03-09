using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

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
        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        public BoatResponse Create(CreateBoatSchema model)
        {
            BoatResponse response = new BoatResponse();
            try
            {
                BoatEntity entity = new BoatEntity()
                {
                    Name = model.Name,
                    Producer = model.Producer,
                    BuildNumber = model.BuildNumber,
                    MaximumLength = model.MaximumLength,
                    MaximumWidth = model.MaximumWidth,
                    PicturesPath = ""
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
