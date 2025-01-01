namespace Recuitment
{
    class JobPortal
    {
        public List<Resume> resumes=new List<Resume>();
        // The external code does not directly create an instance of JobPortal
        private static JobPortal jobPortal=new JobPortal();

       private JobPortal()
       {

       }


       // the JobPortal class itself ensures only one instance exists 
       //and "calls back" when accessed through JobPortal.get().
       public static JobPortal get()
       {
        return jobPortal;
       }

       public void uploadContent(string name, string email, string position)
       {
            Resume resume=new Resume{
                Name=name,
                Email=email,
                Position=position
            };

            resumes.Add(resume);
       }

        //The Resume objects don't independently handle their notifications. 
        //Instead, the JobPortal manages the process and invokes the required actions, maintaining control
       public  void triggerCompusing()
       {
            foreach(Resume resume in resumes)
            {
                Console.WriteLine("sending notification to: "+resume.ToString());
            }
       } 
    }


}