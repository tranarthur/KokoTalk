using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KokoTalk
{
    public class Post
    {
        string time = "";
        string post = "";

        public string getTime() {
            return time;
        }
        public string getPost() {
            return post;
        }

        public void setTime(string date) {
            this.time = date;
        }

        public void setPost(string text) {
            this.post = text;
        }
    }
}