using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmpRegCon
{
    public class EmployerManager
    {
        public int tempId;
        public void EmpAdd()
        {
            Console.WriteLine("İsim ;");
            string name = Console.ReadLine();
            Console.WriteLine("Yaş ;");
            int age = Convert.ToInt32(Console.ReadLine());
            DateTime dateTime = DateTime.Now;
            DateTime entryTime = dateTime;
            Console.WriteLine("Pozisyon ;");
            string position = Console.ReadLine();
            Console.WriteLine("Maaş ;");
            int salary = Convert.ToInt32(Console.ReadLine());
            Employer NewEmp = new Employer();
            NewEmp.EmpNameSname = name;
            NewEmp.EntryTime = entryTime;
            NewEmp.Age = age;
            NewEmp.Salary = salary;
            NewEmp.Position = position;
            DataAccessLayer.con.Open();
            DataAccessLayer.com= new SqlCommand("insert into isci_Tbl  values  (@p1,@p2,@p3,@p4,@p5)",DataAccessLayer.con);
            DataAccessLayer.com.Parameters.AddWithValue("@p1",NewEmp.EmpNameSname);
            DataAccessLayer.com.Parameters.AddWithValue("@p2", NewEmp.Age);
            DataAccessLayer.com.Parameters.AddWithValue("@p3", NewEmp.Position);
            DataAccessLayer.com.Parameters.AddWithValue("@p4", NewEmp.Salary);
            DataAccessLayer.com.Parameters.AddWithValue("@p5", NewEmp.EntryTime);
            DataAccessLayer.com.ExecuteNonQuery();
            DataAccessLayer.con.Close();
            Console.WriteLine(name + " İsimli İşçi Eklendi !\n-----------------------");
        }
        public void EmpDelete(int Id)
        {
            
            DataAccessLayer.con.Open();
            DataAccessLayer.com = new SqlCommand("select * from isci_Tbl where isci_id=@p1", DataAccessLayer.con);
            DataAccessLayer.com.Parameters.AddWithValue("@p1",Id);
            DataAccessLayer.reader=DataAccessLayer.com.ExecuteReader();
            

            while (DataAccessLayer.reader.Read())
            {
                
                Console.WriteLine("ID : "+DataAccessLayer.reader[0] + ", AD SOYAD : " + DataAccessLayer.reader[1] + ", YAŞ: " + DataAccessLayer.reader[2]+", POZİSYON : " + DataAccessLayer.reader[3]+", MAAŞ : " + DataAccessLayer.reader[4]+", İŞE BAŞLAMA TARİHİ : " + DataAccessLayer.reader[5]);
                
            }
            DataAccessLayer.con.Close();
            Console.WriteLine("İşçiyi Silmek İstediğinizden Emin Misiniz ? (Onaylamak için 1'i, Vazgeçmek için herhangi bir tuşa basınız) ");
            string choose=Console.ReadLine();
            if (choose=="1")
            {
                DataAccessLayer.con.Open();
                DataAccessLayer.com = new SqlCommand("delete  from isci_Tbl where isci_id=@p1", DataAccessLayer.con);
                DataAccessLayer.com.Parameters.AddWithValue("@p1", Id);
                DataAccessLayer.com.ExecuteNonQuery();
                DataAccessLayer.con.Close();
                Console.WriteLine("Silme İşlemi Başarılı\n---------------");
            }



        }
        public void EmpShow()
        {
            DataAccessLayer.con.Open();
            DataAccessLayer.com = new SqlCommand("select * from isci_Tbl ", DataAccessLayer.con);
           // DataAccessLayer.com.Parameters.AddWithValue("@p1", Id);
            DataAccessLayer.reader = DataAccessLayer.com.ExecuteReader();


            while (DataAccessLayer.reader.Read())
            {

                Console.WriteLine("ID : " + DataAccessLayer.reader[0] + ", AD SOYAD : " + DataAccessLayer.reader[1] + ", YAŞ: " + DataAccessLayer.reader[2] + ", POZİSYON : " + DataAccessLayer.reader[3] + ", MAAŞ : " + DataAccessLayer.reader[4] + ", İŞE BAŞLAMA TARİHİ : " + DataAccessLayer.reader[5]);

            }
            DataAccessLayer.con.Close();
            Console.WriteLine("---------------------");
        }
        public void EmpUpdate(int Id)
        {
            Console.Write("1 - AD\n2 - YAŞ\n3 - POZİSYON\n4 - MAAŞ\n\n\tDeğiştirmek istediğiniz bilgiyi giriniz ; ");
            int choose=Convert.ToInt32(Console.ReadLine());
            DataAccessLayer.com = new SqlCommand();

            DataAccessLayer.con.Open();
            switch (choose)
            {
                case 1:
                    Console.Write("Yeni isim giriniz ; ");
                    string newName=Console.ReadLine();
                    DataAccessLayer.com.CommandText = "update isci_Tbl set isci_ad=@p1 where isci_id=@p2";
                    DataAccessLayer.com.Connection = DataAccessLayer.con;
                    DataAccessLayer.com.Parameters.AddWithValue("@p1",newName);
                    DataAccessLayer.com.Parameters.AddWithValue("@p2",Id);
                    DataAccessLayer.com.ExecuteNonQuery();
                   break;
                case 2:
                    Console.Write("Yeni yaş giriniz ; ");
                    int newAge = Convert.ToInt32(Console.ReadLine()) ;
                    DataAccessLayer.com.CommandText = "update isci_Tbl set isci_yas=@p1 where isci_id=@p2";
                    DataAccessLayer.com.Connection = DataAccessLayer.con;
                    DataAccessLayer.com.Parameters.AddWithValue("@p1", newAge);
                    DataAccessLayer.com.Parameters.AddWithValue("@p2", Id);
                    DataAccessLayer.com.ExecuteNonQuery();
                    break;
                case 3:
                    Console.Write("Yeni pozisyon giriniz ; ");
                    string newPosition = Console.ReadLine();
                    DataAccessLayer.com.CommandText = "update isci_Tbl set isci_pozisyon=@p1 where isci_id=@p2";
                    DataAccessLayer.com.Connection = DataAccessLayer.con;
                    DataAccessLayer.com.Parameters.AddWithValue("@p1", newPosition);
                    DataAccessLayer.com.Parameters.AddWithValue("@p2", Id);
                    DataAccessLayer.com.ExecuteNonQuery();
                    break;
                case 4:
                    Console.Write("Yeni maaş giriniz ; ");
                    int newSalary = Convert.ToInt32(Console.ReadLine()) ;
                    DataAccessLayer.com.CommandText = "update isci_Tbl set isci_maas=@p1 where isci_id=@p2";
                    DataAccessLayer.com.Connection = DataAccessLayer.con;
                    DataAccessLayer.com.Parameters.AddWithValue("@p1", newSalary);
                    DataAccessLayer.com.Parameters.AddWithValue("@p2", Id);
                    DataAccessLayer.com.ExecuteNonQuery();
                    break;
            }
            DataAccessLayer.con.Close();    
            DataAccessLayer.con.Open();
            DataAccessLayer.com = new SqlCommand("select * from isci_Tbl where isci_id=@p1", DataAccessLayer.con);
            DataAccessLayer.com.Parameters.AddWithValue("@p1", Id);
            DataAccessLayer.reader = DataAccessLayer.com.ExecuteReader();


            while (DataAccessLayer.reader.Read())
            {

                Console.WriteLine("ID : " + DataAccessLayer.reader[0] + ", AD SOYAD : " + DataAccessLayer.reader[1] + ", YAŞ: " + DataAccessLayer.reader[2] + ", POZİSYON : " + DataAccessLayer.reader[3] + ", MAAŞ : " + DataAccessLayer.reader[4] + ", İŞE BAŞLAMA TARİHİ : " + DataAccessLayer.reader[5]);

            }
            DataAccessLayer.con.Close();
            Console.WriteLine("-----------------------");


            // DataAccessLayer.com1 = new SqlCommand("update isci_Tbl set isci_ad=@p1 where isci_id=@p2", DataAccessLayer.con);
            //DataAccessLayer.com2 = new SqlCommand("update isci_Tbl set isci_ad=@p1 where isci_id=@p2", DataAccessLayer.con);

            /*DataAccessLayer.com.Parameters.AddWithValue("@p1", NewEmp.EmpNameSname);
            DataAccessLayer.com.Parameters.AddWithValue("@p2", NewEmp.Age);
            DataAccessLayer.com.Parameters.AddWithValue("@p3", NewEmp.Position);
            DataAccessLayer.com.Parameters.AddWithValue("@p4", NewEmp.Salary);
            DataAccessLayer.com.Parameters.AddWithValue("@p5", NewEmp.EntryTime);*/
            
        }
        public void EmpChoose()
        {
            Console.WriteLine("İşçi Id'sini Giriniz ; ");
            tempId = Convert.ToInt32(Console.ReadLine());
        }

    }
}










