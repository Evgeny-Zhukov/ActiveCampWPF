using ActiveCamp.BL;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;

namespace ActiveCamp.CMD
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            News news = new News(1, "News Text Title", "New Text, dehsufhiushfihw,wiewoi",DateTime.Now, false);
            NewsController newsController = new NewsController();
            newsController.AddNews(news);
        }
    }
}

