using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeVideoInWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int w = 346;
            int h = 224;
            this.webBrowser1.Width = w + 2;
            this.webBrowser1.Height = h + 2;
            var embed = 
            "<html>"+
            "<head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge,chrome=1\"/>" +
            "<script>" +
            "function pause() {{" +
            "var i = document.getElementsByTagName(\"iframe\")[0].contentWindow;" +
            "i.postMessage('{{\"event\":\"command\",\"func\":\"pauseVideo\",\"args\":\"\"}}', '*');" +
            "}}"+
            "function play() {{" +
            "var i = document.getElementsByTagName(\"iframe\")[0].contentWindow;" +
            "i.postMessage('{{\"event\":\"command\",\"func\":\"playVideo\",\"args\":\"\"}}', '*');" +
            "}}" +
            "</script>" +
            "</head>" +
            "<body scroll=\"no\" style=\"padding:0px;margin:0px;\">" +
            "<iframe style=\"border: 1px solid #fff;\" width=\"{1}\" height=\"{2}\" src=\"{0}\"" +
            "allow =\"autoplay; encrypted-media\" ></iframe>" +
            "</body></html>";
            var url = "https://www.youtube.com/embed/L6ZgzJKfERM?enablejsapi=1";
            webBrowser1.DocumentText = string.Format(embed, url, w, h);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("play", null);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("pause", null);
        }
    }
}
