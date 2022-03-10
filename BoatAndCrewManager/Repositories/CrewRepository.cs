using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories
{
    public interface ICrewRepository
    {
        public void Create(CrewMemberEntity entity);
        public CrewMemberEntity Get(Guid id);
        public List<CrewMemberEntity> GetAll();
        public List<CrewMemberEntity> List(int page, int itemsPerPage);
        public void Delete(Guid id);
        public CrewMemberEntity Update(CrewMemberEntity entity);
    }
    public class CrewRepository : ICrewRepository
    {
        private readonly BoatAndCrewDbContext _context;
        public CrewRepository(BoatAndCrewDbContext context)
        {
            _context = context;
        }

        public void Create(CrewMemberEntity entity)
        {
            _context.CrewMembers.Add(entity);
            _context.SaveChanges();
        }
        public CrewMemberEntity Get(Guid id)
        {
            return _context.CrewMembers.First(c => c.Id == id);
        }
        public List<CrewMemberEntity> GetAll()
        {
            return _context.CrewMembers.ToList();
        }
        public List<CrewMemberEntity> List(int page, int itemsPerPage)
        {
            return _context.CrewMembers
                .Skip((page - 1) * 10)
                .Take(itemsPerPage)
                .ToList(); ;
        }
        public void Delete(Guid id)
        {
            var entity = Get(id);
            _context.CrewMembers.Remove(entity);
            _context.SaveChanges();
        }
        public CrewMemberEntity Update(CrewMemberEntity entity)
        {
            _context.CrewMembers.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
