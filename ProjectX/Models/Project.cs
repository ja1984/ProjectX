using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Member Creator { get; set; }
        public string GitHubName { get; set; }
        public List<Image> Images { get; set; }
        public List<Helper> Helpers { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }



        public int CreatorId { get; set; }


        public Project GetFakeProject()
        {
            return new Project
                {
                    Created = DateTime.Now,
                    Creator = new Member().GetFakeMember(),
                    Description = "<p>Look, just because I don't be givin' no man a foot massage don't make it right for Marsellus to throw Antwone into a glass motherfuckin' house, fuckin' up the way the nigger talks. Motherfucker do that shit to me, he better paralyze my ass, 'cause I'll kill the motherfucker, know what I'm sayin'? </p><p>My money's in that office, right? If she start giving me some bullshit about it ain't there, and we got to go someplace else and get it, I'm gonna shoot you in the head then and there. Then I'm gonna shoot that bitch in the kneecaps, find out where my goddamn money is. She gonna tell me too. Hey, look at me when I'm talking to you, motherfucker. You listen: we go in there, and that nigga Winston or anybody else is in there, you the first motherfucker to get shot. You understand? </p><p>Now that we know who you are, I know who I am. I'm not a mistake! It all makes sense! In a comic, you know how you can tell who the arch-villain's going to be? He's the exact opposite of the hero. And most times they're friends, like you and me! I should've known way back when... You know why, David? Because of the kids. They called me Mr Glass. </p>",
                    GitHubName = "Twee",
                    Helpers = new List<Helper>(),
                    Images = new Image().GetFakeImages(),
                    Name = "Twee",
                    Id = 1

                };
        }

    }



    public class ProjectViewModel
    {
        public Project Project { get; set; }
    }
}