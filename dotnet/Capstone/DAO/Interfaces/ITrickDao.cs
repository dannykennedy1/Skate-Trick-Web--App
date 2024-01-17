using Capstone.Models;
using System.Collections.Generic;
using System.Globalization;

namespace Capstone.DAO
{
    public interface ITrickDao
    {
        public IList<Trick> GetTricks();

        public Trick GetTrickById(int id);

        public Trick AddNewTrick(Trick newTrick);

        public Trick UpdateTrick(Trick updatedTrick);
        public bool DeleteTrickById(int id);

    }
}