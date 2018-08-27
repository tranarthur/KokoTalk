/*Author: Dennis Suarez
 *
 * Description: This code is meant to model the profile
 * of a user in our application. It has all the attributes
 * required to be displayed on the profile
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KokoTalk
{
    public class UserProfile
    {
        /// <summary>
        /// This method has the ability to return or set the value of the user's name
        /// </summary>
        public string Fullname { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's email
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's age
        /// </summary>
        public string Age { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's sex
        /// </summary>
        public string Sex { set; get; }

        /// <summary>
        /// This method has the ability to return or set the number of friends for the user
        /// </summary>
        public string Friends { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's city
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's province
        /// </summary>
        public string Province { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's job
        /// </summary>
        public string Job { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's company
        /// </summary>
        public string Company { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's school
        /// </summary>
        public string School { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's profile picture
        /// </summary>
        public string Profile_pic { set; get; }

        /// <summary>
        /// This method has the ability to return or set the value of the user's status
        /// </summary>
        public string Profile_status { set; get; }
    }
}