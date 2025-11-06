using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Resumes Project.");
        Job job1 = new Job();
        job1._jobTitle = "software Engineer" ;
        job1._company = "Microsoft";
        job1._startYear = 2003;
        job1._endYear = 2010;

        Job job2 = new Job();
        job2._jobTitle = "Genealogy Assistant" ;
        job2._company = "Apple";
        job2._startYear = 2013;
        job2._endYear = 2011;

        // Console.WriteLine($"{job1._company}");
        // Console.WriteLine($"{job2._company}");
        job1.DisplayJobDetails();
        job2.DisplayJobDetails();

        Console.WriteLine("");
        
        Resume person1 = new Resume();
        person1._jobs.Add(job1);
        person1._jobs.Add(job2);
        person1._name = "Yves Anthony";

        // Console.WriteLine($"{person1._jobs[0]._jobTitle}");
        person1.DisplayResume();
    }
}