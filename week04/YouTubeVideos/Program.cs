using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("How to Cook Pasta", "Chef Mario", 420);
        v1.AddComment(new Comment("John", "Great tutorial!"));
        v1.AddComment(new Comment("Sarah", "I tried this and it worked perfectly."));
        v1.AddComment(new Comment("Mike", "Thanks for the tips!"));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        v2.AddComment(new Comment("Alice", "Very helpful video."));
        v2.AddComment(new Comment("Bob", "Explained clearly!"));
        v2.AddComment(new Comment("Emily", "I learned a lot, thank you!"));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Top 10 Travel Destinations", "WanderWorld", 300);
        v3.AddComment(new Comment("David", "I want to visit them all!"));
        v3.AddComment(new Comment("Olivia", "Amazing places."));
        v3.AddComment(new Comment("Chris", "Great recommendations."));
        videos.Add(v3);

        // Displaying all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}