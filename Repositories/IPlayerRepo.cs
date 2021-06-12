using GolfCourse.Entity;
using System.Collections.Generic;

namespace GolfCourse.Repositories
{
    public interface IPlayerRepo
    {
        bool AddPlayer(Player player);
        bool DeleteAmateur(string name);
        List<Player> GetPlayers();
        bool UpdateExperience(string name, Player player);
    }
}