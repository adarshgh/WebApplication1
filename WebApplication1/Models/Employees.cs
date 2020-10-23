using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class Employees
    {
        private String connectionstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        
        /*public List<employeeAccessLayer> getdata2()
        {
            List<employeeAccessLayer> lol = new List<employeeAccessLayer>();

            try
            {


                SqlConnection conn2 = new SqlConnection(connectionstring);
                SqlCommand cmd2 = new SqlCommand("sp_getdata", conn2);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Employees");

                while (ds.)
                {
                    employeeAccessLayer emp = new employeeAccessLayer();
                    emp.id = Convert.ToInt32(rdr2.GetValue(0).ToString());
                    emp.fname = rdr2.GetValue(1).ToString();
                    emp.lname = rdr2.GetValue(2).ToString();
                    lol.Add(emp);

                }

            }

            catch (Exception)
            {
                throw;
            }

             return lol;
            
        }*/
        
        public List<employeeAccessLayer> getdata()
        {
            List<employeeAccessLayer> li = new List<employeeAccessLayer>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("sp_getdata", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    employeeAccessLayer emp = new employeeAccessLayer();
                    emp.id = Convert.ToInt32(rdr.GetValue(0).ToString());
                    emp.fname = rdr.GetValue(1).ToString();
                    emp.lname = rdr.GetValue(2).ToString();
                    li.Add(emp);

                }



            }
            catch (Exception)
            {
                throw;
            }



            return li;
        }
    }
}