namespace DemoPOO.Entities
{
    public class Player
    {


        //public int Id {
        //    get;// set;
        //    }


       static  int lastId =100;

        private int _id;
        public int Id { get { return _id; } }

        public Player()
        {
            this._id = lastId++;
        }


        public static int Get => lastId;

    }
}