using System;
using System.Collections.Generic;

namespace BMS.Data
{
    public static class Data
    {
        public static List<Book> Books => allBooks;

        static List<Book> allBooks = new List<Book>
        {
            new Book()
            {
                Id = 2,
                Title = "The story of ConMAn",

                 Description = "the story of 1 person and thier target  ",
                 Author = "Samman" ,
                 Rate = (double) 5.9,
                 DateStart = new DateTime(2022,06,03),
                 DateRead = null

            },
             new Book()
            {
                Id = 3,
                Title = "the ANgry bird",

                 Description = "the story of 2 birds and thier clashes ",
                 Author = "Rabail" ,
                 Rate = (double) 5.9,
                 DateStart = new DateTime(2022,06,03),
                 DateRead = null

            },

              new Book()
            {
                Id = 1,
                Title = "Fifty shades of grey",

                 Description = "the story of 2 person and thier clashes ",
                 Author = "Aman" ,
                 Rate = (double) 5.9,
                 DateStart = new DateTime(2022,06,03),
                 DateRead = null

            },
        };
    }
}
