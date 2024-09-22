
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDemoPOO
{
    public class Tool
    {

        // écrire une méthode qui compare deux objects 
        // et qui retourne le plus grand 

        //public object GetBigger(object one, object two)
        //{
        //    #region old Fashion
        //    //object result;
        //    //if (one > two)
        //    //{
        //    //    result = one;
        //    //}
        //    //else
        //    //{
        //    //    result = two;
        //    //}
        //    //return result;
        //    #endregion
        //    return one > two ? one : two;
        //}

        //public int GetBigger(int one, int two)
        //{
        //    return one > two ? one : two;
        //}
        //public int GetBiggerBetter(int one, int two)
        //{
        //    return one.CompareTo( two) > 0  ? one : two;
        //}

        //public FootBallPlayer GetBigger(FootBallPlayer one, FootBallPlayer two)
        //{
        //    return one.CompareTo(two) > 0 ? one : two;
        //}

        public static T GetBigger<T>(T one, T two) where T : IComparable<T>
        {
            return one.CompareTo(two) > 0 ? one : two;
        }
    }
}
