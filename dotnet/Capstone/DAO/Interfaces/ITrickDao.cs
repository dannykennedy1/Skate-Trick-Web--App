using Capstone.Models;
using System.Collections.Generic;
using System.Globalization;

namespace Capstone.DAO
{
    public interface ITrickDao
    {
        IList<Trick> GetTricks();

        Trick GetTrickById(int id);

        Trick AddNewTrick(Trick newTrick);

        Trick UpdateTrick(Trick updatedTrick);
      
/*
        //Trick GetTrickByStance(string stance);
        Trick UpdateTrick(string bagged)
        IList<Trick> GetBaggedTricks(bool bagged)*/

    }
}