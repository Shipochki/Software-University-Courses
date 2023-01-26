namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private int weigth;

        public Cargo(string type, int weigth)
        {
            Type = type;
            Weigth = weigth;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Weigth
        {
            get { return weigth; }
            set { weigth = value; }
        }
    }
}