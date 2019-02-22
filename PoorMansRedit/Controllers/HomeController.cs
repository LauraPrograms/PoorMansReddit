using Newtonsoft.Json.Linq;
using PoorMansRedit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PoorMansRedit.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reddit()
        {

            ViewBag.Message = "Imported data from Reddit - aka \"Filtered Reddit\"";


            List<JToken> posts = GetPosts();
            List<Post> aww = new List<Post>();
            

                for (int i = 0 ; i < 10; i++)
                {
                    JToken post = posts[i];
                    string title = post["data"]["title"].ToString();
                    string permalink = post["data"]["permalink"].ToString();
                    string image = post["data"]["thumbnail"].ToString();
                    Post p = new Post(title, permalink, image);
                    aww.Add(p);
                   
                }
            
            ViewBag.Aww = aww;

           
            return View();
        }

        public List<JToken> GetPosts()
        {
            string URL = "https://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(URL);
            //request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string readit = sr.ReadToEnd();
            sr.Close();
            JToken redditPost = JToken.Parse(readit);
            List<JToken> posts = new List<JToken>();
            //i skipped index 0 because it was returning me the header "subreddit of the week"
           
            for (int i = 1; i < 11; i++)
            {
                posts.Add(redditPost["data"]["children"][i]);
                
            }
            return posts;

        }     
        


    }
}