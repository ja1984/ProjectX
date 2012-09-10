using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Added { get; set; }


        public List<Image> GetFakeImages()
        {
            var images = new List<Image>();

            images.Add(new Image
            {
                Added = DateTime.Now,
                Id = new Random().Next(),
                Name = "/Uploads/Screenshot_2012-08-29-09-13-02.png"
            });
            images.Add(new Image
            {
                Added = DateTime.Now,
                Id = new Random().Next(),
                Name = "/Uploads/Screenshot_2012-08-29-09-13-09.png"
            });
            images.Add(new Image
            {
                Added = DateTime.Now,
                Id = new Random().Next(),
                Name = "/Uploads/Screenshot_2012-08-29-09-13-33.png"
            });
            images.Add(new Image
            {
                Added = DateTime.Now,
                Id = new Random().Next(),
                Name = "/Uploads/Screenshot_2012-08-29-09-13-40.png"
            });
            images.Add(new Image
            {
                Added = DateTime.Now,
                Id = new Random().Next(),
                Name = "/Uploads/Screenshot_2012-08-29-09-14-05.png"
            });

            return images;
        }

    }
}