using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
       public static List<Student> students = new List<Student>();
        [WebMethod]
        public List<Student> getAll()
        {
            return students;
        }

        [WebMethod]
        public Student addStudent(string ma, string ten)
        { 
                students.Add(new Student() { ma = ma,ten = ten }) ;
                return new Student() { ma = ma, ten = ten };
        }

        [WebMethod]
        public void deleteStudent(string ma)
        {
            Student stu = null;
             foreach(Student st in students){
                if(ma == st.ma)
                 stu = st;
             }
            students.Remove(stu);
            
        }



    }
}
