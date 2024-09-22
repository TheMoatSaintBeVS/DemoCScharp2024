
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDemoPOO
{
    public class FootBallPlayer:System.IComparable<FootBallPlayer>
    {
        public string Name { get; set; }
        public int NumberOfGoals { get; set; }

        //public int CompareTo(object? obj)
        //{
        //  return this.NumberOfGoals >  ( (FootBallPlayer)obj).NumberOfGoals ? 1 : -1;
        //}

        public int CompareTo(FootBallPlayer? other)
        {
            return this.NumberOfGoals > other.NumberOfGoals ? 1 : -1;
        }
    }
}
