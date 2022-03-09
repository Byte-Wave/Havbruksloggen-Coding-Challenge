using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories
{
    public interface IBoatRepository
    {
        public void Create(BoatEntity entity);
        public BoatEntity Get(Guid id);
        public List<BoatEntity> GetAll();
        public List<BoatEntity> List(int page, int itemsPerPage);
        public void Delete(Guid id);
        public BoatEntity Update(BoatEntity entity);
    }
    public class BoatRepository : IBoatRepository
    {
        private BoatAndCrewDbContext _context;
        public BoatRepository(BoatAndCrewDbContext context)
        {
            _context = context;
        }

        public void Create(BoatEntity entity)
        {
            _context.Boats.Add(entity);
            _context.SaveChanges();
        }
        public BoatEntity Update(BoatEntity entity)
        {
            _context.Boats.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(Guid id)
        {
            var entity = Get(id);
            _context.Boats.Remove(entity);
            _context.SaveChanges();
        }
        public BoatEntity Get(Guid id)
        {
           return _context.Boats.First(c => c.Id == id);
        }

        public List<BoatEntity> GetAll()
        {
            return _context.Boats.ToList();
        }

        public List<BoatEntity> List(int page, int itemsPerPage)
        {
            return _context.Boats
                .Skip((page - 1) * 10)
                .Take(itemsPerPage)
                .ToList(); ;
        }
    }
}
