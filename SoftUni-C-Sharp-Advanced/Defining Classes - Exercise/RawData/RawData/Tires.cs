namespace DefiningClasses
{
    public class Tires
    {
        private int tire1Age;
        
        private float tire1Pressure;
        

        public Tires(int tire1Age, float tire1Pressure)
        {
            Tire1Age = tire1Age;
            
            Tire1Pressure = tire1Pressure;
            
        }

        public int Tire1Age
        {
            get { return tire1Age; }
            set { tire1Age = value; }
        }
       

        public float Tire1Pressure
        {
            get { return tire1Pressure; }
            set { tire1Pressure = value; }
        }

        
    }
}