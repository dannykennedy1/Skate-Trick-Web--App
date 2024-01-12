using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ITrickDao
    {
        IList<Trick> GetTricks();

        Trick GetTrickById(int id);

        Trick GetTrickByName(string name);

        Trick GetTrickByStance (string stance);

        IList<Trick> GetBaggedTricks(bool bagged);

    }
}