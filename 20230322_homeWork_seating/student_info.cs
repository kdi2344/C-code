using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230322_homeWork_seating
{
    class student_info
    {
        public string name;
        public string gender;
        public string phone;
        public student_info(string sentence)
        {
            string[] arr = sentence.Split(' ');
            name = arr[0];
            gender = arr[1];
            phone = arr[2];
        }
    }
    
}
