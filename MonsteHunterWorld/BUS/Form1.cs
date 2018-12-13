using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;
using MonsteHunterWorld.VO;

namespace MonsteHunterWorld.BUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //예제
            Parameter parameter = new Parameter("items");
            parameter.Name = "가마루코인";
            JArray ja = JArray.Parse(GetJson(parameter));          
        }    

        /// <summary>
        /// 제이슨 문자열을 반환하는 메서드
        /// </summary>
        /// <param name="parameter">검색할 문자열 옵션을 가지고있는 객체</param>
        /// <returns>제이슨 문자열을 반환한다</returns>
        public string GetJson(Parameter parameter)
        {
            string url = GetUrl(parameter);
            string JsonStr = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string status = response.StatusCode.ToString(); // 서버의 응답코드
            if (status == "OK")
            {
                var stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                JsonStr = sr.ReadToEnd();
                if(JsonStr[0].ToString() != "[")
                {
                    JsonStr = (String.Concat("[", JsonStr) + "]");
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("에러발생!\n" + status);
            }
            return JsonStr;
        }

        /// <summary>
        /// Url을 만들어주는 메서드
        /// </summary>
        /// <param name="parameter">검색할 문자열 옵션을 가지고있는 객체</param>
        /// <returns>Url을 반환한다</returns>
        private string GetUrl(Parameter parameter)
        {
            string hexParameter = "";
            if (parameter.GetName != null)
            {
                hexParameter += HttpUtility.UrlEncode(parameter.GetName);
            }
            if (parameter.Name != null)
            {
                hexParameter += "?name=" + HttpUtility.UrlEncode(parameter.Name);
            }
            if (parameter.Type != null)
            {
                hexParameter += "&type=" + HttpUtility.UrlEncode(parameter.Type);
            }
            return "http://www.mhwdb.kr/apis/" + hexParameter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMonster form = new FormMonster();
            form.Owner = this;
            form.Show();
        }
    }
}
