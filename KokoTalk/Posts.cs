/*Author: Dennis Suarez
 *
 * Description: This code is meant to model what a post 
 * Object is supposed to look like in our application.
 * It also contains all the attributes a Post would have.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KokoTalk
{
    public class Posts
    {
        /// <summary>
        /// This two variables are to hold the information for a post. Text and time
        /// </summary>
        string time = "";
        string post = "";

        /// <summary>
        /// This method provides the time of the post
        /// </summary>
        /// <returns></returns>
        public string GetTime()
        {
            return time;
        }

        /// <summary>
        /// This method provides the text of the post
        /// </summary>
        /// <returns></returns>
        public string GetPost()
        {
            return post;
        }

        /// <summary>
        /// This method sets the time for the post
        /// </summary>
        /// <param name="date"></param>
        public void SetTime(string date)
        {
            this.time = date;
        }

        /// <summary>
        /// This method sets the text for the post
        /// </summary>
        /// <param name="text"></param>
        public void SetPost(string text)
        {
            this.post = text;
        }
    }
}