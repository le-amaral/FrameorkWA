namespace FrameorkWA.Models
{
    public class Descendentes
    {
        private int _id;
        private string _name;
        private int _paiId;
        private string _email;
        private Titular? _pai;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }

        public int PaiId
        {
            get { return _paiId; }
            set { _paiId = value; }
        }
        public Titular Pai
        {
            get { return _pai; }
            set { _pai = value; }
        }
    }
}