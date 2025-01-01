namespace Recuitment
{
    class JobPortal
    {
        public List<Resume> resumes=new List<Resume>();
       private static JobPortal jobPortal=new JobPortal();

       private JobPortal()
       {

       }

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

       public  void triggerCompusing()
       {
            foreach(Resume resume in resumes)
            {
                Console.WriteLine("sending notification to: "+resume.ToString());
            }
       } 
    }


}