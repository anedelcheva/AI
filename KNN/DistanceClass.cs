namespace KNN
{
    // DistanceClass represents the pair (distance, class)
    // distance is the absdolute distance b/n 2 points (representing entries)
    // class type is the class of an entry (data point)
    class DistanceClass
    {
        private double distance;
        private double classType;

        public DistanceClass(double distance, double classType)
        {
            this.distance = distance;
            this.classType = classType;
        }

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public double ClassType
        {
            get { return classType; }
            set { classType = value; }
        }
    }
}
