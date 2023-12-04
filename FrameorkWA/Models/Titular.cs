using System.Security.Cryptography;

namespace FrameorkWA.Models
{
    public class Titular
    {
        private int _id;
        private string _name;
        private string _email;
        private List<Descendentes> _filhos;

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

        public List<Descendentes> Filhos
        {
            get { return _filhos; }
            set { _filhos = value; }
        }

    }
}
