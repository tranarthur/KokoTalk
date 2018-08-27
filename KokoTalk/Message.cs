using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/**
 * 
 * Author henrique
 * */
namespace KokoTalk
{

    /// <summary>
    /// This class is for holding message values and generating the string to update the webpage
    /// </summary>
    public class Message
    {
        public string sender { set; get; }
        public string receiver { set; get; }
        public string time { set; get; }
        public string message { set; get; }

        /// <summary>
        /// This method creates the string for the sender of the message, to be on the right and blue
        /// </summary>
        /// <returns>String with the html to create a div with the message</returns>
        public string PostSender()
        {
            return "<div class='speech'><div class='speech-bubble2'> <div class='message'> " + this.message + "</div><div class='time'>" + this.time + "</div></div></div>";
        }

        /// <summary>
        /// This method creates the string for the receiver of the messages, to be on the left and gray
        /// </summary>
        /// <returns>String with the html to create a div with the message</returns>
        public string PostReceiver()
        {
            return "<div class='speech'><div class='speech-bubble'> <div class='name>" + this.sender + "</div> <div class='message'> " + this.message + "</div><div class='time'>" + this.time + "</div></div></div>";
        }
    }
}