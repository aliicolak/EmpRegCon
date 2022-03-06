using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Program
{


    public class Program
    {
        public static void Main()
        {
            Head:
            Console.Write("1 - İşçi Ekleme\n2 - İşçi Güncelleme\n3 - İşçi Göster\n4 - İşçi Sil\n\nİşlem Seçiniz; ");
            int choose = Convert.ToInt32(Console.ReadLine());
            EmpRegCon.EmployerManager emx = new EmpRegCon.EmployerManager();
            switch (choose)
            {

                case 1:
                    emx.EmpAdd();
                    goto Head;
                case 2:
                    emx.EmpChoose();
                    emx.EmpUpdate(emx.tempId);
                    goto Head;
                case 3:
                    emx.EmpShow();
                    goto Head;
                case 4:
                    emx.EmpChoose();
                    emx.EmpDelete(emx.tempId);
                    goto Head;

            }
        }




    }
}

