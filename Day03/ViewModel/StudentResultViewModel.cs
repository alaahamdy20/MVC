namespace Day03.ViewModel
{
    public class StudentResultViewModel
    {
         
        public int stdId { get; set; }
        public string cName { get; set; }
        public int CrsId { get; set; }
        public string Name { get; set; }
        public int? Degree { get; set; }
        public int MinDegree { get; init; }
        public string Stauts { 
            get {
            
                if (Degree > MinDegree)
                {
                    return "Pass";

                }
                else
                {
                    return "Fail";

                }

            } }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }

}
